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
    public partial class Total_Income : Form
    {
        public Total_Income()
        {
            InitializeComponent();
        }

        private void Total_Income_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            using (var db = new SparrowEntities())
            {
                GetIncomeReport_ResultBindingSource.DataSource =
                    db.GetIncomeReport(dateTimePicker1.Value, dateTimePicker2.Value).ToList();

                ReportParameter[] rParams = new ReportParameter[]
                {
                    new ReportParameter("fromDate",dateTimePicker1.Value.Date.ToShortDateString()),
                    new ReportParameter("toDate", dateTimePicker2.Value.Date.ToShortDateString())
                };

                reportViewer1.LocalReport.SetParameters(rParams);

                reportViewer1.RefreshReport();
            }
        }
    }
}
