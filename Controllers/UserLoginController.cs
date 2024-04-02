using Microsoft.AspNetCore.Mvc;
using GestorNFEpagamentosXML.Db;
using GestorNFEpagamentosXML.Models;

namespace GestorNFEpagamentosXML.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly DataContext _context;

        public UserLoginController(DataContext context)
        {
            _context = context;
        }

        // CADASTRAR
        [HttpPost]
        public async Task<ActionResult<UserLoginMODEL>> CadastrarUsuario(UserLoginMODEL usuario)
        {
            try
            {
                _context.UserLoginMODEL.Add(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CadastrarUsuario), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar usuário: {ex.Message}");
            }
        }
    }
}
