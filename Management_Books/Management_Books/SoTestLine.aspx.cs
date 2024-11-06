using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace Management_Books
{
    public partial class SoTestLine : System.Web.UI.Page
    {
        ThaoTacDuLieu SQLhelper = new ThaoTacDuLieu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string MaNV = Session["MaNV"].ToString();
                DataTable dt = new DataTable();
                dt = SQLhelper.GetDataToTable("Check_PhanQuyen_TheoSo", new SqlParameter[] {
                    new SqlParameter("@MaNV", MaNV)
                });

                if (dt.Rows.Count > 0)
                {
                    string maSo = dt.Rows[0]["Ma_So"].ToString();
                    bool allbooks = Convert.ToBoolean(dt.Rows[0]["ALL_Books"]);

                    if (allbooks)
                    {
                        // Cho Phép Đăng Nhập Với Quyền Admin
                    }
                    else if (maSo == "3")
                    {
                        // Cho Phép Đăng Nhập Với Quyền Thao Tác Sổ
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                if (Session["MaNV"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblTenDanhNhap.Text = convertToUnSign3(Session["Ten"].ToString());
                    Load_Gridview();
                }
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["MaNV"] = null;
            Session["Quyen"] = null;
            Session["Ten"] = null;
            Session["BoPhan"] = null;
            Session["Factory"] = null;
            Response.Redirect("Login.aspx");
        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        private void MsgBox(string sMessage)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert(\"" + sMessage.Replace("\r\n", "") + "\");", true);
        }
        private void Load_Gridview()
        {
            DataTable dt = new DataTable();
            dt = SQLhelper.GetDataToTable("Books_Kashime_Get_SoTestLine");
            if(dt.Rows.Count > 0)
            {
                GridView.DataSource = dt;
                GridView.DataBind();
            }
            else
            {
                MsgBox("Không Có Dữ Liệu");
            }
        }
    }
}