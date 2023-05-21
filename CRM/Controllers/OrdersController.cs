using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var result = await _context.Orders.ToListAsync();
            return View(result);
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = OrderStatus.Active;
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: OrdersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            return View(toDelete);
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var toDelete = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                _context.Orders.Remove(toDelete);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
