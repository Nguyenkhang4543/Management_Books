using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

namespace Management_Books
{
    public partial class Management_Employees : System.Web.UI.Page
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
                    if (Session["Quyen"].ToString() != "1")
                    {
                        Response.Redirect("Login.aspx");
                    }
                    lblTenDanhNhap.Text = convertToUnSign3(Session["Ten"].ToString());
                    Load_GridView();
                    Load_GridView_DanhSachSo();

                    DataTable dt = new DataTable();
                    dt = SQLhelper.GetDataToTable("Books_Get_AllSo");
                    ddlLoaiSo.DataSource = dt;
                    ddlLoaiSo.DataTextField = "Ten_So";
                    ddlLoaiSo.DataValueField = "Ten_So";
                    ddlLoaiSo.DataBind();
                    ddlLoaiSo.Items.Insert(0, new ListItem("-----Select-----", ""));
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

        private void Load_GridView()
        {
            DataTable dt = new DataTable();
            dt = SQLhelper.GetDataToTable("Books_Get_ThongTinNhanVien");
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void Load_GridView_DanhSachSo()
        {
            DataTable dt = new DataTable();
            dt = SQLhelper.GetDataToTable("Books_Get_DanhSachSo");

            if(dt.Rows.Count > 0)
            {
                GridViewDanhSach.DataSource = dt;
                GridViewDanhSach.DataBind();
            }
        }
        protected void ddlLoaiSo_IndexChanged(object sender, EventArgs e)
        {
            DataTable dt = SQLhelper.GetDataToTable("Books_Get_So_By_Bo_Phan", new SqlParameter[] {
                                                SQLhelper.CreateParameter("@BoPhan", ddlBoPhan.SelectedValue.Trim())
                                                });

            ddlLoaiSo.DataSource = dt;
            ddlLoaiSo.DataTextField = "Ten_So";
            ddlLoaiSo.DataValueField = "Ten_So";
            ddlLoaiSo.DataBind();
            ddlLoaiSo.Items.Insert(0, new ListItem("-----Select-----", ""));
        }

        protected void ddlMa_So(object sender, EventArgs e)
        {
            DataTable dt = SQLhelper.GetDataToTable("Books_Get_So_Ma_So", new SqlParameter[] {
                                                SQLhelper.CreateParameter("@TenSo", ddlLoaiSo.SelectedValue.Trim())
                                                });
            if (dt.Rows.Count > 0 && ddlLoaiSo.Text != "-----Select-----")
            {
                lblMa_So.Text = dt.Rows[0].Field<string>("Ma_So");
            }
            else
            {
                lblMa_So.Text = null;
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
            if (CheckData() == true && Check_NhanVien()==true)
            {
               int insert = SQLhelper.ExecuteNonQuery("Books_Insert_PhanQuyen", new SqlParameter[]
           {
                new SqlParameter("@Ma_So",lblMa_So.Text),
                new SqlParameter("@ALL_Books",CheckAllQuyen.Checked),
                new SqlParameter("@MSNV",txtMaNhanVien.Text),
                new SqlParameter("@Ten_So",ddlLoaiSo.Text)
           });
                if(insert > 0)
                {
                    MsgBox("Lưu Thành Công!");
                    ResetData();
                    Load_GridView();
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
        private void ResetData()
        {
            txtMaNhanVien.Text = "";
            CheckAllQuyen.Checked = false;
            ddlLoaiSo.Text = "";
            txtTenNhanVien.Text = "";
        }
        private bool CheckData()
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
            DataTable dt = new DataTable();
            dt = SQLhelper.GetDataToTable("Check_PhanQuyen_NhanVien", new SqlParameter[]
            {
                new SqlParameter("@Ma_So",lblMa_So.Text),
                new SqlParameter("@MSNV",txtMaNhanVien.Text)
            });
            if(dt.Rows.Count < 0)
            {
                return true;
            }
            else
            {
                MsgBox("Nhân Viên Đã Có Thông Tin Với :" + ddlLoaiSo.SelectedValue);
                return false;
            }
        }
       
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);
            DataTable dt = SQLhelper.GetDataToTable("Books_Get_ThongTinNhanVien_ByID", new SqlParameter[] {
                         new SqlParameter("@ID", id)
             });
            if (dt.Rows.Count > 0)
            {
                lblID.Text = dt.Rows[0].Field<int>("ID").ToString();
                ddlLoaiSo.Text = dt.Rows[0].Field<string>("Ten_So");
                txtMaNhanVien.Text = dt.Rows[0].Field<string>("MSNV");
                txtTenNhanVien.Text = dt.Rows[0].Field<string>("HoTen");
                CheckAllQuyen.Checked = dt.Rows[0].Field<bool>("ALL_Books");
            }
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Check_Update() == true)
            {
                if (!string.IsNullOrEmpty(lblID.Text) && int.TryParse(lblID.Text, out int id))
                {
                    int update = 0;
                    update = SQLhelper.ExecuteNonQuery("Books_Update_PhanQuyen", new SqlParameter[] {
                            new SqlParameter("@ID", id),
                            new SqlParameter("@Ma_So",lblMa_So.Text),
                            new SqlParameter("@ALL_Books",CheckAllQuyen.Checked),
                            new SqlParameter("@MSNV",txtMaNhanVien.Text),
                            new SqlParameter("@Ten_So",ddlLoaiSo.Text)
              });
                    if (update > 0)
                    {
                        MsgBox("Update Thành Công");
                        ResetData();
                        Load_GridView();
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
            else
            {
                MsgBox("Xảy Ra Lỗi Trong Quá Trình Update!");
                return;
            }
            
        }
        private bool Check_Update()
        {
            int update = SQLhelper.ExecuteNonQuery("Check_PhanQuyen_NhanVien", new SqlParameter[]
            {
                new SqlParameter("@Ma_So",lblMa_So.Text),
                new SqlParameter("@MSNV",txtMaNhanVien.Text)
            });
            if (update < 0)
            {
                return true;
            }
            else
            {
                MsgBox("Nhân Viên Đã Có Thông Tin Với :" + ddlLoaiSo.SelectedValue);
                return false;
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
                int delete = SQLhelper.ExecuteNonQuery("Books_Delete_ThongTinNhanVien", prameter);
                if (delete > 0)
                {
                    MsgBox("Xóa Thành Công!");
                    ResetData();
                    Load_GridView();
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
    }
}