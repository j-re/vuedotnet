using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vue.Data;

namespace vue.Features.Filters
{
  [Route("api/[controller]")]
  public class FiltersController : Controller
  {
    private readonly VueContext _db;

    public FiltersController(VueContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var brands = await _db.Brands
        .Select(x => x.Name)
        .ToListAsync();

      var storage = await _db.Storage
        .Select(x => $"{x.Capacity}GB")
        .ToListAsync();

      var colours = await _db.Colours
        .Select(x => x.Name)
        .ToListAsync();

      var os = await _db.OS
        .Select(x => x.Name)
        .ToListAsync();

      var features = await _db.Features
        .Select(x => x.Name)
        .ToListAsync();

      return Ok(new FiltersListViewModel
      {
        Brands = brands,
        Storage = storage,
        Colours = colours,
        OS = os,
        Features = features
      });
    }
  }
}