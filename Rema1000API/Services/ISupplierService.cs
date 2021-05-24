using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Rema1000API.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetSuppliers();

        Task<Supplier> GetSupplier(int id);

        Task<bool> PutSupplier(int id, Supplier supplier);

        Task<Supplier> PostSupplier(Supplier supplier);

        Task DeleteSupplier(int id);

        bool SupplierExists(int id);
    }
}