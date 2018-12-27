using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace zalik_Putova
{
    class Insert_command
    {
        string sqlExpression;
        string connectionString;
        string table;

        public Insert_command(string connectString)
        {
            connectionString = connectString;
        }

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("Insert data in... \n1. Films_Actors\n2. Actors\n3. Films\n4. Directors");
            string answ = Console.ReadLine();
            
            switch (answ)
            {
                case "1": table = "Films_Actors"; InsertData(table); break;
                case "2": table = "Actors"; InsertData(table); break;
                case "3": table = "Films"; InsertData(table); break;
                case "4": table = "Directors"; InsertData(table); break;

                default: break;
            }

        }

        public void InsertData(string table)
        {           
             
            //Console.WriteLine("Enter condition");
            string cond = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                sqlExpression = String.Concat("Delete from ", table, " where ", cond);
                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                command1.ExecuteNonQuery();

            }
      
        }
    }
}
