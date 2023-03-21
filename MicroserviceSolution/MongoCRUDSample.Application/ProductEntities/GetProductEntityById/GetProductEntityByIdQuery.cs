using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoCRUDSample.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities.GetProductEntityById
{
    public class GetProductEntityByIdQuery : IRequest<ProductEntityDto>, IQuery
    {
        public string Id { get; set; }

    }
}