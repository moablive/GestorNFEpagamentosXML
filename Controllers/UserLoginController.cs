//System
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;

//Project
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
                // Hash da senha usando SHA256
                usuario.senha = HashSenha(usuario.senha);

                _context.UserLoginMODEL.Add(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CadastrarUsuario), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar usuário: {ex.Message}");
            }
        }

        // Método para realizar o hash SHA256 na senha
        private string HashSenha(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
