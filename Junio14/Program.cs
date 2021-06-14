using Junio14.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Junio14.dto;

namespace Junio14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // listar entidad
            using(var contexto=new SakilaContext()) {
                var actores=contexto.Actors.ToList();
                foreach(var actor in actores)
                {
                   // Console.WriteLine(actor.FirstName+" "+actor.LastName);
                }
            } // disponer el contexto si la ejecucion sale de este bloque de codigo.

            // ordenar entidad
            using(var contexto=new SakilaContext()) {
                var actores=contexto
                    .Actors
                    .Where( a => a.FirstName.StartsWith("C") )
                    .OrderBy( a => a.FirstName).ThenBy(a => a.LastName)    
                    
                    .ToList();
                foreach(var actor in actores)
                {
                 //   Console.WriteLine(actor.FirstName+" "+actor.LastName);
                }
            } 
            using(var contexto=new SakilaContext()) {
                var cities=contexto
                    .Cities
                    .Include( c=>c.Country )
                    .ToList();
                foreach(var city in cities)
                {
                  //  Console.WriteLine($"{city.City1} ciudad:{city.CityId} pais:{city.Country.Country1}");
                    //Console.WriteLine(city.City1+" "+city.CityId);
                }
            }
            using(var contexto=new SakilaContext()) {
                List<string> cities=contexto
                    .Cities // list<city>
                    .Select( c => c.City1.ToUpper()) // list<string>
                    .ToList();
                foreach(var city in cities)
                {
                 //   Console.WriteLine($"{city}");
                    //Console.WriteLine(city.City1+" "+city.CityId);
                }
            }
            // agrupar.
            using(var contexto=new SakilaContext()) {
                List<AgrupacionPaisxCiudad> agrupar=contexto
                    .Countries // lista de paises
                    .Include( c => c.Cities)
                    .GroupBy( c => c.Country1) // una agrupacion 
                    .Select( g => new AgrupacionPaisxCiudad { 
                       Nombre=  g.Key,
                       CantidadCiudades= g.Count()
                    }) // transformar los datos.
                    .ToList();
                foreach(var item in agrupar)
                {
                    Console.WriteLine($"pais:{item.Nombre} {item.CantidadCiudades}");
                }
            }
            // agrupar iniciando por cities
            // procedural funcion().funcion().funcion() = fluido.
            using(var contexto=new SakilaContext()) {
                List<AgrupacionPaisxCiudad> agrupar=contexto
                    .Cities // lista de ciudades
                    .Include( c => c.Country) // dentro de la lista, incluyo los paises
                    .GroupBy( c => c.Country.Country1) // una agrupacion por el nombre del pais 
                    .Select( g => new AgrupacionPaisxCiudad { 
                       Nombre=  g.Key,
                       CantidadCiudades= g.Count()
                    }) // transformar los datos.
                    .ToList();
                foreach(var item in agrupar)
                {
                    Console.WriteLine($"pais2 :{item.Nombre} {item.CantidadCiudades}");
                }
            }
            // linq usando query.
            using(var contexto=new SakilaContext()) {
                List<AgrupacionPaisxCiudad> agrupar=
                    (from c in contexto.Cities.Include(c=>c.Country)
                        group c by c.Country.Country1 into g
                        select new AgrupacionPaisxCiudad { 
                           Nombre=  g.Key,
                           CantidadCiudades= g.Count()
                        }).ToList();

                foreach(var item in agrupar)
                {
                    Console.WriteLine($"pais2 :{item.Nombre} {item.CantidadCiudades}");
                }
            }




        }
    }
}
