using CDWebShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CDWebShop.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customer
        public async Task<ViewResult> Index()
        {
            if (User.IsInRole("Admin"))
                return View("AdminIndex", await _context.Customers.ToListAsync());
            
            return View(await _context.Customers.ToListAsync());
        }
               
        public async Task<ActionResult> Create()
        {
            if (User.IsInRole("Admin"))
                return View(new CreateCustomerViewModel {
                    Subscriptions = await _context.Subscriptions.ToListAsync()
                }); 
            
            return HttpNotFound();
        }

        [ValidateAntiForgeryToken] [HttpPost]
        public async Task<ActionResult> Create(CreateCustomerViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Subscriptions = await _context.Subscriptions.ToListAsync();
                return View(vm);
            }

            if (User.IsInRole("Admin"))
            {
                Customer nc = new Customer
                {
                    Firstname = vm.Firstname,
                    Lastname = vm.Lastname,
                    Email = vm.Email,
                    Subscription = await _context.Subscriptions.SingleOrDefaultAsync(s => s.Id.Equals(vm.SubscriptionId))
                };

                _context.Customers.Add(nc);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            
            return HttpNotFound();
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (User.IsInRole("Admin"))
            {
                Customer cu = await _context.Customers.Include(c => c.Subscription).FirstOrDefaultAsync(c => c.Id.Equals(id));
                return View(new EditCustomerViewModel
                {
                    Id = cu.Id,
                    Firstname = cu.Firstname,
                    Lastname = cu.Lastname,
                    Email = cu.Email,
                    SubscriptionId = cu.Subscription.Id,
                    Subscriptions = await _context.Subscriptions.ToListAsync()
                });
            }

            return HttpNotFound();
        }

        [ValidateAntiForgeryToken] [HttpPost]
        public async Task<ActionResult> Edit(EditCustomerViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Subscriptions = await _context.Subscriptions.ToListAsync();
                return View(vm);
            }

            if (User.IsInRole("Admin"))
            {
                Customer customerInDb = await _context.Customers.Include(c => c.Subscription).FirstOrDefaultAsync(c => c.Id.Equals(vm.Id));

                customerInDb.Firstname = vm.Firstname;
                customerInDb.Lastname = vm.Lastname;
                customerInDb.Email = vm.Email;
                customerInDb.Subscription = await _context.Subscriptions.FirstOrDefaultAsync(s => s.Id.Equals(vm.SubscriptionId));

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            
            return HttpNotFound();
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (User.IsInRole("Admin"))            
                return View(await _context.Customers.FirstOrDefaultAsync(x => x.Id.Equals(id)));
           
            return HttpNotFound();
        }

        [ValidateAntiForgeryToken] [HttpPost]
        public async Task<ActionResult> Delete(Customer c)
        {
            if (User.IsInRole("Admin"))
            {
                _context.Customers.Remove(await _context.Customers.FirstOrDefaultAsync(x => x.Id.Equals(c.Id)));
                await _context.SaveChangesAsync();

                return Redirect("/Customer");
            }

            return HttpNotFound();
        }
    }
}