using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad_Iron_CoChallenge.Class
{
    public class PhoneKeypad
    {

        /// param => The input string with # marking the end.
        /// returns => The resulting text output after processing the keypad presses
        public static string OldPhonePad(string input)
        {
            // Early validation
            if (string.IsNullOrEmpty(input) || !input.EndsWith("#"))
            {
                throw new ArgumentException("Input must not be empty and must end with #", nameof(input));
            }

            // Remove the terminating # character
            input = input.TrimEnd('#');

            // Phone keypad mapping
            var keypadMapping = new[]
            {
            " ",
            "&'(",
            "ABC",
            "DEF",
            "GHI",
            "JKL",
            "MNO",
            "PQRS",
            "TUV",
            "WXYZ"
        };

            StringBuilder result = new StringBuilder();
            string[] segments = input.Split(' ');

            foreach (var segment in segments)
            {
                ProcessSegment(segment, result, keypadMapping);
            }

            return result.ToString();
        }

        /// Processes a segment (portion of input between spaces) and appends the resulting characters to the output.        
        /// result =>The StringBuilder to which the processed characters are appended
        /// keypadMapping =>The keypad mapping array
        private static void ProcessSegment(string segment, StringBuilder result, string[] keypadMapping)
        {
            if (string.IsNullOrEmpty(segment))
            {
                return;
            }

            char currentDigit = segment[0];
            int consecutiveCount = 1;

            for (int i = 1; i <= segment.Length; i++)
            {
                // Process the current group when we reach the end or encounter a different digit
                if (i == segment.Length || segment[i] != currentDigit)
                {
                    ProcessDigitGroup(currentDigit, consecutiveCount, result, keypadMapping);

                    if (i < segment.Length)
                    {
                        currentDigit = segment[i];
                        consecutiveCount = 1;
                    }
                }
                else
                {
                    consecutiveCount++;
                }
            }
        }

        /// summary => Processes a group of consecutive identical digits and updates the result accordingly
        /// digit => The digit being processed
        /// count => The number of consecutive occurrences of the digit
        /// result => The StringBuilder to which the processed characters are appended
        /// keypadMapping => The keypad mapping array
        private static void ProcessDigitGroup(char digit, int count, StringBuilder result, string[] keypadMapping)
        {
            if (digit == '*')
            {
                // Backspace - remove last character for each '*'
                for (int i = 0; i < count; i++)
                {
                    if (result.Length > 0)
                    {
                        result.Length--;
                    }
                }
                return;
            }

            if (char.IsDigit(digit))
            {
                int digitValue = digit - '0';
                if (digitValue >= 0 && digitValue <= 9)
                {
                    string letters = keypadMapping[digitValue];
                    if (letters.Length > 0)
                    {
                        // Calculate which letter to add based on the number of consecutive presses
                        int letterIndex = (count - 1) % letters.Length;
                        result.Append(letters[letterIndex]);
                    }
                }
            }
        }
    }
}
