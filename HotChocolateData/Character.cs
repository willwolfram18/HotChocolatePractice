using System;
using System.Collections.Generic;

namespace HotChocolateData
{
    /// <summary>
    /// Represents a character in the game.
    /// </summary>
    public class Character
    {
        public string Id { get; set; }

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The jobs the character has currently started leveling.
        /// </summary>
        public IEnumerable<CharacterJob> Jobs { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}