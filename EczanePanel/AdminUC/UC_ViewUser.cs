using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczanePanel.AdminUC
{
    public partial class UC_ViewUser : UserControl
    {
        function fn = new function();
        String query;
        String currentUser = "";

        public UC_ViewUser()
        {
            InitializeComponent();
        }

        public string ID 
        {
            set { currentUser = value; }
        }

        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            query = "select * from users"; //veri tabani sorgusu yazildi
            DataSet ds =fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0]; //verileri data grid alaninda gostermesi icin esitlendi
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username like '" + txtUserName.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1 .DataSource = ds.Tables[0];
        }


        String userName;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                userName = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Emin Misin?","Onayla!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)

            if (currentUser != userName) 
            {
                    query = "delete from users where username='" + userName + "'";
                    fn.setData(query, "Kullanıcı Kaydı Silindi");
                    UC_ViewUser_Load(this, null);
            }
            else 
            {
                MessageBox.Show("Kendi profilini silmeye çalışıyorsun.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_ViewUser_Load(this, null);
        }
    }
}
