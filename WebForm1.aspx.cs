using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace asprevproject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dt;

        string connectionString = "Data Source=DESKTOP-L5DGAO5;User ID=sa;Password=Vijaya@123;Initial Catalog=genic";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                
            }
        }

        protected void BindGridView()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L5DGAO5;User ID=sa;Password=Vijaya@123;Initial Catalog=genic");
            {
                string query = "SELECT * FROM employee22";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
       
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string firstName = tb1.Text;
            string lastName = tb2.Text;
            string gender = rblGender.SelectedValue;
            string email = tb3.Text;
            string mobile = tb4.Text;
            string dob = tb6.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mobile)  )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please fill in all required fields.');", true);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO employee22  (FirstName, LastName, Gender, Email, Mobile) VALUES (@FirstName, @LastName, @Gender, @Email, @Mobile)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Mobile", mobile);
                //command.Parameters.AddWithValue("@Dob", Dob);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Data inserted successfully
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Data added to the database.');", true);
                    
                    BindGridView();
                }
                else
                {
                    // Error occurred while inserting data
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Failed to insert data into the database.');", true);
                }
            }

            // Clear the form fields
            ClearFields();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string empno = tb5.Text;
            string firstName = tb1.Text;
            string lastName = tb2.Text;
            string gender = rblGender.SelectedValue;
            string email = tb3.Text;
            string mobile = tb4.Text;
            string dob = tb6.Text;

            string query = "DELETE FROM employee22 WHERE empno=" + empno ;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        
                        
                       
                       
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                BindGridView();
                ClearFields();
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Employee details deleted successfully.');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
            }
           // btnDelete_Click.
        }
        
        private void ClearFields()
        {
            tb1.Text = string.Empty;
            tb2.Text = string.Empty;
            rblGender.ClearSelection();
            tb3.Text = string.Empty;
            tb4.Text = string.Empty;
            tb6.Text = string.Empty;
        }
    }
}
