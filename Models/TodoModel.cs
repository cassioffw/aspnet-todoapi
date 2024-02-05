using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Todo.Models;

public class TodoModel
{
    [JsonIgnore]
    [BindNever]
    public int Id { get; set; }

    [Required(ErrorMessage = "Titulo é obrigatório!")]
    public required string Title { get; set; }
    public required DateTime DateTask { get; set; }

    public required bool Done { get; set; }

    [BindNever]
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }

    [BindNever]
    public required string UserId { get; set; }

}


