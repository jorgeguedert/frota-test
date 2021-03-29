using Jorge.FrotaVeiculo.Domain.Entities;
using Jorge.FrotaVeiculo.Domain.Interfaces.Services;
using Jorge.FrotaVeiculo.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jorge.FrotaVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService veiculoService;
        public VeiculoController(IVeiculoService veiculoService)
        {
            this.veiculoService = veiculoService;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(veiculoService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(veiculoService.GetById(id));
        }

        [HttpGet("BuscarPorChassi/{chassi}")]
        public IActionResult FindByChassi(string chassi)
        {
            return Ok(veiculoService.FindByChassi(chassi));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Veiculo obj)
        {
            try
            {
                return Ok(veiculoService.Add(obj));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{chassi}")]
        public IActionResult Put(string chassi, [FromBody] VeiculoCorViewModel veiculoCor)
        {
            try
            {
                return Ok(veiculoService.Update(chassi, veiculoCor.Cor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{chassi}")]
        public IActionResult Delete(string chassi)
        {
            try
            {
                veiculoService.Remove(chassi);
            return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
