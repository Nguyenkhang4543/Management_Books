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
    public partial class SoCatCable : System.Web.UI.Page
    {
        ThaoTacDuLieu SQLhelper = new ThaoTacDuLieu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Load_Gridview();
            }
           
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        private void Load_Gridview()
        {
            DataTable dt = new DataTable();
            dt = SQLhelper.GetDataToTable("Books_LineCut_Get_SoCatCable");
            if(dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}