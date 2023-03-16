using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IgnProductCatalogueService.Application
{

    public class QueryFilter
    {
        public QueryFilter()
        {
        }

        public static QueryFilter Create(
            string field,
            string @operator,
            object value)
        {
            return new QueryFilter
            {
                Field = field,
                Operator = @operator,
                Value = value,
            };
        }

        public string Field { get; set; }

        public string Operator { get; set; }

        public object Value { get; set; }

    }
}