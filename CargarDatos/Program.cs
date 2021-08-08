using System;
using System.IO;
namespace CargarDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*string pathEntidades = System.IO.Path.GetFullPath("Archivos/Entidades.csv");

            CargarArchivos carga = new CargarArchivos(pathEntidades);
            carga.CargarEntidades();*/

            //string pathMunicipios = System.IO.Path.GetFullPath("Archivos/Municipios.csv");

           // CargarMunicipios carga = new CargarMunicipios(pathMunicipios);
            //carga.CargarMunycipios();


            string pathLocalidades = System.IO.Path.GetFullPath("Archivos/Localidades.csv");

            CargarLocalidades carga = new CargarLocalidades(pathLocalidades);
            carga.CargarLocalydades();


        }
    
    }
}
 