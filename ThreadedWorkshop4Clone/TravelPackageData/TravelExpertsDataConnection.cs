using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPackageData.Models;

namespace TravelPackageData
{

    public record ProductSupplierDTO(string ProductId, string ProductName, string SupplierId, string SupplierName);
    public class TravelExpertsDataConnection
    {
        private TravelExpertsContext db = new(); // The Database
        public Package? selectedPackage;
        public Product? FindProduct(int productId)
        {

            return db.Products.Find(productId);

        }
        public List<ProductSupplierDTO> GetAllProductsAndSuppliers() =>
        (from p in db.Products
         join productSupplier in db.ProductsSuppliers on p.ProductId equals productSupplier.ProductId
         join s in db.Suppliers on productSupplier.SupplierId equals s.SupplierId
         orderby p.ProductId
         select new ProductSupplierDTO(
             p.ProductId.ToString(),
             p.ProdName,
             s.SupplierId.ToString(),
             s.SupName
         )).ToList();

        public List<ProductSupplierDTO> GetProductsAndSuppliersOfSelectedPackage(Package selectedPackage) =>
            (from p in db.Products
             join ps in db.ProductsSuppliers on p.ProductId equals ps.ProductId
             join s in db.Suppliers on ps.SupplierId equals s.SupplierId
             join pps in db.PackagesProductsSuppliers on ps.ProductSupplierId equals pps.ProductSupplierId
             join pk in db.Packages on pps.PackageId equals pk.PackageId
             where pk.PackageId == selectedPackage!.PackageId
             orderby p.ProductId
             select new ProductSupplierDTO(
                 p.ProductId.ToString(),
                 p.ProdName,
                 s.SupplierId.ToString(),
                 s.SupName
             )).ToList();
    }
    
}
