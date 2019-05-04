using HotChocolateData;

namespace HotChocolateWebApi.Models.Operations
{
    public class Query
    {
        private readonly ICharacterRepository _characterRepo;

        public Query(ICharacterRepository characterRepo)
        {
            _characterRepo = characterRepo;
        }

        public string Hello()
        {
            return "Hello from GraphQL!";
        }
    }
}