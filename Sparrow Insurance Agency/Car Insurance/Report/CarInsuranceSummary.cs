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
    public partial class CarInsuranceSummary : Form
    {
        public CarInsuranceSummary()
        {
            InitializeComponent();
        }

        private void Total_Income_Load(object sender, EventArgs e)
        {
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using(var db = new SparrowEntities())
            {
                getCarInsurancePolicyReportBindingSource.DataSource = 
                    db.GetCarInsurancePolicyReport1(dateTimePicker1.Value, dateTimePicker2.Value).ToList();

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
