using System;
using System.IO;
using System.Collections.Generic;
using CargarDatos.Models;
using System.Linq;

namespace CargarDatos
{
    public class CargarArchivos
    {
        string _rutaArchivo {get;set;}

        public CargarArchivos(string rutaArchivo)
        {
            _rutaArchivo=rutaArchivo;
        }


        public void CargarEntidades(){
                var datosEnELArchivo = File.ReadAllLines(_rutaArchivo);

                List<EntidadFederativa> Entidades = new List<EntidadFederativa>();

                foreach (var linea in datosEnELArchivo)
                {
                    var arregloDatos = linea.Split(',');
                    EntidadFederativa entidadesInsertar = new EntidadFederativa();
                    Int EntidadId = 0;
                    if(int.TryParse(arregloDatos[0], out EntidadId) ){

                        entidadesInsertar.EntidadId = EntidadId;
                        entidadesInsertar.Nombre = arregloDatos[1];
                        entidadesInsertar.NombreAbreviado = arregloDatos[2];
                        entidadesInsertar.PoblacionTotal = arregloDatos[3];
                        entidadesInsertar.PoblacionMasculina = arregloDatos[4];
                        entidadesInsertar.PoblacionFemenina =  arregloDatos[5];
                    }

                    Entidades.Add(entidadesInsertar);




                
                
                }
                
                using(var BaseDeDatos = new ElcoBitContext()){

                    foreach (var Entidad in Entidades){
                    
                    BaseDeDatos.EntidadFederativa.Add(Entidad);
                       BaseDeDatos.SaveChanges();
                       Console.WriteLine($"Ya cargue  la Entidad:{Entidad.Nombre} ");
                        
                    }
                     
                }

        }

    }
    
}
