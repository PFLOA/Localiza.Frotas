using System;
using System.Collections.Generic;
using System.Linq;
using Localiza.Frotas.Domain.Model;
using Localiza.Frotas.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Localiza.Frotas.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly ILogger<VeiculosController> _logger;
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculosController(ILogger<VeiculosController> logger, IVeiculoRepository veiculoRepository)
        {
            this._logger = logger;
            this.veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public ActionResult GetVeiculo() => Ok(this.veiculoRepository.GetAll());

        [HttpGet("{id}")]
        public ActionResult GetVeiculoById(Guid id)
        {
            var veiculo = this.veiculoRepository.GetVeiculoById(id);

            if(veiculo == null)
                return NotFound();

            return Ok();
        }

        [HttpPost]
        public ActionResult AddVeiculo([FromBody] Veiculo veiculo ){
            this.veiculoRepository.Add(veiculo);
            return CreatedAtAction(nameof(GetVeiculoById), new {id = veiculo.id,}, veiculo);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] Veiculo veiculo){
            this.veiculoRepository.Update(veiculo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id){
            var veiculo  = this.veiculoRepository.GetVeiculoById(id);
            if(veiculo == null)
                return NotFound();

            this.veiculoRepository.Delete(veiculo);    
            
            return NoContent();
        }
    }
}