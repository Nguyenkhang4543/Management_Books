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
                        btnSoThaoTac.Visible = true;
                        btnSoTestLine.Visible = true;
                        ////////////////////////////////// So Line Cut //////////////////////////////////
                        btnSoCatCable.Visible = true;
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
                            if (maSo == 1)
                            {
                                btnSoThaoTac.Visible = true;
                            }
                            if (maSo == 2)
                            {
                                btnSoTestLine.Visible = true;
                            }
                            if (maSo == 3)
                            {
                                btnSoCatCable.Visible = true;
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