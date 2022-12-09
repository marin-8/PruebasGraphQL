
using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;

using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Resolvers;

using AutoMapper;

using GraphQLPruebas.DTOs;
using GraphQLPruebas.Models;

namespace GraphQLPruebas.Data;

public class Query
{
	private static readonly Expression<Func<DEvento, string>> _Mapear_Precio =
		(entity) =>
			entity.PrecioMinimo.HasValue
				? entity.PrecioMaximo.HasValue
					? $"{(int)entity.PrecioMinimo} - {(int)entity.PrecioMaximo} €"
					: $"{(int)entity.PrecioMinimo} €"
				: "Gratis";

	private static readonly MapperConfiguration _MapperConfiguration =
		new (cfg =>
			cfg.CreateProjection<DEvento, ResumenEvento>()
			.ForMember(dto =>
				dto.Precio,
				conf => { conf.MapFrom(_Mapear_Precio); conf.ExplicitExpansion(); }));

	[UseProjection]
	[UseFiltering]
	[UseSorting]
	public IQueryable<ResumenEvento> GetEventos (
		IResolverContext resolverContext,
		[Service] AppJuJuDataBaseDevContext dbContext)
	{
		var fields =
			resolverContext.Selection.SyntaxNode.SelectionSet?.Selections
			.Select(s => FirstCharToUpper(s.ToString()))
			.ToArray();

		return dbContext.DEventos.ProjectTo<ResumenEvento>(_MapperConfiguration, null, fields);
	}

	public string FirstCharToUpper (string input)
	{
		if (input.Length == 0) return string.Empty;

		Span<char> destination = stackalloc char[1];
		input.AsSpan(0, 1).ToUpperInvariant(destination);
		return $"{destination}{input.AsSpan(1)}";
	}
}
