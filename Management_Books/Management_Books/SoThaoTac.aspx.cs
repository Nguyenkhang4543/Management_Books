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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInitialRow();

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
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            // Thêm các cột tương ứng với các TemplateField trong GridView
            //dt.Columns.Add(new DataColumn("OK", typeof(bool)));
            //dt.Columns.Add(new DataColumn("No", typeof(int)));
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

            // Khởi tạo các giá trị ban đầu cho các cột
            //dr["OK"] = false;
            //dr["No"] = 1;
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
    }
}