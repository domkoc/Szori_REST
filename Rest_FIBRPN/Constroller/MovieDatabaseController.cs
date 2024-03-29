﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace Rest_FIBRPN
{
    [ApiController]
    [Route("Rest_FIBRPN/resources/[controller]")] // FIXME: Ez NEPTUN volt
    public class MovieDatabaseController : Controller
    {
        [JsonPropertyName("movie")]
        private static MoviesList Movies { get; set; } = new MoviesList();

        [HttpGet]
        [Route("sayHello")]
        public string SayHello([FromQuery] string name) // csak tesztelési célból
        {
            return $"Hello: {name}";
        }

        [HttpPost]
        [Route("movies")]
        public IActionResult AddMovie([FromBody] Movie movie) // beszúrja a kapott Movie objektumot (azonosítót a szerver rendel hozzá), visszaadja a szerver által hozzárendelt azonosítót
        {
            Movies.Add(movie);
            var dto = new IdDTO()
            {
                Id = movie.getId()
            };
            return Ok(dto);
        }

        [HttpPut]
        [Route("movies/{id}")]
        public IActionResult UpdateMovie([FromRoute] int id, [FromBody] Movie movie) // beszúrja vagy frissíti a kapott Movie objektumot, azonosítót a kliens rendel hozzá (ha még nem létezik ilyen azonosítójú objektum, akkor beszúr, egyébként frissít)
        {
            var movieIdx = Movies.IndexOf(Movies.Find(x => x.getId() == id));
            movie.setId(id);
            if (movieIdx != -1)
            {
                Movies[movieIdx] = movie;
            }
            else
            {
                Movies.Add(movie);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("movies/{id}")]
        public IActionResult DeleteMovie([FromRoute] int id) // törli az adott azonosítójú Movie objektumot
        {
            Movies.Remove(Movies.Find(x => x.getId() == id));
            return Ok();
        }

        [HttpGet]
        [Route("movies/{id}")]
        public ActionResult<Movie> GetMovie([FromRoute] int id) // visszaadja az adott azonosítójú Movie objektumot ha ilyen azonosítójú objektum nem létezik, akkor HTTP 404-es(not found) státuszkóddal tér vissza
        {
            var movie = Movies.Find(x => x.getId() == id);
            if (!Movies.Contains(movie))
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("movies")]
        public ActionResult<List<Movie>> GetMovies() // visszaadja az összes Movie objektum listáját
        {
            var dto = new MoviesDTO()
            {
                Movies = MovieDatabaseController.Movies
            };
            return Ok(dto);
        }

        [HttpGet]
        [Route("movies/find")]
        public ActionResult<Movie[]> FindMovies([FromQuery] int year, [FromQuery] string orderby) // visszaadja az összes {year} évhez tartozó Movie objektum azonosítóját egy listában a listát rendezni kell a { field } paraméterben megadott kritérium alapján(Title esetén cím szerint, Director esetén a rendező neve szerint)
        {
            var moviesByYear = Movies.FindAll(x => x.Year == year);
            if (orderby == "Title")
            {
                moviesByYear.Sort((x, y) => x.Title.CompareTo(y.Title));
            }
            else if (orderby == "Director")
            {
                moviesByYear.Sort((x, y) => x.Director.CompareTo(y.Director));
            }
            else
            {
                return BadRequest();
            }
            var dto = new IdsDTO()
            {
                Ids = moviesByYear.Select(x => x.getId()).ToList()
            };
            return Ok(dto);
        }
    }
}
