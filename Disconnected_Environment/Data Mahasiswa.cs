using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected_Environment
{
    public partial class Data_Mahasiswa : Form
    {
        private string stringConnection = "data source=DESKTOP-1E9FTCI\\FAQOD;database=activity;User ID=sa;Password=123";
        private SqlConnection koneksi;
        private string nim, nama, alamat, jk, prodi;
        private DateTime tgl;
        BindingSource customersBindingSource = new BindingSource();

        private Data_Mahasiswa()
        {
            koneksi.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("Select m.nim, m.nama_mahasiswa," + "m.alamat, m.jenis_kel, m.tgl_lahir, p.nama_prodi Form dbo.Mahasiswa m" + "join dbo.Prodi p on m.id_prodi = p.id_prodi",koneksi));
            DataSet ds = DataSet();
            dataAdapter.Fill(ds);

            this.customersBindingSource.DataSource = ds.Tables[0];
            this.txtNIM.dataBindings.Add(
                new Binding("Text", this.customersBindingSource, "NIM", true));
            this.txtNama.dataBindings.Add(
                new Binding("Text", this.customersBindingSource, "nama_mahasiswa", true));
            this.txtAlamat.dataBindings.Add(
                new Binding("Text", this.customersBindingSource, "alamat", true));
            this.cbxJenisKelamin.DataBindings.Add(
                new Binding("Text", this.customersBindingSource, "jenis_kel", true));
            this.dtTanggalLahir.DataBindings.Add(
                new Binding("Text", this.customersBindingSource, "Tgl_lahir", true));
            this.cbxProdi.DataBindings.Add(
                new Binding("Text", this.customersBindingSource, "nama_prodi", true));
            koneksi.Close();
        }
        private void clearBinding()
        {
            this.txtNIM.DataBindings.Clear();
            this.txtNama.DataBindings.Clear();
            this.txtAlamat.DataBindings.Clear();
            this.cbxJenisKelamin.DataBindings.Clear();
            this.dtTanggalLahir.DataBindings.Clear();
            this.cbxProdi.DataBindings.Clear();
        }
        private  void refreshform()
        {
            txtNIM.Enabled = false;
            txtNama.Enabled = false;
            cbxJenisKelamin.Enabled = false;
            txtAlamat.Enabled = false;
            dtTanggalLahir.Enabled = false;
            cbxProdi.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            clearBinding();
            Data_Mahasiswa();
        }
        public Data_Mahasiswa()
        {
            InitializeComponent();
            koneksi = new SqlConnection(kstr);
            this.bnMahasiswa.BindingSource = this.customersBindingSource;
            refreshform();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
