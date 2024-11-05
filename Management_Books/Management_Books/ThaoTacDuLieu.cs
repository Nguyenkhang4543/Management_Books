using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.IO;

namespace Management_Books
{
    public class ThaoTacDuLieu
    {
         public string GetConnectionString()
        {
            string connetionString = null;
            //connetionString = @"Data Source=CL3010\SQLEXPRESS;Initial Catalog=NEV_WebRequest;User ID=sa;Password=Pass@12345";
            connetionString = @"Data Source=SV114;Initial Catalog=NEM_Management_Books;User ID=sa; MultipleActiveResultSets=True";
            if (connetionString != null)
            {
                return connetionString;
            }
            else
            {
                return "";
            }
        }
        public static string Encrypt_V1(string plainText, string key)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            string base64String = Convert.ToBase64String(array);
            return base64String.Replace('+', '-').Replace('/', '_').Replace("=", "");
        }

        public static string Decrypt_V1(string cipherText, string key)
        {
            byte[] iv = new byte[16];
            string base64String = cipherText.Replace('-', '+').Replace('_', '/');
            switch (base64String.Length % 4)
            {
                case 2: base64String += "=="; break;
                case 3: base64String += "="; break;
            }
            byte[] buffer = Convert.FromBase64String(base64String);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public object ExecuteScala(string procedureName, params SqlParameter[] parameters)
        {
            object temp = null;
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(parameters[i]);
                    }
                }
                temp = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
                if (cmd != null) cmd.Dispose();
            }
            return temp;
        }

        public DataTable GetDataToTable(string procedureName, params SqlParameter[] parameters)
        {
            int n = 0;
            SqlConnection conn = new SqlConnection(GetConnectionString());
            DataTable dtbl = new DataTable();
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(parameters[i]);
                    }
                    n = da.Fill(dtbl);
                    cmd.Parameters.Clear();
                }
                else
                {
                    n = da.Fill(dtbl);
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
            }
            return dtbl;
        }
        public SqlParameter CreateParameter(string paraName, object obj)
        {
            return new SqlParameter(paraName, obj);
        }
        public int CompareBetweenDatetime(DateTime dt1, DateTime dt2)
        {
            DateTime compare1 = new DateTime(dt1.Year, dt1.Month, dt1.Day);
            DateTime compare2 = new DateTime(dt2.Year, dt2.Month, dt2.Day);
            return DateTime.Compare(compare1, compare2);
        }
        public int ExecuteNonQuery(string procedureName, params SqlParameter[] parameters)
        {
            int temp;
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(parameters[i]);
                    }
                }
                temp = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return temp;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                if (cmd != null) cmd.Dispose();
            }
        }
        public string ExecuteNonQueryTest(string procedureName, params SqlParameter[] parameters)
        {
            string temp;
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(parameters[i]);
                    }
                }
                temp = cmd.ExecuteNonQuery().ToString();
                cmd.Parameters.Clear();
                return temp;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return ex.ToString();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                if (cmd != null) cmd.Dispose();
            }
        }
        /*HAM LAY NGAY THANG*/
        public List<DateTime> GetDateFromDatetimeToDatetime(DateTime startdate, DateTime enddate)
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(startdate);

            while ((startdate = startdate.AddDays(1)) <= enddate)
            {
                dates.Add(startdate);
            }

            return dates;
        }
        /// Mã hóa ký tự với kiểu mã hõa TripleDes - MD5
        public string Encrypt(string key, string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        
        public string Decrypt(string key, string toDecrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            //byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toDecrypt);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public DataTable ExecuteDataTable(string procedureName, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(parameters[i]);
                    }

                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                // throw;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
            }
            return dt;
        }

        public List<DateTime> GetTimeFromDatetimeToDatetime(DateTime startdate, DateTime enddate)
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(startdate);

            while ((startdate = startdate.AddMinutes(15)) <= enddate)
            {
                dates.Add(startdate);
            }

            return dates;
        }
    }
}