using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSystem
{
    internal class CRUD
    {
        public static string connection = "server=localhost;database=ugyfelek;user=root;password=;";

        public List<Client> GetClient() {

            var clients = new List <Client>();

            try {

                using (MySqlConnection conn = new MySqlConnection(connection)) {
                    conn.Open();
                    string query = "SELECT * FROM ugyfel";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                Client client = new Client();
                                client.id = reader.GetInt32("id");
                                client.veznev = reader.GetString("veznev");
                                client.kernev = reader.GetString("kernev");
                                client.email = reader.GetString("email");
                                client.telszam = reader.GetString("telszam");
                                client.szuldatum = reader.GetDateTime("szuldatum");
                                clients.Add(client);                            
                           
                            }                        
                        
                        }
                    }
                
                }

            } 
            catch(Exception ex) {
                MessageBox.Show("Hiba történt" + ex.Message);
            }
            return clients;
        
        }

        public void CreateClient(Client client) {

            try {
                using (MySqlConnection conn = new MySqlConnection(connection)) {
                    conn.Open();
                    string query = "INSERT INTO ugyfel (veznev,kernev,email,telszam,szuldatum) VALUES (@veznev,@kernev,@email,@telszam,@szuldatum)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@veznev",client.veznev);
                        cmd.Parameters.AddWithValue("@kernev",client.kernev);
                        cmd.Parameters.AddWithValue("@email", client.email);
                        cmd.Parameters.AddWithValue("@telszam", client.telszam);
                        cmd.Parameters.AddWithValue("@szuldatum", client.szuldatum);
                        cmd.ExecuteNonQuery();
                    }
                }
            } 
            catch (Exception ex) {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        
        }

        public Client GetClient(int id) {
            try {
                using (MySqlConnection conn = new MySqlConnection(connection)) {
                    conn.Open();
                    string query = "SELECT * FROM ugyfel WHERE id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(query,conn)) {
                        cmd.Parameters.AddWithValue("@id",id);

                        using (MySqlDataReader reader = cmd.ExecuteReader()) { 

                            reader.Read();
                            Client client = new Client();

                            client.id = reader.GetInt32("id");
                            client.veznev = reader.GetString("veznev");
                            client.kernev = reader.GetString("kernev");
                            client.email = reader.GetString("email");
                            client.telszam = reader.GetString("telszam");
                            client.szuldatum = reader.GetDateTime("szuldatum");
                            return client;                        
                        } 
                       
                    }               
                }           
            } 
            catch (Exception ex) {
                MessageBox.Show("Hiba történt" + ex.Message);
            }
            return null;
        }

        public void DeleteClient(int id) {
            try {

                using (MySqlConnection conn = new MySqlConnection(connection)) {
                    conn.Open();
                    string query = "DELETE FROM ugyfel WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@id",id);
                        cmd.ExecuteNonQuery();
                    }
                
                }
            
            }                                    
            catch (Exception ex) {
                MessageBox.Show("Hiba" + ex.Message);
            }
        
        }

        public void UpdateClient(Client client) {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection)) {
                    conn.Open();
                    string query = "UPDATE ugyfel SET veznev=@veznev,kernev=@kernev,email=@email,telszam=@telszam,szuldate=@szuldate WHERE id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(query,conn)) {
                        cmd.Parameters.AddWithValue("@veznev",client.veznev);
                        cmd.Parameters.AddWithValue("@kernev", client.kernev);
                        cmd.Parameters.AddWithValue("@email", client.email);
                        cmd.Parameters.AddWithValue("@szuldatum", client.szuldatum);
                        cmd.Parameters.AddWithValue("@id", client.id);
                        cmd.ExecuteNonQuery();
                    }

                }

            }
            catch (Exception ex) {
                MessageBox.Show("Hiba történt" + ex.Message);
            
            }
        
        }

    }
}
