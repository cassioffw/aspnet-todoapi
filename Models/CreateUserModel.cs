using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Todo.Models;

public class CreateUserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [BindNever]
    [JsonIgnore]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Usuario é obrigatório!")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "Admin? é obrigatório!")]
    public required bool IsAdmin { get; set; }

    [Required(ErrorMessage = "Email é obrigatório!")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatório!")]
    public required string Password { get; set; }

}
