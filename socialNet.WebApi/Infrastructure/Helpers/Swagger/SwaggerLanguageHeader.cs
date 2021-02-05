using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.Helpers
{
    public class SwaggerLanguageHeader : IOperationFilter
    {
        public enum Languages
        {
            pl = 0,
            en = 1,
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();


            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Description = "Supported languages",
                Schema = new OpenApiSchema
                {
                    Type = "String",
                    Enum = typeof(Languages)
                                        .GetEnumValues()
                                        .Cast<object>()
                                        .Select(value => (IOpenApiAny)new OpenApiString(value.ToString()))
                                        .ToList()
                },

                Required = false
            });
        }
    }
}
