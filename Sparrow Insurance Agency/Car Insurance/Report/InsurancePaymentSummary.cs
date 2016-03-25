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
using Sparrow_Insurance_Agency.Class;

namespace Sparrow_Insurance_Agency.Car_Insurance.Report
{
    public partial class InsurancePaymentSummary : Form
    {
        PaymentReportParameters parameters;

        public InsurancePaymentSummary(PaymentReportParameters _parameters)
        {
            InitializeComponent();
            parameters = _parameters;
        }

        private void InsurancePaymentSummary_Load(object sender, EventArgs e)
        {
            using (var db = new SparrowEntities())
            {
                GetInsurancePaymentReport_ResultBindingSource.DataSource =
                    db.GetInsurancePaymentReport(parameters.PolicyID);

                ReportParameter[] rParams = new ReportParameter[]
                {
                    new ReportParameter("PolicyNo", parameters.PolicyNo),
                    new ReportParameter("Assured", parameters.Assured),
                    new ReportParameter("PlateNo", parameters.PlateNo),
                    new ReportParameter("SerialNo", parameters.SerialNo),
                    new ReportParameter("EngineNo", parameters.EngineNo),
                    new ReportParameter("Gross", parameters.Gross)
                };

                reportViewer.LocalReport.SetParameters(rParams);

                reportViewer.RefreshReport();
            }
        }
    }
}
