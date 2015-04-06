namespace СartridgeMaster
{
    partial class StatesForm
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
            this.lvStates = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cxStates = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьСтатусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСтатусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cxStates.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.lvStates);
            this.splitContainer1.Size = new System.Drawing.Size(706, 651);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
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
            this.tvObjectType.Size = new System.Drawing.Size(235, 651);
            this.tvObjectType.TabIndex = 0;
            this.tvObjectType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvObjectType_AfterSelect);
            // 
            // lvStates
            // 
            this.lvStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lvStates.ContextMenuStrip = this.cxStates;
            this.lvStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStates.FullRowSelect = true;
            this.lvStates.GridLines = true;
            this.lvStates.Location = new System.Drawing.Point(0, 0);
            this.lvStates.Name = "lvStates";
            this.lvStates.ShowGroups = false;
            this.lvStates.Size = new System.Drawing.Size(467, 651);
            this.lvStates.TabIndex = 0;
            this.lvStates.UseCompatibleStateImageBehavior = false;
            this.lvStates.View = System.Windows.Forms.View.Details;
            this.lvStates.DoubleClick += new System.EventHandler(this.lvStates_DoubleClick);
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
            // cxStates
            // 
            this.cxStates.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСтатусToolStripMenuItem,
            this.удалитьСтатусToolStripMenuItem});
            this.cxStates.Name = "cxStates";
            this.cxStates.Size = new System.Drawing.Size(164, 48);
            // 
            // добавитьСтатусToolStripMenuItem
            // 
            this.добавитьСтатусToolStripMenuItem.Name = "добавитьСтатусToolStripMenuItem";
            this.добавитьСтатусToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.добавитьСтатусToolStripMenuItem.Text = "Добавить статус";
            this.добавитьСтатусToolStripMenuItem.Click += new System.EventHandler(this.добавитьСтатусToolStripMenuItem_Click);
            // 
            // удалитьСтатусToolStripMenuItem
            // 
            this.удалитьСтатусToolStripMenuItem.Name = "удалитьСтатусToolStripMenuItem";
            this.удалитьСтатусToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.удалитьСтатусToolStripMenuItem.Text = "Удалить статус";
            this.удалитьСтатусToolStripMenuItem.Click += new System.EventHandler(this.удалитьСтатусToolStripMenuItem_Click);
            // 
            // StatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 651);
            this.Controls.Add(this.splitContainer1);
            this.Name = "StatesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статусы";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cxStates.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvObjectType;
        private System.Windows.Forms.ListView lvStates;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip cxStates;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтатусToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСтатусToolStripMenuItem;
    }
}