# Godot Dice Rolling
Simple dice rolling system for Godot Engine in C#!

Works using a static class for ease of access for rolling dice

## Features
- Roll dice for common dice types e.g. d6, d20
- Roll dice of custom number of sides e.g. d42
- Roll multiple dice and combine the results e.g. 2d4

## Installation
- Simply clone or download the repository into your Godot project

## Usage
- Add `using PS.Dice` to your script
- Use any of the dice rolling methods from the `DiceRoller` static class e.g. `DiceRoller.Roll(DiceType.D20)`

## Notes
- Tested in Godot 4.5.1, and should work in all Godot 4.x versions
- If using in Godot 3.x or lower, make sure to initialise global random first in `_Ready()` using `GD.Randomize()`, for more info see [the Godot Docs](https://docs.godotengine.org/en/stable/tutorials/math/random_number_generation.html#the-randomize-method)

## License
Released under [MIT License](https://github.com/Pos1tr0n/godot-dice-rolling/blob/main/LICENSE)
