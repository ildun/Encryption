using System;

namespace Encryption
{
    class Program
    {
        //97-122 in ASCII
        public static string EncryptCesarsCipher(uint key, string msg)
        {
            key %= 26;
            char[] returnString = msg.ToCharArray();
            for (int i = 0; i < msg.Length; ++i)
            {
                char currChar = (char)(returnString[i] + key);
                if (currChar > 'z')
                {
                    currChar = (char)('a' + currChar- 'z' -1);
                }
                returnString[i] = currChar;
            }
            return new string(returnString);
        }
        public static string DecryptCesarsCipher(uint key, string code)
        {
            key %= 26;
            char[] returnString = code.ToCharArray();
            for (int i = 0; i < code.Length; ++i)
            {
                char currChar = (char)(returnString[i] - key);
                if (currChar < 'a')
                {
                    currChar = (char)('z' - ('a' - currChar));
                }
                returnString[i] = currChar;
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
                char currChar = (char)(returnString[i] + (key[i] - 'a'));
                if (currChar > 'z')
                {
                    currChar = (char)('a'+1 + currChar - 'z' - 1);
                } 
                returnString[i] = currChar;
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
                char currChar = (char)(returnString[i] - (key[i] - 'a'));
                if (currChar < 'a')
                {
                    currChar = (char)('z'+1 - ('a' - currChar));
                }
                returnString[i] = currChar;
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
                Console.WriteLine(EncryptCesarsCipher(uint.Parse(args[2]), args[3]));
            }
            else if (mode == "undo" && method == "cesar")
            {
                Console.WriteLine(DecryptCesarsCipher(uint.Parse(args[2]), args[3]));
            }
            else if (mode == "do" && method == "vigenere")
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
