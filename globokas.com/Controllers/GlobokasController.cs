using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using Entity;
//using Entity;
using Microsoft.AspNetCore.Mvc;
using Util;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace globokas.com.Controllers
{
    [Route("api/[controller]")]
    public class GlobokasController : Controller
    {

        private readonly GloboKasDbContext _context;

        public GlobokasController(GloboKasDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Usuario> GetUsurio(Usuario user)
        {
            return Mapper.Map<IEnumerable<Usuario>>(_context.Usuario.OrderBy(x => x.Correo));
        }


        [HttpGet("ListaRol")]
        public IEnumerable<Rol> ListaRol()
        {
            return Mapper.Map<IEnumerable<Rol>>(_context.Rol.OrderBy(x => x.Idrol));
        }

        [HttpGet("CalificacionSegunCliente")]
        public List<Calificacion> CalificacionSegunCliente()
        {
            //var calificcacion=Mapper.Map<IEnumerable<Calificacion>>(_context.Calificacion.OrderBy(x => x.Correo));

         var calificacion = Mapper.Map<IEnumerable<Calificacion>>(_context.Calificacion).ToList();
         var listaCliente = Mapper.Map<IEnumerable<Cliente>>(_context.Cliente).Where(x => x.IdUsuario==  1).FirstOrDefault();           
          var calificacionDTO = calificacion.Where(x => listaCliente.Idcliente==x.Idcliente).ToList();
            return calificacionDTO;
        }
        [HttpPost]
        public async Task<IActionResult> GuardarUsuario([FromBody] UsuarioDTO usuario)
        {

            if (usuario.Password != null)
            {
                UsuarioDTO usu = new UsuarioDTO();
                usu = usuario;
                var key = "E546C8DF278CD5931069B522E695D4F2";
                usu.Password = EncriptacionAES.Encriptar("DDD" + usu.Password + "DDD", key);
                usu.IdRol = 1;
                usu.FechaCreacion = DateTime.Now;


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var os = Mapper.Map<Usuario>(usu);

                _context.Usuario.Add(os);
                await _context.SaveChangesAsync();
                usuario.IdUsuario = os.IdUsuario;
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Json(usuario);
            // return CreatedAtAction("GetOrderStatus", new { IdUsuario = os.IdUsuario }, usuario);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuario)
        {
            UsuarioDTO usu = new UsuarioDTO();
            var usuariolist= new Usuario();
           usu = usuario;
            var passdescripter = string.Empty;
            if (usu.Password != null)
            {
                var key = "E546C8DF278CD5931069B522E695D4F2";
                 usuariolist = Mapper.Map<IEnumerable<Usuario>>(_context.Usuario).Where(x => x.Correo==usu.Correo).FirstOrDefault();
                passdescripter = EncriptacionAES.Desencriptar("DDD" + usu.Password + "DDD", key);

            }
            else {
                return Json("UsuarioInvalido");
            }
            //var os = Mapper.Map<Usuario>(usu);
            //_context.Usuario.Add(os);
            //await _context.SaveChangesAsync();
            if (passdescripter != null && passdescripter != "" && usuariolist!= null && usuariolist.Password !=null)
            {
                if (passdescripter != usuariolist.Password)
                {
                    return Json("UsuarioInvalido");
                }
                else
                {
                    return Json("EXITO");

                }
            }
            else
            {
                return Json("UsuarioInvalido");

            }
        }

    }
}
