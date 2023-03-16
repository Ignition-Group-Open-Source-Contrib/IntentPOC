using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IgnProductCatalogueService.Application
{

    public class SearchQuery
    {
        public SearchQuery()
        {
        }

        public static SearchQuery Create(
            List<QueryFilter> filters,
            IEnumerable<string> attributes)
        {
            return new SearchQuery
            {
                Filters = filters,
                Attributes = attributes,
            };
        }

        public List<QueryFilter> Filters { get; set; }

        public IEnumerable<string> Attributes { get; set; }

    }
}