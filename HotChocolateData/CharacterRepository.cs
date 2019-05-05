using System;
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
                CreatedAt = DateTimeOffset.Parse("2019-01-10 08:14:12-08:00"),
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
                CreatedAt = DateTimeOffset.Parse("2017-04-13 15:21:10-04:00"),
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
            },
            new Character
            {
                Id = "3",
                Name = "Haynd Silverback",
                CreatedAt = DateTimeOffset.Parse("2019-02-02 01:04:17-07:00"),
                Jobs = new []
                {
                    new CharacterJob
                    {
                        Level = 35,
                        Class = CharacterClass.Summoner
                    },
                    new CharacterJob
                    {
                        Level = 9,
                        Class = CharacterClass.Warrior
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

        public Task<IEnumerable<Character>> GetFriendsOfCharacter(string characterId)
        {
            return Task.FromResult(
                _characters.Where(c => c.Id != characterId)
            );
        }
    }
}