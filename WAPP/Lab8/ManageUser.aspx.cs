using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WAPP.Lab8
{
    public partial class ManageUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["firstName"] != null)
            {
                svfName.Text = "Hi, " + Session["firstName"].ToString();
            }
            else
            {
                Response.Redirect("~/Lab 6 - 7/login.aspx");
            }

            if (!Page.IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from userTable where usertype = @usertype", con);
                    da.SelectCommand.Parameters.AddWithValue("@usertype", usertype.Text);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    uname.DataSource = dt;
                    uname.DataTextField = "username";
                    uname.DataBind();
                }

                //the first user is selected by default, so SelectedIndexChanged
                //never fires for it; load its record up front
                if (uname.Items.Count > 0)
                {
                    LoadRecord();
                }
            }
        }

        protected void uname_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void LoadRecord()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from userTable where username = @username", con);
                da.SelectCommand.Parameters.AddWithValue("@username", uname.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return;
                }

                DataRow row = dt.Rows[0];
                fname.Text = row["fname"].ToString().Trim();
                lname.Text = row["lname"].ToString().Trim();
                //select the matching item instead of overwriting the selected
                //item's text (that caused the "M, M" list in Figure 5)
                ListItem g = gender.Items.FindByValue(row["gender"].ToString().Trim());
                if (g != null)
                {
                    gender.ClearSelection();
                    g.Selected = true;
                }
                country.Text = row["country"].ToString().Trim();
                email.Text = row["email"].ToString().Trim();
                pwd.Text = row["password"].ToString().Trim();
            }
        }

        protected void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Figure 8: make sure "F" is always available in the list
            if (gender.Items.FindByValue("F") == null)
            {
                ListItem li = new ListItem();
                li.Text = "F";
                li.Value = "F";
                gender.Items.Add(li);
            }
        }

        //Save: update the selected member's record
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "update userTable set fname = @fname, lname = @lname, gender = @gender, country = @country, "
                             + "email = @email, password = @password, usertype = @usertype where username = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fname", fname.Text);
                cmd.Parameters.AddWithValue("@lname", lname.Text);
                cmd.Parameters.AddWithValue("@gender", gender.Text);
                cmd.Parameters.AddWithValue("@country", country.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@password", pwd.Text);
                cmd.Parameters.AddWithValue("@usertype", usertype.Text);
                cmd.Parameters.AddWithValue("@username", uname.Text);
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("ManageUser.aspx");
        }

        //Remove: delete the selected member's record
        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "delete from userTable where username = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", uname.Text);
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("ManageUser.aspx");
        }
    }
}
