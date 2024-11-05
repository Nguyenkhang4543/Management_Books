using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Management_Books
{
    public partial class Home : System.Web.UI.Page
    {
        ThaoTacDuLieu SQLhelper = new ThaoTacDuLieu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaNV"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblTenDanhNhap.Text = convertToUnSign3(Session["Ten"].ToString());

                if(Session["Quyen"].ToString() == "1")
                {
                    btnAdmin.Visible = true;
                }
                DataTable dtPhanQuyenXem = new DataTable();
                dtPhanQuyenXem = SQLhelper.ExecuteDataTable("Check_PhanQuyen", new SqlParameter[]
                {
                     new SqlParameter("@MSNV", Session["MaNV"].ToString())
                });

                if (dtPhanQuyenXem.Rows.Count > 0)
                {
                    CheckAdmin.Checked = dtPhanQuyenXem.Rows[0].Field <bool>("ALL_Books");
                    if(CheckAdmin.Checked == true)
                    {
                        ////////////////////////////////// So Kashime //////////////////////////////////
                        lblSoKashime.Visible = true;
                        btnSoThaoTac.Visible = true;
                        btnSoTestLine.Visible = true;
                        ////////////////////////////////// So Line Cut //////////////////////////////////
                        lblSoLineCut.Visible = true;
                        btnSoCatCable.Visible = true;

                        ////////////////////////////////// So Test //////////////////////////////////
                        btnSoThaoTac1.Visible = true;
                        btnSoThaoTac2.Visible = true;
                        btnSoThaoTac3.Visible = true;
                        btnSoThaoTac4.Visible = true;
                        btnSoThaoTac5.Visible = true;
                        btnSoThaoTac6.Visible = true;
                        btnSoThaoTac7.Visible = true;
                        btnSoThaoTac8.Visible = true;
                        btnSoThaoTac9.Visible = true;
                        btnSoThaoTac10.Visible = true;
                        btnSoThaoTac11.Visible = true;
                        btnSoThaoTac12.Visible = true;
                        btnSoThaoTac13.Visible = true;
                        btnSoThaoTac14.Visible = true;
                        btnSoThaoTac15.Visible = true;
                        btnSoThaoTac16.Visible = true;
                        btnSoThaoTac17.Visible = true;
                        btnSoThaoTac18.Visible = true;
                        btnSoThaoTac19.Visible = true;
                        btnSoThaoTac20.Visible = true;

                    }
                    else
                    {
                        List<int> maSoList = new List<int>();

                        foreach (DataRow row in dtPhanQuyenXem.Rows)
                        {
                            int maSo = Convert.ToInt32(row["Ma_So"]);
                            maSoList.Add(maSo);
                        }

                        int[] maSoArray = maSoList.ToArray();

                        foreach (int maSo in maSoArray)
                        {
                            if (maSo == 2)
                            {
                                btnSoThaoTac.Visible = true;
                                lblSoKashime.Visible = true;
                            }
                            if (maSo == 3)
                            {
                                btnSoTestLine.Visible = true;
                                lblSoKashime.Visible = true;
                            }
                            if (maSo == 4)
                            {
                                btnSoCatCable.Visible = true;
                                lblSoLineCut.Visible = true;
                            }
                        }
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
        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["MaNV"] = null;
            Session["Quyen"] = null;
            Session["Ten"] = null;
            Session["BoPhan"] = null;
            Session["Factory"] = null;
            Response.Redirect("Login.aspx");
        }

        ///////////////////////////// Quản Lý Danh Sách Sổ/////////////////////////////////////////
        protected void btnManagement_Employees_Click(object sender, EventArgs e)
        {
            Response.Redirect("Management_Employees.aspx");
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