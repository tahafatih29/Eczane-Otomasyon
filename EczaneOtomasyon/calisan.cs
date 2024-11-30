using cafeProje;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon
{
    internal class calisan
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _CalisanId;
        private int _CalisanGorevId;
        private string _CalisanAd;
        private string _CalisanSoyad;
        private string _CalisanParola;
        private string _CalisanKullaniciAdi;
   
        #endregion
        #region Properties
        public int PersonelId
        {
            get
            {
                return _CalisanId;
            }
            set
            {
                _CalisanId = value;
            }
        }
        public int CalisanGorevId { get => _CalisanGorevId; set => _CalisanGorevId = value; }
        public string CalisanAd { get => _CalisanAd; set => _CalisanAd = value; }
        public string CalisanSoyad { get => _CalisanSoyad; set => _CalisanSoyad = value; }
        public string CalisanParola { get => _CalisanParola; set => _CalisanParola = value; }
        public string CalisanKullaniciAdi { get => _CalisanKullaniciAdi; set => _CalisanKullaniciAdi = value; }

        #endregion

        public bool CalisanGirisKontrol(string kullaniciAdi, string sifre)
        {
            bool result = false;
            string query = "SELECT id, gorev_id, ad, soyad, kullanici_adi FROM calisan WHERE kullanici_adi = @kullaniciAdi AND sifre = @sifre";

            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(query, conn);
            {
                cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        // Kullanıcı adı ve şifre doğruysa cGenel'e id ve gorev_id'yi kaydediyoruz
                        cGenel._calisanId = Convert.ToInt32(reader["id"]);
                        cGenel._calisanGorevId = Convert.ToInt32(reader["gorev_id"]);
                        cGenel._calisanAd = Convert.ToString(reader["ad"]);
                        cGenel._calisanSoyad = Convert.ToString(reader["soyad"]);
                        cGenel._calisanKullaniciAdi = Convert.ToString(reader["kullanici_adi"]);
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    throw;
                }
            }
            return result;
        }

        public void GuncelleCalisanGiris(int calisanId)
        {
            string query = "UPDATE calisan SET son_giris = GETDATE() WHERE id = @calisanId";
            using (SqlConnection conn = new SqlConnection(gnl.conString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@calisanId", calisanId);
                conn.Open();
                cmd.ExecuteNonQuery(); // Trigger otomatik olarak tetiklenecek.
            }
        }
    }
}
