using System.Collections.Generic;

namespace HotChocolateData
{
    public class Character
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CharacterJob> Jobs { get; set; }
    }
}