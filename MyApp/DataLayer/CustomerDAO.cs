using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusinessModel;
using MyApp.Models;

namespace DataLayer
{
    public class CustomerDAO
    {
        public string connectionString = "server=DESKTOP-AL1KICC;Integrated Security=True;database=Customer;";


        public void AddCustomer(Customer customer)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("addCustomer", connection);
            cmd.Parameters.AddWithValue("@username", customer.UserName);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@password", customer.Password);
            cmd.Parameters.AddWithValue("@number", customer.Number);
            cmd.Parameters.AddWithValue("@addres", customer.Address);
            cmd.Parameters.AddWithValue("@dob", customer.DOB);
            cmd.Parameters.AddWithValue("@gender", customer._Gender);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                ErrorHandling objerror = new ErrorHandling();
                objerror.errorMessage = "Username or Email is already taken";
            }
            connection.Close();

        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("deleteCustomer", connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void Edit(Customer customer)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("updateCustomer", connection);
            cmd.Parameters.AddWithValue("@username", customer.UserName);
            cmd.Parameters.AddWithValue("@gender", customer._Gender);
            cmd.Parameters.AddWithValue("@number", customer.Number);
            cmd.Parameters.AddWithValue("@addres", customer.Address);
            cmd.Parameters.AddWithValue("id", customer.CustomerID);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public List<Customer> GetAllCustomer()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("getAllCustomer", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var dt = ds.Tables[0];
            connection.Close();
            var userList = new List<Customer>();
            foreach (DataRow row in dt.Rows)
            {
                var users = new Customer()
                {
                    CustomerID = Convert.ToUInt16(row["Customer_id"]),
                    UserName = row["Username"].ToString(),
                    Email = row["Email"].ToString(),
                    _Gender = row["Gender"].ToString(),
                    Number = (long)(row["MobileNo"]),
                    Address = row["Address"].ToString(),
                    DOB = row["DOB"].ToString(),
                    JoinDate = row["DOJ"].ToString(),
                    Password=row["Password"].ToString()
                    
                };
                userList.Add(users);
            }

            return userList;

        }
        public List<Image> GetImgUrl()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("getlocation", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var dt = ds.Tables[0];
            connection.Close();
            List<Image> urlList = new List<Image>();
            foreach (DataRow row in dt.Rows)
            {
                var users = new Image()
                {
                    id = Convert.ToUInt16(row["id"]),
                    imageUrl = row["img_url"].ToString(),
               

                };
                urlList.Add(users);
            }

            return urlList;

        }
        public void AddUrl(Image objImage)
        {
            SqlConnection SqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("addurl", SqlConnection);
            cmd.Parameters.AddWithValue("@url", objImage.imageUrl);   
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection.Open();
            cmd.ExecuteNonQuery();
            SqlConnection.Close();

        }

    }
}
