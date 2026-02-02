using Godot;
using Godot.Collections;
using System;

namespace PS.Dice
{
    /// <Summary>
    /// Common dice types
    /// </Summary>
    public enum DiceType
    {
        D2, // Included here for convenience, basically a coin flip
        D4,
        D6, // Standard 6 sided die
        D8,
        D10,
        D12,
        D20,
        D100 // In D&D this would be done with percentile die and d10
    }

    /// <Summary>
    /// Dice Rolling static class, useful for rolling dice, tabletop RPG style
    /// <para>Remember to initialise random with GD.Randomize if using a version of Godot before 4.0</para>
    /// </Summary>
    public static class DiceRoller
    {
        /// <Summary>
        /// Lookup table for DiceType
        /// </Summary>
        private static readonly Dictionary<DiceType, int> diceLookupTable = new()
        {
            { DiceType.D2, 2 },
            { DiceType.D4, 4 },
            { DiceType.D6, 6 },
            { DiceType.D8, 8 },
            { DiceType.D10, 10 },
            { DiceType.D12, 12 },
            { DiceType.D20, 20 },
            { DiceType.D100, 100 },
        };

        /// <Summary>
        /// Lookup table for DiceType
        /// </Summary>
        public static Dictionary<DiceType, int> DiceLookupTable => diceLookupTable;

        /// <Summary>
        /// Rolls a dice with the specified number of faces
        /// </Summary>
        public static int Roll(int faces)
        {
            // Generates a random number between 1 and the number of faces specified (inclusive random) and returns the result
            int result = GD.RandRange(1, faces);
            return result;
        }

        /// <Summary>
        /// Rolls a dice based on a common die type, e.g. d6
        /// </Summary>
        public static int Roll(DiceType diceType)
        {
            // Rolls a dice based on the dice type from the dice lookup table, and returns the result
            int result = Roll(DiceLookupTable[diceType]);
            return result;
        }

        /// <Summary>
        /// Rolls multiple dice with the specified number of faces, combining the rolls together
        /// </Summary>
        public static int RollMultiple(int faces, int amount)
        {
            // Rolls the amount of dice specified, adding each result to a total, which we then return
            int totalResult = 0;
            for (int i = 0; i < amount; i++)
            {
                totalResult += Roll(faces);
            }
            return totalResult;
        }

        /// <Summary>
        /// Rolls multiple common dice e.g. 2d6, combining rolls together
        /// </Summary>
        public static int RollMultiple(DiceType diceType, int amount)
        {
            // Rolls the amount of dice based on the dice type from the dice lookup table, and returns the total result
            int totalResult = RollMultiple(DiceLookupTable[diceType], amount);
            return totalResult;
        }
    }
}
