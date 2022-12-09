
using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using GraphQLPruebas.Data;
using GraphQLPruebas.Models;

namespace GraphQLPruebas;

public class Program
{
	public static void Main (string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddDbContext<AppJuJuDataBaseDevContext>(
			(optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information));
		builder.Services.AddAutoMapper(typeof(Program));
		builder.Services.AddGraphQLServer()
			.AddProjections()
			.AddFiltering()
			.AddSorting()
			.AddQueryType<Query>();

		var app = builder.Build();
		app.MapGet("/", () => "Hello World!");
		app.MapGraphQL();

		app.Run();
	}
}
