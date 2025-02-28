using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad_Iron_CoChallenge.Class
{
    public class PhoneKeypad
    {
        // Phone keypad mapping
        private static Dictionary<char, string> KeypadMappings = new Dictionary<char, string>
        {
            {'0', " "},
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'*', ""}, 
            {'#', ""}, 
        };

        /// param => The input string with # marking the end.
        /// returns => The resulting text output after processing the keypad presses
        public static string OldPhonePad(string input)
        {
            ValidateInput(input);

            string trimmedInput = input.TrimEnd('#');

            return ProcessInput(trimmedInput);
        }

        /// Validates that the input is properly formatted
        private static void ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input must not be empty", nameof(input));
            }

            if (!input.Contains("#"))
            {
                throw new ArgumentException("Input must contain a terminating # character", nameof(input));
            }
        }

        /// Processes the input string and converts it to the old phone keypad output
        private static string ProcessInput(string input)
        {
            StringBuilder result = new StringBuilder();
            string[] segments = input.Split(' ');

            foreach (var segment in segments)
            {
                if (string.IsNullOrEmpty(segment))
                {
                    result.Append(' ');
                    continue;
                }

                ProcessSegment(segment, result);
            }

            return result.ToString();
        }

        /// Processes a segment (portion of input between spaces) and appends the resulting characters to the output.        
        /// result =>The StringBuilder to which the processed characters are appended
        private static void ProcessSegment(string segment, StringBuilder result)
        {
            int i = 0;
            while (i < segment.Length)
            {
                char currentDigit = segment[i];
                int count = CountConsecutiveDigits(segment, i, currentDigit);

                ProcessDigitGroup(currentDigit, count, result);

                i += count;
            }
        }

        /// summary => Counts consecutive occurrences of a digit in a segment
        /// segment => The segment to check
        /// startIndex => The starting index
        /// digit => The digit to count
        /// returns => The count of consecutive occurrences
        private static int CountConsecutiveDigits(string segment, int startIndex, char digit)
        {
            int count = 0;
            for (int i = startIndex; i < segment.Length && segment[i] == digit; i++)
            {
                count++;
            }
            return count;
        }

        /// summary => Processes a group of consecutive identical digits and updates the result accordingly
        /// digit => The digit being processed
        /// count => The number of consecutive occurrences of the digit
        /// result => The StringBuilder to which the processed characters are appended
        private static void ProcessDigitGroup(char digit, int count, StringBuilder result)
        {
            // Handle backspace (*) - remove last character for each *
            if (digit == '*')
            {
                for (int i = 0; i < count; i++)
                {
                    if (result.Length > 0)
                    {
                        result.Length--;
                    }
                }
                return;
            }

            if (KeypadMappings.TryGetValue(digit, out string letters) && !string.IsNullOrEmpty(letters))
            {
                // Calculate which letter to add based on the number of consecutive presses
                int letterIndex = (count - 1) % letters.Length;
                result.Append(letters[letterIndex]);
            }
        }
    }
}
