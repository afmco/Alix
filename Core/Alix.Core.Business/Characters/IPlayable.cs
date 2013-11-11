using Alix.Core.Business.Classes;
using Alix.Core.Business.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Characters
{
    public interface IPlayable : ICharacter
    {
        #region Properties

        /// <summary>
        /// The maximum amount of hit points a playable character can have.
        /// </summary>
        long TotalHitPoints { get; set; }

        /// <summary>
        /// The amount of hit points a playable character has left. Cannot be below zero or above the <c>TotalHitPoints</c> property.
        /// </summary>
        long RemainingHitPoints { get; set; }

        /// <summary>
        /// The maximum amount of magic points a playable character can have.
        /// </summary>
        long TotalMagicPoints { get; set; }

        /// <summary>
        /// The amount of magic points a playable character has left. Cannot be below zero or above the <c>TotalMagicPoints</c> property.
        /// </summary>
        long RemainingMagicPoints { get; set; }

        /// <summary>
        /// The level of the playable character. This increases as the experience increases.
        /// </summary>
        int Level { get; set; }

        /// <summary>
        /// The experience of the playable character. This increases based on battles and potentially items.
        /// </summary>
        long Experience { get; set; }

        /// <summary>
        /// The strength of the playable character. This directly affects a character's hit power with close range weapons.
        /// </summary>
        int Strength { get; set; }

        /// <summary>
        /// The stamina of the playable character. This directly affects a character's total hit points, especially upon leveling up.
        /// </summary>
        int Stamina { get; set; }

        /// <summary>
        /// The agility of the playable character. This directly affects a character's ability to attack first in battle.
        /// </summary>
        int Agility { get; set; }

        /// <summary>
        /// The intelligence of the playable character. This directly affects the character's magical power.
        /// </summary>
        int Intelligence { get; set; }

        /// <summary>
        /// The charisma of the playable character. Not sure what this will do just yet.
        /// </summary>
        int Charisma { get; set; }

        /// <summary>
        /// The willpower of the playable character. This directly affects the character's ability to block status ailments.
        /// </summary>
        int Willpower { get; set; }

        /// <summary>
        /// The luck of the playable character. This has many uses. Not sure what they are just yet.
        /// </summary>
        int Luck { get; set; }

        /// <summary>
        /// The class of the playable character.
        /// </summary>
        IClass Class { get; set; }

        #endregion
    }
}
