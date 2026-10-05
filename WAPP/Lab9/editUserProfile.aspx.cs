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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("select * from userTable where username = '" +
                                                       Session["userName"] + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return;
                }

                fname.Text = dt.Rows[0][1].ToString();
                lname.Text = dt.Rows[0][2].ToString();
                gender.SelectedItem.Text = dt.Rows[0][3].ToString();
                country.Text = dt.Rows[0][4].ToString();
                email.Text = dt.Rows[0][5].ToString();
                pwd.Text = dt.Rows[0][7].ToString();
                Image1.ImageUrl = dt.Rows[0][9].ToString();
                img.Text = dt.Rows[0][9].ToString();
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
                cmd.Parameters.AddWithValue("@username", Convert.ToString(Session["userName"]));
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
