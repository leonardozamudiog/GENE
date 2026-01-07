using System;
using System.Data.SqlClient;

namespace Practica2JJBN
{

    //Implementar en Mi Proyecto de Panaderia
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Consulta de Ventas - Panadería ===");
            Console.Write("Ingresa el ID del producto: ");

            int productoId;
            while (!int.TryParse(Console.ReadLine(), out productoId))
            {
                Console.Write("ID inválido. Ingresa un número: ");
            }

            string connectionString =
                "Server=localhost;Database=Panaderia;Trusted_Connection=True;TrustServerCertificate=True;";

            // QUERY CONCATENADO
            string query ="SELECT TOP 1 " + "VentaID, " + "ProductoID, " + "Cantidad, " + "Precio, " +
                "Fecha " + "FROM Ventas " + "WHERE ProductoID = " + productoId + " " +
                "ORDER BY Fecha;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("\nResultados encontrados:\n");

                    while (reader.Read())
                    {
                        Console.WriteLine($"Venta ID: {reader["VentaID"]}");
                        Console.WriteLine($"Producto ID: {reader["ProductoID"]}");
                        Console.WriteLine($"Cantidad: {reader["Cantidad"]}");
                        Console.WriteLine($"Precio: ${reader["Precio"]}");
                        Console.WriteLine($"Fecha: {reader["Fecha"]}");
                        Console.WriteLine("-----------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron ventas para ese producto.");
                }
            }

            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}
