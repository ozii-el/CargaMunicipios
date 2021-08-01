using System;
using System.IO;
namespace CargarDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string pathEntidades = System.IO.Path.GetFullPath("Archivos/Entidades.csv");

            CargarArchivos carga = new CargarArchivos(pathEntidades);
            carga.CargarEntidades();
        }
    }
}
 