using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationWeb.Models
{
    public class Database
    {
        public string connectionString = "server=DESKTOP-AL1KICC;Integrated Security=True;database=DbWeather;";

        public void addData(Detail objDetail)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("addinfo", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@city_name", objDetail.city_name);
            sqlCommand.Parameters.AddWithValue("@country_name", objDetail.country_name);
            sqlCommand.Parameters.AddWithValue("@longitude", objDetail.longitude);
            sqlCommand.Parameters.AddWithValue("@latitude", objDetail.latitude);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }


        public List<Detail> getdetail()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("getInfo", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var dt = ds.Tables[0];
            connection.Close();
            var userList = new List<Detail>();
            foreach (DataRow row in dt.Rows)
            {
                Detail users = new Detail()
                {
                    id=Convert.ToUInt16(row["id"]),
                    city_name=row["city_name"].ToString(),
                    country_name=row["country_name"].ToString(),
                    latitude=row["latitude"].ToString(),
                    longitude=row["longitude"].ToString()
                };
                userList.Add(users);
            }

            return userList;

        }
    }

}

