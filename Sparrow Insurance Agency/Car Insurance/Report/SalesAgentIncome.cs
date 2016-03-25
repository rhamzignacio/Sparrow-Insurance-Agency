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
    public partial class SalesAgentIncome : Form
    {
        public Guid agentID;

        public SalesAgentIncome()
        {
            InitializeComponent();
        }

        private void SalesAgentIncome_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBoxAgent.Text != "")
            {
                using (var db = new SparrowEntities())
                {
                    GetSalesAgentReport_ResultBindingSource.DataSource =
                        db.GetSalesAgentReport(agentID, datePickerFrom.Value, datePickerTo.Value).ToList();

                    ReportParameter[] rParams = new ReportParameter[]
                    {
                        new ReportParameter("salesAgent", agentID.ToString()),
                        new ReportParameter("fromDate", datePickerFrom.Value.Date.ToShortDateString()),
                        new ReportParameter("toDate", datePickerTo.Value.Date.ToShortDateString()),
                        new ReportParameter("salesAgentName", txtBoxAgent.Text)
                    };

                    reportViewer1.LocalReport.SetParameters(rParams);

                    reportViewer1.RefreshReport();
                }
            }
            else
                MessageBox.Show("Please select sales agent", "Error");
        }

        private void btnSearchAgent_Click_1(object sender, EventArgs e)
        {
            SalesAgent form = new SalesAgent(this);
            form.ShowDialog();
        }
    }
}
