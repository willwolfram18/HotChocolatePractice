using HotChocolate.Types;
using HotChocolateData;

namespace HotChocolateWebApi.Models.Types
{
    public class CharacterObjectType : ObjectType<Character>
    {
        protected override void Configure(IObjectTypeDescriptor<Character> descriptor)
        {
            descriptor.Field(f => f.Jobs)
                .Type<NonNullType<ListType<CharacterJobObjectType>>>();

            descriptor.Field(f => f.Id)
                .Type<IdType>();

            descriptor.Field(f => f.Name)
                .Type<NonNullType<StringType>>();
        }
    }
}