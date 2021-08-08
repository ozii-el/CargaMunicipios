using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CargarDatos.Models;


namespace CargarDatos
{
    public class CargarMunicipios
    {
        string _rutaArchivo{get;set;}

        public CargarMunicipios(string rutaArchivo)
        {
            _rutaArchivo=rutaArchivo;
        }


        public void CargarMunycipios(){
            var DatosMunycipios = File.ReadAllLines(_rutaArchivo);
            
            List<Municipio> Municipios = new List<Municipio>();

            foreach (var linea in DatosMunycipios)
            {
                Console.WriteLine(linea);
                var arregloMunicipios = linea.Split(',');
               
                Municipio municipiosInsertar = new Municipio();
                int EntidadId = 0;
                if(int.TryParse(arregloMunicipios[0].Replace('"',' ').TrimEnd().TrimStart(), out EntidadId)){
                    municipiosInsertar.EntidadId = EntidadId;
                
                int MunicipioId = 0;
                if(int.TryParse(arregloMunicipios[1].Replace('"',' ').TrimEnd().TrimStart(), out MunicipioId)){
                    municipiosInsertar.MunicipioId = MunicipioId;

                }
                 municipiosInsertar.Nombre = arregloMunicipios[2].Replace('"', ' ').TrimEnd().TrimStart();
            
                int PoblacionTotal = 0;
                if(int.TryParse(arregloMunicipios[3].Replace('"', ' ').TrimEnd().TrimStart(), out PoblacionTotal)){
                        
                    municipiosInsertar.PoblacionTotal = PoblacionTotal;
                        
                        
                }

                int PoblacionMasculina = 0;
                if(int.TryParse(arregloMunicipios[4].Replace('"', ' ').TrimEnd().TrimStart(), out PoblacionMasculina)){

                    municipiosInsertar.PoblacionMasculina = PoblacionMasculina;
                        
                        
                }
                int PoblacionFemenina = 0;
                if(int.TryParse(arregloMunicipios[5].Replace('"', ' ').TrimEnd().TrimStart(), out PoblacionFemenina)){

                    municipiosInsertar.PoblacionFemenina = PoblacionFemenina;

                        
                }
                Municipios.Add(municipiosInsertar);
                }
                
            }

            using(var BaseDeDatos = new CesarElcoBitContext()){

                foreach (var Municipio in Municipios){
                    //Console.WriteLine($"{Municipos.Nombre}");
                    //Console.WriteLine($"{MunicipioId}");
                    BaseDeDatos.Municipios.Add(Municipio);
                    BaseDeDatos.SaveChanges();
                    Console.WriteLine($"Ya cargur el Municipio:{Municipio.Nombre}");
                }
                
                    
                
            }



        }
        
    }
}