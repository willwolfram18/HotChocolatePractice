using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolateData
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetCharacters();

        Task<Character> GetCharacterById(string id);

        Task<IEnumerable<Character>> GetFriendsOfCharacter(string characterId);
    }
}