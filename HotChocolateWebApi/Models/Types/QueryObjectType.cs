using HotChocolate.Types;
using HotChocolateWebApi.Models.Extensions;
using HotChocolateWebApi.Models.Operations;

namespace HotChocolateWebApi.Models.Types
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.AddFieldWithXmlDescription(f => f.Characters())
                .Type<NonNullType<ListType<CharacterObjectType>>>();

            descriptor.Field(f => f.Character(default))
                .Description("Get a particular Final Fantasy XIV character by Id");
        }
    }
}