using System.ComponentModel.DataAnnotations;

public class Vehiculo
{
    [Key]
    public int VehiculoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "La longitud del nombre debe estar entre 5 y 30 caracteres.")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar un número de teléfono.")]
    [StringLength(maximumLength: 17, MinimumLength = 10, ErrorMessage = "La longitud del número de teléfono debe estar entre 10 y 17 caracteres.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El celular es obligatorio.")]
    [StringLength(maximumLength: 17, MinimumLength = 10, ErrorMessage = "La longitud del número de celular debe estar entre 10 y 17 caracteres.")]
    public string? Celular { get; set; }

    [Required(ErrorMessage = "El RNC es obligatorio.")]
    [StringLength(maximumLength: 17, MinimumLength = 10, ErrorMessage = "La longitud del RNC debe estar entre 10 y 17 caracteres.")]
    public string RNC { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar un correo electrónico.")]
    [StringLength(maximumLength: 30, MinimumLength = 15, ErrorMessage = "La longitud del correo electrónico debe estar entre 15 y 30 caracteres.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar una dirección.")]
    [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "La longitud de la dirección debe estar entre 6 y 50 caracteres.")]
    public string Direccion { get; set; } = string.Empty;
}
