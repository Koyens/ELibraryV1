﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ELibrary2.models;
using Newtonsoft.Json;

namespace ELibrary2.Classes
{
    public class ADMIN
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        adminModels m = new adminModels();

        public int adminLogin(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<adminModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("adminLogin", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@admin_id", SqlDbType.NVarChar, 50).Value = m.adminID.Trim();
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = m.password.Trim();

                        var output = cmd.Parameters.Add("@Return", SqlDbType.Int);
                        output.Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        if(Convert.ToInt32(output.Value) == 1)
                        {
                            DataTable dt = new DataTable();
                            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                            adapt.Fill(dt);

                            HttpContext.Current.Session["fullname"] = dt.Rows[0]["full_name"].ToString();
                            HttpContext.Current.Session["username"] = "";
                            HttpContext.Current.Session["role"] = "admin";
                        }

                        con.Close();
                        return Convert.ToInt32(output.Value);
                    }
                }
            }
            catch (Exception)
            {
                throw;
                con.Close();
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}