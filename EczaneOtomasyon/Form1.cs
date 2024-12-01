using cafeProje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();
            calisan c = new calisan();
            bool result = c.CalisanGirisKontrol(txtKullaniciAdi.Text, txtParola.Text);
            if (result)
            {
                c.GuncelleCalisanGiris(cGenel._calisanId);
                Menu frmMenu = new Menu();
                frmMenu.Show(); 
                this.Hide();
                
                
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış!", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
