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
    public class BlogController : ControllerBase
    {
        private readonly IApiRespository _api;

        public BlogController(IApiRespository api){
            _api = api;
        }

        [HttpGet]

        public async Task<IActionResult> GetB(){
            var Blogs = await _api.GetBlogsAsync();
            return Ok(Blogs);
        }
        [HttpPost]
        public async Task<IActionResult> PostB(Blogs blogs){

            _api.Add(blogs);
            if (await _api.SaveAll()){
                return Ok(blogs);
            }else{
                return BadRequest();
            }
        }
        [HttpGet("{Id_Blog}")]
        public async Task<IActionResult> Id(int Id_Blog){
            var Blogs = await _api.GetBlogsIdAsync(Id_Blog);
            if(Blogs == null){
                return NotFound("No existe el dato solicitado");
            }else{
                return Ok(Blogs);
            }
        }
        [HttpPut("{Id_Blog}")]
        public async Task<IActionResult> PutBlog(int Id_Blog, Blogs blogs){
            if(Id_Blog != blogs.Id_Blog){
                return BadRequest("Los datos no coinciden");
            }
            var BlogsUpdate = await _api.GetBlogsIdAsync(blogs.Id_Blog);
            if(BlogsUpdate == null){
                return BadRequest();
            }
            BlogsUpdate.UrlFoto = blogs.UrlFoto;
            BlogsUpdate.Uso_Agua = blogs.Uso_Agua;
            BlogsUpdate.Ubicacion = blogs.Ubicacion;
            BlogsUpdate.Opinion = blogs.Opinion;
            BlogsUpdate.Id_Medidor_fk = blogs.Id_Medidor_fk;
            if(await _api.SaveAll()){
                return NoContent();
            }
            return Ok(BlogsUpdate);
        }
        [HttpDelete("{Id_Blog}")]

        public async Task<IActionResult> Delete(int Id_Blog){
            var Blogdelete = await _api.GetBlogsIdAsync(Id_Blog);
            if(Blogdelete == null){
                return NotFound("Usuario no encontrado");
            }
            _api.Delete(Blogdelete);
            if(!await _api.SaveAll()){
                return BadRequest("no se pudo eliminar el usuario");
            }
            return Ok(Blogdelete);
        }
    }
}