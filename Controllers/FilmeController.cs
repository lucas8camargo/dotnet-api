using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Models;
using System;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();

        private static int id = 1;

        //[HttpPost]
        //public void AdicionaFilme([FromBody] Filme filme)
        //{
        //    filme.Id = id++;
        //    filmes.Add(filme);
        //    Console.WriteLine(filme.Titulo);
            
        //}

        //[HttpPost]
        //public void AdicionaFilme([FromBody] Filme filme)
        //{
        //    filme.Id = id++;
        //    filmes.Add(filme);
        //}

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { id = filme.Id }, filme);
        }

        //[HttpGet]
        //public IEnumerable<Filme> RecuperaFilmes()
        //{
        //    return filmes;
        //}

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(filmes);
        }

        //[HttpGet("{id}")]
        //public Filme RecuperaFilmesPorId(int id)
        //{
        //    foreach(Filme filme in filmes)
        //    {
        //        if(filme.Id == id)
        //        {
        //            return filme;
        //        }
        //    } 
        //    return null;
        //}

        //[HttpGet("{id}")]
        //public Filme RecuperaFilmesPorId(int id)
        //{
        //    return filmes.FirstOrDefault(filme => filme.Id == id);
        //}

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
