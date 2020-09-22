using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespesas.Models;

namespace GerenciadorDespesas.Controllers
{
    public class TipoDespesasController : Controller
    {
        private readonly Contexto _context;

        public TipoDespesasController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDespesas.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!string.IsNullOrWhiteSpace(txtProcurar))
            {
                return View(await _context.TiposDespesas.Where(td => td.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await _context.TiposDespesas.ToListAsync());
        }

        public async Task<JsonResult> TipoDespesaExiste(string Nome)
        {
            if(await _context.TiposDespesas.AnyAsync(td => td.Nome.ToUpper() == Nome.ToUpper()))
            {
                return Json("Esse tipo de despesa ja está cadastrado!");
            }

            return Json(true);
        }
        
        // GET: TipoDespesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDespesasId,Nome")] TipoDespesas tipoDespesas)
        {
            if (ModelState.IsValid)
            {
                TempData["Comfirmacao"] = tipoDespesas.Nome + " foi cadastrado com sucesso.";

                _context.Add(tipoDespesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesas);
        }

        // GET: TipoDespesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDespesas = await _context.TiposDespesas.FindAsync(id);
            if (tipoDespesas == null)
            {
                return NotFound();
            }
            return View(tipoDespesas);
        }

        // POST: TipoDespesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDespesasId,Nome")] TipoDespesas tipoDespesas)
        {
            if (id != tipoDespesas.TipoDespesasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Comfirmacao"] = tipoDespesas.Nome + " foi atualizado com sucesso.";

                    _context.Update(tipoDespesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDespesasExists(tipoDespesas.TipoDespesasId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesas);
        }

      

        // POST: TipoDespesas/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var tipoDespesas = await _context.TiposDespesas.FindAsync(id);
            TempData["Comfirmacao"] = tipoDespesas.Nome + " foi excluido com sucesso.";
            _context.TiposDespesas.Remove(tipoDespesas);
            await _context.SaveChangesAsync();
            return Json(tipoDespesas.Nome + " excluido com sucesso");
        }

        private bool TipoDespesasExists(int id)
        {
            return _context.TiposDespesas.Any(e => e.TipoDespesasId == id);
        }
    }
}
