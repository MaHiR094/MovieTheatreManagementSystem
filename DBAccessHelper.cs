using Movie_Ticket_Management_System;
using MovieTicketBookingSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public class ResultSet
    {
        public bool HasError
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public DataTable Data
        {
            get;
            set;
        }
    }

    public class DBAccessHelper
    {
        public static SqlConnection con =
          new SqlConnection(
            "Data Source=MAHIR\\SQLEXPRESS;Initial Catalog=MovieTheatreManagementSystem;Integrated Security=True;TrustServerCertificate=True"
          );

        public ResultSet GetQueryData(string query)
        {
            var resultSet = new ResultSet();

            if (string.IsNullOrWhiteSpace(query))
            {
                resultSet.HasError = true;

                resultSet.Message = "Query cannot be empty.";

                return resultSet;
            }

            try
            {
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                resultSet.Data = dataTable;
            }

            catch (Exception exp)
            {
                resultSet.HasError = true;

                resultSet.Message ="Error executing query: " +exp.Message;
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return resultSet;
        }

        public ResultSet ExecuteNonQuery(string query)
        {
            var resultSet = new ResultSet();

            if (string.IsNullOrWhiteSpace(query))
            {
                resultSet.HasError = true;

                resultSet.Message ="Query cannot be empty.";

                return resultSet;
            }

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }

            catch (Exception exp)
            {
                resultSet.HasError = true;

                resultSet.Message = "Error executing query: " + exp.Message;
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return resultSet;
        }
    }
}