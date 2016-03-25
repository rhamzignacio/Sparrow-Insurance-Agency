namespace Sparrow_Insurance_Agency.Car_Insurance.Report
{
    partial class SalesAgentIncome
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
            this.GetSalesAgentReport_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchAgent = new System.Windows.Forms.Button();
            this.txtBoxAgent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.GetSalesAgentReport_ResultBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetSalesAgentReport_ResultBindingSource
            // 
            this.GetSalesAgentReport_ResultBindingSource.DataSource = typeof(Sparrow_Insurance_Agency.GetSalesAgentReport_Result);
            // 
            // panel1
            // 
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
            this.panel1.Size = new System.Drawing.Size(1057, 46);
            this.panel1.TabIndex = 5;
            // 
            // btnSearchAgent
            // 
            this.btnSearchAgent.Location = new System.Drawing.Point(774, 12);
            this.btnSearchAgent.Name = "btnSearchAgent";
            this.btnSearchAgent.Size = new System.Drawing.Size(31, 23);
            this.btnSearchAgent.TabIndex = 11;
            this.btnSearchAgent.Text = ". . .";
            this.btnSearchAgent.UseVisualStyleBackColor = true;
            this.btnSearchAgent.Click += new System.EventHandler(this.btnSearchAgent_Click_1);
            // 
            // txtBoxAgent
            // 
            this.txtBoxAgent.Enabled = false;
            this.txtBoxAgent.Location = new System.Drawing.Point(542, 14);
            this.txtBoxAgent.Name = "txtBoxAgent";
            this.txtBoxAgent.Size = new System.Drawing.Size(226, 20);
            this.txtBoxAgent.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Agent";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(811, 12);
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
            this.label2.Location = new System.Drawing.Point(269, 17);
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
            this.datePickerTo.Location = new System.Drawing.Point(295, 15);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(200, 20);
            this.datePickerTo.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EchoDataset";
            reportDataSource1.Value = this.GetSalesAgentReport_ResultBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sparrow_Insurance_Agency.Reports.SalesAgentIncomeReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 46);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1057, 478);
            this.reportViewer1.TabIndex = 6;
            // 
            // SalesAgentIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 524);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "SalesAgentIncome";
            this.Text = "Sales Agent Income";
            this.Load += new System.EventHandler(this.SalesAgentIncome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetSalesAgentReport_ResultBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GetSalesAgentReport_ResultBindingSource;
        private System.Windows.Forms.Button btnSearchAgent;
        public  System.Windows.Forms.TextBox txtBoxAgent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}