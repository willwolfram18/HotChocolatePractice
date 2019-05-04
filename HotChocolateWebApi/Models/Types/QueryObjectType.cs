using HotChocolate.Types;
using HotChocolateWebApi.Models.Operations;

namespace HotChocolateWebApi.Models.Types
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(f => f.Characters())
                .Description("Get the Final Fantasy XIV characters.")
                .Type<NonNullType<ListType<CharacterObjectType>>>();
        }
    }
}