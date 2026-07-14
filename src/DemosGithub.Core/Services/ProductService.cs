namespace DemosGithub.Core.Services;

public class ProductService
{
    private readonly List<Product> _products;
    private readonly Dictionary<int, Product> _productsById;

    public ProductService()
    {
        _products = Enumerable.Range(1, 1000)
            .Select(i => new Product(i, $"Product {i}", i * 9.99m))
            .ToList();
        _productsById = _products.ToDictionary(p => p.Id);
    }

    public IReadOnlyList<Product> GetAll() => _products;

    public Product? GetById(int id) =>
        _productsById.GetValueOrDefault(id);

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
