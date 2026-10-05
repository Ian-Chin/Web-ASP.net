using System;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAPP.Lab9
{
    public partial class editUserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["firstName"] != null)
            {
                uname.Text = "Hi," + Session["firstName"].ToString();
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
                    SqlDataAdapter da = new SqlDataAdapter("select * from userTable where username = @username", con);
                    da.SelectCommand.Parameters.AddWithValue("@username", Session["userName"].ToString());
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        return;
                    }

                    DataRow row = dt.Rows[0];
                    fname.Text = row["fname"].ToString().Trim();
                    lname.Text = row["lname"].ToString().Trim();
                    //select the matching item instead of overwriting the selected item's text
                    ListItem g = gender.Items.FindByValue(row["gender"].ToString().Trim());
                    if (g != null)
                    {
                        gender.ClearSelection();
                        g.Selected = true;
                    }
                    country.Text = row["country"].ToString().Trim();
                    email.Text = row["email"].ToString().Trim();
                    pwd.Text = row["password"].ToString().Trim();
                    img.Text = row["photo"].ToString().Trim();
                    Image1.ImageUrl = img.Text;
                    //no photo yet, hide the broken image
                    Image1.Visible = img.Text != "";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //for file upload
            string folderPath = Server.MapPath("~/ProfilePic/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }

            string ImgPath = "";

            if (this.FileUpload1.HasFile) //to change profile picture
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                ImgPath = "~/ProfilePic/" + fileName;
                //saving the photo to the file directory
                FileUpload1.SaveAs(folderPath + fileName);
            }
            else
            {
                ImgPath = img.Text;
            }

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "update userTable set fname = @fname, lname = @lname, gender = @gender, country = @country, "
                             + "email = @email, password = @password, usertype = @usertype, photo = @photo where username = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fname", fname.Text);
                cmd.Parameters.AddWithValue("@lname", lname.Text);
                cmd.Parameters.AddWithValue("@gender", gender.Text);
                cmd.Parameters.AddWithValue("@country", country.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@password", pwd.Text);
                cmd.Parameters.AddWithValue("@usertype", usertype.Text);
                cmd.Parameters.AddWithValue("@photo", ImgPath);
                cmd.Parameters.AddWithValue("@username", Session["userName"].ToString());
                cmd.ExecuteNonQuery();
            }

            //keep the greeting in sync with the new first name
            Session["firstName"] = fname.Text;
            Response.Redirect("editUserProfile.aspx");
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();

            Response.Redirect("~/Lab 6 - 7/login.aspx");
        }
    }
}
