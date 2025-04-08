using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSystem
{
    public partial class ClientEdit : Form
    {
        public ClientEdit()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }

        public int clientId = 0;
        public void FelhasznaloModosita(Client client)
        {

           

            this.Text = "Módosítás";
            this.textBox1.Text = client.veznev;
            this.textBox2.Text = client.kernev;
            this.textBox3.Text = client.email;
            this.textBox4.Text = client.telszam;           
            this.textBox5.Text = Convert.ToString(client.szuldatum);

            this.clientId = client.id;
            var data = new CRUD();
            data.UpdateClient(client);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();

            client.veznev= this.textBox1.Text;
            client.kernev = this.textBox2.Text;
            client.email = this.textBox3.Text;
            client.telszam = this.textBox4.Text;
            client.szuldatum = Convert.ToDateTime(this.textBox5.Text);

            var data = new CRUD();
            data.CreateClient(client);
            MessageBox.Show("Az adatok hozzá lettek adva az adatbázishoz!");
        }
    }
}
