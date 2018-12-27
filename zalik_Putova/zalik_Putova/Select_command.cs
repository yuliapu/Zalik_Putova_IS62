using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace zalik_Putova
{
    class Select_command
    {
         string sqlExpression;
        string connectionString;
        public Select_command(string connectString)
        {
            connectionString = connectString;
        }

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("Which table do you want to see?\n1. Films_Actors\n2. Actors\n3. Films\n4. Directors\n "+
           "5. Знайти всі фільми, що вийшли на екран у 1998 і 1997 році.\n "+
           "6. Вивести інформацію про акторів, що знімалися в заданому фільмі.\n "+
            "7. Вивести інформацію про акторів, що знімалися як мінімум в N фільмах.\n "+
             "8. Вивести інформацію про фільми, дата виходу яких була більш заданого числа років тому.\n "+
              "9. Вивести інформацію про акторів, які були режисерами хоча б одного з фільмів.\n ");
        string answ = Console.ReadLine();
        switch(answ)
        {
            case "1": sqlExpression = "SELECT * FROM Films_Actors"; selection(); break;
            case "2": sqlExpression = "SELECT * FROM Actors"; selection(); break;
            case "3": sqlExpression = "SELECT * FROM Films"; selection(); break;
            case "4": sqlExpression = "SELECT * FROM Directors"; selection(); break;

            case "5": sqlExpression = "SELECT Films.Name, Films.Release_date FROM Films WHERE year(Release_date)=1997 OR year(Release_date)=1998"; selection(); break;

            case "6": Console.WriteLine("Enter film's name");
                string name = Console.ReadLine();
                sqlExpression = "SELECT Actors.Name, Actors.Birth_date, Films.Name FROM Actors " 
                +" INNER JOIN Films_actors ON Actors.Id=Films_actors.Actor_id" 
                +" INNER JOIN Films ON Films_actors.Film_id=Films.Id"
                +" WHERE Films.Name="+"'"+name+"'"; selection(); break;

            case "7": Console.WriteLine("Enter actor's films number");
                string n = Console.ReadLine();
                sqlExpression = "SELECT Actors.Name, Actors.Birth_date, Count(Films.Name) AS Films_count FROM Actors "
                                    +" INNER JOIN Films_actors ON Actors.Id=Films_actors.Actor_id "
                                    +" INNER JOIN Films ON Films_actors.Film_id=Films.Id "
                                    +" GROUP BY Actors.Name, Actors.Birth_date"
                                    +" HAVING Count(Films.Name)>="+n; selection(); break;

            case "8": Console.WriteLine("Enter years number");
                string m = Console.ReadLine();
                sqlExpression = "SELECT * FROM FILMS WHERE"+
                                " year(Release_date)+"+m+">=2018"; selection(); break;
            case "9": sqlExpression = "SELECT Actors.Name, Actors.Birth_date FROM Actors  "
                                  + " INNER JOIN Films_actors ON Films_actors.Actor_id=Actors.Id "
                                  + " INNER JOIN Films ON Films_actors.Film_id=Films.id "
                                  + " INNER JOIN Directors ON Films.Director_id=Directors.Id "
                                  + " WHERE Directors.Name=Actors.Name"; selection(); break;
            default: break;
        }
   

        }
        public void selection()
        {
            
             using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
       
                foreach (DataTable dt in ds.Tables)
                {
                    Console.WriteLine(dt.TableName); 
       
                    foreach (DataColumn column in dt.Columns)
                        Console.Write("\t{0}", column.ColumnName);
                    Console.WriteLine();
                
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        foreach (object cell in cells)
                            Console.Write("\t{0}", cell);
                        Console.WriteLine();
                    }
                }
            }
             Console.WriteLine("Press any key");
            Console.ReadLine();
            
          
        }
     
    }
}
