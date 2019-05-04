using System.Collections.Generic;
using System.Threading.Tasks;
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

        /// <summary>
        /// Trying out a summary XML doctring.
        /// </summary>
        public Task<IEnumerable<Character>> Characters()
        {
            return _characterRepo.GetCharacters();
        }

        public Task<Character> Character(string id)
        {
            return _characterRepo.GetCharacterById(id);
        }
    }
}