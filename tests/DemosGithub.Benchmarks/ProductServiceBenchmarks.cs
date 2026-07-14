using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DemosGithub.Core.Services;

namespace DemosGithub.Benchmarks;

/// <summary>
/// Performance benchmarks for <see cref="ProductService"/>.
/// Measures throughput and latency of the main data-access operations.
/// </summary>
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class ProductServiceBenchmarks
{
    private ProductService _service = null!;

    [GlobalSetup]
    public void Setup() => _service = new ProductService();

    [Benchmark(Description = "GetAll – list all 1 000 products")]
    public int GetAll() => _service.GetAll().Count;

    [Benchmark(Description = "GetById – lookup existing product by id")]
    public Product? GetById() => _service.GetById(500);

    [Benchmark(Description = "GetById – lookup non-existing product")]
    public Product? GetByIdMiss() => _service.GetById(9999);

    [Benchmark(Description = "Search – partial-name search across all products")]
    public int Search() => _service.Search("Product 5").Count;

    [Benchmark(Description = "GetByPriceRange – filter products in a price range")]
    public int GetByPriceRange() => _service.GetByPriceRange(100m, 500m).Count;

    [Benchmark(Description = "CalculateTotalValue – aggregate price of all products")]
    public decimal CalculateTotalValue() => _service.CalculateTotalValue();
}
