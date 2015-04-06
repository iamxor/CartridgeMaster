namespace СartridgeMaster
{
    partial class OperationTypesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Принтер");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Картридж");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvObjectType = new System.Windows.Forms.TreeView();
            this.lvOperationTypes = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cxOperationTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьТипОперацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьТипОперацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cxOperationTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvObjectType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvOperationTypes);
            this.splitContainer1.Size = new System.Drawing.Size(712, 610);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvObjectType
            // 
            this.tvObjectType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObjectType.HideSelection = false;
            this.tvObjectType.Location = new System.Drawing.Point(0, 0);
            this.tvObjectType.Name = "tvObjectType";
            treeNode1.Name = "Node0";
            treeNode1.Tag = "0";
            treeNode1.Text = "Принтер";
            treeNode2.Name = "Node1";
            treeNode2.Tag = "1";
            treeNode2.Text = "Картридж";
            this.tvObjectType.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.tvObjectType.Size = new System.Drawing.Size(237, 610);
            this.tvObjectType.TabIndex = 0;
            this.tvObjectType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvObjectType_AfterSelect);
            // 
            // lvOperationTypes
            // 
            this.lvOperationTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader1});
            this.lvOperationTypes.ContextMenuStrip = this.cxOperationTypes;
            this.lvOperationTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOperationTypes.FullRowSelect = true;
            this.lvOperationTypes.GridLines = true;
            this.lvOperationTypes.Location = new System.Drawing.Point(0, 0);
            this.lvOperationTypes.Name = "lvOperationTypes";
            this.lvOperationTypes.ShowGroups = false;
            this.lvOperationTypes.Size = new System.Drawing.Size(471, 610);
            this.lvOperationTypes.TabIndex = 0;
            this.lvOperationTypes.UseCompatibleStateImageBehavior = false;
            this.lvOperationTypes.View = System.Windows.Forms.View.Details;
            this.lvOperationTypes.DoubleClick += new System.EventHandler(this.lvOperationTypes_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Код";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Наименование";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Статус";
            this.columnHeader1.Width = 150;
            // 
            // cxOperationTypes
            // 
            this.cxOperationTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьТипОперацииToolStripMenuItem,
            this.удалитьТипОперацииToolStripMenuItem});
            this.cxOperationTypes.Name = "cxStates";
            this.cxOperationTypes.Size = new System.Drawing.Size(206, 48);
            // 
            // добавитьТипОперацииToolStripMenuItem
            // 
            this.добавитьТипОперацииToolStripMenuItem.Name = "добавитьТипОперацииToolStripMenuItem";
            this.добавитьТипОперацииToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.добавитьТипОперацииToolStripMenuItem.Text = "Добавить тип операции";
            this.добавитьТипОперацииToolStripMenuItem.Click += new System.EventHandler(this.добавитьТипОперацииToolStripMenuItem_Click);
            // 
            // удалитьТипОперацииToolStripMenuItem
            // 
            this.удалитьТипОперацииToolStripMenuItem.Name = "удалитьТипОперацииToolStripMenuItem";
            this.удалитьТипОперацииToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.удалитьТипОперацииToolStripMenuItem.Text = "Удалить тип операции";
            this.удалитьТипОперацииToolStripMenuItem.Click += new System.EventHandler(this.удалитьТипОперацииToolStripMenuItem_Click);
            // 
            // OperationTypesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 610);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OperationTypesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Типы операций";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cxOperationTypes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvObjectType;
        private System.Windows.Forms.ListView lvOperationTypes;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip cxOperationTypes;
        private System.Windows.Forms.ToolStripMenuItem добавитьТипОперацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьТипОперацииToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}