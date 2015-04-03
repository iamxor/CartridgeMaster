using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Globalization;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace СartridgeMaster
{
    public enum ObjectType: int
    {
        [Description("Принтер")]
        Printer = 0,
        [Description("Картридж")]
        Cartridge = 1
    }

    class ObjectTypeConverter: EnumConverter
    {
        private Type _enumType;
        public ObjectTypeConverter(Type type): base(type)
        {
            _enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
            DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            foreach (FieldInfo fi in _enumType.GetFields())
            {
                DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }
            return Enum.Parse(_enumType, (string)value);
        }
    }

    public class LocationDetails
    {
        [DisplayName("Расположение"), Description("Расположение принтера"), Category("")]
        public string name { get; set; }
    }

    public class PrinterDetails
    {
        [DisplayName("Производитель"), Description("Производитель принтера"), Category("")]
        public string manufacturer { get; set; }
        [DisplayName("Модель"), Description("Модель принтера"), Category("")]
        public string model { get; set; }
        [DisplayName("Номер"), Description("Серийный или инвентарный номер принтера"), Category("")]
        public string number { get; set; }
        [DisplayName("Количество страниц"), Description("Количество отпечатанных страниц"), Category("")]
        public int pages_count { get; set; }
        [DisplayName("Статус"), Description("Статус принтера"), Category("")]
        public int state { get; set; }
    }

    public class PrinterOperationDetails
    {
        [DisplayName("Дата"), Description(""), Category("")]
        public DateTime datetime { get; set; }
        [DisplayName("Операция"), Description(""), Category("")]
        public int operation { get; set; }
        [DisplayName("Примечание"), Description(""), Category("")]
        public string notes { get; set; }
    }

    public class CartridgeDetails
    {
        [DisplayName("Номер"), Description(""), Category("")]
        public string number { get; set; }
        [DisplayName("Модель"), Description(""), Category("")]
        public string model { get; set; }
        [DisplayName("Статус"), Description(""), Category("")]
        public int state { get; set; }
    }

    public class CartridgeOperationDetails
    {
        [DisplayName("Дата"), Description(""), Category("")]
        public DateTime datetime { get; set; }
        [DisplayName("Операция"), Description(""), Category("")]
        public int operation { get; set; }
        [DisplayName("Примечание"), Description(""), Category("")]
        public string notes { get; set; }
    }

    public class StateTypeDetails
    {
        [DisplayName("Тип объекта"), Description(""), Category(""), TypeConverter(typeof(ObjectTypeConverter))]
        public ObjectType object_type { get; set; }
        [DisplayName("Код"), Description("Цифровой код состояния"), Category("")]
        public int state_value { get; set; }
        [DisplayName("Наименование"), Description("Наименование состояния"), Category("")]
        public string name { get; set; }
    }

    public class OperationTypeDetails
    {
        [DisplayName("Тип объекта"), Description(""), Category(""), TypeConverter(typeof(ObjectTypeConverter))]
        public ObjectType object_type { get; set; }
        [DisplayName("Код"), Description("Цифровой код операции"), Category("")]
        public int operation_value { get; set; }
        [DisplayName("Наименование"), Description("Наименование операции"), Category("")]
        public string name { get; set; }
        [DisplayName("Статус"), Description("Статус вызванный операцией"), Category(""), TypeConverter(typeof(StateTypeConverter)), Editor(typeof(StateEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Guid state { get; set; }
    }

    public class StateTypeConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                Guid id = (Guid)value;
                if (id != Guid.Empty)
                {
                    state_types st = Runtime.DB.state_types.SingleOrDefault(x => x.id == id);
                    if (st != null)
                        return st.name;
                }
                return "";
            }
            return "";
        }
    }

    public class StateEditor : UITypeEditor
    {
        private IWindowsFormsEditorService svc;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (svc != null)
            {                
                StateSelect frm = new StateSelect(context.Instance);
                frm.ValueSelected += frm_ValueSelected;
                svc.DropDownControl(frm);
                if (frm.Selected != null)
                    value = frm.Selected.id;
                else
                    value = Guid.Empty;
            }
            return value;
        }

        void frm_ValueSelected(object sender, EventArgs e)
        {
            if(svc != null)
                svc.CloseDropDown();
        }
    }
}
