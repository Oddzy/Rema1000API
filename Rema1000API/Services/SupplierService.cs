using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Rema1000API.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            return supplier;
        }

        public async Task<bool> PutSupplier(int id, Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return false;
                }

                throw;
            }
        }

        public async Task<Supplier> PostSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.Include(x => x.Addresses).Include(x => x.ContactPersons).FirstOrDefaultAsync(x => x.Id == id);

            if (supplier == null)
            {
                return;
            }

            supplier.Addresses.ForEach(x => _context.Addresses.Remove(x));
            supplier.ContactPersons.ForEach(x => _context.ContactPersons.Remove(x));
            _context.Suppliers.Remove(supplier);

            await _context.SaveChangesAsync();

        }

        public bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}