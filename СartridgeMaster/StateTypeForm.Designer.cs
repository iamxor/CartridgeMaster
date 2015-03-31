namespace СartridgeMaster
{
    partial class StateTypeForm
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
            this.btCmd = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // btCmd
            // 
            this.btCmd.Location = new System.Drawing.Point(12, 494);
            this.btCmd.Name = "btCmd";
            this.btCmd.Size = new System.Drawing.Size(75, 23);
            this.btCmd.TabIndex = 7;
            this.btCmd.Text = "button1";
            this.btCmd.UseVisualStyleBackColor = true;
            this.btCmd.Click += new System.EventHandler(this.btCmd_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(12, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(474, 476);
            this.propertyGrid1.TabIndex = 6;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // StateTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 529);
            this.Controls.Add(this.btCmd);
            this.Controls.Add(this.propertyGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StateTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StateTypeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCmd;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}