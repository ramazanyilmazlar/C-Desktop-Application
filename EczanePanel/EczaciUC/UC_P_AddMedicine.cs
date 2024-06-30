using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EczanePanel.EczaciUC
{
    public partial class UC_P_AddMedicine : UserControl
    {
        function fn = new function();
        String query;
        public UC_P_AddMedicine()
        {
            InitializeComponent();
        }

        private void txtMediId_TextChanged(object sender, EventArgs e)
        {
            query = "select * from ilacInfo where mid ='" + txtMediId.Text + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtMediName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtPricePerUnit.Text = ds.Tables[0].Rows[0][2].ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMediId.Text != "" && txtMediName.Text != "" && txtQuantity.Text != "" && txtPricePerUnit.Text != "")
            {
                String mid = txtMediId.Text;
                String mname = txtMediName.Text;
                String mdate= txtManufacturingDate.Text;
                String edate= txtExpireDate.Text;
                Int64 quantity = Int64.Parse(txtQuantity.Text);
                Int64 perunit=Int64.Parse(txtPricePerUnit.Text);

                query = "insert into medic (mid,mname,mDate,EDate,quantity,perUnit) values ('"+mid+ "','"+mname+"','"+mdate+"','"+edate+ "','"+quantity+"','"+perunit+"') ";
                fn.setData(query, "İlaç Eklendi");
            }
            else
            {
                MessageBox.Show("İlaç bilgilerinin tamamı doldurulmadı.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtMediId.Clear();
            txtMediName.Clear();
            txtPricePerUnit.Clear();
            txtQuantity.Clear();
            txtManufacturingDate.ResetText();
            txtExpireDate.ResetText();
        }
    }
}
