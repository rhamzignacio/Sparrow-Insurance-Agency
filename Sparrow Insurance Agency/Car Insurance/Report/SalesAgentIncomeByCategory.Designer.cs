namespace Sparrow_Insurance_Agency.Car_Insurance.Report
{
    partial class SalesAgentIncomeByCategory
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBoxAgentID = new System.Windows.Forms.TextBox();
            this.cmbBoxCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearchAgent = new System.Windows.Forms.Button();
            this.txtBoxAgent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.GetSalesAgentReport_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getSalesAgentReportByCategoryResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetSalesAgentReport_ResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSalesAgentReportByCategoryResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBoxAgentID);
            this.panel1.Controls.Add(this.cmbBoxCategory);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSearchAgent);
            this.panel1.Controls.Add(this.txtBoxAgent);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.datePickerFrom);
            this.panel1.Controls.Add(this.datePickerTo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 69);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtBoxAgentID
            // 
            this.txtBoxAgentID.Enabled = false;
            this.txtBoxAgentID.Location = new System.Drawing.Point(300, 41);
            this.txtBoxAgentID.Name = "txtBoxAgentID";
            this.txtBoxAgentID.Size = new System.Drawing.Size(200, 20);
            this.txtBoxAgentID.TabIndex = 14;
            this.txtBoxAgentID.Visible = false;
            // 
            // cmbBoxCategory
            // 
            this.cmbBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxCategory.FormattingEnabled = true;
            this.cmbBoxCategory.Items.AddRange(new object[] {
            "CV",
            "PC",
            "LTO"});
            this.cmbBoxCategory.Location = new System.Drawing.Point(569, 14);
            this.cmbBoxCategory.Name = "cmbBoxCategory";
            this.cmbBoxCategory.Size = new System.Drawing.Size(175, 21);
            this.cmbBoxCategory.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Category";
            // 
            // btnSearchAgent
            // 
            this.btnSearchAgent.BackgroundImage = global::Sparrow_Insurance_Agency.Properties.Resources.Zoom_icon;
            this.btnSearchAgent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchAgent.Location = new System.Drawing.Point(263, 39);
            this.btnSearchAgent.Name = "btnSearchAgent";
            this.btnSearchAgent.Size = new System.Drawing.Size(31, 23);
            this.btnSearchAgent.TabIndex = 11;
            this.btnSearchAgent.UseVisualStyleBackColor = true;
            this.btnSearchAgent.Click += new System.EventHandler(this.btnSearchAgent_Click);
            // 
            // txtBoxAgent
            // 
            this.txtBoxAgent.Enabled = false;
            this.txtBoxAgent.Location = new System.Drawing.Point(63, 41);
            this.txtBoxAgent.Name = "txtBoxAgent";
            this.txtBoxAgent.Size = new System.Drawing.Size(200, 20);
            this.txtBoxAgent.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Agent";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(750, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Location = new System.Drawing.Point(63, 15);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(200, 20);
            this.datePickerFrom.TabIndex = 0;
            // 
            // datePickerTo
            // 
            this.datePickerTo.Location = new System.Drawing.Point(306, 15);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(200, 20);
            this.datePickerTo.TabIndex = 1;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SalesAgentIncomeByCategory";
            reportDataSource1.Value = this.getSalesAgentReportByCategoryResultBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Sparrow_Insurance_Agency.Reports.SalesAgentIncomeByCategoryReport.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 69);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(1038, 446);
            this.reportViewer.TabIndex = 8;
            // 
            // getSalesAgentReportByCategoryResultBindingSource
            // 
            this.getSalesAgentReportByCategoryResultBindingSource.DataSource = typeof(Sparrow_Insurance_Agency.GetSalesAgentReportByCategory_Result);
            // 
            // SalesAgentIncomeByCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 515);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panel1);
            this.Name = "SalesAgentIncomeByCategory";
            this.Text = "SalesAgentIncomeByCategory";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetSalesAgentReport_ResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSalesAgentReportByCategoryResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbBoxCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearchAgent;
        public System.Windows.Forms.TextBox txtBoxAgent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.BindingSource GetSalesAgentReport_ResultBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource getSalesAgentReportByCategoryResultBindingSource;
        public System.Windows.Forms.TextBox txtBoxAgentID;
    }
}