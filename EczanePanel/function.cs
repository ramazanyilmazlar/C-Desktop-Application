using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczanePanel
{
    internal class function
    {
        protected SqlConnection getConnection()
        {   
            //sql veri tabanina baglanti yolu yapildi
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = OBSERVER\\SQLEXPRESS;database=eczane;integrated security = True";
            return con;
        }

        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand(); //sql komutu olusturuldu
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);  // sql bagdastirici nesnesi olusturuldu
            DataSet ds = new DataSet(); // veri seti olusturuldu
            da.Fill(ds); //   icerilen veri seti kumesi ile veri seti dolduruldu
            return ds; // veri tabanina donduruldu
        }

        public void setData(String query, String msg)
        {
            SqlConnection con = getConnection(); // baglanti nesnesi olusturuldu
            SqlCommand cmd = new SqlCommand(); // baglanti nesnesini alan cmd komutu olusturuldu
            cmd.Connection = con;
            con.Open(); // baglantiyi acildi
            cmd.CommandText = query; // sorgu iletildi
            cmd.ExecuteNonQuery(); // sorgu yurutuldu
            con.Close(); // sorgu kapatildi
            MessageBox.Show(msg,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information); // ileti
        }
    }

}
