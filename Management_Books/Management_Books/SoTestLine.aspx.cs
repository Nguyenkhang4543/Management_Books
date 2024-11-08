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
using System.Drawing;

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
                        btnAdminMain.Visible = true;
                        btnMainBack.Visible = true;
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
                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    btnSearch_Click(null, null);
                    Load_GridView_PhanQuyen();
                    //Load_Gridview();
                }
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void btnAdminMain_Click(object sender, EventArgs e)
        {
            btnMain.Visible = false;
            btnAdmin.Visible = true;
        }
        protected void btnMainBack_Click(object sender, EventArgs e)
        {
            btnMain.Visible = true;
            btnAdmin.Visible = false;
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
            if (dt.Rows.Count > 0)
            {
                GridView.DataSource = dt;
                GridView.DataBind();
            }
            else
            {
                MsgBox("Không Có Dữ Liệu");
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFromDate.Text.ToString()) && !string.IsNullOrEmpty(txtToDate.Text.ToString()))
            {
                DateTime Tu = DateTime.Parse(txtFromDate.Text.ToString()) + new TimeSpan(0, 0, 0);
                DateTime Den = DateTime.Parse(txtToDate.Text.ToString()) + new TimeSpan(23, 59, 0);
                string SoLine = "";
                SoLine = txtSoLine_Search.Text.ToString().Trim();
                SqlParameter[] para = new SqlParameter[]
                                  {
                                    new SqlParameter("@Tu", Tu),
                                    new SqlParameter("@Den", Den),
                                    new SqlParameter("@So_Line", SoLine),
                                    new SqlParameter("@MaBP",Session["BoPhan"].ToString()),
                                    new SqlParameter("@Factory",Session["Factory"].ToString()),
                                    new SqlParameter("@Quyen",Session["Quyen"].ToString() )
                                  };
                DataTable dt = SQLhelper.GetDataToTable("Books_Kashime_Get_ALL_SoTestLine", para);
                GridView.DataSource = dt;
                GridView.DataBind();
                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblSo_Line")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblNgay_SX")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblThoiGianDoi_SP")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblSP_DangThaoTac")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblSP_TienHanhDoi")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTConLai_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTConLai_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblThuGomConLai_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblThuGomConLai_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblGiaoTP_QC_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblGiaoTP_QC_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTPhePham_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTPhePham_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblACB_XacNhan_SX_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblACB_XacNhan_QC_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTCDC_A_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTCDC_A_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTCD_DTA_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTCD_DTA_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTND_A1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTND_A2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblACB_XacNhan_SX_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblACB_XacNhan_QC_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTTaibar_A_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTTaibar_A_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTDongGoi_A_1")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblKTDongGoi_A_2")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblACB_XacNhan_SX_3")).Text)
                        || string.IsNullOrEmpty(((Label)GridView.Rows[i].FindControl("lblACB_XacNhan_QC_3")).Text)
                        
                         )
                    {
                        GridView.Rows[i].BackColor = Color.FromArgb(248, 255, 66);
                    }
                    else
                    {
                        GridView.Rows[i].BackColor = Color.FromArgb(224, 255, 250);
                    }
                }


            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ID = string.IsNullOrEmpty(hdfID.Value) ? null : hdfID.Value;
            int insert = SQLhelper.ExecuteNonQuery("Books_Kashime_Insert_SoTestLine", new SqlParameter[]
            {
                new SqlParameter("@ID",ID),
                new SqlParameter("@So_Line",txtSo_Line.Text),
                new SqlParameter("@Ngay_SX",txtNgay_SX.Text),
                new SqlParameter("@ThoiGianDoi_SP",txtThoiGianDoi_SP.Text),
                new SqlParameter("@SP_DangThaoTac",txtSP_DangThaoTac.Text),
                new SqlParameter("@SP_TienHanhDoi",txtSP_TienHanhDoi.Text),
                new SqlParameter("@KTConLai_1",txtKTConLai_1.Text),
                new SqlParameter("@KTConLai_2",txtKTConLai_2.Text),
                new SqlParameter("@ThuGomConLai_1",txtThuGomConLai_1.Text),
                new SqlParameter("@ThuGomConLai_2",txtThuGomConLai_2.Text),
                new SqlParameter("@GiaoTP_QC_1",txtGiaoTP_QC_1.Text),
                new SqlParameter("@GiaoTP_QC_2",txtGiaoTP_QC_2.Text),
                new SqlParameter("@KTPhePham_1",txtKTPhePham_1.Text),
                new SqlParameter("@KTPhePham_2",txtKTPhePham_2.Text),
                new SqlParameter("@ACB_XacNhan_SX_1",txtACB_XacNhan_SX_1.Text),
                new SqlParameter("@ACB_XacNhan_QC_1",txtACB_XacNhan_QC_1.Text),
                new SqlParameter("@DapCable_GhiChu",txtDapCable_GhiChu.Text),

                new SqlParameter("@KTCDC_A_1",txtKTCDC_A_1.Text),
                new SqlParameter("@KTCDC_A_2",txtKTCDC_A_2.Text),
                new SqlParameter("@KTCD_DTA_1",txtKTCD_DTA_1.Text),
                new SqlParameter("@KTCD_DTA_2",txtKTCD_DTA_2.Text),
                new SqlParameter("@KTND_A1",txtKTND_A1.Text),
                new SqlParameter("@KTND_A2",txtKTND_A2.Text),
                new SqlParameter("@ACB_XacNhan_SX_2",txtACB_XacNhan_SX_2.Text),
                new SqlParameter("@ACB_XacNhan_QC_2",txtACB_XacNhan_QC_2.Text),
                new SqlParameter("@QC_GhiChu",txtQC_GhiChu.Text),

                new SqlParameter("@KTTaibar_A_1",txtKTTaibar_A_1.Text),
                new SqlParameter("@KTTaibar_A_2",txtKTTaibar_A_2.Text),
                new SqlParameter("@KTDongGoi_A_1",txtKTDongGoi_A_1.Text),
                new SqlParameter("@KTDongGoi_A_2",txtKTDongGoi_A_2.Text),
                new SqlParameter("@ACB_XacNhan_SX_3",txtACB_XacNhan_SX_3.Text),
                new SqlParameter("@ACB_XacNhan_QC_3",txtACB_XacNhan_QC_3.Text),
                new SqlParameter("@DongGoi_GhiChu",txtDongGoi_GhiChu.Text),
                new SqlParameter("@MaBP",Session["BoPhan"].ToString()),
                new SqlParameter("@Factory",Session["Factory"].ToString())
            });
            if (insert > 0)
            {
                MsgBox("Lưu Dữ Liệu Thành Công");
                Enable_Field();
                btnSearch_Click(null, null);
                Reset_Data();
            }
            else
            {
                MsgBox("Lưu Dữ Liệu Không Thành Công!");
            }
        }
        private void Reset_Data()
        {
            txtSo_Line.Text = "";
            txtNgay_SX.Text = "";
            txtThoiGianDoi_SP.Text = "";
            txtSP_DangThaoTac.Text = "";
            txtSP_TienHanhDoi.Text = "";
            txtKTConLai_1.Text = "";
            txtKTConLai_2.Text = "";
            txtThuGomConLai_1.Text = "";
            txtThuGomConLai_2.Text = "";
            txtGiaoTP_QC_1.Text = "";
            txtGiaoTP_QC_2.Text = "";
            txtKTPhePham_1.Text = "";
            txtKTPhePham_2.Text = "";
            txtACB_XacNhan_SX_1.Text = "";
            txtACB_XacNhan_QC_1.Text = "";
            txtDapCable_GhiChu.Text = "";
            txtKTCDC_A_1.Text = "";
            txtKTCDC_A_2.Text = "";
            txtKTCD_DTA_1.Text = "";
            txtKTCD_DTA_2.Text = "";
            txtKTND_A1.Text = "";
            txtKTND_A2.Text = "";
            txtACB_XacNhan_SX_2.Text = "";
            txtACB_XacNhan_QC_2.Text = "";
            txtQC_GhiChu.Text = "";
            txtKTTaibar_A_1.Text = "";
            txtKTTaibar_A_2.Text = "";
            txtKTDongGoi_A_1.Text = "";
            txtKTDongGoi_A_2.Text = "";
            txtACB_XacNhan_SX_3.Text = "";
            txtACB_XacNhan_QC_3.Text = "";
            txtDongGoi_GhiChu.Text = "";
            hdfID.Value = "";
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            int id = int.Parse(GridView.DataKeys[rowIndex].Values[0].ToString());
            DataTable dt = SQLhelper.GetDataToTable("Books_Kashime_Get_SoTestLine_By_ID", new SqlParameter("@ID", id));
            if (dt.Rows.Count > 0)
            {
                txtSo_Line.Text = dt.Rows[0].Field<string>("So_Line").ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0].Field<DateTime?>("Ngay_SX"))))
                {
                    txtNgay_SX.Text = dt.Rows[0].Field<DateTime>("Ngay_SX").ToString("yyyy-MM-dd") ?? string.Empty;
                }
                if (dt.Rows[0]["ThoiGianDoi_SP"] != DBNull.Value)
                {
                    txtThoiGianDoi_SP.Text = dt.Rows[0].Field<string>("ThoiGianDoi_SP") ?? string.Empty;
                }
                if (dt.Rows[0]["SP_DangThaoTac"] != DBNull.Value)
                {
                    txtSP_DangThaoTac.Text = dt.Rows[0].Field<string>("SP_DangThaoTac") ?? string.Empty;
                }
                if (dt.Rows[0]["SP_TienHanhDoi"] != DBNull.Value)
                {
                    txtSP_TienHanhDoi.Text = dt.Rows[0].Field<string>("SP_TienHanhDoi") ?? string.Empty;
                }
                 if (dt.Rows[0]["KTConLai_1"] != DBNull.Value)
                {
                    txtKTConLai_1.Text = dt.Rows[0].Field<string>("KTConLai_1") ?? string.Empty;
                }
                if (dt.Rows[0]["KTConLai_2"] != DBNull.Value)
                {
                    txtKTConLai_2.Text = dt.Rows[0].Field<string>("KTConLai_2") ?? string.Empty;
                }
                if (dt.Rows[0]["ThuGomConLai_1"] != DBNull.Value)
                {
                    txtThuGomConLai_1.Text = dt.Rows[0].Field<string>("ThuGomConLai_1") ?? string.Empty;
                }
                if (dt.Rows[0]["ThuGomConLai_2"] != DBNull.Value)
                {
                    txtThuGomConLai_2.Text = dt.Rows[0].Field<string>("ThuGomConLai_2") ?? string.Empty;
                }
                if (dt.Rows[0]["GiaoTP_QC_1"] != DBNull.Value)
                {
                    txtGiaoTP_QC_1.Text = dt.Rows[0].Field<string>("GiaoTP_QC_1") ?? string.Empty;
                }
                if (dt.Rows[0]["GiaoTP_QC_2"] != DBNull.Value)
                {
                    txtGiaoTP_QC_2.Text = dt.Rows[0].Field<string>("GiaoTP_QC_2") ?? string.Empty;
                }
                if (dt.Rows[0]["KTPhePham_1"] != DBNull.Value)
                {
                    txtKTPhePham_1.Text = dt.Rows[0].Field<string>("KTPhePham_1") ?? string.Empty;
                }
                if (dt.Rows[0]["KTPhePham_2"] != DBNull.Value)
                {
                    txtKTPhePham_2.Text = dt.Rows[0].Field<string>("KTPhePham_2") ?? string.Empty;
                }
                if (dt.Rows[0]["ACB_XacNhan_SX_1"] != DBNull.Value)
                {
                    txtACB_XacNhan_SX_1.Text = dt.Rows[0].Field<string>("ACB_XacNhan_SX_1") ?? string.Empty;
                }
                if (dt.Rows[0]["ACB_XacNhan_QC_1"] != DBNull.Value)
                {
                    txtACB_XacNhan_QC_1.Text = dt.Rows[0].Field<string>("ACB_XacNhan_QC_1") ?? string.Empty;
                }
                if (dt.Rows[0]["DapCable_GhiChu"] != DBNull.Value)
                {
                    txtDapCable_GhiChu.Text = dt.Rows[0].Field<string>("DapCable_GhiChu") ?? string.Empty;
                }
                if (dt.Rows[0]["KTCDC_A_1"] != DBNull.Value)
                {
                    txtKTCDC_A_1.Text = dt.Rows[0].Field<string>("KTCDC_A_1") ?? string.Empty;
                }
                if (dt.Rows[0]["KTCDC_A_2"] != DBNull.Value)
                {
                    txtKTCDC_A_2.Text = dt.Rows[0].Field<string>("KTCDC_A_2") ?? string.Empty;
                }
                if (dt.Rows[0]["KTCD_DTA_1"] != DBNull.Value)
                {
                    txtKTCD_DTA_1.Text = dt.Rows[0].Field<string>("KTCD_DTA_1") ?? string.Empty;
                }
                if (dt.Rows[0]["KTCD_DTA_2"] != DBNull.Value)
                {
                    txtKTCD_DTA_2.Text = dt.Rows[0].Field<string>("KTCD_DTA_2") ?? string.Empty;
                }
                 if (dt.Rows[0]["KTND_A1"] != DBNull.Value)
                {
                    txtKTND_A1.Text = dt.Rows[0].Field<string>("KTND_A1") ?? string.Empty;
                }
                if (dt.Rows[0]["KTND_A2"] != DBNull.Value)
                {
                    txtKTND_A2.Text = dt.Rows[0].Field<string>("KTND_A2") ?? string.Empty;
                }
                 if (dt.Rows[0]["ACB_XacNhan_SX_2"] != DBNull.Value)
                {
                    txtACB_XacNhan_SX_2.Text = dt.Rows[0].Field<string>("ACB_XacNhan_SX_2") ?? string.Empty;
                }
                if (dt.Rows[0]["ACB_XacNhan_QC_2"] != DBNull.Value)
                {
                    txtACB_XacNhan_QC_2.Text = dt.Rows[0].Field<string>("ACB_XacNhan_QC_2") ?? string.Empty;
                }
                if (dt.Rows[0]["QC_GhiChu"] != DBNull.Value)
                {
                    txtQC_GhiChu.Text = dt.Rows[0].Field<string>("QC_GhiChu") ?? string.Empty;
                }
                if (dt.Rows[0]["KTTaibar_A_1"] != DBNull.Value)
                {
                    txtKTTaibar_A_1.Text = dt.Rows[0].Field<string>("KTTaibar_A_1") ?? string.Empty;
                }
                if (dt.Rows[0]["KTTaibar_A_2"] != DBNull.Value)
                {
                    txtKTTaibar_A_2.Text = dt.Rows[0].Field<string>("KTTaibar_A_2") ?? string.Empty;
                }
                 if (dt.Rows[0]["KTDongGoi_A_1"] != DBNull.Value)
                {
                    txtKTDongGoi_A_1.Text = dt.Rows[0].Field<string>("KTDongGoi_A_1") ?? string.Empty;
                }
                 if (dt.Rows[0]["KTDongGoi_A_2"] != DBNull.Value)
                {
                    txtKTDongGoi_A_2.Text = dt.Rows[0].Field<string>("KTDongGoi_A_2") ?? string.Empty;
                }
                if (dt.Rows[0]["ACB_XacNhan_SX_3"] != DBNull.Value)
                {
                    txtACB_XacNhan_SX_3.Text = dt.Rows[0].Field<string>("ACB_XacNhan_SX_3") ?? string.Empty;
                }
                if (dt.Rows[0]["ACB_XacNhan_QC_3"] != DBNull.Value)
                {
                    txtACB_XacNhan_QC_3.Text = dt.Rows[0].Field<string>("ACB_XacNhan_QC_3") ?? string.Empty;
                }
                if (dt.Rows[0]["DongGoi_GhiChu"] != DBNull.Value)
                {
                    txtDongGoi_GhiChu.Text = dt.Rows[0].Field<string>("DongGoi_GhiChu") ?? string.Empty;
                }
                if(!string.IsNullOrEmpty(txtSo_Line.Text)
                    &&!string.IsNullOrEmpty(txtNgay_SX.Text)
                    && !string.IsNullOrEmpty(txtThoiGianDoi_SP.Text)
                    && !string.IsNullOrEmpty(txtSP_DangThaoTac.Text)
                    && !string.IsNullOrEmpty(txtSP_TienHanhDoi.Text)
                    && !string.IsNullOrEmpty(txtKTConLai_1.Text)
                    && !string.IsNullOrEmpty(txtKTConLai_2.Text)
                    && !string.IsNullOrEmpty(txtThuGomConLai_1.Text)
                    && !string.IsNullOrEmpty(txtThuGomConLai_2.Text)
                    && !string.IsNullOrEmpty(txtGiaoTP_QC_1.Text)
                    && !string.IsNullOrEmpty(txtGiaoTP_QC_2.Text)
                    && !string.IsNullOrEmpty(txtKTPhePham_1.Text)
                    && !string.IsNullOrEmpty(txtKTPhePham_2.Text)
                    && !string.IsNullOrEmpty(txtACB_XacNhan_SX_1.Text)
                    && !string.IsNullOrEmpty(txtACB_XacNhan_QC_1.Text)
                    && !string.IsNullOrEmpty(txtKTCDC_A_1.Text)
                    && !string.IsNullOrEmpty(txtKTCDC_A_2.Text)
                    && !string.IsNullOrEmpty(txtKTCD_DTA_1.Text)
                    && !string.IsNullOrEmpty(txtKTCD_DTA_2.Text)
                    && !string.IsNullOrEmpty(txtKTND_A1.Text)
                    && !string.IsNullOrEmpty(txtKTND_A2.Text)
                    && !string.IsNullOrEmpty(txtACB_XacNhan_SX_2.Text)
                    && !string.IsNullOrEmpty(txtACB_XacNhan_QC_2.Text)
                    && !string.IsNullOrEmpty(txtKTTaibar_A_1.Text)
                    && !string.IsNullOrEmpty(txtKTTaibar_A_2.Text)
                    && !string.IsNullOrEmpty(txtKTDongGoi_A_1.Text)
                    && !string.IsNullOrEmpty(txtKTDongGoi_A_2.Text)
                    && !string.IsNullOrEmpty(txtACB_XacNhan_SX_3.Text)
                    && !string.IsNullOrEmpty(txtACB_XacNhan_QC_3.Text)
                    )
                {
                    Enable_Field(false);
                }
                else
                {
                    Enable_Field();
                }
            }
        }
        private void Enable_Field(bool flag = true)
        {
            txtSo_Line.Enabled = flag;
            txtNgay_SX.Enabled = flag;
            txtThoiGianDoi_SP.Enabled = flag;
            txtSP_DangThaoTac.Enabled = flag;
            txtSP_TienHanhDoi.Enabled = flag;
            txtKTConLai_1.Enabled = flag;
            txtKTConLai_2.Enabled = flag;
            txtThuGomConLai_1.Enabled = flag;
            txtThuGomConLai_2.Enabled = flag;
            txtGiaoTP_QC_1.Enabled = flag;
            txtGiaoTP_QC_2.Enabled = flag;
            txtKTPhePham_1.Enabled = flag;
            txtKTPhePham_2.Enabled = flag;
            txtACB_XacNhan_SX_1.Enabled = flag;
            txtACB_XacNhan_QC_1.Enabled = flag;
            txtDapCable_GhiChu.Enabled = flag;

            txtKTCDC_A_1.Enabled = flag;
            txtKTCDC_A_2.Enabled = flag;
            txtKTCD_DTA_1.Enabled = flag;
            txtKTCD_DTA_2.Enabled = flag;
            txtKTND_A1.Enabled = flag;
            txtKTND_A2.Enabled = flag;
            txtACB_XacNhan_SX_2.Enabled = flag;
            txtACB_XacNhan_QC_2.Enabled = flag;
            txtQC_GhiChu.Enabled = flag;

            txtKTTaibar_A_1.Enabled = flag;
            txtKTTaibar_A_2.Enabled = flag;
            txtKTDongGoi_A_1.Enabled = flag;
            txtKTDongGoi_A_2.Enabled = flag;
            txtACB_XacNhan_SX_3.Enabled = flag;
            txtACB_XacNhan_QC_3.Enabled = flag;
            txtDongGoi_GhiChu.Enabled = flag;
        }

        protected void ACB_XacNhan(object sender, EventArgs e)
        {
            DataTable dtPhanQuyenXem = SQLhelper.ExecuteDataTable("Check_PhanQuyen", new SqlParameter[]
            {
        new SqlParameter("@MSNV", Session["MaNV"].ToString())
            });

            if (dtPhanQuyenXem.Rows.Count > 0)
            {
                CheckAdmin.Checked = dtPhanQuyenXem.Rows[0].Field<bool>("ALL_Books");
                if (!CheckAdmin.Checked)
                {
                    //ValidateAndExecute(txtACB_XacNhan_SX_1, "SX");
                    //ValidateAndExecute(txtACB_XacNhan_QC_1, "QC");
                    //ValidateAndExecute(txtACB_XacNhan_SX_2, "SX");
                    //ValidateAndExecute(txtACB_XacNhan_QC_2, "QC");
                    //ValidateAndExecute(txtACB_XacNhan_SX_3, "SX");
                    //ValidateAndExecute(txtACB_XacNhan_QC_3, "SX");
                    if (!string.IsNullOrEmpty(txtACB_XacNhan_SX_1.Text))
                    {
                        int checkSX1 = SQLhelper.ExecuteNonQuery("Book_Kashime_Check_ACB_Xac_Nhan_SoTestLine", new SqlParameter[]
                        {
                        new SqlParameter("@MSNV", Session["MaNV"].ToString()),
                        new SqlParameter("@BoPhan", "SX")
                        });
                        if(checkSX1 < 0)
                        {
                            MsgBox("Bạn Không Có Quyền Thực Hiện Thao Tác!");
                            txtACB_XacNhan_SX_1.Text = "";
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(txtACB_XacNhan_QC_1.Text))
                    {
                        int checkQC1 = SQLhelper.ExecuteNonQuery("Book_Kashime_Check_ACB_Xac_Nhan_SoTestLine", new SqlParameter[]
                        {
                        new SqlParameter("@MSNV", Session["MaNV"].ToString()),
                        new SqlParameter("@BoPhan", "QC")
                        });
                        if (checkQC1 < 0)
                        {
                            MsgBox("Bạn Không Có Quyền Thực Hiện Thao Tác!");
                            txtACB_XacNhan_QC_1.Text = "";
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(txtACB_XacNhan_SX_2.Text))
                    {
                        int checkSX2 = SQLhelper.ExecuteNonQuery("Book_Kashime_Check_ACB_Xac_Nhan_SoTestLine", new SqlParameter[]
                        {
                        new SqlParameter("@MSNV", Session["MaNV"].ToString()),
                        new SqlParameter("@BoPhan", "SX")
                        });
                        if (checkSX2 < 0)
                        {
                            MsgBox("Bạn Không Có Quyền Thực Hiện Thao Tác!");
                            txtACB_XacNhan_SX_2.Text = "";
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(txtACB_XacNhan_QC_2.Text))
                    {
                        int checkQC2 = SQLhelper.ExecuteNonQuery("Book_Kashime_Check_ACB_Xac_Nhan_SoTestLine", new SqlParameter[]
                        {
                        new SqlParameter("@MSNV", Session["MaNV"].ToString()),
                        new SqlParameter("@BoPhan", "QC")
                        });
                        if (checkQC2 < 0)
                        {
                            MsgBox("Bạn Không Có Quyền Thực Hiện Thao Tác!");
                            txtACB_XacNhan_QC_2.Text = "";
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(txtACB_XacNhan_SX_3.Text))
                    {
                        int checkSX3 = SQLhelper.ExecuteNonQuery("Book_Kashime_Check_ACB_Xac_Nhan_SoTestLine", new SqlParameter[]
                        {
                        new SqlParameter("@MSNV", Session["MaNV"].ToString()),
                        new SqlParameter("@BoPhan", "SX")
                        });
                        if (checkSX3 < 0)
                        {
                            MsgBox("Bạn Không Có Quyền Thực Hiện Thao Tác!");
                            txtACB_XacNhan_SX_3.Text = "";
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(txtACB_XacNhan_QC_3.Text))
                    {
                        int checkQC3 = SQLhelper.ExecuteNonQuery("Book_Kashime_Check_ACB_Xac_Nhan_SoTestLine", new SqlParameter[]
                        {
                        new SqlParameter("@MSNV", Session["MaNV"].ToString()),
                        new SqlParameter("@BoPhan", "QC")
                        });
                        if (checkQC3 < 0)
                        {
                            MsgBox("Bạn Không Có Quyền Thực Hiện Thao Tác!");
                            txtACB_XacNhan_QC_3.Text = "";
                            return;
                        }
                    }
                }
            }
        }
        private void ValidateAndExecute(TextBox textBox, string boPhan)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                DataTable dt = new DataTable();
                dt = SQLhelper.GetDataToTable("Book_Kashime_Check_ACB_Xac_Nhan_SoTestLine", new SqlParameter[]
                {
                new SqlParameter("@MSNV", Session["MaNV"].ToString()),
                new SqlParameter("@BoPhan", boPhan)
                });
                if(dt.Rows.Count > 0)
                {

                }
                else
                {
                    MsgBox("Bạn Không Có Quyền Thực Hiện Thao Tác!");
                    textBox.Text = "";
                }
            }
           
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void Load_GridView_PhanQuyen()
        {
            DataTable dt = new DataTable();
            dt = SQLhelper.GetDataToTable("Books_Kashime_Get_PhanQuyen_SoTestLine");

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
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
            if (CheckData() == true && Check_NhanVien() == true)
            {
                int insert = SQLhelper.ExecuteNonQuery("Books_Kashime_Insert_PhanQuyen_SoTestLine", new SqlParameter[]
            {
                new SqlParameter("@MSNV",txtMaNhanVien.Text),
                new SqlParameter("@HoTen",txtTenNhanVien.Text),
                new SqlParameter("@BoPhan",ddlBoPhan.SelectedValue)
               
            });
                if (insert > 0)
                {
                    MsgBox("Lưu Thành Công!");
                    ResetData();
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
        private void ResetData()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            ddlBoPhan.Text = "";
        }
        private bool CheckData()
        {

            if (string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MsgBox("Chưa Chọn Nhân Viên !");
                return false;
            }
            if (string.IsNullOrEmpty(ddlBoPhan.Text))
            {
                MsgBox("Chưa Chọn Bộ Phận !");
                return false;
            }
            return true;
        }
        private bool Check_NhanVien()
        {
            int check = 0;
            check = SQLhelper.ExecuteNonQuery("Check_PhanQuyen_ACB_XacNhan_SoTestLine", new SqlParameter[]
            {
                new SqlParameter("@MSNV",txtMaNhanVien.Text),
                new SqlParameter("@BoPhan",ddlBoPhan.SelectedValue)
            });
            if(check > 0)
            {
                MsgBox("Nhân Viên Đã Có Thông Tin Với :" + ddlBoPhan.SelectedValue);
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnEditQuyen_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);
            DataTable dt = SQLhelper.GetDataToTable("Books_Kashime_Get_PhanQuyen_SoTestLine_By_ID", new SqlParameter[] {
                         new SqlParameter("@ID", id)
             });
            if (dt.Rows.Count > 0)
            {
                lblID.Text = dt.Rows[0].Field<int>("ID").ToString();
                txtMaNhanVien.Text = dt.Rows[0].Field<string>("MSNV");
                txtTenNhanVien.Text = dt.Rows[0].Field<string>("HoTen");
                ddlBoPhan.Text = dt.Rows[0].Field<string>("BoPhan");
            }
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Check_Update() == true)
            {
                if (!string.IsNullOrEmpty(lblID.Text) && int.TryParse(lblID.Text, out int id))
                {
                    int update = 0;
                    update = SQLhelper.ExecuteNonQuery("Books_Kashime_Update_PhanQuyen_SoTestLine_By_ID", new SqlParameter[] {
                            new SqlParameter("@ID", id),
                            new SqlParameter("@MSNV",txtMaNhanVien.Text),
                            new SqlParameter("@HoTen",txtTenNhanVien.Text),
                            new SqlParameter("@BoPhan",ddlBoPhan.SelectedValue)

              });
                    if (update > 0)
                    {
                        MsgBox("Update Thành Công");
                        ResetData();
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
            else
            {
                MsgBox("Xảy Ra Lỗi Trong Quá Trình Update!");
                return;
            }
        }
        private bool Check_Update()
        {
            int update = SQLhelper.ExecuteNonQuery("Check_PhanQuyen_ACB_XacNhan_SoTestLine", new SqlParameter[]
            {
                new SqlParameter("@MSNV",txtMaNhanVien.Text),
                new SqlParameter("@BoPhan",ddlBoPhan.SelectedValue),
            });
            if (update < 0)
            {
                return true;
            }
            else
            {
                MsgBox("Nhân Viên Đã Có Thông Tin Với :" + ddlBoPhan.SelectedValue);
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
                int delete = SQLhelper.ExecuteNonQuery("Books_Kashime_DELETE_PhanQuyen_SoTestLine_By_ID", prameter);
                if (delete > 0)
                {
                    MsgBox("Xóa Thành Công!");
                    ResetData();
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}