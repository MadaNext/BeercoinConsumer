using QRCode.DBContext;
using QRCode.Models;
namespace QRCode.Services;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    Product AddProduct(Product product);
    Product UpdateProduct(int id, Product product);
    void DeleteProduct(int id);
}

public class ProductService : IProductService
{
    private readonly IProductDbContext _context;

    public ProductService(IProductDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products;
    }

    public Product GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public Product AddProduct(Product product)
    {
        _context.AddProduct(product);
        return product;
    }

    public Product UpdateProduct(int id, Product product)
    {
        var existingProduct = _context.GetProductById(id);
        if (existingProduct != null)
        {
            _context.UpdateProduct(id, product);
            return existingProduct;
        }
        return null;
    }

    public void DeleteProduct(int id)
    {
        _context.DeleteProduct(id);
    }
}