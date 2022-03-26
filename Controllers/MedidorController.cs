using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyectoagua.Data.Interface;
using Proyectoagua.Models;
//using Proyectoagua.Models;

namespace Proyectoagua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidorController : ControllerBase
    {

        private readonly IApiRespository _api;

        public MedidorController(IApiRespository api){
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetMedidores(){
            var Medidor = await _api.GetMedidoresAsync();
            return Ok(Medidor);
        }
        
        [HttpPost]

        public async Task<IActionResult> Post(Medidores medidores){
            
            _api.Add(medidores);
            if(await _api.SaveAll()){
                return Ok(medidores);
            }else{
                return BadRequest();
            }
        }
        [HttpGet("{Id_Medidor}")]
        public async Task<IActionResult> GetId (int Id_Medidor){
            var Medidor = await _api.GetMedidoresByIdAsync(Id_Medidor);
            if(Medidor == null){
                return NotFound("No existe el dato solicitado");
            }else{
                return Ok(Medidor);
            }

        }
        [HttpPut("{Id_Medidor}")]
        public async Task<IActionResult> Getput (int Id_Medidor, Medidores medidores){
            if(Id_Medidor != medidores.Id_Medidor){
                return BadRequest("El id no coincide");
            }
            var MedidorUpdate = await _api.GetMedidoresByIdAsync(medidores.Id_Medidor);

            if(MedidorUpdate == null)
                return BadRequest();


            
            MedidorUpdate.Marca = medidores.Marca;
            MedidorUpdate.Proveedor = medidores.Proveedor;


            if(await _api.SaveAll())
                return NoContent();
            
            return Ok(MedidorUpdate);
        }
        [HttpDelete("{Id_Medidor}")]

        public async Task<IActionResult> Delete(int Id_Medidor){
            var MedidorDelete = await _api.GetMedidoresByIdAsync(Id_Medidor);
            if(MedidorDelete == null){
                return NotFound("Usuario no encontrado");
            }
            _api.Delete(MedidorDelete);
            if(!await _api.SaveAll()){
                return BadRequest("no se pudo eliminar el usuario");
            }
            return Ok(MedidorDelete);
        }

    }
}