using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using HotChocolate.Types;
using HotChocolateData;
using HotChocolateWebApi.Models.Extensions;
using NJsonSchema.Infrastructure;

namespace HotChocolateWebApi.Models.Types
{
    public class CharacterObjectType : ObjectType<Character>
    {
        protected override void Configure(IObjectTypeDescriptor<Character> descriptor)
        {
            descriptor.DescriptionFromXmlSummary();

            descriptor.FieldWitDescriptionFromXmlSummary(f => f.Jobs)
                .Type<NonNullType<ListType<CharacterJobObjectType>>>();

            descriptor.FieldWitDescriptionFromXmlSummary(f => f.Id)
                .Type<IdType>();

            descriptor.FieldWitDescriptionFromXmlSummary(f => f.Name)
                .Type<NonNullType<StringType>>();

            descriptor.FieldWitDescriptionFromXmlSummary(f => f.CreatedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}