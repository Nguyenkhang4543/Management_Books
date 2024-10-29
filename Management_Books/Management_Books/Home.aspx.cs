using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Management_Books
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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