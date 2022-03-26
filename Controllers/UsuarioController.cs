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
    public class UsuarioController : ControllerBase
    {

        private readonly IApiRespository _api;

        public UsuarioController(IApiRespository api){
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var usuarios = await _api.GetUsuariosAsync();
            return Ok(usuarios);
        }
        
        [HttpPost]

        public async Task<IActionResult> Post(Usuario usuarios){
            
            _api.Add(usuarios);
            if(await _api.SaveAll()){
                return Ok(usuarios);
            }else{
                return BadRequest();
            }
        }
        [HttpGet("{Id_us}")]

        public async Task<IActionResult> GetUsId(int Id_us){

            var usuarios = await _api.GetUsuarioByIdAsync(Id_us);
            if(usuarios == null){
                return NotFound("No existe este dato");
            }else{
                return Ok(usuarios);
            }
        }
        [HttpGet("verificacion/{Nombre}/{Contrasenia}")]

        public async Task<IActionResult> GetUslogin(string Nombre, string Contrasenia){

            var usuarios = await _api.GetUsuariologin(Nombre, Contrasenia);
            if(usuarios == null){
                return NotFound("No existe este dato");
            }else{
                return Ok(usuarios);
            }
        }
        [HttpPut("{Id_us}")]
        public async Task<IActionResult> GetPut (int Id_us, Usuario usuarios){
            if(Id_us != usuarios.Id_us){
                return BadRequest("Los datos no coinciden");
            }
            var UsuariosUpdate = await _api.GetUsuarioByIdAsync(usuarios.Id_us);

            if(UsuariosUpdate == null)
                return BadRequest();
            
            UsuariosUpdate.Nombre = usuarios.Nombre;
            UsuariosUpdate.Contrasenia = usuarios.Contrasenia;
            UsuariosUpdate.domicilio = usuarios.domicilio;
            UsuariosUpdate.Nacimiento = usuarios.Nacimiento;
            UsuariosUpdate.Id_Medidor = usuarios.Id_Medidor;
            UsuariosUpdate.Correo = usuarios.Correo;

            if(await _api.SaveAll())
                return NoContent();
            
            return Ok(UsuariosUpdate);
        }
        [HttpDelete("{Id_us}")]

        public async Task<IActionResult> Delete(int Id_us){
            var usuariodelete = await _api.GetUsuarioByIdAsync(Id_us);
            if(usuariodelete == null){
                return NotFound("Usuario no encontrado");
            }
            _api.Delete(usuariodelete);
            if(!await _api.SaveAll()){
                return BadRequest("no se pudo eliminar el usuario");
            }
            return Ok(usuariodelete);
        }

    }
}