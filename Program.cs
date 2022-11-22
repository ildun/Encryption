using System;

namespace Encryption
{
    class Program
    {
        public static string EncryptCesarsCipher(int key, string msg)
        {
            char[] returnString = msg.ToCharArray();
            for (int i = 0; i < msg.Length; ++i)
            {
                uint currCharInt = (uint)(returnString[i] + key);
                if(currCharInt >= 128)
                {
                    currCharInt = currCharInt - (currCharInt / 128) * 128;
                }
                returnString[i] = (char)(currCharInt);
            }
            return new string(returnString);
        }
        public static string DecryptCesarsCipher(int key, string code)
        {
            char[] returnString = code.ToCharArray();
            for (int i = 0; i < code.Length; ++i)
            {
                uint currCharInt = (uint)(returnString[i] - key);
                if (currCharInt >= 128)
                {
                    currCharInt = currCharInt - (currCharInt / 128) * 128;
                }
                returnString[i] = (char)(currCharInt);
            }
            return new string(returnString);
        }
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Not enough or invalid command line arguments.");
                return;
            }
            string method = args[0];
            string mode = args[1];
            if (mode == "do" && method=="cesar")
            {
                Console.WriteLine(EncryptCesarsCipher(int.Parse(args[2]), args[3]));
            }
            else if (mode == "undo" && method == "cesar")
            {
                Console.WriteLine(DecryptCesarsCipher(int.Parse(args[2]), args[3]));
            }
            else
            {
                Console.WriteLine("Not enough or invalid command line arguments.");
                return;
            }
        }
    }
}
