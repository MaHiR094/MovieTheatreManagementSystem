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
    // =====================================================
    // RESULT SET CLASS
    // =====================================================

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

    // =====================================================
    // DATABASE ACCESS HELPER CLASS
    // =====================================================

    public class DBAccessHelper
    {
        // =================================================
        // DATABASE CONNECTION
        // =================================================

        public static SqlConnection con =
          new SqlConnection(
            "Data Source=MAHIR\\SQLEXPRESS;Initial Catalog=MovieTheatreManagementSystem;Integrated Security=True;TrustServerCertificate=True"
          );

        // =================================================
        // SELECT QUERY METHOD
        // =================================================

        public ResultSet GetQueryData(string query)
        {
            var resultSet = new ResultSet();

            // =============================================
            // EMPTY QUERY CHECK
            // =============================================

            if (string.IsNullOrWhiteSpace(query))
            {
                resultSet.HasError = true;

                resultSet.Message =
                  "Query cannot be empty.";

                return resultSet;
            }

            // =============================================
            // EXECUTE SELECT QUERY
            // =============================================

            try
            {
                con.Open();

                SqlDataAdapter adapter =
                  new SqlDataAdapter(query, con);

                DataTable dataTable =
                  new DataTable();

                adapter.Fill(dataTable);

                resultSet.Data = dataTable;
            }

            // =============================================
            // ERROR HANDLING
            // =============================================
            catch (Exception exp)
            {
                resultSet.HasError = true;

                resultSet.Message =
                  "Error executing query: " +
                  exp.Message;
            }

            // =============================================
            // CLOSE CONNECTION
            // =============================================
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return resultSet;
        }

        // =================================================
        // INSERT / UPDATE / DELETE METHOD
        // =================================================

        public ResultSet ExecuteNonQuery(string query)
        {
            var resultSet = new ResultSet();

            // =============================================
            // EMPTY QUERY CHECK
            // =============================================

            if (string.IsNullOrWhiteSpace(query))
            {
                resultSet.HasError = true;

                resultSet.Message =
                  "Query cannot be empty.";

                return resultSet;
            }

            // =============================================
            // EXECUTE QUERY
            // =============================================

            try
            {
                con.Open();

                SqlCommand cmd =
                  new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }

            // =============================================
            // ERROR HANDLING
            // =============================================
            catch (Exception exp)
            {
                resultSet.HasError = true;

                resultSet.Message =
                  "Error executing query: " +
                  exp.Message;
            }

            // =============================================
            // CLOSE CONNECTION
            // =============================================
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
