﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Rest_FIBRPN
{
    [ApiController]
    [Route("Rest_NEPTUN/resources/[controller]")]
    public class MovieDatabaseController : Controller
    {
        private static List<Movie> movies = new List<Movie>();

        [HttpGet]
        [Route("sayHello")]
        public string SayHello([FromQuery] string name) // csak tesztelési célból
        {
            return $"Hello: {name}";
        }

        [HttpGet]
        [Route("movies")]
        public Movie[] GetMovies() // visszaadja az összes Movie objektum listáját
        {
            return movies.ToArray();
        }

        [HttpGet]
        [Route("movies/{id}")]
        public Movie GetMovie(string id) // visszaadja az adott azonosítójú Movie objektumot ha ilyen azonosítójú objektum nem létezik, akkor HTTP 404-es(not found) státuszkóddal tér vissza
        {
            return movies.Find(x => x.Id == id);
        }

        [HttpPost]
        [Route("movies")]
        public void AddMovie([FromBody] Movie movie) // beszúrja a kapott Movie objektumot (azonosítót a szerver rendel hozzá), visszaadja a szerver által hozzárendelt azonosítót
        {
            movies.Add(movie);
        }

        [HttpPut]
        [Route("movies/{id}")]
        public void UpdateMovie(string id, [FromBody] Movie movie) // beszúrja vagy frissíti a kapott Movie objektumot, azonosítót a kliens rendel hozzá (ha még nem létezik ilyen azonosítójú objektum, akkor beszúr, egyébként frissít)
        {
            var movieIdx = movies.IndexOf(movies.Find(x => x.Id == id));
            movies[movieIdx] = movie;
        }

        [HttpDelete]
        [Route("movies/{id}")]
        public void DeleteMovie(string id) // törli az adott azonosítójú Movie objektumot
        {
            movies.Remove(movies.Find(x => x.Id == id));
        }

        [HttpGet]
        [Route("movies/find")]
        public Movie[] FindMovies([FromQuery] int year, [FromQuery] string orderby) // visszaadja az összes {year} évhez tartozó Movie objektum azonosítóját egy listában a listát rendezni kell a { field } paraméterben megadott kritérium alapján(Title esetén cím szerint, Director esetén a rendező neve szerint)
        {
            var moviesByYear = movies.FindAll(x => x.Year == year);
            if (orderby == "Title")
            {
                moviesByYear.Sort((x, y) => x.Title.CompareTo(y.Title));
            }
            else if (orderby == "Director")
            {
                moviesByYear.Sort((x, y) => x.Director.CompareTo(y.Director));
            }
            return moviesByYear.ToArray();
        }
    }
}
