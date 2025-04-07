using MySqlX.XDevAPI.Common;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadClient();
        }

        public void ReadClient() { 
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Név");
            dt.Columns.Add("Email");
            dt.Columns.Add("Telefonszám");
            dt.Columns.Add("Születési dátum");

            var data = new CRUD();
            var clients = data.GetClient();

            foreach (var client in clients) {
                var row = dt.NewRow();
                row["ID"] = client.id;
                row["Név"] = client.veznev + "" + client.kernev;
                row["Email"] = client.email;
                row["Telefonszám"] = client.telszam;
                row["Születési dátum"] = client.szuldatum;

                dt.Rows.Add(row);
            }
            this.dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientEdit cledit = new ClientEdit();
            cledit.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var val = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (val == null || val.Length == 0) return;

            int clientId = int.Parse(val);

            DialogResult result = MessageBox.Show("Biztos törölni szeretnéd?","Ügyfél törlése",MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            var data = new CRUD();
            data.DeleteClient(clientId);
            ReadClient();
        }
    }
}
