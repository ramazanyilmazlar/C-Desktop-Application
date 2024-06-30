using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczanePanel
{
    public partial class Form1 : Form
    {
        function fn = new function(); //gerekli veritabani baglantilari eklendi
        String query;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //uygulamadan cikma
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnsign_Click(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0 ) 
            {
                if(txtUsername.Text=="root" && txtPassword.Text == "root") 
                {
                    admin am = new admin();
                    am.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from users where username = '" + txtUsername.Text + "' and pass= '" + txtPassword.Text +"' ";
                ds=fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0) 
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if(role == "Yönetici") 
                    {
                        admin am = new admin(txtUsername.Text); 
                        am.Show();
                        this.Hide();
                    }
                    else if (role == "Eczaci") 
                    {
                        Eczaci eczaci = new Eczaci();
                        eczaci.Show();
                        this.Hide();
                    }

                   
                }

                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            














            /*
            
            if(txtUsername.Text=="ramazan" && txtPassword.Text=="admin")
            {
                admin am = new admin();
                am.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
