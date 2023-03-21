﻿using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace IgnProductCatalogueService.Application.Helper
{
    public class MongoDBQueryBuilder<TDomain>
    {
        bool firstClauseAdded = false;
        public FilterDefinition<TDomain> CreateFilter(List<QueryFilter> filters)
        {
            var builder = Builders<TDomain>.Filter;
            FilterDefinition<TDomain> completeFilter = builder.Empty;
            foreach (var filter in filters)
            {
                FilterDefinition<TDomain> fl = builder.Empty;
                switch (filter.Operator)
                {
                    case "in":
                        fl = builder.Eq(filter.Field, filter.Value);
                        break;
                    case "=":
                        fl = builder.Eq(filter.Field, filter.Value);
                        break;
                    case ">":
                        fl = builder.Gt(filter.Field, filter.Value);
                        break;
                    case ">=":
                        fl = builder.Gte(filter.Field, filter.Value);
                        break;
                    case "<":
                        fl = builder.Lt(filter.Field, filter.Value);
                        break;
                    case "<=":
                        fl = builder.Lte(filter.Field, filter.Value);
                        break;
                    case "!=":
                        fl = builder.Ne(filter.Field, filter.Value);
                        break;
                    case "like":
                        fl = builder.Regex(filter.Field, new BsonRegularExpression(filter.Value.ToString()));
                        break;
                    default:
                        fl = builder.Eq(filter.Field, filter.Value);
                        break;
                }
                completeFilter = firstClauseAdded ? completeFilter & fl : fl;
                firstClauseAdded = true;
            }
            return completeFilter;
        }

    }
}