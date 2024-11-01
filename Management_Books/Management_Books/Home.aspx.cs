using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

namespace Management_Books
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaNV"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblTenDanhNhap.Text = convertToUnSign3(Session["Ten"].ToString());

            }
        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }



        ///////////////////////////// Sổ Quản Lý Kashime /////////////////////////////////////////
        protected void btnSoThaoTac_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoThaoTac.aspx");
        }
        protected void btnSoTestLine_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoTestLine.aspx");
        }

        ///////////////////////////// Sổ Quản Lý Kashime /////////////////////////////////////////


        ///////////////////////////// Sổ Quản Lý Line Cut/////////////////////////////////////////
        protected void btnSoCatCable_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoCatCable.aspx");
        }

       
        ///////////////////////////// Sổ Quản Lý Kashime /////////////////////////////////////////

    }
}