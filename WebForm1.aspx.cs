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
                string query = "SELECT * FROM Employee11";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }




        //protected void btnInsert_Click(object sender, EventArgs e)
        //{
        //    string firstName = tb1.Text;
        //    string lastName = tb2.Text;
        //    string gender = rblGender.SelectedValue;
        //    string email = tb3.Text;
        //    string mobile = tb4.Text;

        //    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mobile))
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please fill in all required fields.');", true);
        //        return;
        //    }

        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            string query = "INSERT INTO Employee11 (FirstName, LastName, Gender, Email, Mobile) VALUES (@FirstName, @LastName, @Gender, @Email, @Mobile)";
        //            using (SqlCommand cmd = new SqlCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("@FirstName", firstName);
        //                cmd.Parameters.AddWithValue("@LastName", lastName);
        //                cmd.Parameters.AddWithValue("@Gender", gender);
        //                cmd.Parameters.AddWithValue("@Email", email);
        //                cmd.Parameters.AddWithValue("@Mobile", mobile);
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //            }
        //        }

        //        BindGridView();
        //        ClearFields();
        //        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Employee details inserted successfully.');", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
        //    }
        //}

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string firstName = tb1.Text;
            string lastName = tb2.Text;
            string gender = rblGender.SelectedValue;
            string email = tb3.Text;
            string mobile = tb4.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mobile))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please fill in all required fields.');", true);
                return;
            }

            // Check if dt is initialized
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("FirstName", typeof(string));
                dt.Columns.Add("LastName", typeof(string));
                dt.Columns.Add("Gender", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Mobile", typeof(string));
            }

            // Create a new row for the DataTable
            DataRow newRow = dt.NewRow();
            newRow["FirstName"] = firstName;
            newRow["LastName"] = lastName;
            newRow["Gender"] = gender;
            newRow["Email"] = email;
            newRow["Mobile"] = mobile;

            // Add the new row to the DataTable
            dt.Rows.Add(newRow);

            // Bind the DataTable to the GridView to display the changes
            GridView1.DataSource = dt;
            GridView1.DataBind();

            // Clear the form fields
            ClearFields();

            // Show a message indicating that the data has been added to the DataTable
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Data added to the table.');", true);
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string firstName = tb1.Text;
            string lastName = tb2.Text;
            string gender = rblGender.SelectedValue;
            string email = tb3.Text;
            string mobile = tb4.Text;

            string query = "DELETE FROM Employee11 WHERE FirstName = @FirstName AND LastName = @LastName AND Gender = @Gender AND Email = @Email AND Mobile = @Mobile";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Mobile", mobile);
                        con.Open();
                        cmd.ExecuteNonQuery();
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
        }

        private void ClearFields()
        {
            tb1.Text = string.Empty;
            tb2.Text = string.Empty;
            rblGender.ClearSelection();
            tb3.Text = string.Empty;
            tb4.Text = string.Empty;
        }
    }
}
