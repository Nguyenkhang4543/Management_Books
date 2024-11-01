using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;

namespace Management_Books
{
    public partial class SoCatCable : System.Web.UI.Page
    {
        ThaoTacDuLieu SQLhelper = new ThaoTacDuLieu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MaNV"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblTenDanhNhap.Text = convertToUnSign3(Session["Ten"].ToString());
                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    //Load_Gridview();
                    btnSearch_Click(null, null);
                    lblID.Text = null;

                }
            }
        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        private void MsgBox(string sMessage)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert(\"" + sMessage.Replace("\r\n", "") + "\");", true);
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFromDate.Text.ToString()) && !string.IsNullOrEmpty(txtToDate.Text.ToString()))
            {
                DateTime Tu = DateTime.Parse(txtFromDate.Text.ToString()) + new TimeSpan(0, 0, 0);
                DateTime Den = DateTime.Parse(txtToDate.Text.ToString()) + new TimeSpan(23, 59, 0);
                string LotNL = "";
                LotNL = txtLotNL_Search.Text.ToString().Trim();
                SqlParameter[] para = new SqlParameter[]
                                  {
                                    new SqlParameter("@Tu", Tu),
                                    new SqlParameter("@Den", Den),
                                    new SqlParameter("@Lot_NL", LotNL),
                                    new SqlParameter("@MaBP",Session["BoPhan"].ToString()),
                                    new SqlParameter("@Factory",Session["Factory"].ToString()),
                                    new SqlParameter("@Quyen",Session["Quyen"].ToString() )
                                  };
                DataTable dt = SQLhelper.GetDataToTable("Books_LineCut_Get_ALL_SoCatCable", para);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblLotNL")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblLotDoan")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblNgayCat")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblLotCat")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblSanPham")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblKichThuocCat")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblSoDon")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblSoDoan")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblLeaderXacNhan")).Text)
                        
                         )
                    {
                        GridView1.Rows[i].BackColor = Color.FromArgb(1, 255, 255, 153);
                    }
                }
            }
            else MsgBox("Vui lòng chọn ngày cần tìm kiếm");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            int id = int.Parse(GridView1.DataKeys[rowIndex].Values[0].ToString());
            DataTable dt = SQLhelper.GetDataToTable("Books_LineCut_Get_SoCatCable_By_ID", new SqlParameter("@ID", id));
            if (dt.Rows.Count > 0)
            {
                txtLotNL.Text = dt.Rows[0].Field<string>("LOT_NL");
                txtDoan.Text = dt.Rows[0].Field<string>("LOT_Doan");
                txtNgayCat.Text = dt.Rows[0].Field<string>("NGAYCAT");
                txtLotCat.Text = dt.Rows[0].Field<string>("LOT_Cat");
                txtSanPham.Text = dt.Rows[0].Field<string>("SanPham");
                txtKichThuocCat.Text = dt.Rows[0].Field<string>("KichThuocCat");
                txtSoDon.Text = dt.Rows[0].Field<string>("So_Don");
                txtSoDoan.Text = dt.Rows[0].Field<string>("So_Doan");
                txtLeaderXacNhan.Text = dt.Rows[0].Field<string>("Leader_XacNhan");
                hdfID.Value = id.ToString();
                if (!string.IsNullOrEmpty(txtLotNL.Text)
                        && !string.IsNullOrEmpty(txtDoan.Text)
                        && !string.IsNullOrEmpty(txtNgayCat.Text)
                        && !string.IsNullOrEmpty(txtLotCat.Text)
                        && !string.IsNullOrEmpty(txtSanPham.Text)
                        && !string.IsNullOrEmpty(txtKichThuocCat.Text)
                        && !string.IsNullOrEmpty(txtSoDon.Text)
                        && !string.IsNullOrEmpty(txtSoDoan.Text)
                        && !string.IsNullOrEmpty(txtLeaderXacNhan.Text)
                         )
                {
                    Enable_field(false);
                }
                else
                {
                    Enable_field();
                }
            }

        }
        private void Enable_field(bool flag = true)
        {
            txtLotNL.Enabled = flag;
            txtDoan.Enabled = flag;
            txtNgayCat.Enabled = flag;
            txtLotCat.Enabled = flag;
            txtSanPham.Enabled = flag;
            txtKichThuocCat.Enabled = flag;
            txtSoDon.Enabled = flag;
            txtSoDoan.Enabled = flag;
            txtLeaderXacNhan.Enabled = flag;
        }
        private bool CheckData()
        {
            bool kq = true;
            if (string.IsNullOrEmpty(txtLotNL.Text) || string.IsNullOrEmpty(txtDoan.Text) || string.IsNullOrEmpty(txtNgayCat.Text) || string.IsNullOrEmpty(txtSanPham.Text) || string.IsNullOrEmpty(txtKichThuocCat.Text)
              || string.IsNullOrEmpty(txtSoDon.Text) || string.IsNullOrEmpty(txtSoDoan.Text))
            {
                kq = false;
            }

            if (kq == false)
            {
                MsgBox("Vui lòng nhập đầy đủ thông tin");
            }
            return kq;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int insert = 0;
            string ID = string.IsNullOrEmpty(hdfID.Value) ? null : hdfID.Value;
            if (CheckData() == true)
            {
                insert = SQLhelper.ExecuteNonQuery("Books_LineCut_Insert_SoCatCable", new SqlParameter[]
                {
                        new SqlParameter("@ID", ID),
                        new SqlParameter("@LOT_NL", txtLotNL.Text.Trim()),
                        new SqlParameter("@LOT_Doan", txtDoan.Text.Trim()),
                        new SqlParameter("@NGAYCAT", txtNgayCat.Text.Trim()),
                        new SqlParameter("@LOT_Cat", txtLotCat.Text.Trim()),
                        new SqlParameter("@SanPham", txtSanPham.Text.Trim()),
                        new SqlParameter("@KichThuocCat", txtKichThuocCat.Text.Trim()),
                        new SqlParameter("@So_Don", txtSoDon.Text.Trim()),
                        new SqlParameter("@So_Doan", txtSoDoan.Text.Trim()),
                        new SqlParameter("@Leader_XacNhan", txtLeaderXacNhan.Text.Trim()),
                        new SqlParameter("@MaBP", Session["BoPhan"].ToString()),
                        new SqlParameter("@Fatory", Session["Factory"].ToString()),
                        new SqlParameter("@NgayGhiNhan", DateTime.Now.ToString()),
                        new SqlParameter("@NguoiGhiNhan", Session["Ten"].ToString()),
                });
                MsgBox("Lưu dữ liệu thành công");
                ResetData();
                Enable_field();
                btnSearch_Click(null, null);
                lblID.Text = null;
              
            }
        }

        private void ResetData()
        {
            txtLotNL.Text = "";
            txtDoan.Text = "";
            txtNgayCat.Text = "";
            txtLotCat.Text = "";
            txtSanPham.Text = "";
            txtKichThuocCat.Text = "";
            txtSoDon.Text = "";
            txtSoDoan.Text = "";
            txtLeaderXacNhan.Text = "";
            hdfID.Value = "";
        }
    }
}