using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class NotificacionesController : Controller
{
    private readonly InventarioContext _context;

    public NotificacionesController(InventarioContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Notificaciones.Include(n => n.Producto).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Notificacion notificacion)
    {
        if (ModelState.IsValid)
        {
            _context.Add(notificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(notificacion);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var notificacion = await _context.Notificaciones.FindAsync(id);
        if (notificacion == null)
        {
            return NotFound();
        }
        return View(notificacion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Notificacion notificacion)
    {
        if (id != notificacion.NotificacionId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(notificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(notificacion);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var notificacion = await _context.Notificaciones.FindAsync(id);
        if (notificacion == null)
        {
            return NotFound();
        }

        _context.Notificaciones.Remove(notificacion);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
