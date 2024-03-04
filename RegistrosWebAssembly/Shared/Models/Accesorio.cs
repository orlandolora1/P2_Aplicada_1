using System.ComponentModel.DataAnnotations;

public class Accesorio
{
    [Key]
    public int AccesorioId { get; set; }

    [Required(ErrorMessage = "La descripcion no puede ser nula")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Es necesario agregar los dias de compromiso")]
    [Range(0, 31)]
    public int Costo { get; set; }
    public int Gastos { get; set; }
}