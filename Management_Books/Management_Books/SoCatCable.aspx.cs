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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;
using System.IO;
using ClosedXML.Excel;
using System.Diagnostics;
using System.Globalization;

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
                    if(Session["Quyen"].ToString() == "1")
                    {
                        taskbar_ImportDuLieuNguon.Visible = true;
                    }
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
        protected void btnSamPle_Click(object sender, EventArgs e)
        {
            string filename = "SampleFileCutCable.xlsx";
            string folderPath = @"\\Management_Books\Management_Books\Templates";
            string FilePath = System.IO.Path.Combine(folderPath, filename);
            System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
            if (file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=" + filename);
                Response.AddHeader("Content-Type", "application/Excel");
                Response.ContentType = "application/vnd.xls";
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpLoad.HasFile == true)
                {
                    //int Del = SQLhelper.ExecuteNonQuery("Delete_Data_QRCode", null);
                    foreach (HttpPostedFile postfiles in FileUpLoad.PostedFiles)
                    {
                        string path = string.Concat(Server.MapPath("~/DownLoad/" + postfiles.FileName));
                        postfiles.SaveAs(path);
                        string conString = string.Empty;
                        string extension = Path.GetExtension(postfiles.FileName);
                        conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                        //ConvertToDataTable(extension);
                        conString = string.Format(conString, path);
                        List<string> listSheet = new List<string>();
                        using (OleDbConnection con = new OleDbConnection(conString))
                        {
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [SOURCE$]", con);
                            con.Open();
                            // Create DbDataReader to Data Worksheet  
                            DbDataReader dr = cmd.ExecuteReader();
                            con.Close();
                            con.Open();
                            OleDbCommand cmdExcel = new OleDbCommand();
                            OleDbDataAdapter oda = new OleDbDataAdapter();
                            DataTable dt = new DataTable();
                            cmdExcel.Connection = con;
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();
                            string[] requiredColumns = { "ITEM", "ITEM NAME", "DRAWING", "PRODUCT LINE", "CUTTING SIZE", "DEVIATION" };
                            foreach (string col in requiredColumns)
                            {
                                if (!dt.Columns.Contains(col))
                                {
                                    MsgBox("This file is not in the correct format. Please! Select the file to which it is correct");
                                    return;
                                }
                                else
                                {
                                    int Del = SQLhelper.ExecuteNonQuery("Books_LineCut_1_1_Delete_SoCatCable_Nguon", null);
                                }
                            }

                            if (dt.Rows.Count > 0)
                            {
                                string ITEM = null;
                                string ITEMNAME = null;
                                string DRAWING = null;
                                string PRODUCTLINE = null;
                                double? CUTTINGSIZE = null;
                                double? DEVIATION = null;


                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    ITEM = dt.Rows[i][0].ToString();
                                    ITEMNAME = dt.Rows[i][1].ToString();
                                    DRAWING = dt.Rows[i][2].ToString();
                                    PRODUCTLINE = dt.Rows[i][3].ToString();
                                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                                    {
                                        CUTTINGSIZE = double.Parse(dt.Rows[i][4].ToString(), CultureInfo.InvariantCulture);
                                    }
                                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                                    {
                                        DEVIATION = double.Parse(dt.Rows[i][5].ToString(), CultureInfo.InvariantCulture);
                                    }

                                    int Ins = SQLhelper.ExecuteNonQuery("Books_LineCut_1_1_Insert_SoCatCable_Nguon", new SqlParameter[] {
                                        new SqlParameter("@MaSP",ITEM),
                                        new SqlParameter("@TenSanPham",ITEMNAME),
                                        new SqlParameter("@BanVe",DRAWING),
                                        new SqlParameter("@LineSanXuat",PRODUCTLINE),
                                        new SqlParameter("@KichThuoc",CUTTINGSIZE),
                                        new SqlParameter("@DoLech",DEVIATION)

                                        });
                                    if (Ins > 0)
                                    {
                                        MsgBox("Import Successfully!");
                                    }
                                    else
                                    {
                                        MsgBox("Import Error!");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MsgBox("Please! Select The File You Want To Import");
                    return;
                }
            }
            catch
            {
                //MsgBox("Xảy ra lỗi trong quá trình Import. " + ex.ToString());
                MsgBox("There's a problem with imports! Please! Reimporting");
                return;
            }
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
                if (!string.IsNullOrEmpty(txtLeader.Text))
                {
                    Enable_field();
                }
                else
                {
                    Enable();
                }
            }
        }
        private void Enable_field(bool flag = false)
        {
            txtNgayCatCable.Enabled = flag;
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
            if (string.IsNullOrEmpty(txtNgayCatCable.Text))
            {
                txtNgayCatCable.Enabled = true;
            }
            else
            {
                txtNgayCatCable.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                txtMaSP.Enabled = true;
            }
            else
            {
                txtMaSP.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtLotNguyenLieu.Text))
            {
                txtLotNguyenLieu.Enabled = true;
            }
            else
            {
                txtLotNguyenLieu.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtLotThanhPham.Text))
            {
                txtLotThanhPham.Enabled = true;
            }
            else
            {
                txtLotThanhPham.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                txtTenSanPham.Enabled = true;
            }
            else
            {
                txtTenSanPham.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtLineSanXuat.Text))
            {
                txtLineSanXuat.Enabled = true;
            }
            else
            {
                txtLineSanXuat.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtBanVe.Text))
            {
                txtBanVe.Enabled = true;
            }
            else
            {
                txtBanVe.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtKTBanVe.Text))
            {
                txtKTBanVe.Enabled = true;
            }
            else
            {
                txtKTBanVe.Enabled = false;
            }
            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtKTThucTe.Text))
            {
                txtKTThucTe.Enabled = true;
            }
            else
            {
                txtKTThucTe.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtMayCat.Text))
            {
                txtMayCat.Enabled = true;
            }
            else
            {
                txtMayCat.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtSoDonNew.Text))
            {
                txtSoDonNew.Enabled = true;
            }
            else
            {
                txtSoDonNew.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtSoDoanNew.Text))
            {
                txtSoDoanNew.Enabled = true;
            }
            else
            {
                txtSoDoanNew.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                txtSoLuong.Enabled = true;
            }
            else
            {
                txtSoLuong.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtNguoiThaoTac.Text))
            {
                txtNguoiThaoTac.Enabled = true;
            }
            else
            {
                txtNguoiThaoTac.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtLeader.Text))
            {
                txtLeader.Enabled = true;
            }
            else
            {
                txtLeader.Enabled = false;
            }
            /////////////////////////////////////////////////

            /////////////////////////////////////////////////
            if (string.IsNullOrEmpty(txtGhiChu.Text))
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
                        new SqlParameter("@ID",ID),
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

        protected void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SQLhelper.GetDataToTable("Books_LineCut_1_1_Get_SoCatCable_Nguon_By_ITEM", new SqlParameter[]
            {
        new SqlParameter("@ITEM", txtMaSP.Text)
            });
            if (dt.Rows.Count > 0)
            {
                txtTenSanPham.Text = dt.Rows[0].Field<string>("TenSanPham");
                txtBanVe.Text = dt.Rows[0].Field<string>("BanVe");
                txtLineSanXuat.Text = dt.Rows[0].Field<string>("LineSanXuat");

                // Kiểm tra giá trị null trước khi chuyển đổi
                float kichThuoc;
                if (dt.Rows[0]["KichThuoc"] != DBNull.Value && float.TryParse(dt.Rows[0]["KichThuoc"].ToString(), out kichThuoc))
                {
                    // Sử dụng định dạng chuỗi nếu cần
                    txtKTBanVe.Text = kichThuoc.ToString("F2"); // Hiển thị 2 chữ số thập phân
                }
                else
                {
                    txtKTBanVe.Text = "N/A"; // Hoặc giá trị mặc định khác
                }

                float dolech;
                if (dt.Rows[0]["DoLech"] != DBNull.Value && float.TryParse(dt.Rows[0]["DoLech"].ToString(), out dolech))
                {
                    // Sử dụng định dạng chuỗi nếu cần
                    lblDoLech.Text = dolech.ToString("F2"); // Hiển thị 2 chữ số thập phân
                }
                else
                {
                    lblDoLech.Text = "N/A"; // Hoặc giá trị mặc định khác
                }
            }
            else
            {
                MsgBox("Mã Sản Phẩm Không Tồn Tại!");
            }
        }

        protected void txtKTThucTe_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra kích thước thực tế nằm trong khoảng kích thước lệch chuẩn
            if (float.TryParse(txtKTBanVe.Text, out float kichthuoc) && float.TryParse(lblDoLech.Text, out float dolech))
            {
                if (double.TryParse(txtKTThucTe.Text.Trim(), out double KichThuocThucTe) == false)
                {
                    MsgBox("Kích thước nhập vào không phải là chữ số");
                    txtKTThucTe.Focus();
                    return;
                }

                if (kichthuoc - dolech < KichThuocThucTe && KichThuocThucTe < kichthuoc + dolech)
                {
                    // Dữ Liệu Đúng
                    MsgBox("Kích thước thực tế nằm trong khoảng cho phép.");
                }
                else
                {
                    MsgBox("Không Đạt Tiêu Chuẩn Về Độ Lệch!");
                    txtKTThucTe.Text = "";
                }
            }
            else
            {
                MsgBox("Không thể lấy giá trị kích thước hoặc độ lệch.");
            }
        }

    }
}