using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aajilaT5.Modelos
{
    [Table("persona")]
    public class Persona
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        [MaxLength(25), Unique]
        public string Nombre { get; set; }
        [Column("telefono")]
        [MaxLength(10), Unique]
        public string Telefono { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}
