using cafeProje;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon
{
    internal class cKullanicilar
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _UserID;
        private int _Role;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;
        #endregion
        #region Properties
        public int PersonelId
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        public int PersonelGorevId { get => _Role; set => _Role = value; }
        public string PersonelAd { get => _PersonelAd; set => _PersonelAd = value; }
        public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
        public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
        public string PersonelKullaniciAdi { get => _PersonelKullaniciAdi; set => _PersonelKullaniciAdi = value; }
        public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; }
        #endregion

        public bool personelEntryControl(String password, int UserId)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Kullanıcılar where user_id=@Id and password=@password", con);
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                string hata = ex.Message;
                throw;
            }

            return result;
        }
    }
}
