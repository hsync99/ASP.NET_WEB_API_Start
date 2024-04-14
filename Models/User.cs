using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace rpgapi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswrodSalt { get; set; }
        public List<Character>? Characters { get; set; }

    }
}
