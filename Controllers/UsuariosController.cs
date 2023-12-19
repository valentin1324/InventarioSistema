using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class UsuariosController : Controller
{
    private readonly InventarioContext _context;

    public UsuariosController(InventarioContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Usuarios.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(usuario);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Usuario usuario)
    {
        if (id != usuario.UsuarioId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(usuario);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
