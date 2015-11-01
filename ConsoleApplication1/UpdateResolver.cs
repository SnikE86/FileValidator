using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileValidator
{
    class UpdateResolver :IUpdateResolver
    {
        public Boolean ResolveUpdate()
        {
            if (MessageBox.Show(
                "An updated version of this program is available. Would you like to download it now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk
                ) == DialogResult.Yes)
            {
                Process.Start("explorer.exe", "http://www.michaelekins.co.uk/#/downloads");
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
