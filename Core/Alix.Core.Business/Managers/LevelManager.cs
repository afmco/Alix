using Alix.Core.Business.Characters;
using Alix.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Managers
{
    /// <summary>
    /// Handles leveling up a character
    /// </summary>
    public static class LevelManager
    {
        #region Public Methods

        public static void CheckLevelUp(IPlayable playableCharacter)
        {
            while (IsLevelUp(playableCharacter))
            {
                LevelUp(playableCharacter);
            }
        }

        #endregion

        #region Private Methods

        private static bool IsLevelUp(IPlayable playableCharacter)
        {
            long experienceNeeded = Constants.LevelOneExperience * (long)(Math.Pow(Constants.ExperienceModifier, double.Parse(playableCharacter.Level.ToString())));
            return playableCharacter.Experience >= experienceNeeded;
        }

        private static void LevelUp(IPlayable playableCharacter)
        {
            playableCharacter.Level++;
            // TODO: Formulas to determine how much to increase the other statistics
        }

        #endregion
    }
}
