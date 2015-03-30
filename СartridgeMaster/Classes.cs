using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace СartridgeMaster
{
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
}
