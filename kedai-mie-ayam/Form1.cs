using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace Kedai_MieAyam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int SafeInt(TextBox t)
        {
            int nilai;
            if (int.TryParse(t.Text, out nilai))
                return nilai;
            return 0; // Kalau kosong atau huruf → dianggap 0
        }


        // Harga menu
        int ori = 12000, ceker = 14000, bakso = 17000, pangsit = 20000, teh = 5000, jeruk = 8000;
        int total = 0;

        private int ParseIntFromTextBox(TextBox tb)
        {
            if (tb == null) return 0;
            string s = tb.Text.Trim();
            if (string.IsNullOrEmpty(s)) return 0;
            // hapus titik, koma, spasi, 'Rp' jsb
            s = s.Replace(".", "").Replace(",", "").Replace("Rp", "").Replace("rp", "").Replace(" ", "");
            int val;
            if (int.TryParse(s, out val)) return val;
            return 0;
        }

        private string BuatStruk()
        {
            string struk = "";
            struk += "======= KEDAI MIE AYAM AZIS =======\n";
            struk += "Tanggal : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\n";
            struk += "-----------------------------------\n";
            struk += "Nama Pesanan : " + txtnama.Text + "\n";
            //struk += "Harga        : Rp " + txtHarga.Text + "\n";
            //struk += "Jumlah       : " + txtJumlah.Text + "\n";
            struk += "Subtotal     : Rp " + txtsubtotal.Text + "\n";
            struk += "Diskon       : Rp " + txtdiskon.Text + "\n";
            struk += "TOTAL BAYAR  : Rp " + Total.Text + "\n";
            struk += "-----------------------------------\n";
            struk += "Uang Bayar   : Rp " + ub.Text + "\n";
            struk += "Kembali      : Rp " + uk.Text + "\n";
            struk += "===================================\n";
            struk += "     Hatur Nuhun parantos mesen!   \n";

            return struk;
        }


        private void btnedit_Click(object sender, EventArgs e)
        {
            if (listpesanan.SelectedIndex != -1)
            {
                string newText = Microsoft.VisualBasic.Interaction.InputBox("Ubah pesanan:", "Edit", listpesanan.SelectedItem.ToString());
                if (!string.IsNullOrEmpty(newText))
                {
                    listpesanan.Items[listpesanan.SelectedIndex] = newText;
                }
            }
        }

        private void btnkeluar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin Ingin Keluar", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void tgl_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            if(tgl.Value.Date < today)
            {
                tgl.Value = today;
            }
        }

        private void TambahPesanan(string namaMenu, int harga, TextBox jumlahBox)
        {
            int jumlah;

            // Validasi jumlah
            if (!int.TryParse(jumlahBox.Text, out jumlah) || jumlah <= 0)
            {
                MessageBox.Show($"Jumlah untuk {namaMenu} harus angka dan lebih dari 0!", "Error");
                return;
            }

            int total = harga * jumlah;

            listpesanan.Items.Add($"{namaMenu} x{jumlah} = Rp.{total:N0}");
        }

        private void ResetInputMenu()
        {
            cbori.Checked = false;
            cbceker.Checked = false;
            cbbakso.Checked = false;
            cbpangsit.Checked = false;
            cbteh.Checked = false;
            cbjeruk.Checked = false;

            jmlori.Clear();
            jmlceker.Clear();
            jmlbakso.Clear();
            jmlpangsit.Clear();
            jmlteh.Clear();
            jmljeruk.Clear();
        }



        private void jumlah(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void jumlah2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void jumlah3(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rbcash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcash.Checked)
            {
                QRIS.Visible = false;
            }
                
        }

        private void rbqris_CheckedChanged(object sender, EventArgs e)
        {
            if (rbqris.Checked)
            {
                QRIS.Visible = true;
            }
            else
            {
                QRIS.Visible =false;
            }
        }

        private void uk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdiskon_TextChanged(object sender, EventArgs e)
        {

        }

        //private void btnTambah_Click(object sender, EventArgs e)
        //{

        //    // Cek jika nama pemesan kosong
        //    if (txtnama.Text == "")
        //    {
        //        MessageBox.Show("Masukkan nama pemesan dulu!");
        //        return;
        //    }

        //    string pesanan = "Nama: " + txtnama.Text + " | ";

        //    // Menu Mie Ayam Ori
        //    if (cbori.Checked)
        //    {
        //        int jml = int.Parse(jmlori.Text);
        //        pesanan += "Mie Ayam Ori x" + jml + "  ";
        //    }

        //    // Menu Mie Ayam Ceker
        //    if (cbceker.Checked)
        //    {
        //        int jml = int.Parse(jmlceker.Text);
        //        pesanan += "Mie Ayam Ceker x" + jml + "  ";
        //    }

        //    // Menu Mie Ayam Bakso
        //    if (cbbakso.Checked)
        //    {
        //        int jml = int.Parse(jmlbakso.Text);
        //        pesanan += "Mie Ayam Bakso x" + jml + "  ";
        //    }

        //    // Menu Mie Pangsit
        //    if (cbpangsit.Checked)
        //    {
        //        int jml = int.Parse(jmlpangsit.Text);
        //        pesanan += "Mie Pangsit x" + jml + "  ";
        //    }

        //    // Es Teh
        //    if (cbteh.Checked)
        //    {
        //        int jml = int.Parse(jmlteh.Text);
        //        pesanan += "Es Teh x" + jml + "  ";
        //    }

        //    // Es Jeruk
        //    if (cbjeruk.Checked)
        //    {
        //        int jml = int.Parse(jmljeruk.Text);
        //        pesanan += "Es Jeruk x" + jml + "  ";
        //    }

        //    // Tambahkan ke listbox
        //    listpesanan.Items.Add(pesanan);

        //    //Reset isian supaya bisa input orang berikutnya
        //    txtnama.Clear();
        //    cbori.Checked = false;
        //    cbceker.Checked = false;
        //    cbbakso.Checked = false;
        //    cbpangsit.Checked = false;
        //    cbteh.Checked = false;
        //    cbjeruk.Checked = false;

        //    jmljeruk.Clear();
        //    jmlceker.Clear();
        //    jmlbakso.Clear();
        //    jmlpangsit.Clear();
        //    jmlteh.Clear();
        //    jmlori.Clear();

        //    bersih();
        //}

        private int AmbilJumlah(string data, string menu)
        {
            try
            {
                int start = data.IndexOf(menu) + menu.Length;
                int end = data.IndexOf(" ", start);

                // kalau di akhir string
                if (end == -1) end = data.Length;

                string angka = data.Substring(start, end - start);

                int.TryParse(angka, out int jumlah);
                return jumlah;
            }
            catch
            {
                return 0;
            }
        }

        private void btnhitung_Click(object sender, EventArgs e)
        {
            if (listpesanan.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih dulu pesanan di list!");
                return;
            }

            string data = listpesanan.SelectedItem.ToString();
            int subtotal = 0;

            // Hitung Ori
            if (data.Contains("Ori x"))
            {
                int jumlah = AmbilJumlah(data, "Ori x");
                subtotal += jumlah * 12000;
            }

            // Hitung Ceker
            if (data.Contains("Ceker x"))
            {
                int jumlah = AmbilJumlah(data, "Ceker x");
                subtotal += jumlah * 14000;
            }

            // Hitung Bakso
            if (data.Contains("Bakso x"))
            {
                int jumlah = AmbilJumlah(data, "Bakso x");
                subtotal += jumlah * 17000;
            }

            // Hitung Pangsit
            if (data.Contains("Pangsit x"))
            {
                int jumlah = AmbilJumlah(data, "Pangsit x");
                subtotal += jumlah * 20000;
            }

            // Hitung Teh
            if (data.Contains("Teh x"))
            {
                int jumlah = AmbilJumlah(data, "Teh x");
                subtotal += jumlah * 5000;
            }

            // Hitung Jeruk
            if (data.Contains("Jeruk x"))
            {
                int jumlah = AmbilJumlah(data, "Jeruk x");
                subtotal += jumlah * 8000;
            }

            // Tampilkan hasil
            txtsubtotal.Text = subtotal.ToString();

            int diskon = 0;
            int total = subtotal;

            if (subtotal > 100000)
            {
                diskon = (int)(subtotal * 0.10);   // diskon 10%
                total = subtotal - diskon;
            }

            txtdiskon.Text = diskon.ToString();
            Total.Text = total.ToString();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.ToLower();

            // kalau kosong, jangan cari
            if (keyword == "")
            {
                MessageBox.Show("Masukkan kata pencarian!");
                return;
            }

            // reset pilihan dulu
            listpesanan.ClearSelected();

            bool found = false;

            for (int i = 0; i < listpesanan.Items.Count; i++)
            {
                string item = listpesanan.Items[i].ToString().ToLower();

                if (item.Contains(keyword))
                {
                    listpesanan.SetSelected(i, true);  // highlight item ditemukan
                    found = true;
                    break;  // berhenti di hasil pertama
                }
            }

            if (!found)
            {
                MessageBox.Show("Data tidak ditemukan!");
            }
        }

        private void btnTambah_Click_1(object sender, EventArgs e)
        {
            // Cek jika nama pemesan kosong
            if (txtnama.Text == "")
            {
                MessageBox.Show("Masukkan nama pemesan dulu!");
                return;
            }

            string pesanan = "Nama: " + txtnama.Text + " | ";

            // Menu Mie Ayam Ori
            if (cbori.Checked)
            {
                int jml = int.Parse(jmlori.Text);
                pesanan += "Mie Ayam Ori x" + jml + "  ";
            }

            // Menu Mie Ayam Ceker
            if (cbceker.Checked)
            {
                int jml = int.Parse(jmlceker.Text);
                pesanan += "Mie Ayam Ceker x" + jml + "  ";
            }

            // Menu Mie Ayam Bakso
            if (cbbakso.Checked)
            {
                int jml = int.Parse(jmlbakso.Text);
                pesanan += "Mie Ayam Bakso x" + jml + "  ";
            }

            // Menu Mie Pangsit
            if (cbpangsit.Checked)
            {
                int jml = int.Parse(jmlpangsit.Text);
                pesanan += "Mie Pangsit x" + jml + "  ";
            }

            // Es Teh
            if (cbteh.Checked)
            {
                int jml = int.Parse(jmlteh.Text);
                pesanan += "Es Teh x" + jml + "  ";
            }

            // Es Jeruk
            if (cbjeruk.Checked)
            {
                int jml = int.Parse(jmljeruk.Text);
                pesanan += "Es Jeruk x" + jml + "  ";
            }

            // Tambahkan ke listbox
            listpesanan.Items.Add(pesanan);

            //Reset isian supaya bisa input orang berikutnya
            txtnama.Clear();
            cbori.Checked = false;
            cbceker.Checked = false;
            cbbakso.Checked = false;
            cbpangsit.Checked = false;
            cbteh.Checked = false;
            cbjeruk.Checked = false;

            jmljeruk.Clear();
            jmlceker.Clear();
            jmlbakso.Clear();
            jmlpangsit.Clear();
            jmlteh.Clear();
            jmlori.Clear();

            bersih();
        }

        private void listpesanan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ub_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ub.Text) && !string.IsNullOrEmpty(Total.Text))
                {
                    // Bersihkan simbol "Rp" dan titik pemisah ribuan
                    string totalText = Total.Text.Replace("Rp.", "").Replace("Rp", "").Replace(".", "").Trim();
                    string bayarText = ub.Text.Replace("Rp.", "").Replace("Rp", "").Replace(".", "").Trim();

                    // Konversi ke int
                    int totalAkhir = int.Parse(totalText);
                    int bayar = int.Parse(bayarText);

                    // Hitung kembalian
                    int kembali = bayar - totalAkhir;

                    // Validasi uang bayar cukup
                    if (kembali < 0)
                    {
                        uk.Text = "Uang kurang!";
                    }
                    else
                    {
                        uk.Text = "Rp. " + kembali.ToString("N0");
                    }
                }
                else
                {
                    uk.Text = "";
                }
            }
            catch
            {
                uk.Text = "";
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (listpesanan.SelectedIndex != -1)
            {
                listpesanan.Items.RemoveAt(listpesanan.SelectedIndex);
            }
        }

        private void btntampil_Click(object sender, EventArgs e)
        {
            string struk = BuatStruk();

            if (string.IsNullOrWhiteSpace(ub.Text))
            {
                MessageBox.Show("Uang bayar harus diisi!",
                                "Peringatan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // stop dulu, jangan tampilkan struk
            }

            MessageBox.Show(struk, "Struk Pembayaran",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        
        private void btnreset_Click(object sender, EventArgs e)
        {
            cbori.Checked = cbceker.Checked = cbbakso.Checked = cbpangsit.Checked = cbteh.Checked = cbjeruk.Checked = false;
            jmlori.Clear(); jmlceker.Clear(); jmlbakso.Clear(); jmlpangsit.Clear(); jmlteh.Clear(); jmljeruk.Clear();
            txtdiskon.Clear(); Total.Clear(); ub.Clear(); uk.Clear();
            listpesanan.Items.Clear();
            txtnama.Clear();
            txtsubtotal.Clear();
            rbcash.Checked = rbqris.Checked = false;
        }

        private void bersih()
        {
            cbori.Checked = cbceker.Checked = cbbakso.Checked = cbpangsit.Checked = cbteh.Checked = cbjeruk.Checked = false;
            jmlori.Clear(); jmlceker.Clear(); jmlbakso.Clear(); jmlpangsit.Clear(); jmlteh.Clear(); jmljeruk.Clear();
            txtdiskon.Clear(); Total.Clear(); ub.Clear(); uk.Clear();
            txtnama.Clear();
            txtsubtotal.Clear();
            rbcash.Checked = rbqris.Checked = false;
        }
    }

        

        //private void btnhitung_Click(object sender, EventArgs e)
        //{

        //    total = 0;
        //    listpesanan.Items.Clear();


        //    if (string.IsNullOrEmpty(txtnama.Text))
        //    {
        //        MessageBox.Show("Nama pembeli belum diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtnama.Focus();
        //        return;
        //    }

        //    if (string.IsNullOrEmpty(txtnama.Text))
        //    {
        //        MessageBox.Show("Nama pembeli belum diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtnama.Focus();
        //        return;
        //    }

        //    // 🔹 Validasi minimal 1 menu dipilih
        //    if (!cbori.Checked && !cbceker.Checked && !cbbakso.Checked &&
        //        !cbpangsit.Checked && !cbteh.Checked && !cbjeruk.Checked)
        //    {
        //        MessageBox.Show("Silakan pilih minimal satu menu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // 🧾 Tambahkan info pembeli
        //    string nama = txtnama.Text;
        //    string tanggal = tgl.Text;

        //    listpesanan.Items.Add("Nama   : " + nama);
        //    listpesanan.Items.Add("Tanggal: " + tanggal);

        //    if (cbori.Checked)
        //    {
        //        int jml = string.IsNullOrEmpty(jmlori.Text) ? 0 : int.Parse(jmlori.Text);
        //        int sub = jml * ori;
        //        listpesanan.Items.Add("     Mie Ayam Ori x" + jml + " = Rp." + sub);
        //        total += sub;
        //    }

        //    if (cbceker.Checked)
        //    {
        //        int jml = string.IsNullOrEmpty(jmlceker.Text) ? 0 : int.Parse(jmlceker.Text);
        //        int sub = jml * ceker;
        //        listpesanan.Items.Add("     Mie Ayam Ceker x" + jml + " = Rp." + sub);
        //        total += sub;
        //    }

        //    if (cbbakso.Checked)
        //    {
        //        int jml = string.IsNullOrEmpty(jmlbakso.Text) ? 0 : int.Parse(jmlbakso.Text);
        //        int sub = jml * bakso;
        //        listpesanan.Items.Add("     Mie Ayam Bakso x" + jml + " = Rp." + sub);
        //        total += sub;
        //    }

        //    if (cbpangsit.Checked)
        //    {
        //        int jml = string.IsNullOrEmpty(jmlpangsit.Text) ? 0 : int.Parse(jmlpangsit.Text);
        //        int sub = jml * pangsit;
        //        listpesanan.Items.Add("     Mie Ayam Pangsit x" + jml + " = Rp." + sub);
        //        total += sub;
        //    }

        //    if (cbteh.Checked)
        //    {
        //        int jml = string.IsNullOrEmpty(jmlteh.Text) ? 0 : int.Parse(jmlteh.Text);
        //        int sub = jml * teh;
        //        listpesanan.Items.Add("     Es Teh Manis x" + jml + " = Rp." + sub);
        //        total += sub;
        //    }

        //    if (cbjeruk.Checked)
        //    {
        //        int jml = string.IsNullOrEmpty(jmljeruk.Text) ? 0 : int.Parse(jmljeruk.Text);
        //        int sub = jml * jeruk;
        //        listpesanan.Items.Add("     Es Jeruk x" + jml + " = Rp." + sub);
        //        total += sub;
        //    }


        //    // Hitung subtotal, diskon, total akhir
        //    double subtotal = total;
        //    double diskon = 0;
        //    double totalAkhir = subtotal;


        //    //listpesanan.Items.Add($"Subtotal = Rp. {subtotal:N0}");
        //    txtsubtotal.Text = "Rp. " + subtotal.ToString("N0");

        //    if (subtotal >= 100000)
        //    {
        //        diskon = subtotal * 0.10;
        //        totalAkhir = subtotal - diskon;
        //        //listpesanan.Items.Add($"Diskon 10% = Rp. {diskon:N0}");
        //        txtdiskon.Text = "Rp. " + diskon.ToString("N0");
        //    }
        //    else
        //    {
        //        //listpesanan.Items.Add("Diskon = Rp. 0");
        //        txtdiskon.Text = "Rp. 0";
        //    }

        //    //listpesanan.Items.Add($"Total Bayar = Rp. {totalAkhir:N0}");
        //    Total.Text = "Rp. " + totalAkhir.ToString("N0");
        //    listpesanan.Items.Add("----------------------------------------------------");


        //}

    }

        //private void checkBox3_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

