using Godot;
using System;

namespace PS.Dice
{
    /// <Summary>
    /// Dice rolling example script, shows how the <see cref="DiceRoller"/> class can be used
    /// </Summary>
    public partial class DiceRollExample : Node
    {
        [Export]
        private Button diceRollButton;
        [Export]
        private OptionButton diceTypeOptionButton;
        [Export]
        private SpinBox diceAmountSpinBox;
        [Export]
        private RichTextLabel diceResultLabel;

        private int diceToRoll = 1;
        private DiceType diceType = DiceType.D6;

        public override void _Ready()
        {
            // Link together the signals from each of the buttons for our functionality
            diceTypeOptionButton.ItemSelected += DiceTypeChanged;
            diceAmountSpinBox.ValueChanged += DiceAmountChanged;
            diceRollButton.Pressed += RollDiceButtonPressed;
        }

        /// <Summary>
        /// Gets called when the dice type option button changes value, selects a dice type
        /// </Summary>
        private void DiceTypeChanged(long selectedItemID)
        {
            // Because the dice are ordered in the option button in the same order as they are in the dice type enum,
            // we can convert the selected item ID into the enum we'd like to use
            // Usually converting int to enum can be a bit risky, so we're doing this here only for example usage
            diceType = (DiceType)selectedItemID;
        }

        /// <Summary>
        /// Gets called when the dice amount spin box changes value, selects dice amount to roll
        /// </Summary>
        private void DiceAmountChanged(double diceAmount)
        {
            // Value we get from the spin box is a double, so we can convert this to int
            // settings on this spin box are set so that it gives integers anyway
            int diceAmountInt = Mathf.RoundToInt(diceAmount);
            // Then we can store this for when we want to roll the dice!
            diceToRoll = diceAmountInt;
        }

        /// <Summary>
        /// Gets called when the roll dice button is pressed, rolls our dice!
        /// </Summary>
        private void RollDiceButtonPressed()
        {
            // Rolls dice and puts the result in the dice result label
            int diceResult = DiceRoller.RollMultiple(diceType, diceToRoll);
            diceResultLabel.Text = diceResult.ToString();
            GD.Print($"Rolled {diceToRoll} {diceType}, result: {diceResult}");
        }

    }
}
