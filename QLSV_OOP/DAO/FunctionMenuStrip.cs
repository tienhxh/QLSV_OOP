using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV_OOP.DTO;
using System.Windows.Forms;

namespace QLSV_OOP.DAO
{
    public class FunctionMenuStrip
    {
        private static FunctionMenuStrip instance;

        public static FunctionMenuStrip Instance
        {
            get
            {
                if (instance == null) instance = new FunctionMenuStrip();
                return instance;
            }
            private set => instance = value;
        }
        private FunctionMenuStrip() { }

        public void SignOut(object sender, EventArgs e)
        {
            if (sender is Form form)
            {
                if (form != null)
                {
                    form.Close();
                    
                }    
            }    
        }
        
    }
}
