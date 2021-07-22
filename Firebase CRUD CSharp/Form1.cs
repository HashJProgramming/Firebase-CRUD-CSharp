using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Firebase_CRUD_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        IFirebaseConfig firebaseConnection = new FirebaseConfig()
        {
            // Check https://console.firebase.google.com
            AuthSecret = "Database Secret here",
            BasePath = "Database PATH here"

        };
        IFirebaseClient firebaseClient;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                firebaseClient = new FireSharp.FirebaseClient(firebaseConnection);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect to the database");
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Insert Data to the Google Firebase Database HashJProgramming
            DatabaseUserInfo db = new DatabaseUserInfo()
            {
                fullname = textBox1.Text,
                idnumber = textBox2.Text,
                email = textBox3.Text,
                message = textBox4.Text
            };
            var dbset = firebaseClient.Set("Users/"+ textBox2.Text, db);
            MessageBox.Show("Done!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get Data to the Google Firebase Database HashJProgramming
            var dbget = firebaseClient.Get("Users/"+textBox5.Text);
            DatabaseUserInfo dbread = dbget.ResultAs<DatabaseUserInfo>();
            textBox1.Text = dbread.fullname;
            textBox2.Text = dbread.idnumber;
            textBox3.Text = dbread.email;
            textBox4.Text = dbread.message;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Update Data to the Google Firebase Database HashJProgramming
            DatabaseUserInfo db = new DatabaseUserInfo()
            {
                fullname = textBox1.Text,
                idnumber = textBox2.Text,
                email = textBox3.Text,
                message = textBox4.Text
            };
            var dbset = firebaseClient.Update("Users/" + textBox2.Text, db);
            MessageBox.Show("Done!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Update Data to the Google Firebase Database HashJProgramming
            var dbdelete = firebaseClient.Delete("Users/" + textBox3.Text);
            MessageBox.Show("Done!");
        }
    }
}
