using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MathLibrary.Utilities;

namespace ProjectEuler.Solutions
{
  // Each character on a computer is assigned a unique code and the preferred standard is ASCII 
  // (American Standard Code for Information Interchange). For example, uppercase A = 65, asterisk (*) = 42, 
  // and lowercase k = 107.
  // 
  // A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with 
  // a given value, taken from a secret key. The advantage with the XOR function is that using the same 
  // encryption key on the cipher text, restores the plain text; for example, 65 XOR 42 = 107, then 
  // 107 XOR 42 = 65.
  // 
  // For unbreakable encryption, the key is the same length as the plain text message, and the key is made up 
  // of random bytes. The user would keep the encrypted message and the encryption key in different locations, 
  // and without both "halves", it is impossible to decrypt the message.
  // 
  // Unfortunately, this method is impractical for most users, so the modified method is to use a password as 
  // a key. If the password is shorter than the message, which is likely, the key is repeated cyclically 
  // throughout the message. The balance for this method is using a sufficiently long password key for 
  // security, but short enough to be memorable.
  // 
  // Your task has been made easy, as the encryption key consists of three lower case characters. 
  // Using cipher1.txt (right click and 'Save Link/Target As...'), a file containing the encrypted ASCII 
  // codes, and the knowledge that the plain text must contain common English words, decrypt the message and 
  // find the sum of the ASCII values in the original text.
  public class Problem59
  {
    private const string _cipherTextFile = @"D:\sandbox\ProjectEuler\ProjectEuler\Resources\Problem59\cipher.txt";
    private const string _plainTextFile = @"D:\sandbox\ProjectEuler\ProjectEuler\Resources\Problem59\plaintext.txt";
    private string[] _cipherText;
    private StreamWriter _writer;
    private StringBuilder _stringBuilder;
    
    public void Solve()
    {
      _cipherText = Utility.ArrayFromCommaDelimitedFile(_cipherTextFile);
      _writer = new StreamWriter(_plainTextFile);
      _stringBuilder = new StringBuilder();

      Decrypt(new char[] { 'g', 'o', 'd' });
      //BruteForce();

      _writer.Close();
    }

    public void BruteForce()
    {
      var keys = GetKeys();

      foreach (char[] key in keys)
      {
        for (int i = 0; i < 50; i++)
        {
          _stringBuilder.Append(
            Convert.ToChar(Convert.ToSByte(_cipherText[i]) ^ Convert.ToSByte(key[i % key.Length])));
        }

        if (!ContainsSpecialCharacters(_stringBuilder.ToString()))
        {
          _writer.Write(string.Format("{0}   [{1}{2}{3}]\n", _stringBuilder.ToString(), key[0], key[1], key[2]));
        }

        _stringBuilder.Remove(0, _stringBuilder.Length);
      }
    }

    public void Decrypt(char[] key)
    {
      var asciiSum = 0;

      for (int i = 0; i < _cipherText.Length; i++)
      {
        var plainText =
          Convert.ToChar(Convert.ToSByte(_cipherText[i]) ^ Convert.ToSByte(key[i % key.Length])).ToString();

        asciiSum += Convert.ToSByte(_cipherText[i]) ^ Convert.ToSByte(key[i % key.Length]);
        _stringBuilder.Append(plainText);
      }

      _writer.Write(_stringBuilder.ToString());
      _writer.WriteLine();
      _writer.WriteLine(string.Format("\nSum of clear text ASCII codes = {0}", asciiSum));
    }

    public bool ContainsSpecialCharacters(string text)
    {
      return text.Contains('%')
        || text.Contains('/')
        || text.Contains('$')
        || text.Contains('#')
        || text.Contains('"')
        || text.Contains('~')
        || text.Contains('`')
        || text.Contains('<')
        || text.Contains('>')
        || text.Contains('=')
        || text.Contains('+')
        || text.Contains('&')
        || text.Contains('*')
        || text.Contains('@');
    }

    public List<char[]> GetKeys()
    {
      var keys = new List<char[]>();
      var alphabet = GetAlphabet();

      for (int i = 0; i < alphabet.Length; i++)
      {
        for (int j = 0; j < alphabet.Length; j++)
        {
          for (int k = 0; k < alphabet.Length; k++)
          {
            keys.Add(new char[] { alphabet[i], alphabet[j], alphabet[k] });
          }
        }
      }

      return keys;
    }

    public char[] GetAlphabet()
    {
      return new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
  }
}
