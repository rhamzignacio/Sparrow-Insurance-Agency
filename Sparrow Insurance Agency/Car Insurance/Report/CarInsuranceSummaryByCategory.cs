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
    public partial class CarInsuranceSummaryByCategory : Form
    {
        public CarInsuranceSummaryByCategory()
        {
            InitializeComponent();
        }

        private void CarInsuranceSummaryByCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var db = new SparrowEntities())
            {
                
                getCarInsurancePolicyReportByCategoryResultBindingSource.DataSource =
                    db.GetCarInsurancePolicyReportByCategory(dateTimePicker1.Value, dateTimePicker2.Value,
                        cmbBoxCategory.Text).ToList();

                ReportParameter[] rParams = new ReportParameter[]
                {
                    new ReportParameter("fromDate",dateTimePicker1.Value.Date.ToShortDateString()),
                    new ReportParameter("toDate", dateTimePicker2.Value.Date.ToShortDateString()),
                    new ReportParameter("category", cmbBoxCategory.Text)
                };

                reportViewer.LocalReport.SetParameters(rParams);

                reportViewer.RefreshReport();
            }
        }
    }
}
