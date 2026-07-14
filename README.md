# demosgithub

Demo repository for GitHub Copilot features.

## Projects

| Project | Description |
|---------|-------------|
| `src/DemosGithub.Core` | Core business logic (services, models) |
| `src/DemosGithub.Api` | Minimal ASP.NET Core Web API |
| `tests/DemosGithub.Benchmarks` | BenchmarkDotNet performance benchmarks |

## Building

```bash
dotnet build DemosGithub.slnx
```

## Running the API

```bash
dotnet run --project src/DemosGithub.Api
```

## Running Performance Benchmarks

Run all benchmarks (requires Release build):

```bash
dotnet run --project tests/DemosGithub.Benchmarks -c Release
```

List available benchmarks without executing them:

```bash
dotnet run --project tests/DemosGithub.Benchmarks -- --list flat
```

Run a specific benchmark class:

```bash
dotnet run --project tests/DemosGithub.Benchmarks -c Release -- --filter "*ProductService*"
```

### Available Benchmarks

| Benchmark | Description |
|-----------|-------------|
| `GetAll` | Lists all 1 000 products |
| `GetById` | Looks up an existing product by id |
| `GetByIdMiss` | Looks up a non-existing product |
| `Search` | Partial-name search across all products |
| `GetByPriceRange` | Filters products in a price range |
| `CalculateTotalValue` | Aggregates the price of all products |