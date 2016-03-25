﻿namespace Sparrow_Insurance_Agency.Car_Insurance.Report
{
    partial class InsurancePaymentSummary
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GetInsurancePaymentReport_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GetInsurancePaymentReport_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PaymentSummary";
            reportDataSource1.Value = this.GetInsurancePaymentReport_ResultBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Sparrow_Insurance_Agency.Reports.PaymentSummary.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(840, 593);
            this.reportViewer.TabIndex = 0;
            // 
            // GetInsurancePaymentReport_ResultBindingSource
            // 
            this.GetInsurancePaymentReport_ResultBindingSource.DataSource = typeof(Sparrow_Insurance_Agency.GetInsurancePaymentReport_Result);
            // 
            // InsurancePaymentSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 593);
            this.Controls.Add(this.reportViewer);
            this.Name = "InsurancePaymentSummary";
            this.Text = "Payment Summary";
            this.Load += new System.EventHandler(this.InsurancePaymentSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetInsurancePaymentReport_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource GetInsurancePaymentReport_ResultBindingSource;
    }
}