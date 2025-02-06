using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Utilities
{
    public class LicenseTool
    {
        int[] arrProductLic = { 570, 712, 496, 714, 705, 497, 822 };
        //string[] arrProductName = { "iVanPOS", "Web Based Attendance", "Phomello EBOS", "Phomello Windows", "Price Checker", "TimeMan", "PLS110-SF" };
        string strBaseURL = "https://www.pegasustech.net/";
        public DataSet DeviceInformation(int iProductId, string strLicenseKey, string strDeviceCode, string strSystemCode1, string strSystemCode2, string strSystemCode3, string strSystemCode4)
        {
            string strResult = string.Empty;
            int iServerProductId = arrProductLic[iProductId - 1];
            try
            {
                string URLAuth = strBaseURL + "index.php?route=api/company_detail/device_information";
                string postString = string.Format("sys_code_1={0}&sys_code_2={1}&sys_code_3={2}&sys_code_4={3}&device_code={4}&license_key={5}&master_product_id={6}", System.Web.HttpUtility.UrlEncode(strSystemCode1), System.Web.HttpUtility.UrlEncode(strSystemCode2), System.Web.HttpUtility.UrlEncode(strSystemCode3), System.Web.HttpUtility.UrlEncode(strSystemCode4), System.Web.HttpUtility.UrlEncode(strDeviceCode), System.Web.HttpUtility.UrlEncode(strLicenseKey), iServerProductId);

                const string contentType = "application/x-www-form-urlencoded";
                System.Net.ServicePointManager.Expect100Continue = false;

                CookieContainer cookies = new CookieContainer();

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 |
                SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 |
                SecurityProtocolType.Ssl3;


                HttpWebRequest webRequest = WebRequest.Create(URLAuth) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.CookieContainer = cookies;

                webRequest.ContentLength = postString.Length;
                webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //webRequest.Referer = "https://accounts.craigslist.org";

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                strResult = responseData;

                responseReader.Close();
                webRequest.GetResponse().Close();
            }
            catch (Exception ex)
            {
                strResult = @"[    {        ""status"": ""false""    }]";
            }


            DataSet dsResult = new DataSet("ResultSet");
            dsResult = DecodeString(strResult);
            return dsResult;
        }
        public DataSet CustomerInformation(int iProductId, string strLicenseKey)
        {
            int iServerProductId = arrProductLic[iProductId - 1];

            string strResult = string.Empty;
            try
            {
                string URLAuth = strBaseURL + "index.php?route=api/company_detail/customer_information";
                string postString = string.Format("license_key={0}&master_product_id={1}", strLicenseKey, iServerProductId);

                const string contentType = "application/x-www-form-urlencoded";
                System.Net.ServicePointManager.Expect100Continue = false;

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(URLAuth) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.CookieContainer = cookies;

                webRequest.ContentLength = postString.Length;
                webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //webRequest.Referer = "https://accounts.craigslist.org";

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                strResult = responseData;
                responseReader.Close();
                webRequest.GetResponse().Close();
            }
            catch
            {
                strResult = @"[    {        ""status"": ""false""    }]";
            }


            DataSet dsResult = new DataSet("ResultSet");
            dsResult = DecodeString(strResult);
            return dsResult;
        }
        public DataSet CustomerInformationRegistrationCode(int iProductId, string strRegistrationCode)
        {
            int iServerProductId = arrProductLic[iProductId - 1];

            string strResult = string.Empty;
            try
            {
                string URLAuth = strBaseURL + "index.php?route=api/database_detail/db_information";
                string postString = string.Format("registration_code={0}&master_product_id={1}", strRegistrationCode, iServerProductId);

                const string contentType = "application/x-www-form-urlencoded";
                System.Net.ServicePointManager.Expect100Continue = false;

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(URLAuth) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.CookieContainer = cookies;

                webRequest.ContentLength = postString.Length;
                webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //webRequest.Referer = "https://accounts.craigslist.org";

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                strResult = responseData;
                responseReader.Close();
                webRequest.GetResponse().Close();
            }
            catch
            {
                strResult = @"[    {        ""status"": ""false""    }]";
            }


            DataSet dsResult = new DataSet("ResultSet");
            dsResult = OnlineDecodeString(strResult);
            return dsResult;
        }
        public DataSet UpdateDatabaseInfo(string strRegistrationCode, int iProductId, string strEmail, string strServerName, string strDBName, string strUserName, string strPassword)
        {

            int iServerProductId = arrProductLic[iProductId - 1];
            string strResult = string.Empty;
            try
            {

                string URLAuth = strBaseURL + "index.php?route=api/database_detail/update_db_information";
                string postString = string.Format("registration_code={0}&master_product_id={1}&email={2}&host_name={3}&user_name={4}&db_name={5}&password={6}", strRegistrationCode, iServerProductId, strEmail, strServerName, strUserName, strDBName, strPassword);

                const string contentType = "application/x-www-form-urlencoded";
                System.Net.ServicePointManager.Expect100Continue = false;

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(URLAuth) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.CookieContainer = cookies;

                webRequest.ContentLength = postString.Length;
                webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //webRequest.Referer = "https://accounts.craigslist.org";

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                strResult = responseData;
                responseReader.Close();
                webRequest.GetResponse().Close();
            }
            catch
            {
                strResult = @"[    {        ""status"": ""false""    }]";
            }


            DataSet dsResult = new DataSet("ResultSet");
            dsResult = OnlineDecodeString(strResult);
            return dsResult;
        }
        public DataSet GetOnineResultSet()
        {
            DataSet ds = new DataSet();

            DataTable dt_status = new DataTable("status");
            dt_status.Columns.Add(new DataColumn("status"));


            DataTable dt_primary_details = new DataTable("primary_details");
            dt_primary_details.Columns.Add(new DataColumn("registration_code"));
            dt_primary_details.Columns.Add(new DataColumn("lic_product_id"));
            dt_primary_details.Columns.Add(new DataColumn("customer_id"));
            dt_primary_details.Columns.Add(new DataColumn("name"));
            dt_primary_details.Columns.Add(new DataColumn("company_name"));
            dt_primary_details.Columns.Add(new DataColumn("email"));
            dt_primary_details.Columns.Add(new DataColumn("phone"));
            dt_primary_details.Columns.Add(new DataColumn("country_id"));
            dt_primary_details.Columns.Add(new DataColumn("version_type"));


            DataTable dt_device_details = new DataTable("device_details");
            dt_device_details.Columns.Add(new DataColumn("lic_customer_license_id"));
            dt_device_details.Columns.Add(new DataColumn("lic_product_id"));
            dt_device_details.Columns.Add(new DataColumn("lic_code"));
            dt_device_details.Columns.Add(new DataColumn("license_key"));
            dt_device_details.Columns.Add(new DataColumn("device_code"));
            dt_device_details.Columns.Add(new DataColumn("c_company_id"));
            dt_device_details.Columns.Add(new DataColumn("c_brand_id"));
            dt_device_details.Columns.Add(new DataColumn("c_branch_id"));
            dt_device_details.Columns.Add(new DataColumn("menu_id"));
            dt_device_details.Columns.Add(new DataColumn("is_root"));
            dt_device_details.Columns.Add(new DataColumn("sys_code_1"));
            dt_device_details.Columns.Add(new DataColumn("sys_code_2"));
            dt_device_details.Columns.Add(new DataColumn("sys_code_3"));
            dt_device_details.Columns.Add(new DataColumn("sys_code_4"));
            dt_device_details.Columns.Add(new DataColumn("device_name"));
            dt_device_details.Columns.Add(new DataColumn("device_symbol"));
            dt_device_details.Columns.Add(new DataColumn("registration_date"));
            dt_device_details.Columns.Add(new DataColumn("expiry_date"));



            DataTable dt_parameter_details = new DataTable("parameter_details");
            dt_parameter_details.Columns.Add(new DataColumn("param_name"));
            dt_parameter_details.Columns.Add(new DataColumn("param_value"));


            DataTable dt_database_details = new DataTable("database_details");
            dt_database_details.Columns.Add(new DataColumn("hostname"));
            dt_database_details.Columns.Add(new DataColumn("user_name"));
            dt_database_details.Columns.Add(new DataColumn("password"));
            dt_database_details.Columns.Add(new DataColumn("database"));


            DataTable dt_message = new DataTable("message");
            dt_message.Columns.Add(new DataColumn("message"));


            ds.Tables.Add(dt_status);
            ds.Tables.Add(dt_primary_details);
            ds.Tables.Add(dt_device_details);
            ds.Tables.Add(dt_parameter_details);
            ds.Tables.Add(dt_message);
            ds.Tables.Add(dt_database_details);

            return ds;


        }
        public DataSet OnlineDecodeString(string str)
        {


            //str = @"{ ""status"": true, ""result"": { ""primary_details"": { ""registration_code"": ""61680"", ""lic_product_id"": ""63"", ""customer_id"": ""7"", ""name"": ""Php Developer"", ""company_name"": ""PhpDeveloper"", ""email"": ""designer@pegasustech.net"", ""phone"": ""246756787"", ""country_id"": ""99"", ""hostname"": ""104.238.86.46/SQLEXPRESS"", ""username"": ""sa"", ""db_password"": ""123"", ""database"": ""timeman_client_61680"", ""port"": """", ""expiry_date"": ""2021-07-07 11:50:08"", ""att_device_count"": ""14"", ""version_type"": ""licensed"", ""license_key"": ""26JUTIME9592N201"", ""lic_code"": ""61680"" }, ""device_details"": [ { ""lic_customer_license_id"": ""1209"", ""oc_customer_id"": ""7"", ""lic_product_id"": ""63"", ""lic_code"": ""61680"", ""license_key"": ""26JUTIME9592N201"", ""device_code"": """", ""c_company_id"": ""0"", ""c_brand_id"": ""0"", ""c_branch_id"": ""0"", ""menu_id"": ""0"", ""is_root"": ""0"", ""sys_code_1"": """", ""sys_code_2"": """", ""sys_code_3"": """", ""sys_code_4"": """", ""device_name"": """", ""device_symbol"": """", ""registration_date"": ""2019-06-26 15:30:05"", ""duration"": ""0"", ""expiry_date"": ""2021-07-07 11:50:08"", ""is_active"": ""1"", ""is_update"": ""1"", ""modified_by"": ""7"", ""modified_date"": ""2019-06-26 15:30:05"" }, { ""lic_customer_license_id"": ""1210"", ""oc_customer_id"": ""7"", ""lic_product_id"": ""63"", ""lic_code"": ""61680"", ""license_key"": ""26JUTIME9592N201"", ""device_code"": """", ""c_company_id"": ""0"", ""c_brand_id"": ""0"", ""c_branch_id"": ""0"", ""menu_id"": ""0"", ""is_root"": ""0"", ""sys_code_1"": """", ""sys_code_2"": """", ""sys_code_3"": """", ""sys_code_4"": """", ""device_name"": """", ""device_symbol"": """", ""registration_date"": ""2019-06-26 15:30:05"", ""duration"": ""0"", ""expiry_date"": ""2021-07-07 11:50:08"", ""is_active"": ""1"", ""is_update"": ""1"", ""modified_by"": ""7"", ""modified_date"": ""2019-06-26 15:30:05"" }, { ""lic_customer_license_id"": ""1222"", ""oc_customer_id"": ""7"", ""lic_product_id"": ""63"", ""lic_code"": ""61680"", ""license_key"": ""26JUTIME9592N201"", ""device_code"": """", ""c_company_id"": ""0"", ""c_brand_id"": ""0"", ""c_branch_id"": ""0"", ""menu_id"": ""0"", ""is_root"": ""0"", ""sys_code_1"": """", ""sys_code_2"": """", ""sys_code_3"": """", ""sys_code_4"": """", ""device_name"": """", ""device_symbol"": """", ""registration_date"": ""2019-06-26 15:30:05"", ""duration"": ""0"", ""expiry_date"": ""2021-07-07 11:50:08"", ""is_active"": ""1"", ""is_update"": ""1"", ""modified_by"": ""7"", ""modified_date"": ""2019-06-26 15:30:05"" } ], ""parameter_details"": [ { ""param_name"": ""no_of_employee"", ""param_display_name"": ""No of Employee"", ""param_value"": ""100"" }, { ""param_name"": ""no_of_device"", ""param_display_name"": ""No of Device"", ""param_value"": ""2"" } ] }, ""message"": ""Data get successfully"" }";
            DataSet ds = GetOnineResultSet();


            try
            {
                JObject results = JObject.Parse(str);
                int i = results.Count;
                int iStart = 0;
                bool bResult = false;
                foreach (var result in results)
                {
                    try
                    {
                        if (iStart == 0)
                        {
                            DataRow row_0 = ds.Tables[0].NewRow();
                            row_0["status"] = result.Value.ToString();
                            ds.Tables[0].Rows.Add(row_0);
                            if (row_0["status"].ToString() == "True")
                            {
                                bResult = true;
                            }
                        }
                        if (iStart == 1)
                        {
                            if (bResult)
                            {
                                JObject jResults = JObject.Parse(result.Value.ToString());
                                int lStart = 0;
                                foreach (var jResult in jResults)
                                {

                                    if (lStart == 0)
                                    {
                                        JObject jPrimary = JObject.Parse(jResult.Value.ToString());

                                        DataRow row_1 = ds.Tables[1].NewRow();
                                        row_1["registration_code"] = jPrimary["registration_code"].ToString();
                                        row_1["lic_product_id"] = jPrimary["lic_product_id"].ToString();
                                        row_1["customer_id"] = jPrimary["customer_id"].ToString();
                                        row_1["name"] = jPrimary["name"].ToString();
                                        row_1["company_name"] = jPrimary["company_name"].ToString();
                                        row_1["email"] = jPrimary["email"].ToString();
                                        row_1["phone"] = jPrimary["phone"].ToString();
                                        row_1["country_id"] = jPrimary["country_id"].ToString();
                                        row_1["version_type"] = jPrimary["version_type"].ToString();
                                        ds.Tables[1].Rows.Add(row_1);
                                    }
                                    if (lStart == 1)
                                    {
                                        JArray jDevices = JArray.Parse(jResult.Value.ToString());

                                        foreach (var jDevice in jDevices)
                                        {

                                            DataRow row_2 = ds.Tables[2].NewRow();
                                            row_2["lic_customer_license_id"] = jDevice["lic_customer_license_id"].ToString();
                                            row_2["lic_product_id"] = jDevice["lic_product_id"].ToString();
                                            row_2["lic_code"] = jDevice["lic_code"].ToString();
                                            row_2["license_key"] = jDevice["license_key"].ToString();
                                            row_2["device_code"] = jDevice["device_code"].ToString();
                                            row_2["c_company_id"] = jDevice["c_company_id"].ToString();
                                            row_2["c_brand_id"] = jDevice["c_brand_id"].ToString();
                                            row_2["c_branch_id"] = jDevice["c_branch_id"].ToString();
                                            row_2["menu_id"] = jDevice["menu_id"].ToString();
                                            row_2["is_root"] = jDevice["is_root"].ToString();
                                            row_2["sys_code_1"] = jDevice["sys_code_1"].ToString();
                                            row_2["sys_code_2"] = jDevice["sys_code_2"].ToString();
                                            row_2["sys_code_3"] = jDevice["sys_code_3"].ToString();
                                            row_2["sys_code_4"] = jDevice["sys_code_4"].ToString();
                                            row_2["device_name"] = jDevice["device_name"].ToString();
                                            row_2["device_symbol"] = jDevice["device_symbol"].ToString();
                                            row_2["registration_date"] = jDevice["registration_date"].ToString();
                                            row_2["expiry_date"] = jDevice["expiry_date"].ToString();
                                            row_2["sys_code_2"] = jDevice["sys_code_2"].ToString();
                                            ds.Tables[2].Rows.Add(row_2);

                                        }

                                    }
                                    if (lStart == 2)
                                    {
                                        JArray jParams = JArray.Parse(jResult.Value.ToString());

                                        foreach (var jParam in jParams)
                                        {

                                            DataRow row_3 = ds.Tables[3].NewRow();
                                            row_3["param_name"] = jParam["param_name"].ToString();
                                            row_3["param_value"] = jParam["param_value"].ToString();
                                            ds.Tables[3].Rows.Add(row_3);

                                        }

                                    }
                                    if (lStart == 3)
                                    {
                                        JObject jDatabase = JObject.Parse(jResult.Value.ToString());
                                        DataRow row_5 = ds.Tables[5].NewRow();
                                        row_5["hostname"] = jDatabase["hostname"].ToString();
                                        row_5["user_name"] = jDatabase["user_name"].ToString();
                                        row_5["password"] = jDatabase["password"].ToString();
                                        row_5["database"] = jDatabase["database"].ToString();
                                        ds.Tables[5].Rows.Add(row_5);
                                    }
                                    lStart = lStart + 1;
                                }
                            }
                        }
                        if (iStart == 2)
                        {
                            DataRow row_4 = ds.Tables[4].NewRow();
                            row_4["message"] = result.Value.ToString();
                            ds.Tables[4].Rows.Add(row_4);
                        }


                    }
                    catch
                    {
                    }
                    iStart = iStart + 1;
                }
            }
            catch
            {
            }
            ds.AcceptChanges();
            return ds;
        }
        public DataSet GetResultSet()
        {
            DataSet ds = new DataSet();

            DataTable dt_status = new DataTable("status");
            dt_status.Columns.Add(new DataColumn("status"));


            DataTable dt_primary_details = new DataTable("primary_details");
            dt_primary_details.Columns.Add(new DataColumn("registration_code"));
            dt_primary_details.Columns.Add(new DataColumn("lic_product_id"));
            dt_primary_details.Columns.Add(new DataColumn("customer_id"));
            dt_primary_details.Columns.Add(new DataColumn("name"));
            dt_primary_details.Columns.Add(new DataColumn("company_name"));
            dt_primary_details.Columns.Add(new DataColumn("email"));
            dt_primary_details.Columns.Add(new DataColumn("phone"));
            dt_primary_details.Columns.Add(new DataColumn("country_id"));
            dt_primary_details.Columns.Add(new DataColumn("version_type"));
            dt_primary_details.Columns.Add(new DataColumn("password"));
            //Check if already registered
            dt_primary_details.Columns.Add(new DataColumn("is_registered"));

            DataTable dt_device_details = new DataTable("device_details");
            dt_device_details.Columns.Add(new DataColumn("lic_customer_license_id"));
            dt_device_details.Columns.Add(new DataColumn("lic_product_id"));
            dt_device_details.Columns.Add(new DataColumn("lic_code"));
            dt_device_details.Columns.Add(new DataColumn("license_key"));
            dt_device_details.Columns.Add(new DataColumn("device_code"));
            dt_device_details.Columns.Add(new DataColumn("c_company_id"));
            dt_device_details.Columns.Add(new DataColumn("c_brand_id"));
            dt_device_details.Columns.Add(new DataColumn("c_branch_id"));
            dt_device_details.Columns.Add(new DataColumn("menu_id"));
            dt_device_details.Columns.Add(new DataColumn("is_root"));
            dt_device_details.Columns.Add(new DataColumn("sys_code_1"));
            dt_device_details.Columns.Add(new DataColumn("sys_code_2"));
            dt_device_details.Columns.Add(new DataColumn("sys_code_3"));
            dt_device_details.Columns.Add(new DataColumn("sys_code_4"));
            dt_device_details.Columns.Add(new DataColumn("device_name"));
            dt_device_details.Columns.Add(new DataColumn("device_symbol"));
            dt_device_details.Columns.Add(new DataColumn("registration_date"));
            dt_device_details.Columns.Add(new DataColumn("expiry_date"));



            DataTable dt_parameter_details = new DataTable("parameter_details");
            dt_parameter_details.Columns.Add(new DataColumn("param_name"));
            dt_parameter_details.Columns.Add(new DataColumn("param_value"));



            DataTable dt_message = new DataTable("message");
            dt_message.Columns.Add(new DataColumn("message"));


            ds.Tables.Add(dt_status);
            ds.Tables.Add(dt_primary_details);
            ds.Tables.Add(dt_device_details);
            ds.Tables.Add(dt_parameter_details);
            ds.Tables.Add(dt_message);

            return ds;


        }
        public DataSet DecodeString(string str)
        {


            //str = @"{ ""status"": true, ""result"": { ""primary_details"": { ""registration_code"": ""61680"", ""lic_product_id"": ""63"", ""customer_id"": ""7"", ""name"": ""Php Developer"", ""company_name"": ""PhpDeveloper"", ""email"": ""designer@pegasustech.net"", ""phone"": ""246756787"", ""country_id"": ""99"", ""hostname"": ""104.238.86.46/SQLEXPRESS"", ""username"": ""sa"", ""db_password"": ""123"", ""database"": ""timeman_client_61680"", ""port"": """", ""expiry_date"": ""2021-07-07 11:50:08"", ""att_device_count"": ""14"", ""version_type"": ""licensed"", ""license_key"": ""26JUTIME9592N201"", ""lic_code"": ""61680"" }, ""device_details"": [ { ""lic_customer_license_id"": ""1209"", ""oc_customer_id"": ""7"", ""lic_product_id"": ""63"", ""lic_code"": ""61680"", ""license_key"": ""26JUTIME9592N201"", ""device_code"": """", ""c_company_id"": ""0"", ""c_brand_id"": ""0"", ""c_branch_id"": ""0"", ""menu_id"": ""0"", ""is_root"": ""0"", ""sys_code_1"": """", ""sys_code_2"": """", ""sys_code_3"": """", ""sys_code_4"": """", ""device_name"": """", ""device_symbol"": """", ""registration_date"": ""2019-06-26 15:30:05"", ""duration"": ""0"", ""expiry_date"": ""2021-07-07 11:50:08"", ""is_active"": ""1"", ""is_update"": ""1"", ""modified_by"": ""7"", ""modified_date"": ""2019-06-26 15:30:05"" }, { ""lic_customer_license_id"": ""1210"", ""oc_customer_id"": ""7"", ""lic_product_id"": ""63"", ""lic_code"": ""61680"", ""license_key"": ""26JUTIME9592N201"", ""device_code"": """", ""c_company_id"": ""0"", ""c_brand_id"": ""0"", ""c_branch_id"": ""0"", ""menu_id"": ""0"", ""is_root"": ""0"", ""sys_code_1"": """", ""sys_code_2"": """", ""sys_code_3"": """", ""sys_code_4"": """", ""device_name"": """", ""device_symbol"": """", ""registration_date"": ""2019-06-26 15:30:05"", ""duration"": ""0"", ""expiry_date"": ""2021-07-07 11:50:08"", ""is_active"": ""1"", ""is_update"": ""1"", ""modified_by"": ""7"", ""modified_date"": ""2019-06-26 15:30:05"" }, { ""lic_customer_license_id"": ""1222"", ""oc_customer_id"": ""7"", ""lic_product_id"": ""63"", ""lic_code"": ""61680"", ""license_key"": ""26JUTIME9592N201"", ""device_code"": """", ""c_company_id"": ""0"", ""c_brand_id"": ""0"", ""c_branch_id"": ""0"", ""menu_id"": ""0"", ""is_root"": ""0"", ""sys_code_1"": """", ""sys_code_2"": """", ""sys_code_3"": """", ""sys_code_4"": """", ""device_name"": """", ""device_symbol"": """", ""registration_date"": ""2019-06-26 15:30:05"", ""duration"": ""0"", ""expiry_date"": ""2021-07-07 11:50:08"", ""is_active"": ""1"", ""is_update"": ""1"", ""modified_by"": ""7"", ""modified_date"": ""2019-06-26 15:30:05"" } ], ""parameter_details"": [ { ""param_name"": ""no_of_employee"", ""param_display_name"": ""No of Employee"", ""param_value"": ""100"" }, { ""param_name"": ""no_of_device"", ""param_display_name"": ""No of Device"", ""param_value"": ""2"" } ] }, ""message"": ""Data get successfully"" }";
            DataSet ds = GetResultSet();


            try
            {
                JObject results = JObject.Parse(str);
                int i = results.Count;
                int iStart = 0;
                bool bResult = false;
                foreach (var result in results)
                {
                    try
                    {
                        if (iStart == 0)
                        {
                            DataRow row_0 = ds.Tables[0].NewRow();
                            row_0["status"] = result.Value.ToString();
                            ds.Tables[0].Rows.Add(row_0);
                            if (row_0["status"].ToString() == "True")
                            {
                                bResult = true;
                            }
                        }
                        if (iStart == 1)
                        {
                            if (bResult)
                            {
                                JObject jResults = JObject.Parse(result.Value.ToString());
                                int lStart = 0;
                                foreach (var jResult in jResults)
                                {

                                    if (lStart == 0)
                                    {
                                        JObject jPrimary = JObject.Parse(jResult.Value.ToString());

                                        DataRow row_1 = ds.Tables[1].NewRow();
                                        row_1["registration_code"] = jPrimary["registration_code"].ToString();
                                        row_1["lic_product_id"] = jPrimary["lic_product_id"].ToString();
                                        row_1["customer_id"] = jPrimary["customer_id"].ToString();
                                        row_1["name"] = jPrimary["name"].ToString();
                                        row_1["company_name"] = jPrimary["company_name"].ToString();
                                        row_1["email"] = jPrimary["email"].ToString();
                                        row_1["phone"] = jPrimary["phone"].ToString();
                                        row_1["country_id"] = jPrimary["country_id"].ToString();
                                        row_1["version_type"] = jPrimary["version_type"].ToString();
                                        row_1["password"] = jPrimary["password"].ToString();
                                        //Check If Registered
                                        row_1["is_registered"] = jPrimary["is_registered"].ToString();
                                        ds.Tables[1].Rows.Add(row_1);
                                    }
                                    if (lStart == 1)
                                    {
                                        JArray jDevices = JArray.Parse(jResult.Value.ToString());

                                        foreach (var jDevice in jDevices)
                                        {

                                            DataRow row_2 = ds.Tables[2].NewRow();
                                            row_2["lic_customer_license_id"] = jDevice["lic_customer_license_id"].ToString();
                                            row_2["lic_product_id"] = jDevice["lic_product_id"].ToString();
                                            row_2["lic_code"] = jDevice["lic_code"].ToString();
                                            row_2["license_key"] = jDevice["license_key"].ToString();
                                            row_2["device_code"] = jDevice["device_code"].ToString();
                                            row_2["c_company_id"] = jDevice["c_company_id"].ToString();
                                            row_2["c_brand_id"] = jDevice["c_brand_id"].ToString();
                                            row_2["c_branch_id"] = jDevice["c_branch_id"].ToString();
                                            row_2["menu_id"] = jDevice["menu_id"].ToString();
                                            row_2["is_root"] = jDevice["is_root"].ToString();
                                            row_2["sys_code_1"] = jDevice["sys_code_1"].ToString();
                                            row_2["sys_code_2"] = jDevice["sys_code_2"].ToString();
                                            row_2["sys_code_3"] = jDevice["sys_code_3"].ToString();
                                            row_2["sys_code_4"] = jDevice["sys_code_4"].ToString();
                                            row_2["device_name"] = jDevice["device_name"].ToString();
                                            row_2["device_symbol"] = jDevice["device_symbol"].ToString();
                                            row_2["registration_date"] = jDevice["registration_date"].ToString();
                                            row_2["expiry_date"] = jDevice["expiry_date"].ToString();
                                            row_2["sys_code_2"] = jDevice["sys_code_2"].ToString();
                                            ds.Tables[2].Rows.Add(row_2);

                                        }

                                    }
                                    if (lStart == 2)
                                    {
                                        JArray jParams = JArray.Parse(jResult.Value.ToString());

                                        foreach (var jParam in jParams)
                                        {

                                            DataRow row_3 = ds.Tables[3].NewRow();
                                            row_3["param_name"] = jParam["param_name"].ToString();
                                            row_3["param_value"] = jParam["param_value"].ToString();
                                            ds.Tables[3].Rows.Add(row_3);

                                        }

                                    }
                                    lStart = lStart + 1;
                                }
                            }
                        }
                        if (iStart == 2)
                        {
                            DataRow row_4 = ds.Tables[4].NewRow();
                            row_4["message"] = result.Value.ToString();
                            ds.Tables[4].Rows.Add(row_4);
                        }


                    }
                    catch
                    {
                    }
                    iStart = iStart + 1;
                }
            }
            catch
            {
            }
            ds.AcceptChanges();
            return ds;
        }

    }
}
