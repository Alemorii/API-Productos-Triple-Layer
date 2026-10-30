using Microsoft.AspNetCore.Mvc;
using ProductosApi.BL.Dtos;
using ProductosApi.BL.Services;



namespace ProductosApi.PL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _service;

    public ProductosController(IProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(_service.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var producto = _service.ObtenerPorId(id);
        if (producto is null) return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public IActionResult Crear([FromBody] CreateProductoDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var creado = _service.Crear(dto);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] CreateProductoDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var actualizado = _service.Actualizar(id, dto);
        if (actualizado is null) return NotFound();
        return Ok(actualizado);
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var eliminado = _service.Eliminar(id);
        if (!eliminado) return NotFound();
        return NoContent();
    }
}
