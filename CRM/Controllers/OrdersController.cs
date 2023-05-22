using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using pepa = System.IO;
using System.Threading.Tasks;

namespace CRM.Controllers
{
    public class OrdersController : Controller
    {
        private readonly CRMContext _context;

        public OrdersController(CRMContext context)
        {
            _context = context;
        }

        // GET: OrdersController
        public async Task<IActionResult> Index()
        {
            var result = await _context.Orders.Include(x => x.Files).ToListAsync();
            return View(result);
        }

        // GET: OrdersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);
            return View(order);
        }

        // POST: OrdersController/Create
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = OrderStatus.Accepted;
            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: OrdersController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);
            return View(order);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var toUpdate = await _context.Orders.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);
                if (collection.Files.Count != 0)
                {
                    foreach (var file in collection.Files)
                    {
                        using var stream = new pepa.MemoryStream();
                        file.CopyTo(stream);
                        var bytes = stream.ToArray();
                        if(toUpdate.Files == null)
                        {
                            toUpdate.Files = new List<OrderFile>();
                        }
                        toUpdate.Files.Add(new OrderFile { OrderId = toUpdate.Id, Filename = file.FileName, File = bytes });
                    }
                }
                else
                {
                    toUpdate.Files = null;
                }

                var status = Convert.ToInt32(collection["Status"]);

                toUpdate.Status = (OrderStatus)status;
                toUpdate.Number = Convert.ToInt32(collection["Number"]);
                toUpdate.Description = collection["Description"].ToString();

                _context.Update(toUpdate);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(int fileId)
        {
            var file = await _context.OrderFiles.FirstOrDefaultAsync(x => x.Id == fileId);

            return File(file.File, System.Net.Mime.MediaTypeNames.Application.Octet, file.Filename);
        }

        // GET: OrdersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _context.Orders.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);

            return View(toDelete);
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var toDelete = await _context.Orders.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);
                _context.Orders.Remove(toDelete);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {

            return RedirectToAction("Edit");
        }
    }
}
