# Old Phone Keypad Text Converter

This project implements a solution for converting old phone keypad inputs into text, simulating the T9 texting experience from early mobile phones.

## Problem Description

The challenge involves implementing a method `OldPhonePad` that converts a string of numbers, spaces, and special characters into text based on an old phone keypad layout:

```
1: &'(    2: ABC    3: DEF
4: GHI    5: JKL    6: MNO
7: PQRS   8: TUV    9: WXYZ
0: Space  *: Backspace  #: Send
```

The input follows these rules:
- Pressing a button multiple times cycles through the available characters
- A space represents a 1-second pause, needed when typing consecutive characters from the same button
- The "*" character functions as a backspace, deleting the last character
- The "#" character marks the end of the input (and is always included)

## Implementation Details

The solution is structured into three main components:

1. **Main Method (`OldPhonePad`)**: Processes the input string and returns the corresponding text output.
2. **Segment Processing**: Handles portions of input between spaces.
3. **Digit Group Processing**: Manages consecutive occurrences of the same digit.

### Algorithm

The algorithm works as follows:

1. Validate that the input ends with "#" and remove it
2. Split the input by spaces to handle the pauses between same-button characters
3. For each segment:
   - Group consecutive identical digits
   - For each group, determine the corresponding character based on the number of presses
   - Handle backspace characters by removing characters from the result
4. Return the final string

## Testing

The solution includes comprehensive unit tests covering:
- Basic character conversion
- Handling of backspace characters
- Multiple consecutive characters from the same button
- Edge cases like empty strings and multiple backspaces
- Special characters and spaces

## Usage Example

```csharp
// Returns "HELLO"
string result = PhoneKeypad.OldPhonePad("4433555 555666#");
```

