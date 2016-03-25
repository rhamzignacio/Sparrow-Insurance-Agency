namespace Sparrow_Insurance_Agency.Car_Insurance.Report
{
    partial class SalesAgent
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
            this.listViewAgent = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radBtnLastName = new System.Windows.Forms.RadioButton();
            this.radBtnFirstName = new System.Windows.Forms.RadioButton();
            this.radBtnAgentNo = new System.Windows.Forms.RadioButton();
            this.btnOkay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewAgent
            // 
            this.listViewAgent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.listViewAgent.FullRowSelect = true;
            this.listViewAgent.Location = new System.Drawing.Point(17, 65);
            this.listViewAgent.Name = "listViewAgent";
            this.listViewAgent.Size = new System.Drawing.Size(467, 286);
            this.listViewAgent.TabIndex = 114;
            this.listViewAgent.UseCompatibleStateImageBehavior = false;
            this.listViewAgent.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 119;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 342;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(400, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 26);
            this.btnSearch.TabIndex = 113;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(83, 9);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(311, 26);
            this.txtBoxSearch.TabIndex = 112;
            this.txtBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxSearch_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 111;
            this.label1.Text = "Search";
            // 
            // radBtnLastName
            // 
            this.radBtnLastName.AutoSize = true;
            this.radBtnLastName.Location = new System.Drawing.Point(408, 42);
            this.radBtnLastName.Name = "radBtnLastName";
            this.radBtnLastName.Size = new System.Drawing.Size(76, 17);
            this.radBtnLastName.TabIndex = 118;
            this.radBtnLastName.TabStop = true;
            this.radBtnLastName.Text = "Last Name";
            this.radBtnLastName.UseVisualStyleBackColor = true;
            // 
            // radBtnFirstName
            // 
            this.radBtnFirstName.AutoSize = true;
            this.radBtnFirstName.Location = new System.Drawing.Point(327, 41);
            this.radBtnFirstName.Name = "radBtnFirstName";
            this.radBtnFirstName.Size = new System.Drawing.Size(75, 17);
            this.radBtnFirstName.TabIndex = 117;
            this.radBtnFirstName.TabStop = true;
            this.radBtnFirstName.Text = "First Name";
            this.radBtnFirstName.UseVisualStyleBackColor = true;
            // 
            // radBtnAgentNo
            // 
            this.radBtnAgentNo.AutoSize = true;
            this.radBtnAgentNo.Checked = true;
            this.radBtnAgentNo.Location = new System.Drawing.Point(251, 41);
            this.radBtnAgentNo.Name = "radBtnAgentNo";
            this.radBtnAgentNo.Size = new System.Drawing.Size(70, 17);
            this.radBtnAgentNo.TabIndex = 116;
            this.radBtnAgentNo.TabStop = true;
            this.radBtnAgentNo.Text = "Agent No";
            this.radBtnAgentNo.UseVisualStyleBackColor = true;
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(400, 357);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(84, 26);
            this.btnOkay.TabIndex = 115;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // SalesAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 392);
            this.Controls.Add(this.listViewAgent);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radBtnLastName);
            this.Controls.Add(this.radBtnFirstName);
            this.Controls.Add(this.radBtnAgentNo);
            this.Controls.Add(this.btnOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SalesAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesAgent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewAgent;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radBtnLastName;
        private System.Windows.Forms.RadioButton radBtnFirstName;
        private System.Windows.Forms.RadioButton radBtnAgentNo;
        private System.Windows.Forms.Button btnOkay;
    }
}