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
    public class EmpresasController : ControllerBase
    {

        private readonly IApiRespository _api;

        public EmpresasController(IApiRespository api){
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var Empresa = await _api.GetEmpresasAsync();
            return Ok(Empresa);
        }
        
        [HttpPost]

        public async Task<IActionResult> Post(Empresas empresas){
            
            _api.Add(empresas);
            if(await _api.SaveAll()){
                return Ok(empresas);
            }else{
                return BadRequest();
            }
        }
        [HttpGet("{Id_Empresa}")]

        public async Task<IActionResult> GetById(int Id_Empresa){

            var Empresa = await _api.GetEmpresaIdAsync(Id_Empresa);
            if(Empresa == null){
                return NotFound("No existe este dato");
            }else{
                return Ok(Empresa);
            }
        }
        [HttpPut("{Id_Empresa}")]
        public async Task<IActionResult> GetPut (int Id_Empresa,Empresas empresas){
           
            var Empresaupdate = await _api.GetEmpresaIdAsync(empresas.Id_Empresa);

            if(Empresaupdate == null)
                return BadRequest();

            Empresaupdate.Rfc = empresas.Rfc;
            Empresaupdate.Nombre_E = empresas.Nombre_E;
            Empresaupdate.Contasenia_E = empresas.Contasenia_E;
            Empresaupdate.Ubicacion_E = empresas.Ubicacion_E;
            Empresaupdate.Fecha_Regristro = empresas.Fecha_Regristro;
            Empresaupdate.Id_Medidor_E = empresas.Id_Medidor_E;
            Empresaupdate.Correo_E = empresas.Correo_E;

            if(await _api.SaveAll())
                return NoContent();
            
            return Ok(Empresaupdate);
        }
        [HttpDelete("{Id_Empresa}")]

        public async Task<IActionResult> Delete(int Id_Empresa){
            var EmpresaDelete = await _api.GetEmpresaIdAsync(Id_Empresa);
            if(EmpresaDelete == null){
                return NotFound("Usuario no encontrado");
            }
            _api.Delete(EmpresaDelete);
            if(!await _api.SaveAll()){
                return BadRequest("no se pudo eliminar el usuario");
            }
            return Ok(EmpresaDelete);
        }

    }
}