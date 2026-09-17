using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace WAPP
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string target = null;

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();

                    string query = "select count(*) from userTable where username = @username and password = @password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", pwd.Text);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        string query1 = "select fname, usertype from userTable where username = @username";
                        SqlCommand cmdType = new SqlCommand(query1, con);
                        cmdType.Parameters.AddWithValue("@username", username.Text);

                        string type = "";
                        string name = "";

                        using (SqlDataReader dr = cmdType.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                type = dr["usertype"].ToString().Trim();
                                name = dr["fname"].ToString().Trim();
                            }
                        }

                        Session["firstName"] = name;
                        Session["userName"] = username.Text;

                        if (type == "admin")
                            target = "adminDashboard.aspx";
                        else if (type == "member")
                            target = "memberDashboard.aspx";
                    }
                    else
                    {
                        errorMsg.Visible = true;
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                        errorMsg.Text = "Username and Password mismatch!";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg.Visible = true;
                errorMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Text = "Login not successful!" + ex.ToString();
                return;
            }

            //redirect outside the try block, otherwise the ThreadAbortException
            //raised by Response.Redirect is caught and shown as a failure
            if (target != null)
            {
                Response.Redirect(target);
            }
        }
    }
}
