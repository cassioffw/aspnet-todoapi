namespace Todo.Models;

public class ResponseModel
{
    public bool Sucess {get; set;} = true;
    public string? Message {get; set;}
    public object? Data {get; set;}
}