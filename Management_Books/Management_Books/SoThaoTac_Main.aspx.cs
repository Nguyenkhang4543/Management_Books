using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Drawing;
using System.Collections;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Web.DynamicData;


namespace Management_Books
{
    public partial class SoThaoTac_Main : System.Web.UI.Page
    {
        ThaoTacDuLieu SQLhelper = new ThaoTacDuLieu();
        int currPage = 1;
        int Total = 0;
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
                    lblCurrPage.Text = "1";
                    Load_Gridview();

                    if(Session["Quyen"].ToString() == "1")
                    {
                        btnadmin.Visible = true;
                    }
                    Load_GridView_PhanQuyen();
                    DataTable dt = new DataTable();
                    SqlParameter[] prams = new SqlParameter[] {
                                    new SqlParameter("@NoiDung","")};
                    dt = SQLhelper.GetDataToTable("Books_Kashime_SoThaoTac_SearchViewList", prams);
                    if (dt.Rows.Count > 0)
                    {
                        double a = dt.Rows.Count;
                        double tong = (a / 20);
                        lblTotal.Text = ((int)Math.Ceiling(tong)).ToString();
                        if (tong > 1)
                        {
                            btnLast.Enabled = true;
                            btnNext.Enabled = true;
                        }
                        else
                        {
                            btnLast.Enabled = false;
                            btnNext.Enabled = false;
                        }
                        btnPrevious.Enabled = false;
                        btnFirst.Enabled = false;
                    }
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
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            taskadmin.Visible = true;
            taskMain.Visible = false;
            btnadmin.Visible = false;
            btnHome.Visible = true;
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            taskadmin.Visible = false;
            taskMain.Visible = true;
            btnadmin.Visible = true;
            btnHome.Visible = false;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoThaoTac.aspx");
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
            dt = SQLhelper.GetDataToTable("Books_Kashime_SoThaoTac_SearchViewPage",new SqlParameter[] {
                 new SqlParameter("@PageNumber",currPage),
                 new SqlParameter("@NoiDung",txtNoiDung.Text.ToString().Trim())
        });
            if (dt.Rows.Count > 0)
            {
                int rowIndex = 0;
                GridView.DataSource = dt;
                GridView.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Label Row = (Label)GridView.Rows[rowIndex].Cells[0].FindControl("lblSTT");
                    LinkButton ID = (LinkButton)GridView.Rows[rowIndex].Cells[1].FindControl("txtID");
                    Label Line = (Label)GridView.Rows[rowIndex].Cells[2].FindControl("lblLine");
                    Label MaSanPham = (Label)GridView.Rows[rowIndex].Cells[3].FindControl("lblMaSanPham");
                    Label TenSanPham = (Label)GridView.Rows[rowIndex].Cells[4].FindControl("lblTenSanPham");
                    Label BanVe = (Label)GridView.Rows[rowIndex].Cells[5].FindControl("lblBanVe");
                    Label NgayThaoTac = (Label)GridView.Rows[rowIndex].Cells[6].FindControl("lblNgayThaoTac");
                    Label NguoiDamNhiem = (Label)GridView.Rows[rowIndex].Cells[7].FindControl("lblNguoiDamNhiem");
                    Label TrangThai = (Label)GridView.Rows[rowIndex].Cells[8].FindControl("lblTrangThai");
                    Label NguoiNhap = (Label)GridView.Rows[rowIndex].Cells[9].FindControl("lblNguoiNhap");
                    Row.Text = dt.Rows[i][0].ToString();
                    ID.Text = dt.Rows[i][1].ToString();
                    Line.Text = dt.Rows[i][2].ToString();
                    MaSanPham.Text = dt.Rows[i][3].ToString();
                    TenSanPham.Text = dt.Rows[i][4].ToString();
                    BanVe.Text = dt.Rows[i][5].ToString();
                    NgayThaoTac.Text = (Convert.ToDateTime(dt.Rows[i][6].ToString())).ToString("yyyy-MM-dd");
                    NguoiDamNhiem.Text = dt.Rows[i][7].ToString();
                    TrangThai.Text = dt.Rows[i][8].ToString();
                    NguoiNhap.Text = dt.Rows[i][9].ToString();
                    rowIndex++;
                }
                SetPreviousData();
            }
        }
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            currPage = 1;
            Load_Gridview();
            lblCurrPage.Text = "1";
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnFirst.Enabled = false;
            btnLast.Enabled = true;
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {

            currPage = int.Parse(lblTotal.Text.ToString());
            Load_Gridview();
            lblCurrPage.Text = currPage.ToString();
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
            btnFirst.Enabled = true;
            btnLast.Enabled = false;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblCurrPage.Text.ToString()) > 1)
            {
                currPage = int.Parse(lblCurrPage.Text.ToString()) - 1;
            }
            else
            {
                currPage = 1;
            }
            lblCurrPage.Text = currPage.ToString();
            if (int.Parse(lblCurrPage.Text.ToString()) > 1)
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
            }
            else
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
                btnFirst.Enabled = false;
                btnLast.Enabled = true;
            }
            Load_Gridview();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblCurrPage.Text.ToString()) < int.Parse(lblTotal.Text.ToString()))
            {
                currPage = int.Parse(lblCurrPage.Text.ToString()) + 1;
            }
            else
            {
                currPage = Total;
            }
            lblCurrPage.Text = currPage.ToString();
            if (int.Parse(lblCurrPage.Text.ToString()) < int.Parse(lblTotal.Text.ToString()))
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
            }
            else
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = false;
                btnFirst.Enabled = true;
                btnLast.Enabled = false;
            }
            Load_Gridview();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label Row = (Label)GridView.Rows[rowIndex].Cells[0].FindControl("lblSTT");
                        LinkButton ID = (LinkButton)GridView.Rows[rowIndex].Cells[1].FindControl("txtID");
                        Label Line = (Label)GridView.Rows[rowIndex].Cells[2].FindControl("lblLine");
                        Label MaSanPham = (Label)GridView.Rows[rowIndex].Cells[3].FindControl("lblMaSanPham");
                        Label TenSanPham = (Label)GridView.Rows[rowIndex].Cells[4].FindControl("lblTenSanPham");
                        Label BanVe = (Label)GridView.Rows[rowIndex].Cells[5].FindControl("lblBanVe");
                        Label NgayThaoTac = (Label)GridView.Rows[rowIndex].Cells[6].FindControl("lblNgayThaoTac");
                        Label NguoiDamNhiem = (Label)GridView.Rows[rowIndex].Cells[7].FindControl("lblNguoiDamNhiem");
                        Label TrangThai = (Label)GridView.Rows[rowIndex].Cells[8].FindControl("lblTrangThai");
                        Label NguoiNhap = (Label)GridView.Rows[rowIndex].Cells[9].FindControl("lblNguoiNhap");
                        Row.Text = dt.Rows[i]["lblSTT"].ToString();
                        ID.Text = dt.Rows[i]["txtID"].ToString();
                        Line.Text = dt.Rows[i]["lblLine"].ToString();
                        MaSanPham.Text = dt.Rows[i]["lblMaSanPham"].ToString();
                        TenSanPham.Text = dt.Rows[i]["lblTenSanPham"].ToString();
                        BanVe.Text = dt.Rows[i]["lblBanVe"].ToString();
                        NgayThaoTac.Text = dt.Rows[i]["lblNgayThaoTac"].ToString();
                        NguoiDamNhiem.Text = dt.Rows[i]["lblNguoiDamNhiem"].ToString();
                        TrangThai.Text = dt.Rows[i]["lblTrangThai"].ToString();
                        NguoiNhap.Text = dt.Rows[i]["lblNguoiNhap"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Load_Gridview();
            lblCurrPage.Text = "1";
            DataTable dt = new DataTable();
            string IDPhieu = Request.QueryString["IDPhieu"];
            SqlParameter[] prams = new SqlParameter[] {
                                new SqlParameter("@NoiDung",txtNoiDung.Text.ToString().Trim())};
            dt = SQLhelper.GetDataToTable("Books_Kashime_SoThaoTac_SearchViewList", prams);
            if (dt.Rows.Count > 0)
            {
                double a = dt.Rows.Count;
                double tong = (a / 20);
                lblTotal.Text = ((int)Math.Ceiling(tong)).ToString();
                btnPrevious.Enabled = false;
                btnFirst.Enabled = false;
                if (tong > 1)
                {
                    btnLast.Enabled = true;
                    btnNext.Enabled = true;
                }
                else
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
        }
        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = GridView.Rows[rowindex];
                string IDPhieu = (gvr.FindControl("txtID") as LinkButton).Text;
                string ID_Phieu_Encrypt = ThaoTacDuLieu.Encrypt_V1(IDPhieu, "NisseiTL1LGMyTho");
                Response.Redirect("SoThaoTac.aspx?IDPhieu=" + ID_Phieu_Encrypt.ToString());
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Load_GridView_PhanQuyen()
        {
            DataTable dt = new DataTable();
            dt = SQLhelper.GetDataToTable("Books_Kashime_1_1_Get_SoCatCable_NguoiXacNhan");

            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        protected void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = SQLhelper.GetDataToTable("Books_Get_ThongTin_NhanVien", new SqlParameter[]
            {
                new SqlParameter("@MaNV", txtMaNhanVien.Text)
            });
            if (dt.Rows.Count > 0)
            {
                txtTenNhanVien.Text = dt.Rows[0].Field<string>("HoTen");
            }
            else
            {
                MsgBox("Mã Nhân Viên Không Tồn Tại !");
                return;
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (CheckDataSave() == true && Check_NhanVien() == true)
            {
                int insert = SQLhelper.ExecuteNonQuery("Books_Kashime_1_1_Insert_SoCatCable_NguoiXacNhan", new SqlParameter[]
            {
                new SqlParameter("@MaNV",txtMaNhanVien.Text),
                new SqlParameter("@HoTen",txtTenNhanVien.Text),

            });
                if (insert > 0)
                {
                    MsgBox("Lưu Thành Công!");
                    ResetDataNULL();
                    Load_GridView_PhanQuyen();
                    return;
                }
                else
                {
                    MsgBox("Lưu Không Thành Công!");
                }

            }
            else
            {
                MsgBox("Không Thành Công, Kiểm Tra Lại Dữ Liệu");
            }

        }
        private void ResetDataNULL()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
        }
        private bool CheckDataSave()
        {

            if (string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MsgBox("Chưa Chọn Nhân Viên !");
                return false;
            }
            return true;
        }
        private bool Check_NhanVien()
        {
            int check = 0;
            check = SQLhelper.ExecuteNonQuery("Books_Kashime_1_1_Check_SoCatCable_NguoiXacNhan", new SqlParameter[]
            {
                new SqlParameter("@MaNV",txtMaNhanVien.Text),
            });
            if (check > 0)
            {
                MsgBox("Nhân Viên Đã Có Thông Tin");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            btnThemMoi.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
        }
        protected void btnEditQuyen_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = false;
            btnThemMoi.Visible = true;
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            int id = Convert.ToInt32(GridView2.DataKeys[rowIndex].Value);
            DataTable dt = SQLhelper.GetDataToTable("Books_Kashime_1_1_Get_SoCatCable_NguoiXacNhan_By_ID", new SqlParameter[] {
                         new SqlParameter("@ID", id)
             });
            if (dt.Rows.Count > 0)
            {
                lblID.Text = dt.Rows[0].Field<int>("ID").ToString();
                txtMaNhanVien.Text = dt.Rows[0].Field<string>("MaNV");
                txtTenNhanVien.Text = dt.Rows[0].Field<string>("HoTen");
            }
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblID.Text) && int.TryParse(lblID.Text, out int id))
            {
                int update = 0;
                update = SQLhelper.ExecuteNonQuery("Books_Kashime_1_1_Update_SoCatCable_NguoiXacNhan_By_ID", new SqlParameter[] {
                            new SqlParameter("@ID", id),
                            new SqlParameter("@MaNV",txtMaNhanVien.Text),
                            new SqlParameter("@HoTen",txtTenNhanVien.Text),

              });
                if (update > 0)
                {
                    MsgBox("Update Thành Công");
                    ResetDataNULL();
                    Load_GridView_PhanQuyen();
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                }
                else
                {
                    MsgBox("Update Không Thành Công");
                    return;
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblID.Text) && int.TryParse(lblID.Text, out int id))
            {
                SqlParameter[] prameter = new SqlParameter[]
                {
                    new SqlParameter("@ID", id)
                };
                int delete = SQLhelper.ExecuteNonQuery("Books_Kashime_1_1_Delete_SoCatCable_NguoiXacNhan_By_ID", prameter);
                if (delete > 0)
                {
                    MsgBox("Xóa Thành Công!");
                    ResetDataNULL();
                    Load_GridView_PhanQuyen();
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                }
                else
                {
                    MsgBox("Xóa Không Thành Công!");
                }
            }
            else
            {
                MsgBox("ID không hợp lệ!");
            }
        }
        int stt = 1;
        public string get_stt()
        {
            return Convert.ToString(stt++);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;   //trang hien tai
            int trang_thu = e.NewPageIndex;      //the hien trang thu may
            int so_dong = GridView2.PageSize;       //moi trang co bao nhieu dong
            stt = trang_thu * so_dong + 1;
            Load_GridView_PhanQuyen();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}