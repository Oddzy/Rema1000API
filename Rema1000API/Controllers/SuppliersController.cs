using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DataAccess;
using DataAccess.Models;
using Rema1000API.Services;

namespace Rema1000API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISupplierService _supplierService;

        public SuppliersController(ApplicationDbContext context, ISupplierService supplierService)
        {
            _context = context;
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _supplierService.GetSuppliers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplier(id);

            return supplier;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            var result = await _supplierService.PutSupplier(id, supplier);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            var result = _supplierService.PostSupplier(supplier);

            return CreatedAtAction("GetSupplier", new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplier(id);
            return NoContent();
        }

    }
}
