using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ItemDao
    {
        public string connectionString = "server=DESKTOP-AL1KICC;Integrated Security=True;database=ItemDB;";
        public void AddItem(Item objItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("addItem", connection);
            cmd.Parameters.AddWithValue("@name", objItem.Item_Name);
            cmd.Parameters.AddWithValue("@quantity", objItem.Item_Quantity);
            cmd.Parameters.AddWithValue("@rate", objItem.Item_Rate);
            cmd.Parameters.AddWithValue("@amount", objItem.Amount);
            cmd.Parameters.AddWithValue("@discount", objItem.Discount);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public List<Item> GetAllItem()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("getItems", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var dt = ds.Tables[0];
            connection.Close();
            List<Item> objItemList = new List<Item>();
            foreach (DataRow row in dt.Rows)
            {
                var users = new Item()
                {
                    ItemID = Convert.ToUInt16(row["id"]),
                    Item_Name = row["item_name"].ToString(),
                    Item_Quantity = Convert.ToDecimal(row["item_quantity"]),
                    Item_Rate = Convert.ToDecimal(row["item_rate"]),
                    Discount = Convert.ToDecimal(row["item_discount"]),
                    Amount = Convert.ToDecimal(row["item_amount"]),
                };
                objItemList.Add(users);
            }

            return objItemList;

        }
    }
}
