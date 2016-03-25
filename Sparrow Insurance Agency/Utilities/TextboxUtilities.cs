using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Utilities
{
    public class TextboxUtilities
    {
        public void TextBoxIntergerOnly(object sender, KeyPressEventArgs _e)
        {
            if (!char.IsControl(_e.KeyChar) && !char.IsDigit(_e.KeyChar)
                && _e.KeyChar != '.')
                _e.Handled = true;

            //allow one decimal point only
            if ((_e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                _e.Handled = true;
        }

        public void Tab(KeyEventArgs _e)
        {
            if(_e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        public string AmountFormat(string _amount)
        {
            string value = "";

            //remove comma
            _amount = _amount.Replace(",", "");

            if(_amount != "")
                value = string.Format("{0:#,##0.00}", double.Parse(_amount));

            return value;
        }
    }
}
