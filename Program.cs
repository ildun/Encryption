using System;

namespace Encryption
{
    class Program
    {
        public static string EncryptCesarsCipher(int key, string msg)
        {
            key = key - (key / 95) * 95;
            char[] returnString = msg.ToCharArray();
            for (int i = 0; i < msg.Length; ++i)
            {
                uint currCharInt = (uint)(returnString[i] + key);
                if (currCharInt >= 95)
                {
                    currCharInt = currCharInt - (currCharInt / 95) * 95;
                }
                returnString[i] = (char)(currCharInt+32);
            }
            return new string(returnString);
        }
        public static string DecryptCesarsCipher(int key, string code)
        {
            key = key - (key / 95) * 95;
            char[] returnString = code.ToCharArray();
            for (int i = 0; i < code.Length; ++i)
            {
                uint currCharInt = (uint)(returnString[i] - key);
                if (currCharInt >= 95)
                {
                    currCharInt = currCharInt - (currCharInt / 95) * 95;
                }
                returnString[i] = (char)(currCharInt + 32);
            }
            return new string(returnString);
        }
        //97-122 in ASCII
        public static string EncryptVigenereCipher(string key, string msg)
        {
            while(key.Length < msg.Length)
            {
                key += key;
            }
            char[] returnString = msg.ToCharArray();
            for(int i = 0; i < msg.Length; ++i)
            {
                uint currCharInt = (uint)(returnString[i] + (key[i] - 'a'));
                if (currCharInt > 122) currCharInt = 96 + (currCharInt - 122);
                returnString[i] = (char)(currCharInt);
            }
            return new string(returnString);
        }
        public static string DecryptVigenereCipher(string key, string msg)
        {
            while (key.Length < msg.Length)
            {
                key += key;
            }
            char[] returnString = msg.ToCharArray();
            for (int i = 0; i < msg.Length; ++i)
            {
                uint currCharInt = (uint)(returnString[i] - (key[i] - 'a'));
                if (currCharInt < 97) currCharInt = 123 - (97-currCharInt);
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
            if (mode == "do" && method == "vigenere")
            {
                Console.WriteLine(EncryptVigenereCipher(args[2], args[3]));
            }
            else if (mode == "undo" && method == "vigenere")
            {
                Console.WriteLine(DecryptVigenereCipher(args[2], args[3]));
            }
            else
            {
                Console.WriteLine("Not enough or invalid command line arguments.");
                return;
            }
        }
    }
}
