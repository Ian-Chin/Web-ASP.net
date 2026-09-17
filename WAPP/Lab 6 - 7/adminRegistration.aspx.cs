using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace WAPP
{
    public partial class adminRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool registered = false;

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();

                    string query = "select count(*) from userTable where username = @username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check > 0)
                    {
                        errMsg.Visible = true;
                        errMsg.ForeColor = System.Drawing.Color.Red;
                        errMsg.Text = "Username has been taken!";
                    }
                    else
                    {
                        //create record in a table called userTable
                        string query1 = "insert into userTable (fname, lname, gender, country, email, username, " +
                                        "password, usertype) values (@firstName, @lastName, @gender, @country, " +
                                        "@email, @username, @password, @usertype) ";
                        SqlCommand cmd1 = new SqlCommand(query1, con);

                        cmd1.Parameters.AddWithValue("@firstName", fname.Text);
                        cmd1.Parameters.AddWithValue("@lastName", lname.Text);
                        cmd1.Parameters.AddWithValue("@gender", gender.SelectedItem.ToString());
                        cmd1.Parameters.AddWithValue("@country", country.Text);
                        cmd1.Parameters.AddWithValue("@email", email.Text);
                        cmd1.Parameters.AddWithValue("@username", username.Text);
                        cmd1.Parameters.AddWithValue("@password", pwd.Text);
                        cmd1.Parameters.AddWithValue("@usertype", usertype.Text);
                        cmd1.ExecuteNonQuery();
                        registered = true;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ForeColor = System.Drawing.Color.Red;
                errMsg.Text = "Registration not sucessful!" + ex.ToString();
                return;
            }

            //redirect outside the try block, otherwise the ThreadAbortException
            //raised by Response.Redirect is caught and shown as a failure
            if (registered)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}
