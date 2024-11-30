using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace cafeProje
{
    class cGenel
    {
        public string conString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public static int _calisanId;
        public static int _calisanGorevId;
        public static string _calisanAd;
        public static string _calisanSoyad;
        public static string _calisanKullaniciAdi;
    }
}

