using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace BestBestBuyPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");


            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(conn);

            var prod = new DapperProductRepository(conn);

            prod.CreateProduct("bicycle", 20, 1);

            var products = prod.GetAllProducts();

            foreach(var pro in products)
            {
                Console.WriteLine($"{pro.ProductID} {pro.Name}");
            }

            Console.WriteLine("Type new department name");

            var NewDepartment = Console.ReadLine();

            repo.InsertDepartment(NewDepartment);

            var departments = repo.GetAllDepartments();

            foreach(var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID}: {dept.Name}");
            }
            
        }
    }
}
