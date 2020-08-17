using System;
using Fixer.Docs.Swagger;
using Fixer.WebApi.Swagger.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Fixer.WebApi.Swagger
{
    public static class Extensions
    {
        private const string SectionName = "swagger";

        public static IFixerBuilder AddWebApiSwaggerDocs(this IFixerBuilder builder, string sectionName = SectionName)
            => builder.AddWebApiSwaggerDocs(b => b.AddSwaggerDocs(sectionName));

        public static IFixerBuilder AddWebApiSwaggerDocs(this IFixerBuilder builder,
            Func<ISwaggerOptionsBuilder, ISwaggerOptionsBuilder> buildOptions)
            => builder.AddWebApiSwaggerDocs(b => b.AddSwaggerDocs(buildOptions));

        public static IFixerBuilder AddWebApiSwaggerDocs(this IFixerBuilder builder, SwaggerOptions options)
            => builder.AddWebApiSwaggerDocs(b => b.AddSwaggerDocs(options));

        private static IFixerBuilder AddWebApiSwaggerDocs(this IFixerBuilder builder, Action<IFixerBuilder> registerSwagger)
        {
            registerSwagger(builder);
            builder.Services.AddSwaggerGen(c => c.DocumentFilter<WebApiDocumentFilter>());
            return builder;
        }
    }
}
