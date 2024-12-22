using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InventarioLivros.Models;
using InventarioLivros.Services;
using InventarioLivros.Services.Interfaces;

namespace InventarioLivros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _service;

        public LivrosController(ILivroService livroService)
        {
            _service = livroService;
        }

        [HttpGet]
        public IEnumerable<Livro> GetLivros() => _service.GetLivros();

        [HttpGet("{id}")]
        public ActionResult<Livro> GetLivroById(int id)
        {
            var livro = _service.GetLivroById(id);
            return livro != null? Ok(livro) : NotFound();
        }

        [HttpPost]
        public IActionResult AddLivro(Livro livro)
        {
            _service.AddLivro(livro);
            return CreatedAtAction(nameof(GetLivroById), new { id = livro.Id }, livro);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLivro(int id, Livro livro)
        {
            if (id != livro.Id)
                return BadRequest();
            _service.UpdateLivro(livro);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLivro(int id)
        {
            _service.DeleteLivro(id);
            return NoContent();
        }
    }
}
    
