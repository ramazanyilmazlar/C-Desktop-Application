using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczanePanel.EczaciUC
{
    public partial class UC_P_MedicineValidityCheck : UserControl
    {

        function fn = new function();
        String query;
        public UC_P_MedicineValidityCheck()
        {
            InitializeComponent();
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtCheck.SelectedIndex == 0)
            {
                query = "select * from medic where eDate>=getdate()";
                DataSet ds=fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "Geçerli İlaçlar";
                setLabel.ForeColor = Color.Black;
            }
            else if (txtCheck.SelectedIndex == 1)
            {
                query = "select * from medic where eDate <= getdate()";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "SKT Geçmiş İlaçlar";
                setLabel.ForeColor = Color.Red;
            }
            else if (txtCheck.SelectedIndex == 2)
            {
                query = "select * from medic";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "";
                setLabel.ForeColor = Color.Black;
            }
        }


        private void UC_P_MedicineValidityCheck_Load(object sender, EventArgs e)
        {
            setLabel.Text = "";
        }
    }
}
