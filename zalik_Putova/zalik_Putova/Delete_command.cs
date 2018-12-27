using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace zalik_Putova
{
    class Delete_command
    {
          string sqlExpression;
        string connectionString;

        public Delete_command(string connectString)
        {
            connectionString = connectString;
        }

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("Which table do you want delete?\n0.Delete Row \n1. All data\n2.All data in Films_Actors\n3.All data in Actors\n4.All data in Films\n5. All data in Directors\n6.Видалити всі фільми, дата виходу яких була більш заданого числа років тому.");
            string answ = Console.ReadLine();
            switch (answ)
            {
                case "0": DeleteRow(); break;
                case "1": DeleteTestData(); break;
                case "2": sqlExpression = "Delete from Films_Actors";DeleteTable(sqlExpression); break;
                case "3": sqlExpression = "Delete from Actors"; DeleteTable(sqlExpression); break;
                case "4": sqlExpression = "Delete from Films"; DeleteTable(sqlExpression); break;
                case "5": sqlExpression = "Delete from Directors"; DeleteTable(sqlExpression); break;
                case "6": Console.WriteLine("Enter actor's films number");
                    string m = Console.ReadLine();
                    sqlExpression = "DELETE FROM FILMS WHERE" +
                                    "year(Release_date)+" + m + ">=2018"; DeleteTable(sqlExpression); break;
                default: break;
            }
           
        }

        public void DeleteRow()
        {

            Console.WriteLine("Enter Table name ");
            string table = Console.ReadLine();
            Console.WriteLine("Enter condition");
            string cond = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                sqlExpression = String.Concat("Delete from ", table, " where ", cond);
                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                command1.ExecuteNonQuery();

            }
      
        }
        public void DeleteTable(string sqlExpression)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                command1.ExecuteNonQuery();
                connection.Close();
            };
      
        }

        public void DeleteTestData()
        {
           
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        sqlExpression = String.Concat("Delete from Films_Actors");
                        SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                        command1.ExecuteNonQuery();

                        sqlExpression = String.Concat("Delete from Actors");
                        SqlCommand command2 = new SqlCommand(sqlExpression, connection);
                        command2.ExecuteNonQuery();

                        sqlExpression = String.Concat("Delete from Films");
                        SqlCommand command3 = new SqlCommand(sqlExpression, connection);
                        command3.ExecuteNonQuery();

                   
                        sqlExpression = String.Concat("Delete from Directors");
                        SqlCommand command5 = new SqlCommand(sqlExpression, connection);
                        command5.ExecuteNonQuery();
                        connection.Close();
                
           
            }
               

        }
    }
    }

