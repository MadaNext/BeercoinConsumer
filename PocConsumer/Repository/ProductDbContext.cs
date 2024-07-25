namespace QRCode.DBContext;

using QRCode;
using QRCode.Models;
using System.Collections.Generic;

public interface IProductDbContext
{
    IEnumerable<Product> Products { get; }
    Product GetProductById(int id);
    Product AddProduct(Product product);
    Product UpdateProduct(int id, Product product);
    void DeleteProduct(int id);
    // Add other methods or properties as needed
}

public class ProductDbContext : IProductDbContext
{
    private readonly Dictionary<int, Product> _productStore = new Dictionary<int, Product>();
    private int _nextProductId = 1;

    public IEnumerable<Product> Products => _productStore.Values;

    public Product GetProductById(int id)
    {
        if (_productStore.TryGetValue(id, out var product))
        {
            return product;
        }
        return null; // Product with the given ID not found
    }

    public Product AddProduct(Product product)
    {
        product.Id = _nextProductId++;
        _productStore.Add(product.Id, product);
        return product;
    }

    public Product UpdateProduct(int id, Product product)
    {
        if (_productStore.ContainsKey(id))
        {
            product.Id = id;
            _productStore[id] = product;
            return product;
        }
        return null; // Product with the given ID not found
    }

    public void DeleteProduct(int id)
    {
        if (_productStore.ContainsKey(id))
        {
            _productStore.Remove(id);
        }
    }
}