using BusinessLayer;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FormaClanovi : Form
    {
        private readonly ClanoviBusiness clanoviBusiness;
        public FormaClanovi()
        {
            this.clanoviBusiness = new ClanoviBusiness();
            InitializeComponent();
        }

        private void FormaClanovi_Load(object sender, EventArgs e)
        {
            RefreshData();  
        }

        private void RefreshData()
        {
            List<Clanovi> listaDece = this.clanoviBusiness.GetAllMember();
            dataGridView_Clanovi.DataSource = listaDece;
        }

        private void button_Dodaj_Click(object sender, EventArgs e)
        {
            if (textBox_ime.Text == "" || textBox_prezime.Text == "" || textBox_broj_telefona.Text == "" || textBox_datum_uclanjenja.Text == "")
            {
                MessageBox.Show("Morate popuniti sva polja!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!Regex.Match(textBox_ime.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                MessageBox.Show("Naziv nije pravilno unet!", "Message",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.Match(textBox_prezime.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                MessageBox.Show("Prezime nije pravilno uneto!", "Message",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.Match(textBox_broj_telefona.Text, @"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$").Success)
            {
                MessageBox.Show("Broj telefona nije pravilno unet!", "Message",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.Match(textBox_datum_uclanjenja.Text, @"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$").Success)
            {
                MessageBox.Show("Datum uclanjenja nije pravilno unet!", "Message",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            

            Clanovi c = new Clanovi();
            c.ime = textBox_ime.Text;
            c.prezime = textBox_prezime.Text;
            c.broj_telefona = textBox_broj_telefona.Text;
            c.datum_uclanjenja = textBox_datum_uclanjenja.Text;




            if (this.clanoviBusiness.InsertMember(c))             
            {
                RefreshData();
                MessageBox.Show("Uspesno ste uneli podatke! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_ime.Clear();
                textBox_prezime.Clear();
                textBox_broj_telefona.Clear();
                textBox_datum_uclanjenja.Clear();
              
            }
            else
            {
                MessageBox.Show("Neuspesan unos podataka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int ID; 
        private void dataGridView_Clanovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView_Clanovi.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox_ime.Text = dataGridView_Clanovi.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox_prezime.Text = dataGridView_Clanovi.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox_broj_telefona.Text = dataGridView_Clanovi.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox_datum_uclanjenja.Text = dataGridView_Clanovi.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }

        private void button_Izmeni_Click(object sender, EventArgs e)
        {
            if (textBox_ime.Text == "" || textBox_prezime.Text == "" || textBox_broj_telefona.Text == "" || textBox_datum_uclanjenja.Text == "")
            {
                MessageBox.Show("Morate popuniti sva polja!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_ime.Focus();
                return;
            }

            if (!Regex.Match(textBox_ime.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                MessageBox.Show("Naziv nije pravilno unet!", "Message",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.Match(textBox_prezime.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                MessageBox.Show("Prezime nije pravilno uneto!", "Message",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            Clanovi c = new Clanovi();
            c.ime = textBox_ime.Text;
            c.prezime = textBox_prezime.Text;
            c.broj_telefona = textBox_broj_telefona.Text;
            c.datum_uclanjenja = textBox_datum_uclanjenja.Text;

            c.id_clana = ID;

           
            if (textBox_update.Text == "")
            {
                MessageBox.Show("Morate uneti ID deteta koje zelite da izmenite!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            c.id_clana = Convert.ToInt32(textBox_update.Text);

            if (this.clanoviBusiness.UpdateMember(c))
            {
                RefreshData();
                MessageBox.Show("Uspesno ste izmenili podatak! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Niste izmenili podatak!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Obrisi_Click(object sender, EventArgs e)
        {
            if (textBox_delete.Text == "")
            {
                MessageBox.Show("Morate uneti ID clana koje zelite da obrisete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Clanovi c = new Clanovi();

            c.id_clana = Convert.ToInt32(textBox_delete.Text);

            if (this.clanoviBusiness.DeleteMember(c))
            {
                RefreshData();
                MessageBox.Show("Uspesno ste obrisali podatak! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Niste obrisali podatak!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sign_out_Click(object sender, EventArgs e)
        {
            FormaClanovi formadeca = new FormaClanovi();
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
