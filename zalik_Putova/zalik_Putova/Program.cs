using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zalik_Putova
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=films_actors;Integrated Security=True";

            Select_command select = new Select_command(connectionString);
            Insert_command insert = new Insert_command(connectionString);
            Delete_command delete = new Delete_command(connectionString);

            menu(select, insert, delete, connectionString);
        }
        static void menu(Select_command select, Insert_command insert, Delete_command delete, string connectionString)
        {
            Console.Clear();

            Console.WriteLine("\nЗалікова робота.\n Виконала Путова Юлія\n Група ІС-62\n Варіант 2. Домашня відеотека\n\n--запити завдання знаходяться у пунктах Show, Delete--\n");

            Console.WriteLine("Menu\n1. Insert data\n2. Show data\n3. Delete data");
            string answ = Console.ReadLine();

            switch (answ)
            {
                case "1": insert.menu(); break;
                case "2": select.menu(); break;
                case "3": delete.menu(); break;

                default: break;
            }
            menu(select, insert, delete, connectionString);

        }
    }
}
