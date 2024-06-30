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
    public partial class UC_P_UpdateMedicine : UserControl
    {
        function fn = new function();
        String query;

        public UC_P_UpdateMedicine()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMedicineID.Text != "")
            {
                query = "select * from medic where mid= '"+txtMedicineID.Text+"'";
                DataSet ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtMediName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtMDate.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtEDate.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtAvailableQuantity.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtPricePerUnit.Text = ds.Tables[0].Rows[0][6].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Barkod Numarası:" + txtMedicineID.Text + " Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                clearAll();
            }
        }

        private void clearAll()
        {
            txtMedicineID.Clear();
            txtMediName.Clear();
            txtMDate.ResetText();
            txtEDate.ResetText();
            txtAvailableQuantity.Clear();
            txtPricePerUnit.Clear();
            if(txtAddQuan.Text != "0")
            {
                txtAddQuan.Text = "0";
            }
            else
            {
                txtAddQuan.Text = "0";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        Int64 totalQuantity;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String mname= txtMediName.Text;
            String mdate = txtMDate.Text;
            String edate= txtEDate.Text;
            Int64 quantity = Int64.Parse(txtAvailableQuantity.Text);
            Int64 addQuantity = Int64.Parse(txtAddQuan.Text);
            Int64 unitprice = Int64.Parse(txtPricePerUnit.Text);

            totalQuantity = quantity + addQuantity;

            query = "update medic set mname='" + mname + "',mDate='" + mdate + "',eDate='" + edate + "',quantity=" + totalQuantity + ",perUnit=" + unitprice + "where mid ='" + txtMedicineID.Text +"' ";
            fn.setData(query, "İlaç Bilgileri Güncellendi.");
        }
    }
}
