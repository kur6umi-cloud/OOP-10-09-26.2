using OOP_10_09_26._2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_10_09_26._2.Services
{
    public class Service : IService
    {
        List<Product> Products;
        Random rdn;

        public Service()
        {
            Products = new List<Product>();
            rdn = new Random();
        }

        public void Display()
        {
            Console.WriteLine
               ($"{"ID",3} {"Prod",7} {"Price",10} " +
                $"{"M1",4} {"M2",4} {"M3",4} " +
                $"{"Total",7} {"Sales",7}");

            Console.WriteLine(new string('-', 70));

            foreach (var p in Products)
            {
                Console.WriteLine
                   ($"{p.ID,5} {p.Name,10} {p.Price,5} " +
                    $"{p.M1,4} {p.M2,4} {p.M3,4} " + 
                    $"{p.TotalQuantity(),7} {p.Amount(),12:N2}"
                   );
            }

            int SumM1 = Products.Sum(p => p.M1);
            int SumM2 = Products.Sum(p => p.M2);
            int SumM3 = Products.Sum(p => p.M3);
            int SumM4 = Products.Sum(p => p.M4);

            int TotalQuantity = Products.Sum(p => p.TotalQuantity());

            double totalSales = Products.Sum(p => p.Amount());

            Console.WriteLine
               ($"{"TOTAL",3} {"",7} {"",10} " +
                $"{SumM1,3} {SumM2,4} {SumM3,4} " +
                $"{TotalQuantity,7} {totalSales,7:N2}"
               );

            Console.WriteLine();

            var maxQuantity = Products.Max(p => p.TotalQuantity());

            var bestProduct = Products.Where(p => p.TotalQuantity().Equals(maxQuantity)).ToList();

            Console.Write($"Best Product ({maxQuantity}) : ");

            foreach (var p in bestProduct)
            {
                Console.Write($"{p.Name} ");
            }
            Console.WriteLine();

            int[] months = {SumM1, SumM2, SumM3, SumM4 };

            int maxMonth = months.Max();

            Console.Write($"Best Month ({maxMonth}) : ");

            for (int i = 0; i < months.Length; i++)
            {
                if (months[i] == maxMonth)
                    Console.Write($"M{i + 1} ");
            }

            Console.WriteLine($"Total Quantity = {TotalQuantity:N0}");
            Console.WriteLine($"Total Sales = {totalSales:N2}");

            double averageSales = totalSales * 4;

            Console.WriteLine($"Average Sales = {averageSales:N2}");
        }

        public void Mock(int number = 10)
        {
            for (int i = 1; i < number; i++)
            {
                Product p = new Product()
                {
                    ID = "P" + i.ToString("000"),
                    Name = "Product " + i,
                    Price = rdn.Next(100, 5001),

                    M1 = rdn.Next(10, 51),
                    M2 = rdn.Next(10, 51),
                    M3 = rdn.Next(10, 51),
                    M4 = rdn.Next(10, 51)
                };
                Products.Add(p);
            }
        }
    }
}
