using System;
using System.Security.Cryptography;
using System.Text;

namespace Password_generator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This is a password generator");
            Console.WriteLine("Please choose a password length");
            Console.WriteLine("Length:");
            int length = int.Parse(Console.ReadLine());
            if (length <= 0)
            {
                Console.WriteLine("The length cannot be 0");
            }


            string password = Generate(length);
            Console.WriteLine("Password:"+" "+password);
        }
        static string Generate(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz" +
           "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "0123456789" + "!@#$%^&*()_+{}[];:,.?<>";
            byte[] data = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }

            var result = new StringBuilder(length);
            foreach (byte b in data)
            {
                result.Append(chars[b % chars.Length]);

            }
            return result.ToString();
        }
    }
}
