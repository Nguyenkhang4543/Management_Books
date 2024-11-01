using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Management_Books
{
    public partial class Login : System.Web.UI.Page
    {
        ThaoTacDuLieu SQLhelper = new ThaoTacDuLieu();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string a = SQLhelper.Encrypt("Web_NEV", txtPassword.Text.ToString().Trim());
            SqlParameter[] arrParam = {
                  new SqlParameter("@TenDangNhap",txtUserName.Text.ToString().Trim()),
                  new SqlParameter("@MatKhau", a /*SQLhelper.Encrypt("Web_NEV",txtPassword.Text.ToString().Trim())*/),
                  //new SqlParameter("@MatKhau", "JiKEb/lUQ1uryZ8j5ESdlA=="),//Test
                  new SqlParameter("@ChuongTrinh","42")
                  };
            DataTable dtb = SQLhelper.ExecuteDataTable("Check_DangNhap", arrParam);
            if (dtb.Rows.Count > 0)
            {
                Session["MaNV"] = txtUserName.Text.ToString().ToUpper();
                Session["Quyen"] = dtb.Rows[0][2].ToString();
                Session["Ten"] = dtb.Rows[0][1].ToString();
                Session["BoPhan"] = dtb.Rows[0][3].ToString();
                Session["Factory"] = dtb.Rows[0][4].ToString();
                if (Session["URL"] != null)
                {
                    Response.Redirect(Session["URL"].ToString());
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert('Error; You are not authorized to login.');", true);
                return;
            }
        }
    }
}