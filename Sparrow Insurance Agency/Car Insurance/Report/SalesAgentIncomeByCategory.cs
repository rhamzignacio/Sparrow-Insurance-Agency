using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Car_Insurance.Report
{
    public partial class SalesAgentIncomeByCategory : Form
    {
        public SalesAgentIncomeByCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBoxAgent.Text != "" && cmbBoxCategory.Text != "")
            {
                using (var db = new SparrowEntities())
                {
                    getSalesAgentReportByCategoryResultBindingSource.DataSource =
                        db.GetSalesAgentReportByCategory(Guid.Parse(txtBoxAgentID.Text), datePickerFrom.Value, datePickerTo.Value,
                            cmbBoxCategory.Text).ToList();

                    ReportParameter[] rParams = new ReportParameter[]
                    {
                        new ReportParameter("salesAgent", txtBoxAgentID.Text),
                        new ReportParameter("fromDate", datePickerFrom.Value.Date.ToShortDateString()),
                        new ReportParameter("toDate", datePickerTo.Value.Date.ToShortDateString()),
                        new ReportParameter("salesAgentName", txtBoxAgent.Text),
                        new ReportParameter("category", cmbBoxCategory.Text)
                    };

                    reportViewer.LocalReport.SetParameters(rParams);

                    reportViewer.RefreshReport();
                }
            }
            else
                MessageBox.Show("Please select sales agent | category", "Error");
        }

        private void btnSearchAgent_Click(object sender, EventArgs e)
        {
            SalesAgent form = new SalesAgent(txtBoxAgentID, txtBoxAgent);
            form.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
