using cafeProje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            cGenel cGenel = new cGenel();


           if(cGenel._calisanKullaniciAdi == "admin")
            {
                btnAyarlar.Visible = true;
            }
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.Show();
            this.Hide();

        }
    }
}
