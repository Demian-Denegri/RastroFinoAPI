using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Genero")]
public class Genero
{
    [Key]
    public int IdGenero { get; set; }

    [Column("Genero")]
    public string Nombre { get; set; }
}