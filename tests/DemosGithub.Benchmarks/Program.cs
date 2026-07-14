using BenchmarkDotNet.Running;
using DemosGithub.Benchmarks;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
