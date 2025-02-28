using OldPhonePad_Iron_CoChallenge.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad_Iron_CoChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(PhoneKeypad.OldPhonePad("33#"));
            Console.WriteLine(PhoneKeypad.OldPhonePad("227*#"));
            Console.WriteLine(PhoneKeypad.OldPhonePad("4433555 555666#"));
            Console.WriteLine(PhoneKeypad.OldPhonePad("8 88777444666*664#"));
            Console.WriteLine(PhoneKeypad.OldPhonePad("444777666 66077776663338#"));
        }
    }
}
