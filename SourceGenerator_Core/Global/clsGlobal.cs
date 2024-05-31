using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceGenerator_Core
{
    public class clsGlobal
    {

        public static bool ValidateTxtBox(TextBox txtBox, string ErrorCase,
            string ErrorText, ErrorProvider errorProvider)
        {
            if (txtBox.Text == ErrorCase)
            {
                errorProvider.SetError(txtBox, ErrorText);
                return false;
            }

            return true;
        }

        public static bool ValidateTxtBox(TextBox txtBox, bool ErrorCase,
           string ErrorText, ErrorProvider errorProvider)
        {
            if (ErrorCase)
            {
                errorProvider.SetError(txtBox, ErrorText);
                return false;
            }

            return true;
        }

        public static bool ValidateTxt(Control C, string ErrorCase, string ErrorText, ErrorProvider errorProvider)
        {
            if (C.Text == ErrorCase)
            {
                errorProvider.SetError(C, ErrorText);
                return false;
            }

            return true;
        }

        public static string CreateConnectionString(string DataBaseName, string UserName, string Password)
        {
            return $@"Server=.;Database={DataBaseName};User Id={UserName};Password={Password};";
        }




    }
}
