using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cmpg323_Hw2.Data;
using cmpg323_Hw2.Models;
using cmpg323_Hw2.Repository;

namespace cmpg323_Hw2.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceRepository _services;

        public ServicesController(IServiceRepository service)
        {
            this._services = service;
        }

        // GET: Services
        public IActionResult Index()
        {
            return View(_services.GetAll());
        }

        // GET: Services/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = _services.Get((Guid)id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ServiceId,ServiceName,ServiceDescription,CreatedDate")] Services services)
        {
            if (ModelState.IsValid)
            {
                services.ServiceId = Guid.NewGuid();
                _services.Add(services);
                return RedirectToAction(nameof(Index));
            }
            return View(services);
        }

        // GET: Services/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = _services.Get((Guid)id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ServiceId,ServiceName,ServiceDescription,CreatedDate")] Services services)
        {
            if (id != services.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _services.Update(services);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesExists(services.ServiceId))
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
            return View(services);
        }

        // GET: Services/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = _services.Get((Guid)id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var services = _services.Get((Guid)id);
            _services.Remove(services);
            return RedirectToAction(nameof(Index));
        }

        private bool ServicesExists(Guid id)
        {
            return _services.Exists(id);
        }
    }
}
