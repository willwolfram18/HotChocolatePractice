using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateData
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly List<Character> _characters = new List<Character>
        {
            new Character
            {
                Id = "1",
                Name = "Atryn Cloudtreader",
                Jobs = new []
                {
                    new CharacterJob
                    {
                        Level = 50,
                        Class = CharacterClass.Samurai
                    },
                    new CharacterJob
                    {
                        Level = 57,
                        Class = CharacterClass.RedMage
                    },
                    new CharacterJob
                    {
                        Level = 40,
                        Class = CharacterClass.Summoner
                    }
                }
            },
            new Character
            {
                Id = "2",
                Name = "Ickthid Stolenpants",
                Jobs = new []
                {
                    new CharacterJob
                    {
                        Level = 10,
                        Class = CharacterClass.Warrior
                    },
                    new CharacterJob
                    {
                        Level = 70,
                        Class = CharacterClass.Ninja
                    }
                }
            }
        };

        public Task<Character> GetCharacterById(string id)
        {
            return Task.FromResult(_characters.FirstOrDefault(c => c.Id == id));
        }

        public Task<IEnumerable<Character>> GetCharacters()
        {
            return Task.FromResult((IEnumerable<Character>)_characters);
        }
    }
}