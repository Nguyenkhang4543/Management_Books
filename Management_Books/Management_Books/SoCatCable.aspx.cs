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
        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["MaNV"] = null;
            Session["Quyen"] = null;
            Session["Ten"] = null;
            Session["BoPhan"] = null;
            Session["Factory"] = null;
            Response.Redirect("Login.aspx");
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
                string MaSP = "";
                MaSP = txtLotNL_Search.Text.ToString().Trim();
                SqlParameter[] para = new SqlParameter[]
                                  {
                                    new SqlParameter("@Tu", Tu),
                                    new SqlParameter("@Den", Den),
                                    new SqlParameter("@MaSP", MaSP),
                                    new SqlParameter("@MaBP",Session["BoPhan"].ToString()),
                                    new SqlParameter("@Factory",Session["Factory"].ToString()),
                                    new SqlParameter("@Quyen",Session["Quyen"].ToString() )
                                  };
                DataTable dt = SQLhelper.GetDataToTable("Books_LineCut_1_1_Get_ALL_SoCatCable", para);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblNgayCat")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblMaSanPham")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblLotNL")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblLotTp")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblSanPham")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblLineSX")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblBanVe")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblKichThuocBanVe")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblKichThuocThucTe")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblMayCat")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblSoDon")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblSoDoan")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblSoLuongSD")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblNguoiThaoTac")).Text)
                        || string.IsNullOrEmpty(((Label)GridView1.Rows[i].FindControl("lblLeaderXacNhan")).Text)
                        
                         )
                    {
                        GridView1.Rows[i].BackColor = Color.FromArgb(248, 255, 66);
                    }
                    else
                    {
                        GridView1.Rows[i].BackColor = Color.FromArgb(224, 255, 250);
                    }
                }
            }
            else MsgBox("Vui lòng chọn ngày cần tìm kiếm");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            int id = int.Parse(GridView1.DataKeys[rowIndex].Values[0].ToString());
            DataTable dt = SQLhelper.GetDataToTable("Books_LineCut_1_1_Get_SoCatCable_By_ID", new SqlParameter("@ID", id));
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0].Field<DateTime?>("NgayCatCable"))))
                {
                    txtNgayCatCable.Text = dt.Rows[0].Field<DateTime>("NgayCatCable").ToString("yyyy-MM-dd") ?? string.Empty;
                }
                txtMaSP.Text = dt.Rows[0].Field<string>("MaSP");
                txtLotNguyenLieu.Text = dt.Rows[0].Field<string>("LotNguyenLieu");
                txtLotThanhPham.Text = dt.Rows[0].Field<string>("LotThanhPham");
                txtTenSanPham.Text = dt.Rows[0].Field<string>("TenSanPham");
                txtLineSanXuat.Text = dt.Rows[0].Field<string>("LineSanXuat");
                txtBanVe.Text = dt.Rows[0].Field<string>("BanVe");
                txtKTBanVe.Text = dt.Rows[0].Field<string>("KichThuocBanVe");
                txtKTThucTe.Text = dt.Rows[0].Field<string>("KichThuocThucTe");
                txtMayCat.Text = dt.Rows[0].Field<string>("MayCat");
                txtSoDonNew.Text = dt.Rows[0].Field<string>("SoDon");
                txtSoDoanNew.Text = dt.Rows[0].Field<string>("SoDoan");
                txtSoLuong.Text = dt.Rows[0].Field<string>("SoLuong");
                txtNguoiThaoTac.Text = dt.Rows[0].Field<string>("NguoiThaoTac");
                txtLeader.Text = dt.Rows[0].Field<string>("LeaderXacNhan");
                txtGhiChu.Text = dt.Rows[0].Field<string>("GhiChu");
                
                hdfID1.Value = id.ToString();
                if (string.IsNullOrEmpty(txtLeader.Text))
                {
                    Enable_field();
                }
                else
                {
                    Enable();
                }
            }
        }
        private void Enable_field(bool flag = true)
        {
            txtMaSP.Enabled = flag;
            txtLotNguyenLieu.Enabled = flag;
            txtLotThanhPham.Enabled = flag;
            txtTenSanPham.Enabled = flag;
            txtLineSanXuat.Enabled = flag;
            txtBanVe.Enabled = flag;
            txtKTBanVe.Enabled = flag;
            txtKTThucTe.Enabled = flag;
            txtMayCat.Enabled = flag;
            txtSoDonNew.Enabled = flag;
            txtSoDoanNew.Enabled = flag;
            txtSoLuong.Enabled = flag;
            txtNguoiThaoTac.Enabled = flag;
            txtLeader.Enabled = flag;
            txtGhiChu.Enabled = flag;
        }
        private void Enable()
        {
            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtNgayCatCable.Text))
            {
                txtNgayCatCable.Enabled = true;
            }
            else
            {
                txtNgayCatCable.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtMaSP.Text))
            {
                txtMaSP.Enabled = true;
            }
            else
            {
                txtMaSP.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtLotNguyenLieu.Text))
            {
                txtLotNguyenLieu.Enabled = true;
            }
            else
            {
                txtLotNguyenLieu.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtLotThanhPham.Text))
            {
                txtLotThanhPham.Enabled = true;
            }
            else
            {
                txtLotThanhPham.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                txtTenSanPham.Enabled = true;
            }
            else
            {
                txtTenSanPham.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtLineSanXuat.Text))
            {
                txtLineSanXuat.Enabled = true;
            }
            else
            {
                txtLineSanXuat.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtBanVe.Text))
            {
                txtBanVe.Enabled = true;
            }
            else
            {
                txtBanVe.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtKTBanVe.Text))
            {
                txtKTBanVe.Enabled = true;
            }
            else
            {
                txtKTBanVe.Enabled = false;
            }
            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtKTThucTe.Text))
            {
                txtKTThucTe.Enabled = true;
            }
            else
            {
                txtKTThucTe.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtMayCat.Text))
            {
                txtMayCat.Enabled = true;
            }
            else
            {
                txtMayCat.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtSoDonNew.Text))
            {
                txtSoDonNew.Enabled = true;
            }
            else
            {
                txtSoDonNew.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtSoDoanNew.Text))
            {
                txtSoDoanNew.Enabled = true;
            }
            else
            {
                txtSoDoanNew.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtSoLuong.Text))
            {
                txtSoLuong.Enabled = true;
            }
            else
            {
                txtSoLuong.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtNguoiThaoTac.Text))
            {
                txtNguoiThaoTac.Enabled = true;
            }
            else
            {
                txtNguoiThaoTac.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtLeader.Text))
            {
                txtLeader.Enabled = true;
            }
            else
            {
                txtLeader.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(txtGhiChu.Text))
            {
                txtGhiChu.Enabled = true;
            }
            else
            {
                txtGhiChu.Enabled = false;
            }
            /////////////////////////////////////////////////
        }
        private bool CheckData()
        {
            bool kq = true;
            if (string.IsNullOrEmpty(txtNgayCatCable.Text) || string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtLotNguyenLieu.Text) || string.IsNullOrEmpty(txtLotThanhPham.Text) || string.IsNullOrEmpty(txtKTBanVe.Text))
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
            string ID = string.IsNullOrEmpty(hdfID1.Value) ? null : hdfID1.Value;
            if (CheckData() == true)
            {
                insert = SQLhelper.ExecuteNonQuery("Books_LineCut_1_1_Insert_SoCatCable", new SqlParameter[]
                {
                        new SqlParameter("@ID", ID),
                        new SqlParameter("@NgayCatCable", txtNgayCatCable.Text.Trim()),
                        new SqlParameter("@MaSP", txtMaSP.Text.Trim()),
                        new SqlParameter("@LotNguyenLieu", txtLotNguyenLieu.Text.Trim()),
                        new SqlParameter("@LotThanhPham", txtLotThanhPham.Text.Trim()),
                        new SqlParameter("@TenSanPham", txtTenSanPham.Text.Trim()),
                        new SqlParameter("@LineSanXuat", txtLineSanXuat.Text.Trim()),
                        new SqlParameter("@BanVe", txtBanVe.Text.Trim()),
                        new SqlParameter("@KichThuocBanVe", txtKTBanVe.Text.Trim()),
                        new SqlParameter("@KichThuocThucTe", txtKTThucTe.Text.Trim()),
                        new SqlParameter("@MayCat",txtMayCat.Text.Trim()),
                        new SqlParameter("@SoDon",txtSoDonNew.Text.Trim()),
                        new SqlParameter("@SoDoan",txtSoDoanNew.Text.Trim()),
                        new SqlParameter("@SoLuong",txtSoLuong.Text.Trim()),
                        new SqlParameter("@NguoiThaoTac",txtNguoiThaoTac.Text.Trim()),
                        new SqlParameter("@LeaderXacNhan", txtLeader.Text.Trim()),
                        new SqlParameter("@GhiChu",txtGhiChu.Text.Trim()),
                        new SqlParameter("@NguoiTaoPhieu", Session["Ten"].ToString()),
                        new SqlParameter("@NgayTaoPhieu", DateTime.Now.ToString()),
                        new SqlParameter("@BoPhan", Session["BoPhan"].ToString()),
                        new SqlParameter("@Factory", Session["Factory"].ToString()),
                });
                if(insert > 0)
                {
                    MsgBox("Lưu Dữ Liệu Thành Công");
                    ResetData();
                    Enable_field();
                    btnSearch_Click(null, null);
                    lblID.Text = null;
                }
                else
                {
                    MsgBox("Lưu Dữ Liệu Không Thành Công!");
                }
               
              
            }
        }

        private void ResetData()
        {
            txtNgayCatCable.Text = "";
            txtMaSP.Text = "";
            txtLotNguyenLieu.Text = "";
            txtLotThanhPham.Text = "";
            txtTenSanPham.Text = "";
            txtLineSanXuat.Text = "";
            txtBanVe.Text = "";
            txtKTBanVe.Text = "";
            txtKTThucTe.Text = "";
            txtMayCat.Text = "";
            txtSoDonNew.Text = "";
            txtSoDoanNew.Text = "";
            txtSoLuong.Text = "";
            txtNguoiThaoTac.Text = "";
            txtLeader.Text = "";
            txtGhiChu.Text = "";
            hdfID1.Value = "";
        }
    }
}