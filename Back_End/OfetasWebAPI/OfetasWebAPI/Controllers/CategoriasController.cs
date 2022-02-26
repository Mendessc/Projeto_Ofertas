﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using OfetasWebAPI.Repositories;

namespace OfetasWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository _CategoriaRepository { get; set; }

        public CategoriasController()
        {
            _CategoriaRepository = new CategoriaRepository();
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_CategoriaRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Categorium novaCategoria)
        {
            _CategoriaRepository.Cadastrar(novaCategoria);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idCategoria}")]
        public IActionResult Deletar(int idCategoria)
        {
            _CategoriaRepository.Deletar(idCategoria);

            return StatusCode(204);
        }
        [Authorize(Roles = "1")]
        [HttpPut("{idCategoria}")]
        public IActionResult Alterar(int idCategoria, Categorium categoriaAtualizado)
        {
            _CategoriaRepository.Atualizar(idCategoria, categoriaAtualizado);

            return StatusCode(200);
        }
    }
}
