using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolateData;
using HotChocolateWebApi.Models.Extensions;
using NJsonSchema.Infrastructure;

namespace HotChocolateWebApi.Models.Types
{
    public class CharacterObjectType : ObjectType<Character>
    {
        protected override void Configure(IObjectTypeDescriptor<Character> descriptor)
        {
            var x = typeof(Character).GetProperty(nameof(Character.Jobs));
            var jobsDescription = x.GetXmlSummaryAsync().GetAwaiter().GetResult();

            descriptor.AddFieldWithXmlDescription(f => f.Jobs)
                .Type<NonNullType<ListType<CharacterJobObjectType>>>();

            descriptor.Field(f => f.Id)
                .Type<IdType>();

            descriptor.Field(f => f.Name)
                .Type<NonNullType<StringType>>();
        }
    }
}