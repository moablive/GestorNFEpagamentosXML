using System.ComponentModel.DataAnnotations.Schema;

namespace GestorNFEpagamentosXML.Models
{
    [Table("User")]
    public class UserLoginMODEL
    {
         public int? Id { get; set; }
         public string email { get; set; }
         public string senha { get; set; }
    }
}