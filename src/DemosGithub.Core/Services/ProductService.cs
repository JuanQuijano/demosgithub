namespace DemosGithub.Core.Services;

public class ProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        _products = Enumerable.Range(1, 1000)
            .Select(i => new Product(i, $"Product {i}", i * 9.99m))
            .ToList();
    }

    public IReadOnlyList<Product> GetAll() => _products;

    public Product? GetById(int id) =>
        _products.FirstOrDefault(p => p.Id == id);

    public IReadOnlyList<Product> Search(string term) =>
        _products
            .Where(p => p.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
            .ToList();

    public IReadOnlyList<Product> GetByPriceRange(decimal min, decimal max) =>
        _products
            .Where(p => p.Price >= min && p.Price <= max)
            .ToList();

    public decimal CalculateTotalValue() =>
        _products.Sum(p => p.Price);
}

public record Product(int Id, string Name, decimal Price);
