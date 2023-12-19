using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class VentasController : Controller
{
    private readonly InventarioContext _context;

    public VentasController(InventarioContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Ventas.Include(v => v.Producto).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Venta venta)
    {
        if (ModelState.IsValid)
        {
            _context.Add(venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(venta);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var venta = await _context.Ventas.FindAsync(id);
        if (venta == null)
        {
            return NotFound();
        }
        return View(venta);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Venta venta)
    {
        if (id != venta.VentaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(venta);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var venta = await _context.Ventas.FindAsync(id);
        if (venta == null)
        {
            return NotFound();
        }

        _context.Ventas.Remove(venta);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
