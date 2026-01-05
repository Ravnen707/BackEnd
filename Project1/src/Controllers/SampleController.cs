using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using project1.Api.Models;

namespace project1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    private static readonly List<SampleModel> Items = new()
    {
        new SampleModel { Id = 1, Name = "Sample" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<SampleModel>> Get() => Ok(Items);

    [HttpGet("{id}")]
    public ActionResult<SampleModel> Get(int id)
    {
        var item = Items.FirstOrDefault(x => x.Id == id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public ActionResult<SampleModel> Post(SampleModel model)
    {
        model.Id = (Items.Count == 0 ? 1 : Items.Max(i => i.Id) + 1);
        Items.Add(model);
        return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, SampleModel model)
    {
        var index = Items.FindIndex(x => x.Id == id);
        if (index == -1) return NotFound();
        model.Id = id;
        Items[index] = model;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var index = Items.FindIndex(x => x.Id == id);
        if (index == -1) return NotFound();
        Items.RemoveAt(index);
        return NoContent();
    }
}