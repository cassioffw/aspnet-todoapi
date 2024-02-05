using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;
[ApiController]
public class HomeController : ControllerBase
{
    [Authorize]
    [HttpGet("/")]
    public IActionResult Get([FromServices] AppDbContext context)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userTodos = context.Todos
                               .Where(todo => todo.UserId == userId)
                               .ToList();

        return Ok(userTodos);
    }

    [Authorize]
    [HttpGet("/{id:int}")]
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var todos = context.Todos.FirstOrDefault(x => x.Id == id);

        if (todos == null)
            return NotFound();

        return Ok(todos);
    }

    [Authorize]
    [HttpPost("/")]
    public async Task<IActionResult> Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        todo.CreatedAt = DateTime.UtcNow;
        todo.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        context.Todos.Add(todo);
        context.SaveChanges();
        return Created($"/{todo.Id}", todo);
    }

    [Authorize]
    [HttpPut("/{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] TodoModel todo,
        [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);

        if (model == null || model.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return NotFound();
        }
        model.Title = todo.Title;
        model.Done = todo.Done;

        context.Todos.Update(model);
        context.SaveChanges();
        return Ok(model);
    }

    [Authorize]
    [HttpDelete("/{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id,
        [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);
        if (model == null || model.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            return NotFound();
        context.Todos.Remove(model);
        context.SaveChanges();
        return Ok(model);
    }

}