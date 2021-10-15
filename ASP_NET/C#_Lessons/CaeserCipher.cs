using System;

namespace CaesarCipher
{
  class Program
  {
    static void Main(string[] args)
    {
      int key;

      Console.WriteLine("Welcome! Please enter a message:");
      string originalMessage = Console.ReadLine().ToLower();
      char[] originalLetters = originalMessage.ToCharArray();

      Console.WriteLine("Please enter a numeric key for your cipher:");
      bool isParsable = Int32.TryParse(Console.ReadLine(), out key);

      if(isParsable)
      {
        Console.WriteLine("Would you like to encrypt or decrypt the entered message?");
        string choice = Console.ReadLine().ToUpper();
        if(choice == "ENCRYPT")
        {
          string secretMessage = Encrypt(originalLetters, key);
          Console.WriteLine($"Encrypted Message: {secretMessage}");
        }
        else if(choice == "DECRYPT")
        {
          string decryptedMessage = Decrypt(originalLetters, key);
          Console.WriteLine($"Decrypted Message: {decryptedMessage}");
        }
      }
      else
      {
        Console.WriteLine("Error: Improper key value given");
      }
    }

    /**
    * Method to encrypt an array of characters, based off of the numeric key, and return the encrypted message
    **/
    static string Encrypt(char[] messageToEncrypt, int key){
      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
      char[] encryptedLetters = new char[messageToEncrypt.Length];

      for(int i = 0; i < messageToEncrypt.Length; i++){
        char letter = messageToEncrypt[i];
        int alphabetPosition = Array.IndexOf(alphabet, letter);
        int encryptedPosition = (alphabetPosition + key) % 26;

        encryptedLetters[i] = alphabet[encryptedPosition];
      }
      string encryptedMessage = String.Join("", encryptedLetters);
      return encryptedMessage;
    }

    /**
    * Method to decrypt an array of characters, based off of the numeric key, and return the decrypted message
    **/
    static string Decrypt(char[] messageToDecrypt, int key){
      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
      char[] decryptedLetters = new char[messageToDecrypt.Length];

      for(int i = 0; i < messageToDecrypt.Length; i++){
        char letter = messageToDecrypt[i];
        int alphabetPosition = Array.IndexOf(alphabet, letter);
        int decryptedPosition = Math.Abs(alphabetPosition - key) % 26;

        decryptedLetters[i] = alphabet[decryptedPosition];
      }
      string decryptedMessage = String.Join("", decryptedLetters);
      return decryptedMessage;
    }
  }
}