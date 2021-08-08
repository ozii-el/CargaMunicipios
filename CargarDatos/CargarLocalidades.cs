using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CargarDatos.Models;


namespace CargarDatos
{
    public class CargarLocalidades
    {
        string _rutaArchivo{get;set;}

        public CargarLocalidades(string rutaArchivo)
        {
            _rutaArchivo=rutaArchivo;
        }


        public void CargarLocalydades()
        {
            var DatosLocalydades = File.ReadAllLines(_rutaArchivo);

            List<Localidad> Localidades = new List<Localidad>();

            foreach (var linea in DatosLocalydades)
            {
              //  Console.WriteLine(linea);
                var arregloLocalidades = linea.Split("\",\"");

                Localidad localidadInsertar = new Localidad();
                
                int EntidadId = 0;
                if(int.TryParse(arregloLocalidades[1].Replace('"',' ').TrimEnd().TrimStart(), out EntidadId))
                {
                    localidadInsertar.EntidadId = EntidadId;
                
                    int MunicipioId = 0;
                    if(int.TryParse(arregloLocalidades[4].Replace('"',' ').TrimEnd().TrimStart(), out MunicipioId))
                    {
                        localidadInsertar.MunicipioId = MunicipioId;
                    }
                
                    int LocalidadId = 0;
                    if(int.TryParse(arregloLocalidades[6].Replace('"',' ').TrimEnd().TrimStart(), out LocalidadId))
                    {
                        localidadInsertar.LocalidadId = LocalidadId;
                    }
                
                    localidadInsertar.Nombre = arregloLocalidades[7].Replace('"',' ').TrimEnd().TrimStart();
                    localidadInsertar.Ambito = arregloLocalidades[8].Replace('"',' ').TrimEnd().TrimStart();

                    //decimal LatitudDecimal = 0000.00000000m;
                    //if(decimal.TryParse(arregloLocalidades[11].Replace('"',' ').TrimEnd().TrimStart(), out LatitudDecimal))
                    //{
                        var uno = arregloLocalidades[11].Replace('"',' ').TrimEnd().TrimStart();
                        localidadInsertar.LatitudDecimal = 0;

                    //decimal LongitudDecimal = 0000.00000000m;
                    //if(decimal.TryParse(arregloLocalidades[12].Replace('"',' ').TrimEnd().//TrimStart(), out LongitudDecimal))
                    //{
                        localidadInsertar.LongitudDecimal =00.0000000m;

                    //}

                    int Altitud = 0;
                    if(int.TryParse(arregloLocalidades[13].Replace('"',' ').TrimEnd().TrimStart(), out Altitud))
                    {
                        localidadInsertar.Altitud = Altitud;
                    }

                    int PoblacionTotal = 0;
                    if(int.TryParse(arregloLocalidades[15].Replace('"',' ').TrimEnd().TrimStart(), out PoblacionTotal))
                    {
                        localidadInsertar.PoblacionTotal = PoblacionTotal;
                    }
                
                    int PoblacionMasculina = 0;
                    if(int.TryParse(arregloLocalidades[16].Replace('"',' ').TrimEnd().TrimStart(), out PoblacionMasculina))
                    {
                        localidadInsertar.PoblacionMasculina = PoblacionMasculina;
                    }

                    int PoblacionFemenina = 0;
                    if(int.TryParse(arregloLocalidades[17].Replace('"',' ').TrimEnd().TrimStart(), out PoblacionFemenina))
                    {
                        localidadInsertar.PoblacionFemenina = PoblacionFemenina;
                    }
                    
                    Localidades.Add(localidadInsertar);

                     using (var BaseDeDatos = new CesarElcoBitContext()){
                         BaseDeDatos.Localidads.Add(localidadInsertar);
                        BaseDeDatos.SaveChanges();
                         //Console.WriteLine($"Ya cargue la Localidad:{localidadInsertar.Nombre} ");
                     }
                }
             }
            /* using (var BaseDeDatos = new CesarElcoBitContext())
                {
                    foreach (var Localidad in Localidades)
                    {
                        //Console.WriteLine($"{Localidades.Nombre} ");
                        //Console.WriteLine($"{LocalidadId} ");
                        BaseDeDatos.Localidads.Add(Localidad);
                        BaseDeDatos.SaveChanges();
                        Console.WriteLine($"Ya cargue la Localidad:{Localidad} ");
                    }

                } */
        }

    }
}