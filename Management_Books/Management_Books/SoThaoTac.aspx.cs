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
    public partial class SoThaoTac : System.Web.UI.Page
    {
        ThaoTacDuLieu SQLhelper = new ThaoTacDuLieu();
        private static int NO_Phieu = 1;
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
                    lblID_Phieu.Text = Request.QueryString["IDPhieu"];
                    if (!string.IsNullOrEmpty(lblID_Phieu.Text))
                    {
                        string Decrpyt = ThaoTacDuLieu.Decrypt_V1(lblID_Phieu.Text, "NisseiTL1LGMyTho");
                        Load_Data_ID_Phieu(Decrpyt);
                    }
                    else
                    {
                        SetInitialRow();

                    }
                }
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoThaoTac_Main.aspx");
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
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("txtSoDon", typeof(string)));
            dt.Columns.Add(new DataColumn("txtSoLot", typeof(string)));
            dt.Columns.Add(new DataColumn("txtNgaySanXuat", typeof(string)));
            dt.Columns.Add(new DataColumn("txtSoLuong", typeof(string)));
            dt.Columns.Add(new DataColumn("txtSetCable", typeof(string)));
            dt.Columns.Add(new DataColumn("txtDapSleeve", typeof(string)));
            dt.Columns.Add(new DataColumn("txtSoLuongDongGoi", typeof(string)));
            dt.Columns.Add(new DataColumn("txtSoLuongBu", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMSNV_DongGoi_1", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMSNV_DongGoi_2", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMSNV_DongGoi_3", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMSNV_DongGoi_4", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMSNV_DongThung_1", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMSNV_DongThung_2", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMSNV_DongThung_3", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMSNV_DongThung_4", typeof(string)));
            dt.Columns.Add(new DataColumn("txtLeader_DongGoi", typeof(string)));
            dt.Columns.Add(new DataColumn("txtCable", typeof(string)));
            dt.Columns.Add(new DataColumn("txtQC_Confirm", typeof(string)));
            dt.Columns.Add(new DataColumn("txtSleeve", typeof(string)));
            dt.Columns.Add(new DataColumn("txtNhungChi", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_1", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_2", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_3", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_4", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_5", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_6", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_7", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_8", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_9", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_10", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_11", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_12", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_13", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_14", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_15", typeof(string)));
            dt.Columns.Add(new DataColumn("txtGiaoNhan_16", typeof(string)));
            dt.Columns.Add(new DataColumn("txtOkDon", typeof(string)));

            dr = dt.NewRow();

            dr["txtSoDon"] = string.Empty;
            dr["txtSoLot"] = string.Empty;
            dr["txtNgaySanXuat"] = string.Empty;
            dr["txtSoLuong"] = string.Empty;
            dr["txtSetCable"] = string.Empty;
            dr["txtDapSleeve"] = string.Empty;
            dr["txtSoLuongDongGoi"] = string.Empty;
            dr["txtSoLuongBu"] = string.Empty;
            dr["txtMSNV_DongGoi_1"] = string.Empty;
            dr["txtMSNV_DongGoi_2"] = string.Empty;
            dr["txtMSNV_DongGoi_3"] = string.Empty;
            dr["txtMSNV_DongGoi_4"] = string.Empty;
            dr["txtMSNV_DongThung_1"] = string.Empty;
            dr["txtMSNV_DongThung_2"] = string.Empty;
            dr["txtMSNV_DongThung_3"] = string.Empty;
            dr["txtMSNV_DongThung_4"] = string.Empty;
            dr["txtLeader_DongGoi"] = string.Empty;
            dr["txtCable"] = string.Empty;
            dr["txtQC_Confirm"] = string.Empty;
            dr["txtSleeve"] = string.Empty;
            dr["txtNhungChi"] = string.Empty;
            dr["txtGiaoNhan_1"] = string.Empty;
            dr["txtGiaoNhan_2"] = string.Empty;
            dr["txtGiaoNhan_3"] = string.Empty;
            dr["txtGiaoNhan_4"] = string.Empty;
            dr["txtGiaoNhan_5"] = string.Empty;
            dr["txtGiaoNhan_6"] = string.Empty;
            dr["txtGiaoNhan_7"] = string.Empty;
            dr["txtGiaoNhan_8"] = string.Empty;
            dr["txtGiaoNhan_9"] = string.Empty;
            dr["txtGiaoNhan_10"] = string.Empty;
            dr["txtGiaoNhan_11"] = string.Empty;
            dr["txtGiaoNhan_12"] = string.Empty;
            dr["txtGiaoNhan_13"] = string.Empty;
            dr["txtGiaoNhan_14"] = string.Empty;
            dr["txtGiaoNhan_15"] = string.Empty;
            dr["txtGiaoNhan_16"] = string.Empty;
            dr["txtOkDon"] = string.Empty;
           

            dt.Rows.Add(dr);

            // Lưu DataTable vào ViewState
            ViewState["CurrentTable"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAddNewRow_Click(object sender, EventArgs e)//thêm dòng trong gridview
        {
            AddNewRowToGrid();
            SetPreviousData();
            EnableField();
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
                        TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtSoDon");
                        TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtSoLot");
                        TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtNgaySanXuat");

                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtSoLuong");

                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtSetCable");

                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtDapSleeve");

                        TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtSoLuongDongGoi");

                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txtSoLuongBu");

                        TextBox box9 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_1");
                        TextBox box10 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_2");
                        TextBox box11 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_3");
                        TextBox box12 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_4");

                        TextBox box13 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_1");
                        TextBox box14 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_2");
                        TextBox box15 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_3");
                        TextBox box16 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_4");

                        TextBox box17 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("txtLeader_DongGoi");

                        TextBox box18 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("txtCable");
                        TextBox box19 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("txtQC_Confirm");

                        TextBox box20 = (TextBox)GridView1.Rows[rowIndex].Cells[12].FindControl("txtSleeve");

                        TextBox box21 = (TextBox)GridView1.Rows[rowIndex].Cells[13].FindControl("txtNhungChi");

                        TextBox box22 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_1");
                        TextBox box23 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_2");
                        TextBox box24 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_3");
                        TextBox box25 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_4");

                        TextBox box26 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_5");
                        TextBox box27 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_6");
                        TextBox box28 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_7");
                        TextBox box29 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_8");

                        TextBox box30 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_9");
                        TextBox box31 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_10");
                        TextBox box32 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_11");
                        TextBox box33 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_12");

                        TextBox box34 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_13");
                        TextBox box35 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_14");
                        TextBox box36 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_15");
                        TextBox box37 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_16");

                        TextBox box38 = (TextBox)GridView1.Rows[rowIndex].Cells[18].FindControl("txtOkDon");

                        box1.Text = dt.Rows[i]["txtSoDon"].ToString();
                        box2.Text = dt.Rows[i]["txtSoLot"].ToString();
                        box3.Text = dt.Rows[i]["txtNgaySanXuat"].ToString();
                        box4.Text = dt.Rows[i]["txtSoLuong"].ToString();
                        box5.Text = dt.Rows[i]["txtSetCable"].ToString();
                        box6.Text = dt.Rows[i]["txtDapSleeve"].ToString();
                        box7.Text = dt.Rows[i]["txtSoLuongDongGoi"].ToString();
                        box8.Text = dt.Rows[i]["txtSoLuongBu"].ToString();
                        box9.Text = dt.Rows[i]["txtMSNV_DongGoi_1"].ToString();
                        box10.Text = dt.Rows[i]["txtMSNV_DongGoi_2"].ToString();
                        box11.Text = dt.Rows[i]["txtMSNV_DongGoi_3"].ToString();
                        box12.Text = dt.Rows[i]["txtMSNV_DongGoi_4"].ToString();
                        box13.Text = dt.Rows[i]["txtMSNV_DongThung_1"].ToString();
                        box14.Text = dt.Rows[i]["txtMSNV_DongThung_2"].ToString();
                        box15.Text = dt.Rows[i]["txtMSNV_DongThung_3"].ToString();
                        box16.Text = dt.Rows[i]["txtMSNV_DongThung_4"].ToString();
                        box17.Text = dt.Rows[i]["txtLeader_DongGoi"].ToString();
                        box18.Text = dt.Rows[i]["txtCable"].ToString();
                        box19.Text = dt.Rows[i]["txtQC_Confirm"].ToString();
                        box20.Text = dt.Rows[i]["txtSleeve"].ToString();
                        box21.Text = dt.Rows[i]["txtNhungChi"].ToString();
                        box22.Text = dt.Rows[i]["txtGiaoNhan_1"].ToString();
                        box23.Text = dt.Rows[i]["txtGiaoNhan_2"].ToString();
                        box24.Text = dt.Rows[i]["txtGiaoNhan_3"].ToString();
                        box25.Text = dt.Rows[i]["txtGiaoNhan_4"].ToString();
                        box26.Text = dt.Rows[i]["txtGiaoNhan_5"].ToString();
                        box27.Text = dt.Rows[i]["txtGiaoNhan_6"].ToString();
                        box28.Text = dt.Rows[i]["txtGiaoNhan_7"].ToString();
                        box29.Text = dt.Rows[i]["txtGiaoNhan_8"].ToString();
                        box30.Text = dt.Rows[i]["txtGiaoNhan_9"].ToString();
                        box31.Text = dt.Rows[i]["txtGiaoNhan_10"].ToString();
                        box32.Text = dt.Rows[i]["txtGiaoNhan_11"].ToString();
                        box33.Text = dt.Rows[i]["txtGiaoNhan_12"].ToString();
                        box34.Text = dt.Rows[i]["txtGiaoNhan_13"].ToString();
                        box35.Text = dt.Rows[i]["txtGiaoNhan_14"].ToString();
                        box36.Text = dt.Rows[i]["txtGiaoNhan_15"].ToString();
                        box37.Text = dt.Rows[i]["txtGiaoNhan_16"].ToString();
                        box38.Text = dt.Rows[i]["txtOkDon"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtSoDon");
                        TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtSoLot");
                        TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtNgaySanXuat");

                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtSoLuong");

                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtSetCable");

                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtDapSleeve");

                        TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtSoLuongDongGoi");

                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txtSoLuongBu");

                        TextBox box9 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_1");
                        TextBox box10 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_2");
                        TextBox box11 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_3");
                        TextBox box12 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_4");

                        TextBox box13 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_1");
                        TextBox box14 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_2");
                        TextBox box15 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_3");
                        TextBox box16 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_4");

                        TextBox box17 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("txtLeader_DongGoi");

                        TextBox box18 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("txtCable");
                        TextBox box19 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("txtQC_Confirm");

                        TextBox box20 = (TextBox)GridView1.Rows[rowIndex].Cells[12].FindControl("txtSleeve");

                        TextBox box21 = (TextBox)GridView1.Rows[rowIndex].Cells[13].FindControl("txtNhungChi");

                        TextBox box22 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_1");
                        TextBox box23 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_2");
                        TextBox box24 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_3");
                        TextBox box25 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_4");

                        TextBox box26 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_5");
                        TextBox box27 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_6");
                        TextBox box28 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_7");
                        TextBox box29 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_8");

                        TextBox box30 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_9");
                        TextBox box31 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_10");
                        TextBox box32 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_11");
                        TextBox box33 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_12");

                        TextBox box34 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_13");
                        TextBox box35 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_14");
                        TextBox box36 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_15");
                        TextBox box37 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_16");

                        TextBox box38 = (TextBox)GridView1.Rows[rowIndex].Cells[18].FindControl("txtOkDon");

                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i - 1]["txtSoDon"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["txtSoLot"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["txtNgaySanXuat"] = box3.Text;

                        dtCurrentTable.Rows[i - 1]["txtSoLuong"] = box4.Text;

                        dtCurrentTable.Rows[i - 1]["txtSetCable"] = box5.Text;

                        dtCurrentTable.Rows[i - 1]["txtDapSleeve"] = box6.Text;

                        dtCurrentTable.Rows[i - 1]["txtSoLuongDongGoi"] = box7.Text;

                        dtCurrentTable.Rows[i - 1]["txtSoLuongBu"] = box8.Text;

                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongGoi_1"] = box9.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongGoi_2"] = box10.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongGoi_3"] = box11.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongGoi_4"] = box12.Text;

                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongThung_1"] = box13.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongThung_2"] = box14.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongThung_3"] = box15.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongThung_4"] = box16.Text;

                        dtCurrentTable.Rows[i - 1]["txtLeader_DongGoi"] = box17.Text;

                        dtCurrentTable.Rows[i - 1]["txtCable"] = box18.Text;
                        dtCurrentTable.Rows[i - 1]["txtQC_Confirm"] = box19.Text;

                        dtCurrentTable.Rows[i - 1]["txtSleeve"] = box20.Text;

                        dtCurrentTable.Rows[i - 1]["txtNhungChi"] = box21.Text;

                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_1"] = box22.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_2"] = box23.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_3"] = box24.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_4"] = box25.Text;

                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_5"] = box26.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_6"] = box27.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_7"] = box28.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_8"] = box29.Text;

                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_9"] = box30.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_10"] = box31.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_11"] = box32.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_12"] = box33.Text;

                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_13"] = box34.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_14"] = box35.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_15"] = box36.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_16"] = box37.Text;

                        dtCurrentTable.Rows[i - 1]["txtOkDon"] = box38.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();

                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }
        protected void InsertDaTaInGridView()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtSoDon");
                        TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtSoLot");
                        TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtNgaySanXuat");

                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtSoLuong");

                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtSetCable");

                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtDapSleeve");

                        TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtSoLuongDongGoi");

                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txtSoLuongBu");

                        TextBox box9 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_1");
                        TextBox box10 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_2");
                        TextBox box11 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_3");
                        TextBox box12 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_4");

                        TextBox box13 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_1");
                        TextBox box14 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_2");
                        TextBox box15 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_3");
                        TextBox box16 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_4");

                        TextBox box17 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("txtLeader_DongGoi");

                        TextBox box18 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("txtCable");
                        TextBox box19 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("txtQC_Confirm");

                        TextBox box20 = (TextBox)GridView1.Rows[rowIndex].Cells[12].FindControl("txtSleeve");

                        TextBox box21 = (TextBox)GridView1.Rows[rowIndex].Cells[13].FindControl("txtNhungChi");

                        TextBox box22 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_1");
                        TextBox box23 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_2");
                        TextBox box24 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_3");
                        TextBox box25 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_4");

                        TextBox box26 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_5");
                        TextBox box27 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_6");
                        TextBox box28 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_7");
                        TextBox box29 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_8");

                        TextBox box30 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_9");
                        TextBox box31 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_10");
                        TextBox box32 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_11");
                        TextBox box33 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_12");

                        TextBox box34 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_13");
                        TextBox box35 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_14");
                        TextBox box36 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_15");
                        TextBox box37 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_16");

                        TextBox box38 = (TextBox)GridView1.Rows[rowIndex].Cells[18].FindControl("txtOkDon");

                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["txtSoDon"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["txtSoLot"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["txtNgaySanXuat"] = box3.Text;

                        dtCurrentTable.Rows[i - 1]["txtSoLuong"] = box4.Text;

                        dtCurrentTable.Rows[i - 1]["txtSetCable"] = box5.Text;

                        dtCurrentTable.Rows[i - 1]["txtDapSleeve"] = box6.Text;

                        dtCurrentTable.Rows[i - 1]["txtSoLuongDongGoi"] = box7.Text;

                        dtCurrentTable.Rows[i - 1]["txtSoLuongBu"] = box8.Text;

                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongGoi_1"] = box9.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongGoi_2"] = box10.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongGoi_3"] = box11.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongGoi_4"] = box12.Text;

                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongThung_1"] = box13.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongThung_2"] = box14.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongThung_3"] = box15.Text;
                        dtCurrentTable.Rows[i - 1]["txtMSNV_DongThung_4"] = box16.Text;

                        dtCurrentTable.Rows[i - 1]["txtLeader_DongGoi"] = box17.Text;

                        dtCurrentTable.Rows[i - 1]["txtCable"] = box18.Text;
                        dtCurrentTable.Rows[i - 1]["txtQC_Confirm"] = box19.Text;

                        dtCurrentTable.Rows[i - 1]["txtSleeve"] = box20.Text;

                        dtCurrentTable.Rows[i - 1]["txtNhungChi"] = box21.Text;

                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_1"] = box22.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_2"] = box23.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_3"] = box24.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_4"] = box25.Text;

                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_5"] = box26.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_6"] = box27.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_7"] = box28.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_8"] = box29.Text;

                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_9"] = box30.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_10"] = box31.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_11"] = box32.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_12"] = box33.Text;

                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_13"] = box34.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_14"] = box35.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_15"] = box36.Text;
                        dtCurrentTable.Rows[i - 1]["txtGiaoNhan_16"] = box37.Text;

                        dtCurrentTable.Rows[i - 1]["txtOkDon"] = box38.Text;
                        rowIndex++;
                    }
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }
        protected void btnDeleteRow_Click(object sender, EventArgs e)
        {
            InsertDaTaInGridView();

            DataTable newdt = (DataTable)ViewState["CurrentTable"];
            for (int i = GridView1.Rows.Count - 1; i >= 0; i--)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    int RecordID = Convert.ToInt32(i);
                    newdt.Rows.RemoveAt(RecordID);
                }
            }
            newdt.AcceptChanges();
            GridView1.DataSource = newdt;
            GridView1.DataBind();
            SetPreviousData();
            if (GridView1.Rows.Count < 1)
            {
                SetInitialRow();
            }
            EnableField();
        }
        private void EnableField()
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox CheckBox1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                TextBox txtSoDon = (TextBox)GridView1.Rows[i].FindControl("txtSoDon");
                TextBox txtSoLot = (TextBox)GridView1.Rows[i].FindControl("txtSoLot");
                TextBox txtNgaySanXuat = (TextBox)GridView1.Rows[i].FindControl("txtNgaySanXuat");
                TextBox txtSoLuong = (TextBox)GridView1.Rows[i].FindControl("txtSoLuong");
                TextBox txtSetCable = (TextBox)GridView1.Rows[i].FindControl("txtSetCable");
                TextBox txtDapSleeve = (TextBox)GridView1.Rows[i].FindControl("txtDapSleeve");
                TextBox txtSoLuongDongGoi = (TextBox)GridView1.Rows[i].FindControl("txtSoLuongDongGoi");
                TextBox txtSoLuongBu = (TextBox)GridView1.Rows[i].FindControl("txtSoLuongBu");
                TextBox txtMSNV_DongGoi_1 = (TextBox)GridView1.Rows[i].FindControl("txtMSNV_DongGoi_1");
                TextBox txtMSNV_DongGoi_2 = (TextBox)GridView1.Rows[i].FindControl("txtMSNV_DongGoi_2");
                TextBox txtMSNV_DongGoi_3 = (TextBox)GridView1.Rows[i].FindControl("txtMSNV_DongGoi_3");
                TextBox txtMSNV_DongGoi_4 = (TextBox)GridView1.Rows[i].FindControl("txtMSNV_DongGoi_4");
                TextBox txtMSNV_DongThung_1 = (TextBox)GridView1.Rows[i].FindControl("txtMSNV_DongThung_1");
                TextBox txtMSNV_DongThung_2 = (TextBox)GridView1.Rows[i].FindControl("txtMSNV_DongThung_2");
                TextBox txtMSNV_DongThung_3 = (TextBox)GridView1.Rows[i].FindControl("txtMSNV_DongThung_3");
                TextBox txtMSNV_DongThung_4 = (TextBox)GridView1.Rows[i].FindControl("txtMSNV_DongThung_4");
                TextBox txtLeader_DongGoi = (TextBox)GridView1.Rows[i].FindControl("txtLeader_DongGoi");
                TextBox txtCable = (TextBox)GridView1.Rows[i].FindControl("txtCable");
                TextBox txtQC_Confirm = (TextBox)GridView1.Rows[i].FindControl("txtQC_Confirm");
                TextBox txtSleeve = (TextBox)GridView1.Rows[i].FindControl("txtSleeve");
                TextBox txtNhungChi = (TextBox)GridView1.Rows[i].FindControl("txtNhungChi");
                TextBox txtGiaoNhan_1 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_1");
                TextBox txtGiaoNhan_2 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_2");
                TextBox txtGiaoNhan_3 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_3");
                TextBox txtGiaoNhan_4 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_4");
                TextBox txtGiaoNhan_5 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_5");
                TextBox txtGiaoNhan_6 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_6");
                TextBox txtGiaoNhan_7 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_7");
                TextBox txtGiaoNhan_8 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_8");
                TextBox txtGiaoNhan_9 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_9");
                TextBox txtGiaoNhan_10 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_10");
                TextBox txtGiaoNhan_11 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_11");
                TextBox txtGiaoNhan_12 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_12");
                TextBox txtGiaoNhan_13 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_13");
                TextBox txtGiaoNhan_14 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_14");
                TextBox txtGiaoNhan_15 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_15");
                TextBox txtGiaoNhan_16 = (TextBox)GridView1.Rows[i].FindControl("txtGiaoNhan_16");
                TextBox txtOkDon = (TextBox)GridView1.Rows[i].FindControl("txtOkDon");
               
                CheckBox1.Enabled = true;
                txtSoDon.Enabled = true;
                txtSoLot.Enabled = true;
                txtNgaySanXuat.Enabled = true;
                txtSoLuong.Enabled = true;
                txtSetCable.Enabled = true;
                txtDapSleeve.Enabled = true;
                txtSoLuongDongGoi.Enabled = true;
                txtSoLuongBu.Enabled = true;
                txtMSNV_DongGoi_1.Enabled = true;
                txtMSNV_DongGoi_2.Enabled = true;
                txtMSNV_DongGoi_3.Enabled = true;
                txtMSNV_DongGoi_4.Enabled = true;
                txtMSNV_DongThung_1.Enabled = true;
                txtMSNV_DongThung_2.Enabled = true;
                txtMSNV_DongThung_3.Enabled = true;
                txtMSNV_DongThung_4.Enabled = true;
                txtLeader_DongGoi.Enabled = true;
                txtCable.Enabled = true;
                txtQC_Confirm.Enabled = true;
                txtSleeve.Enabled = true;
                txtNhungChi.Enabled = true;
                txtGiaoNhan_1.Enabled = true;
                txtGiaoNhan_2.Enabled = true;
                txtGiaoNhan_3.Enabled = true;
                txtGiaoNhan_4.Enabled = true;
                txtGiaoNhan_5.Enabled = true;
                txtGiaoNhan_6.Enabled = true;
                txtGiaoNhan_7.Enabled = true;
                txtGiaoNhan_8.Enabled = true;
                txtGiaoNhan_9.Enabled = true;
                txtGiaoNhan_10.Enabled = true;
                txtGiaoNhan_11.Enabled = true;
                txtGiaoNhan_12.Enabled = true;
                txtGiaoNhan_13.Enabled = true;
                txtGiaoNhan_14.Enabled = true;
                txtGiaoNhan_15.Enabled = true;
                txtGiaoNhan_16.Enabled = true;
                txtOkDon.Enabled = true;
            }
        }
        private string PhatSinhSoPhieu()
        {
            string Auto_IDPhieu = string.Format("{0:yyMM}", DateTime.Now.Date);
            SqlParameter[] paramet = new SqlParameter[]
                                  {
                                    SQLhelper.CreateParameter("@IDPhieu", Auto_IDPhieu),
                                  };
            object chuoi = SQLhelper.ExecuteScala("Books_Kashime_Auto_IDPhieu_SoThaoTac", paramet);
            if (chuoi == null)
            {
                Auto_IDPhieu += "001";
            }
            else
            {
                string strChuoi = chuoi.ToString();
                //count = chuoi + 1;
                if (!string.IsNullOrEmpty(strChuoi))
                {
                    int count = int.Parse(strChuoi.Substring(4)) + 1;
                    if (count < 10)
                        Auto_IDPhieu += "00" + count.ToString();
                    else if (count < 100)
                        Auto_IDPhieu += "0" + count.ToString();
                    else if (count < 1000)
                        Auto_IDPhieu += "" + count.ToString();
                    else
                        Auto_IDPhieu += count.ToString();
                }
                else Auto_IDPhieu += "001";
            }
            return Auto_IDPhieu;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblID_Phieu.Text))
            {
                if (Check_Data_Save() == true && Check_Data_Save_Detail() == true)
                {
                    string TrangThai = "Drawing";
                    string ID_Phieu = PhatSinhSoPhieu();
                    int insert = SQLhelper.ExecuteNonQuery("Books_Kashime_Insert_SoThaoTac_Data", new SqlParameter[] {
                        new SqlParameter("@ID_Phieu",ID_Phieu),
                        new SqlParameter("@Line",txtLine.Text),
                        new SqlParameter("@BanVe",txtBanVe.Text),
                        new SqlParameter("@MaSanPham",txtMaSanPham.Text),
                        new SqlParameter("@TenSanPham",txtTenSanPham.Text),
                        new SqlParameter("@NgayThaoTac",txtNgayThaoTac.Text),
                        new SqlParameter("@NguoiDamNhiem",txtNguoiDamNhiem.Text),
                        new SqlParameter("@HoiMayDay",txtHoiMayDap.Text),
                        new SqlParameter("@MayCable1",txtCable1.Text),
                        new SqlParameter("@MayCable2",txtCable2.Text),
                        new SqlParameter("@MayCable3",txtCable3.Text),
                        new SqlParameter("@MayCable4",txtCable4.Text),
                        new SqlParameter("@MayCable5",txtCable5.Text),
                        new SqlParameter("@Sleeve1",txtSlevee1.Text),
                        new SqlParameter("@Sleeve2",txtSlevee2.Text),
                        new SqlParameter("@Sleeve3",txtSlevee3.Text),
                        new SqlParameter("@Sleeve4",txtSlevee4.Text),
                        new SqlParameter("@Sleeve5",txtSlevee5.Text),
                        new SqlParameter("@TrangThai",TrangThai),
                        new SqlParameter("@NguoiNhap",Session["Ten"].ToString())
                });
                 foreach (GridViewRow row in GridView1.Rows)
                    {
                        TextBox NO_Don = (TextBox)row.FindControl("txtSoDon");
                        string txtNO_Don = NO_Don.Text;

                        TextBox So_Lot = (TextBox)row.FindControl("txtSoLot");
                        string txtSo_Lot = So_Lot.Text;

                        TextBox NgaySX = (TextBox)row.FindControl("txtNgaySanXuat");
                        string txtNgaySanXuat = NgaySX.Text;

                        TextBox SoLuong = (TextBox)row.FindControl("txtSoLuong");
                        string txtSoLuong = SoLuong.Text;

                        TextBox SetCable = (TextBox)row.FindControl("txtSetCable");
                        string txtSetCable = SetCable.Text;

                        TextBox Dap_Sleeve = (TextBox)row.FindControl("txtDapSleeve");
                        string txtDapSleeve = Dap_Sleeve.Text;

                        TextBox SLDongGoi = (TextBox)row.FindControl("txtSoLuongDongGoi");
                        string txtSoLuongDongGoi = SLDongGoi.Text;

                        TextBox SLBoSung = (TextBox)row.FindControl("txtSoLuongBu");
                        string txtSoLuongBu = SLBoSung.Text;

                        TextBox NguoiDongGoi1 = (TextBox)row.FindControl("txtMSNV_DongGoi_1");
                        string txtMSNV_DongGoi_1 = NguoiDongGoi1.Text;

                        TextBox NguoiDongGoi2 = (TextBox)row.FindControl("txtMSNV_DongGoi_2");
                        string txtMSNV_DongGoi_2 = NguoiDongGoi2.Text;

                        TextBox NguoiDongGoi3 = (TextBox)row.FindControl("txtMSNV_DongGoi_3");
                        string txtMSNV_DongGoi_3 = NguoiDongGoi3.Text;

                        TextBox NguoiDongGoi4 = (TextBox)row.FindControl("txtMSNV_DongGoi_4");
                        string txtMSNV_DongGoi_4 = NguoiDongGoi4.Text;

                        TextBox NguoiDongThung1 = (TextBox)row.FindControl("txtMSNV_DongThung_1");
                        string txtMSNV_DongThung_1 = NguoiDongThung1.Text;

                        TextBox NguoiDongThung2 = (TextBox)row.FindControl("txtMSNV_DongThung_2");
                        string txtMSNV_DongThung_2 = NguoiDongThung2.Text;

                        TextBox NguoiDongThung3 = (TextBox)row.FindControl("txtMSNV_DongThung_3");
                        string txtMSNV_DongThung_3 = NguoiDongThung3.Text;

                        TextBox NguoiDongThung4 = (TextBox)row.FindControl("txtMSNV_DongThung_4");
                        string txtMSNV_DongThung_4 = NguoiDongThung4.Text;

                        TextBox LeaderDongGoi = (TextBox)row.FindControl("txtLeader_DongGoi");
                        string txtLeader_DongGoi = LeaderDongGoi.Text;

                        TextBox Cable = (TextBox)row.FindControl("txtCable");
                        string txtCable = Cable.Text;

                        TextBox QC_Confirm = (TextBox)row.FindControl("txtQC_Confirm");
                        string txtQC_Confirm = QC_Confirm.Text;

                        TextBox Sleeve = (TextBox)row.FindControl("txtSleeve");
                        string txtSleeve = Sleeve.Text;

                        TextBox NhungChi = (TextBox)row.FindControl("txtNhungChi");
                        string txtNhungChi = NhungChi.Text;

                        TextBox GiaoNhan_1 = (TextBox)row.FindControl("txtGiaoNhan_1");
                        string txtGiaoNhan_1 = GiaoNhan_1.Text;

                        TextBox GiaoNhan_2 = (TextBox)row.FindControl("txtGiaoNhan_2");
                        string txtGiaoNhan_2 = GiaoNhan_2.Text;

                        TextBox GiaoNhan_3 = (TextBox)row.FindControl("txtGiaoNhan_3");
                        string txtGiaoNhan_3 = GiaoNhan_3.Text;

                        TextBox GiaoNhan_4 = (TextBox)row.FindControl("txtGiaoNhan_4");
                        string txtGiaoNhan_4 = GiaoNhan_4.Text;

                        TextBox GiaoNhan_5 = (TextBox)row.FindControl("txtGiaoNhan_5");
                        string txtGiaoNhan_5 = GiaoNhan_5.Text;

                        TextBox GiaoNhan_6 = (TextBox)row.FindControl("txtGiaoNhan_6");
                        string txtGiaoNhan_6 = GiaoNhan_6.Text;

                        TextBox GiaoNhan_7 = (TextBox)row.FindControl("txtGiaoNhan_7");
                        string txtGiaoNhan_7 = GiaoNhan_7.Text;

                        TextBox GiaoNhan_8 = (TextBox)row.FindControl("txtGiaoNhan_8");
                        string txtGiaoNhan_8 = GiaoNhan_8.Text;

                        TextBox GiaoNhan_9 = (TextBox)row.FindControl("txtGiaoNhan_9");
                        string txtGiaoNhan_9 = GiaoNhan_9.Text;

                        TextBox GiaoNhan_10 = (TextBox)row.FindControl("txtGiaoNhan_10");
                        string txtGiaoNhan_10 = GiaoNhan_10.Text;

                        TextBox GiaoNhan_11 = (TextBox)row.FindControl("txtGiaoNhan_11");
                        string txtGiaoNhan_11 = GiaoNhan_11.Text;

                        TextBox GiaoNhan_12 = (TextBox)row.FindControl("txtGiaoNhan_12");
                        string txtGiaoNhan_12 = GiaoNhan_12.Text;

                        TextBox GiaoNhan_13 = (TextBox)row.FindControl("txtGiaoNhan_13");
                        string txtGiaoNhan_13 = GiaoNhan_13.Text;

                        TextBox GiaoNhan_14 = (TextBox)row.FindControl("txtGiaoNhan_14");
                        string txtGiaoNhan_14 = GiaoNhan_14.Text;

                        TextBox GiaoNhan_15 = (TextBox)row.FindControl("txtGiaoNhan_15");
                        string txtGiaoNhan_15 = GiaoNhan_15.Text;

                        TextBox GiaoNhan_16 = (TextBox)row.FindControl("txtGiaoNhan_16");
                        string txtGiaoNhan_16 = GiaoNhan_16.Text;

                        TextBox OkeDon = (TextBox)row.FindControl("txtOkDon");
                        string txtOkDon = OkeDon.Text;

                        int insert_datadetail = SQLhelper.ExecuteNonQuery("Books_Kashime_Insert_SoThaoTac_Data_Detail", new SqlParameter[] {
                         new SqlParameter("@ID_Phieu",ID_Phieu),
                         new SqlParameter("@NO_Phieu",NO_Phieu),
                         new SqlParameter("@NO_Don",txtNO_Don),
                         new SqlParameter("@So_Lot",txtSo_Lot),
                         new SqlParameter("@NgaySX",txtNgaySanXuat),
                         new SqlParameter("@SoLuong",txtSoLuong),
                         new SqlParameter("@SetCable",txtSetCable),
                         new SqlParameter("@Dap_Sleeve",txtDapSleeve),
                         new SqlParameter("@SLDongGoi",txtSoLuongDongGoi),
                         new SqlParameter("@SLBoSung",txtSoLuongBu),
                         new SqlParameter("@NguoiDongGoi1",txtMSNV_DongGoi_1),
                         new SqlParameter("@NguoiDongGoi2",txtMSNV_DongGoi_2),
                         new SqlParameter("@NguoiDongGoi3",txtMSNV_DongGoi_3),
                         new SqlParameter("@NguoiDongGoi4",txtMSNV_DongGoi_4),
                         new SqlParameter("@NguoiDongThung1",txtMSNV_DongThung_1),
                         new SqlParameter("@NguoiDongThung2",txtMSNV_DongThung_2),
                         new SqlParameter("@NguoiDongThung3",txtMSNV_DongThung_3),
                         new SqlParameter("@NguoiDongThung4",txtMSNV_DongThung_4),
                         new SqlParameter("@LeaderDongGoi",txtLeader_DongGoi),
                         new SqlParameter("@Cable",txtCable),
                         new SqlParameter("@QC_Confirm",txtQC_Confirm),
                         new SqlParameter("@Sleeve",txtSleeve),
                         new SqlParameter("@NhungChi",txtNhungChi),
                         new SqlParameter("@GiaoNhan_1",txtGiaoNhan_1),
                         new SqlParameter("@GiaoNhan_2",txtGiaoNhan_2),
                         new SqlParameter("@GiaoNhan_3",txtGiaoNhan_3),
                         new SqlParameter("@GiaoNhan_4",txtGiaoNhan_4),
                         new SqlParameter("@GiaoNhan_5",txtGiaoNhan_5),
                         new SqlParameter("@GiaoNhan_6",txtGiaoNhan_6),
                         new SqlParameter("@GiaoNhan_7",txtGiaoNhan_7),
                         new SqlParameter("@GiaoNhan_8",txtGiaoNhan_8),
                         new SqlParameter("@GiaoNhan_9",txtGiaoNhan_9),
                         new SqlParameter("@GiaoNhan_10",txtGiaoNhan_10),
                         new SqlParameter("@GiaoNhan_11",txtGiaoNhan_11),
                         new SqlParameter("@GiaoNhan_12",txtGiaoNhan_12),
                         new SqlParameter("@GiaoNhan_13",txtGiaoNhan_13),
                         new SqlParameter("@GiaoNhan_14",txtGiaoNhan_14),
                         new SqlParameter("@GiaoNhan_15",txtGiaoNhan_15),
                         new SqlParameter("@GiaoNhan_16",txtGiaoNhan_16),
                         new SqlParameter("@XacNhanDon",txtOkDon),
                    });
                        NO_Phieu++;
                    }
                    MsgBox("lưu Thành Công!");
                    Load_Data_ID_Phieu(ID_Phieu);
                }
            }
            else
            {
                if (Check_Data_Save() == true && Check_Data_Save_Detail() == true)
                {
                    string TrangThai = "Drawing";
                    string ID_Phieu_Update = ThaoTacDuLieu.Decrypt_V1(lblID_Phieu.Text, "NisseiTL1LGMyTho");
                    int insert = SQLhelper.ExecuteNonQuery("Books_Kashime_Update_SoThaoTac_Data", new SqlParameter[] {
                        new SqlParameter("@ID_Phieu",ID_Phieu_Update),
                        new SqlParameter("@Line",txtLine.Text),
                        new SqlParameter("@BanVe",txtBanVe.Text),
                        new SqlParameter("@MaSanPham",txtMaSanPham.Text),
                        new SqlParameter("@TenSanPham",txtTenSanPham.Text),
                        new SqlParameter("@NgayThaoTac",txtNgayThaoTac.Text),
                        new SqlParameter("@NguoiDamNhiem",txtNguoiDamNhiem.Text),
                        new SqlParameter("@HoiMayDay",txtHoiMayDap.Text),
                        new SqlParameter("@MayCable1",txtCable1.Text),
                        new SqlParameter("@MayCable2",txtCable2.Text),
                        new SqlParameter("@MayCable3",txtCable3.Text),
                        new SqlParameter("@MayCable4",txtCable4.Text),
                        new SqlParameter("@MayCable5",txtCable5.Text),
                        new SqlParameter("@Sleeve1",txtSlevee1.Text),
                        new SqlParameter("@Sleeve2",txtSlevee2.Text),
                        new SqlParameter("@Sleeve3",txtSlevee3.Text),
                        new SqlParameter("@Sleeve4",txtSlevee4.Text),
                        new SqlParameter("@Sleeve5",txtSlevee5.Text),
                        new SqlParameter("@TrangThai",TrangThai),
                        new SqlParameter("@NguoiNhap",Session["Ten"].ToString())
                });
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        TextBox NO_Don = (TextBox)row.FindControl("txtSoDon");
                        string txtNO_Don = NO_Don.Text;

                        TextBox So_Lot = (TextBox)row.FindControl("txtSoLot");
                        string txtSo_Lot = So_Lot.Text;

                        TextBox NgaySX = (TextBox)row.FindControl("txtNgaySanXuat");
                        string txtNgaySanXuat = NgaySX.Text;

                        TextBox SoLuong = (TextBox)row.FindControl("txtSoLuong");
                        string txtSoLuong = SoLuong.Text;

                        TextBox SetCable = (TextBox)row.FindControl("txtSetCable");
                        string txtSetCable = SetCable.Text;

                        TextBox Dap_Sleeve = (TextBox)row.FindControl("txtDapSleeve");
                        string txtDapSleeve = Dap_Sleeve.Text;

                        TextBox SLDongGoi = (TextBox)row.FindControl("txtSoLuongDongGoi");
                        string txtSoLuongDongGoi = SLDongGoi.Text;

                        TextBox SLBoSung = (TextBox)row.FindControl("txtSoLuongBu");
                        string txtSoLuongBu = SLBoSung.Text;

                        TextBox NguoiDongGoi1 = (TextBox)row.FindControl("txtMSNV_DongGoi_1");
                        string txtMSNV_DongGoi_1 = NguoiDongGoi1.Text;

                        TextBox NguoiDongGoi2 = (TextBox)row.FindControl("txtMSNV_DongGoi_2");
                        string txtMSNV_DongGoi_2 = NguoiDongGoi2.Text;

                        TextBox NguoiDongGoi3 = (TextBox)row.FindControl("txtMSNV_DongGoi_3");
                        string txtMSNV_DongGoi_3 = NguoiDongGoi3.Text;

                        TextBox NguoiDongGoi4 = (TextBox)row.FindControl("txtMSNV_DongGoi_4");
                        string txtMSNV_DongGoi_4 = NguoiDongGoi4.Text;

                        TextBox NguoiDongThung1 = (TextBox)row.FindControl("txtMSNV_DongThung_1");
                        string txtMSNV_DongThung_1 = NguoiDongThung1.Text;

                        TextBox NguoiDongThung2 = (TextBox)row.FindControl("txtMSNV_DongThung_2");
                        string txtMSNV_DongThung_2 = NguoiDongThung2.Text;

                        TextBox NguoiDongThung3 = (TextBox)row.FindControl("txtMSNV_DongThung_3");
                        string txtMSNV_DongThung_3 = NguoiDongThung3.Text;

                        TextBox NguoiDongThung4 = (TextBox)row.FindControl("txtMSNV_DongThung_4");
                        string txtMSNV_DongThung_4 = NguoiDongThung4.Text;

                        TextBox LeaderDongGoi = (TextBox)row.FindControl("txtLeader_DongGoi");
                        string txtLeader_DongGoi = LeaderDongGoi.Text;

                        TextBox Cable = (TextBox)row.FindControl("txtCable");
                        string txtCable = Cable.Text;

                        TextBox QC_Confirm = (TextBox)row.FindControl("txtQC_Confirm");
                        string txtQC_Confirm = QC_Confirm.Text;

                        TextBox Sleeve = (TextBox)row.FindControl("txtSleeve");
                        string txtSleeve = Sleeve.Text;

                        TextBox NhungChi = (TextBox)row.FindControl("txtNhungChi");
                        string txtNhungChi = NhungChi.Text;

                        TextBox GiaoNhan_1 = (TextBox)row.FindControl("txtGiaoNhan_1");
                        string txtGiaoNhan_1 = GiaoNhan_1.Text;

                        TextBox GiaoNhan_2 = (TextBox)row.FindControl("txtGiaoNhan_2");
                        string txtGiaoNhan_2 = GiaoNhan_2.Text;

                        TextBox GiaoNhan_3 = (TextBox)row.FindControl("txtGiaoNhan_3");
                        string txtGiaoNhan_3 = GiaoNhan_3.Text;

                        TextBox GiaoNhan_4 = (TextBox)row.FindControl("txtGiaoNhan_4");
                        string txtGiaoNhan_4 = GiaoNhan_4.Text;

                        TextBox GiaoNhan_5 = (TextBox)row.FindControl("txtGiaoNhan_5");
                        string txtGiaoNhan_5 = GiaoNhan_5.Text;

                        TextBox GiaoNhan_6 = (TextBox)row.FindControl("txtGiaoNhan_6");
                        string txtGiaoNhan_6 = GiaoNhan_6.Text;

                        TextBox GiaoNhan_7 = (TextBox)row.FindControl("txtGiaoNhan_7");
                        string txtGiaoNhan_7 = GiaoNhan_7.Text;

                        TextBox GiaoNhan_8 = (TextBox)row.FindControl("txtGiaoNhan_8");
                        string txtGiaoNhan_8 = GiaoNhan_8.Text;

                        TextBox GiaoNhan_9 = (TextBox)row.FindControl("txtGiaoNhan_9");
                        string txtGiaoNhan_9 = GiaoNhan_9.Text;

                        TextBox GiaoNhan_10 = (TextBox)row.FindControl("txtGiaoNhan_10");
                        string txtGiaoNhan_10 = GiaoNhan_10.Text;

                        TextBox GiaoNhan_11 = (TextBox)row.FindControl("txtGiaoNhan_11");
                        string txtGiaoNhan_11 = GiaoNhan_11.Text;

                        TextBox GiaoNhan_12 = (TextBox)row.FindControl("txtGiaoNhan_12");
                        string txtGiaoNhan_12 = GiaoNhan_12.Text;

                        TextBox GiaoNhan_13 = (TextBox)row.FindControl("txtGiaoNhan_13");
                        string txtGiaoNhan_13 = GiaoNhan_13.Text;

                        TextBox GiaoNhan_14 = (TextBox)row.FindControl("txtGiaoNhan_14");
                        string txtGiaoNhan_14 = GiaoNhan_14.Text;

                        TextBox GiaoNhan_15 = (TextBox)row.FindControl("txtGiaoNhan_15");
                        string txtGiaoNhan_15 = GiaoNhan_15.Text;

                        TextBox GiaoNhan_16 = (TextBox)row.FindControl("txtGiaoNhan_16");
                        string txtGiaoNhan_16 = GiaoNhan_16.Text;

                        TextBox OkeDon = (TextBox)row.FindControl("txtOkDon");
                        string txtOkDon = OkeDon.Text;

                        int Update_Detail = SQLhelper.ExecuteNonQuery("Books_Kashime_Update_SoThaoTac_Data_Detail", new SqlParameter[] {
                         new SqlParameter("ID_Phieu",ID_Phieu_Update),
                         new SqlParameter("@NO_Phieu",NO_Phieu),
                         new SqlParameter("@NO_Don",txtNO_Don),
                         new SqlParameter("@So_Lot",txtSo_Lot),
                         new SqlParameter("@NgaySX",txtNgaySanXuat),
                         new SqlParameter("@SoLuong",txtSoLuong),
                         new SqlParameter("@SetCable",txtSetCable),
                         new SqlParameter("@Dap_Sleeve",txtDapSleeve),
                         new SqlParameter("@SLDongGoi",txtSoLuongDongGoi),
                         new SqlParameter("@SLBoSung",txtSoLuongBu),
                         new SqlParameter("@NguoiDongGoi1",txtMSNV_DongGoi_1),
                         new SqlParameter("@NguoiDongGoi2",txtMSNV_DongGoi_2),
                         new SqlParameter("@NguoiDongGoi3",txtMSNV_DongGoi_3),
                         new SqlParameter("@NguoiDongGoi4",txtMSNV_DongGoi_4),
                         new SqlParameter("@NguoiDongThung1",txtMSNV_DongThung_1),
                         new SqlParameter("@NguoiDongThung2",txtMSNV_DongThung_2),
                         new SqlParameter("@NguoiDongThung3",txtMSNV_DongThung_3),
                         new SqlParameter("@NguoiDongThung4",txtMSNV_DongThung_4),
                         new SqlParameter("@LeaderDongGoi",txtLeader_DongGoi),
                         new SqlParameter("@Cable",txtCable),
                         new SqlParameter("@QC_Confirm",txtQC_Confirm),
                         new SqlParameter("@Sleeve",txtSleeve),
                         new SqlParameter("@NhungChi",txtNhungChi),
                         new SqlParameter("@GiaoNhan_1",txtGiaoNhan_1),
                         new SqlParameter("@GiaoNhan_2",txtGiaoNhan_2),
                         new SqlParameter("@GiaoNhan_3",txtGiaoNhan_3),
                         new SqlParameter("@GiaoNhan_4",txtGiaoNhan_4),
                         new SqlParameter("@GiaoNhan_5",txtGiaoNhan_5),
                         new SqlParameter("@GiaoNhan_6",txtGiaoNhan_6),
                         new SqlParameter("@GiaoNhan_7",txtGiaoNhan_7),
                         new SqlParameter("@GiaoNhan_8",txtGiaoNhan_8),
                         new SqlParameter("@GiaoNhan_9",txtGiaoNhan_9),
                         new SqlParameter("@GiaoNhan_10",txtGiaoNhan_10),
                         new SqlParameter("@GiaoNhan_11",txtGiaoNhan_11),
                         new SqlParameter("@GiaoNhan_12",txtGiaoNhan_12),
                         new SqlParameter("@GiaoNhan_13",txtGiaoNhan_13),
                         new SqlParameter("@GiaoNhan_14",txtGiaoNhan_14),
                         new SqlParameter("@GiaoNhan_15",txtGiaoNhan_15),
                         new SqlParameter("@GiaoNhan_16",txtGiaoNhan_16),
                         new SqlParameter("@XacNhanDon",txtOkDon),
                    });
                        NO_Phieu++;
                    }
                    NO_Phieu = 1;
                    MsgBox("Cập Nhật Thành Công!");
                    Load_Data_ID_Phieu(ID_Phieu_Update);
                }
            }
            Check_Finished();
        }
        private bool Check_Data_Save()
        {
            if (string.IsNullOrEmpty(txtLine.Text))
            {
                MsgBox("Chưa Nhập Số Line");
                return false;
            }
            if (string.IsNullOrEmpty(txtBanVe.Text))
            {
                MsgBox("Chưa Nhập Bản Vẽ");
                return false;
            }
            if (string.IsNullOrEmpty(txtMaSanPham.Text))
            {
                MsgBox("Chưa Nhập Mã Sản Phẩm");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                MsgBox("Chưa Nhập Tên Sản Phẩm");
                return false;
            }
            if (string.IsNullOrEmpty(txtNgayThaoTac.Text))
            {
                MsgBox("Chưa Nhập Ngày Thao Tác");
                return false;
            }
            if (string.IsNullOrEmpty(txtNguoiDamNhiem.Text))
            {
                MsgBox("Chưa Nhập Người Đảm Nhiệm");
                return false;
            }
            if (string.IsNullOrEmpty(txtHoiMayDap.Text))
            {
                MsgBox("Chưa Nhập Hơi Máy Dậy");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool Check_Data_Save_Detail()
        {
            bool KQ = true;
            string ThongBao = "";
            for(int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox txtSoDon = (TextBox)GridView1.Rows[i].FindControl("txtSoDon");
                TextBox txtSoLot = (TextBox)GridView1.Rows[i].FindControl("txtSoLot");
                TextBox txtNgaySanXuat = (TextBox)GridView1.Rows[i].FindControl("txtNgaySanXuat");
                TextBox txtSoLuong = (TextBox)GridView1.Rows[i].FindControl("txtSoLuong");
                TextBox txtSetCable = (TextBox)GridView1.Rows[i].FindControl("txtSetCable");
                int Dong = i + 1;
                if (string.IsNullOrEmpty(txtSoDon.Text))
                {
                    ThongBao += "\\n + Chưa Nhập Item Tại Dòng Thứ: " + Dong;
                }
                if (string.IsNullOrEmpty(txtSoLot.Text))
                {
                    ThongBao += "\\n + Chưa Nhập Item Tại Dòng Thứ: " + Dong;
                }
                if (string.IsNullOrEmpty(txtNgaySanXuat.Text))
                {
                    ThongBao += "\\n + Chưa Nhập Item Tại Dòng Thứ: " + Dong;
                }
                if (string.IsNullOrEmpty(txtSoLuong.Text))
                {
                    ThongBao += "\\n + Chưa Nhập Item Tại Dòng Thứ: " + Dong;
                }
                if (string.IsNullOrEmpty(txtSetCable.Text))
                {
                    ThongBao += "\\n + Chưa Nhập Item Tại Dòng Thứ: " + Dong;
                }
                if (!string.IsNullOrEmpty(ThongBao.Trim()))
                {
                    MsgBox(ThongBao);
                    KQ = false;
                }
            }
            return KQ;
        }

        private void Check_Finished()
        {
            string Decrpyt_Check = ThaoTacDuLieu.Decrypt_V1(lblID_Phieu.Text, "NisseiTL1LGMyTho");
            DataTable dtcheck_Finished = new DataTable();
            dtcheck_Finished = SQLhelper.ExecuteDataTable("Book_Kashime_Check_Fisnished_SoThaoTac", new SqlParameter[]
            {
                     new SqlParameter("@ID_Phieu", Decrpyt_Check)
            });

            if (dtcheck_Finished.Rows.Count > 0)
            {
                List<string> maSoList = new List<string>();

                foreach (DataRow row in dtcheck_Finished.Rows)
                {
                    string maSo = row["XacNhanDon"].ToString();
                    maSoList.Add(maSo);
                }

                string[] maSoArray = maSoList.ToArray();

                // Kiểm tra nếu mảng không có phần tử nào là null hoặc rỗng
                if (maSoArray.All(maSo => !string.IsNullOrEmpty(maSo)))
                {
                    lblTrangThai.Text = "Finished";
                    DataTable dt = new DataTable();
                    dt = SQLhelper.ExecuteDataTable("Book_Kashime_Update_Fisnished_SoThaoTac",new SqlParameter[]
                   {
                            new SqlParameter("@ID_Phieu", Decrpyt_Check),
                    });
                }
                else
                {
                    lblTrangThai.Text = "Drawing";
                }
            }
            else
            {
                lblTrangThai.Text = "Drawing";
            }
        }
        private void Load_Data_ID_Phieu(string ID_Phieu_Decrypt)
        {
            DataTable dt = SQLhelper.GetDataToTable("Books_Kashime_Get_SoThaoTac_By_ID_Phieu", new SqlParameter[] {
                    SQLhelper.CreateParameter("@ID_Phieu",ID_Phieu_Decrypt),
                });
            if (dt.Rows.Count > 0)
            {
                txtLine.Text = dt.Rows[0].Field<string>("Line").ToString() ?? string.Empty;
                txtBanVe.Text = dt.Rows[0].Field<string>("BanVe").ToString() ?? string.Empty;
                txtMaSanPham.Text = dt.Rows[0].Field<string>("MaSanPham").ToString() ?? string.Empty;
                txtTenSanPham.Text = dt.Rows[0].Field<string>("TenSanPham").ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0].Field<DateTime?>("NgayThaoTac"))))
                {
                    txtNgayThaoTac.Text = dt.Rows[0].Field<DateTime>("NgayThaoTac").ToString("yyyy-MM-dd") ?? string.Empty;
                }
                if (dt.Rows[0]["NguoiDamNhiem"] != DBNull.Value)
                {
                    txtNguoiDamNhiem.Text = dt.Rows[0].Field<string>("NguoiDamNhiem") ?? string.Empty;
                }
                if (dt.Rows[0]["HoiMayDay"] != DBNull.Value)
                {
                    txtHoiMayDap.Text = dt.Rows[0].Field<string>("HoiMayDay") ?? string.Empty;
                }
                if (dt.Rows[0]["MayCable1"] != DBNull.Value)
                {
                    txtCable1.Text = dt.Rows[0].Field<string>("MayCable1") ?? string.Empty;
                }
                if (dt.Rows[0]["MayCable2"] != DBNull.Value)
                {
                    txtCable2.Text = dt.Rows[0].Field<string>("MayCable2") ?? string.Empty;
                }
                if (dt.Rows[0]["MayCable3"] != DBNull.Value)
                {
                    txtCable3.Text = dt.Rows[0].Field<string>("MayCable3") ?? string.Empty;
                }
                if (dt.Rows[0]["MayCable4"] != DBNull.Value)
                {
                    txtCable4.Text = dt.Rows[0].Field<string>("MayCable4") ?? string.Empty;
                }
                if (dt.Rows[0]["MayCable5"] != DBNull.Value)
                {
                    txtCable5.Text = dt.Rows[0].Field<string>("MayCable5") ?? string.Empty;
                }
                if (dt.Rows[0]["Sleeve1"] != DBNull.Value)
                {
                    txtSlevee1.Text = dt.Rows[0].Field<string>("Sleeve1") ?? string.Empty;
                }
                if (dt.Rows[0]["Sleeve2"] != DBNull.Value)
                {
                    txtSlevee2.Text = dt.Rows[0].Field<string>("Sleeve2") ?? string.Empty;
                }
                if (dt.Rows[0]["Sleeve3"] != DBNull.Value)
                {
                    txtSlevee3.Text = dt.Rows[0].Field<string>("Sleeve3") ?? string.Empty;
                }
                if (dt.Rows[0]["Sleeve4"] != DBNull.Value)
                {
                    txtSlevee4.Text = dt.Rows[0].Field<string>("Sleeve4") ?? string.Empty;
                }
                if (dt.Rows[0]["Sleeve5"] != DBNull.Value)
                {
                    txtSlevee5.Text = dt.Rows[0].Field<string>("Sleeve5") ?? string.Empty;
                }
            }

            DataTable dtCurrentTable = SQLhelper.GetDataToTable("Books_Kashime_Get_SoThaoTac_Detail_By_ID_Phieu", new SqlParameter[] {
                SQLhelper.CreateParameter("@ID_Phieu", ID_Phieu_Decrypt),
            });
            int rowIndex = 0;
            GridView1.DataSource = dtCurrentTable;
            GridView1.DataBind();
            for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            {
                TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtSoDon");
                TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtSoLot");
                TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtNgaySanXuat");

                TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtSoLuong");

                TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtSetCable");

                TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtDapSleeve");

                TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtSoLuongDongGoi");

                TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txtSoLuongBu");

                TextBox box9 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_1");
                TextBox box10 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_2");
                TextBox box11 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_3");
                TextBox box12 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("txtMSNV_DongGoi_4");

                TextBox box13 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_1");
                TextBox box14 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_2");
                TextBox box15 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_3");
                TextBox box16 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("txtMSNV_DongThung_4");

                TextBox box17 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("txtLeader_DongGoi");

                TextBox box18 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("txtCable");
                TextBox box19 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("txtQC_Confirm");

                TextBox box20 = (TextBox)GridView1.Rows[rowIndex].Cells[12].FindControl("txtSleeve");

                TextBox box21 = (TextBox)GridView1.Rows[rowIndex].Cells[13].FindControl("txtNhungChi");

                TextBox box22 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_1");
                TextBox box23 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_2");
                TextBox box24 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_3");
                TextBox box25 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("txtGiaoNhan_4");

                TextBox box26 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_5");
                TextBox box27 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_6");
                TextBox box28 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_7");
                TextBox box29 = (TextBox)GridView1.Rows[rowIndex].Cells[15].FindControl("txtGiaoNhan_8");

                TextBox box30 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_9");
                TextBox box31 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_10");
                TextBox box32 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_11");
                TextBox box33 = (TextBox)GridView1.Rows[rowIndex].Cells[16].FindControl("txtGiaoNhan_12");

                TextBox box34 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_13");
                TextBox box35 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_14");
                TextBox box36 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_15");
                TextBox box37 = (TextBox)GridView1.Rows[rowIndex].Cells[17].FindControl("txtGiaoNhan_16");

                TextBox box38 = (TextBox)GridView1.Rows[rowIndex].Cells[18].FindControl("txtOkDon");

                box1.Text = dtCurrentTable.Rows[i][2].ToString();
                box2.Text = dtCurrentTable.Rows[i][3].ToString();
                box3.Text = dtCurrentTable.Rows[i][4].ToString();
                box4.Text = dtCurrentTable.Rows[i][5].ToString();
                box5.Text = dtCurrentTable.Rows[i][6].ToString();
                box6.Text = dtCurrentTable.Rows[i][7].ToString();
                box7.Text = dtCurrentTable.Rows[i][8].ToString();
                box8.Text = dtCurrentTable.Rows[i][9].ToString();
                box9.Text = dtCurrentTable.Rows[i][10].ToString();
                box10.Text = dtCurrentTable.Rows[i][11].ToString();

                box11.Text = dtCurrentTable.Rows[i][12].ToString();
                box12.Text = dtCurrentTable.Rows[i][13].ToString();
                box13.Text = dtCurrentTable.Rows[i][14].ToString();
                box14.Text = dtCurrentTable.Rows[i][15].ToString();
                box15.Text = dtCurrentTable.Rows[i][16].ToString();
                box16.Text = dtCurrentTable.Rows[i][17].ToString();
                box17.Text = dtCurrentTable.Rows[i][18].ToString();
                box18.Text = dtCurrentTable.Rows[i][19].ToString();
                box19.Text = dtCurrentTable.Rows[i][20].ToString();
                box20.Text = dtCurrentTable.Rows[i][21].ToString();

                box21.Text = dtCurrentTable.Rows[i][22].ToString();
                box22.Text = dtCurrentTable.Rows[i][23].ToString();
                box23.Text = dtCurrentTable.Rows[i][24].ToString();
                box24.Text = dtCurrentTable.Rows[i][25].ToString();
                box25.Text = dtCurrentTable.Rows[i][26].ToString();
                box26.Text = dtCurrentTable.Rows[i][27].ToString();
                box27.Text = dtCurrentTable.Rows[i][28].ToString();
                box28.Text = dtCurrentTable.Rows[i][29].ToString();
                box29.Text = dtCurrentTable.Rows[i][30].ToString();
                box30.Text = dtCurrentTable.Rows[i][31].ToString();

                box31.Text = dtCurrentTable.Rows[i][32].ToString();
                box32.Text = dtCurrentTable.Rows[i][33].ToString();
                box33.Text = dtCurrentTable.Rows[i][34].ToString();
                box34.Text = dtCurrentTable.Rows[i][35].ToString();
                box35.Text = dtCurrentTable.Rows[i][36].ToString();
                box36.Text = dtCurrentTable.Rows[i][37].ToString();
                box37.Text = dtCurrentTable.Rows[i][38].ToString();
                box38.Text = dtCurrentTable.Rows[i][39].ToString();
                rowIndex++;

                if (!string.IsNullOrEmpty(box38.Text))
                {
                    box1.Enabled = false;
                    box2.Enabled = false;
                    box3.Enabled = false;
                    box4.Enabled = false;
                    box5.Enabled = false;
                    box6.Enabled = false;
                    box7.Enabled = false;
                    box8.Enabled = false;
                    box9.Enabled = false;
                    box10.Enabled = false;
                    box11.Enabled = false;
                    box12.Enabled = false;
                    box13.Enabled = false;
                    box14.Enabled = false;
                    box15.Enabled = false;
                    box16.Enabled = false;
                    box17.Enabled = false;
                    box18.Enabled = false;
                    box19.Enabled = false;
                    box20.Enabled = false;
                    box21.Enabled = false;
                    box22.Enabled = false;
                    box23.Enabled = false;
                    box24.Enabled = false;
                    box25.Enabled = false;
                    box26.Enabled = false;
                    box27.Enabled = false;
                    box28.Enabled = false;
                    box29.Enabled = false;
                    box30.Enabled = false;
                    box31.Enabled = false;
                    box32.Enabled = false;
                    box33.Enabled = false;
                    box34.Enabled = false;
                    box35.Enabled = false;
                    box36.Enabled = false;
                    box37.Enabled = false;
                    box38.Enabled = false;
                    btnSave.Visible = false;
                }
            }
            SetPreviousData();
        }
    }
}