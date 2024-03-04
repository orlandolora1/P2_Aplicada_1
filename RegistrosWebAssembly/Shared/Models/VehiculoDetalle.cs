using System.ComponentModel.DataAnnotations;
public class VehiculoDetalle
{
    [Key]

    public int VehiculoId { get; set; }
    public int AccesorioId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Today; 

    [Required(ErrorMessage = "Es necesario especificar por quien fue solicitado")]
    public string? SolicitadoPor { get; set; }

    [Required(ErrorMessage = "Es necesario especificar el asunto")]
    public string? Costo { get; set; }

    [Required(ErrorMessage = "Es necesario dar una descripcion")]
    public string? Descripcion { get; set; }

}