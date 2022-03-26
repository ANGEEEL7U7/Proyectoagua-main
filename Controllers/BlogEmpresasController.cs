using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyectoagua.Data.Interface;
using Proyectoagua.Models;

namespace Proyectoagua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogEmpresasController : ControllerBase
    {
        private readonly IApiRespository _api;

        public BlogEmpresasController(IApiRespository api){
            _api = api;
        }

        [HttpGet]

        public async Task<IActionResult> Get(){
            var BlogEmpresas = await _api.GetBlogEmpresasAsync();
            return Ok(BlogEmpresas);
        }
        [HttpPost]
        public async Task<IActionResult> PostB(BlogEmpresa blogEmpresa){

            _api.Add(blogEmpresa);
            if (await _api.SaveAll()){
                return Ok(blogEmpresa);
            }else{
                return BadRequest();
            }
        }
        [HttpGet("{Id_BlogEmpresa}")]
        public async Task<IActionResult> Id(int Id_BlogEmpresa){
            var BlogsEmpresas = await _api.GetBlogEmpresaIdAsync(Id_BlogEmpresa);
            if(BlogsEmpresas == null){
                return NotFound("No existe el dato solicitado");
            }else{
                return Ok(BlogsEmpresas);
            }
        }
        [HttpPut("{Id_BlogEmpresa}")]
        public async Task<IActionResult> PutBlog(int Id_BlogEmpresa, BlogEmpresa blogEmpresa){
            
            var BlogsUpdate = await _api.GetBlogEmpresaIdAsync(blogEmpresa.Id_BlogEmpresa);
            if(BlogsUpdate == null){
                return BadRequest();
            }
            BlogsUpdate.UrlFoto_E = blogEmpresa.UrlFoto_E;
            BlogsUpdate.Uso_Agua_E = blogEmpresa.Uso_Agua_E;
            BlogsUpdate.Ubicacion_E = blogEmpresa.Ubicacion_E;
            BlogsUpdate.Opinion_E = blogEmpresa.Opinion_E;
            BlogsUpdate.Id_Medidor_fk_E = blogEmpresa.Id_Medidor_fk_E;
            if(await _api.SaveAll()){
                return NoContent();
            }
            return Ok(BlogsUpdate);
        }
        [HttpDelete("{Id_BlogEmpresa}")]

        public async Task<IActionResult> Delete(int Id_BlogEmpresa){
            var BlogEmpresadelete = await _api.GetBlogEmpresaIdAsync(Id_BlogEmpresa);
            if(BlogEmpresadelete == null){
                return NotFound("Usuario no encontrado");
            }
            _api.Delete(BlogEmpresadelete);
            if(!await _api.SaveAll()){
                return BadRequest("no se pudo eliminar el usuario");
            }
            return Ok(BlogEmpresadelete);
        }
    }
}