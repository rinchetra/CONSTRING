using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONSTRING
{
    public partial class ConString : Form
    {
        public ConString()
        {
            InitializeComponent();
        }

        private void ConString_Load(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection connection = new SqlConnection(constring);
            
            try
            {
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TblUser;", connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvConSring.DataSource = dt;
                MessageBox.Show("Connection Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed");
            }
        }
    }
}
