using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAPP
{
    public partial class memberDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["firstName"] != null)
            {
                uname.Text = "Hi," + Session["firstName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Clear();
            Response.Redirect("login.aspx");
        }
    }
}
