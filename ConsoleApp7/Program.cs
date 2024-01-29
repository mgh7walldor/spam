//Mahdi Gholamian
//پروژه تشخیص و شمارش اسپم
using System;

class SpamDetector
{
    private string inputSentence;   // جمله ورودی کاربر
    private int spamWordCount;      // تعداد کلمات اسپم

    public SpamDetector(string inputSentence)
    {
        this.inputSentence = inputSentence;
        spamWordCount = 0;
    }

    public void DetectSpam()
    {
        string[] words = inputSentence.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // بررسی اینکه کلمه اسپم است یا نه
            if (IsSpamWord(word))
            {
                spamWordCount++;
            }
        }

        Console.WriteLine($"Number of spam words: {spamWordCount}");
    }

    private bool IsSpamWord(string word)
    {
        // الگوهای اسپم
        string pattern1 = @"(\p{L})\1+";  // حروف تکراری
        string pattern2 = "[aeiouAEIOUآاایی]";  // حروف صدادار
        string pattern3 = "[A-Zآاایی]";  // حروف بزرگ
        string pattern4 = "[^a-zA-Zآاایی0-9 ]";  // حروف غیر الفبا، اعداد، و فاصله
        string pattern5 = @"\d";  // اعداد

        if (System.Text.RegularExpressions.Regex.IsMatch(word, pattern1) ||
            !System.Text.RegularExpressions.Regex.IsMatch(word, pattern2) ||
            System.Text.RegularExpressions.Regex.IsMatch(word, pattern3) ||
            System.Text.RegularExpressions.Regex.IsMatch(word, pattern4) ||
            System.Text.RegularExpressions.Regex.IsMatch(word, pattern5))
        {
            return true;
        }

        return false;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a string:");
        string inputSentence = Console.ReadLine();

        SpamDetector spamDetector = new SpamDetector(inputSentence);
        spamDetector.DetectSpam();
        Console.ReadLine();
    }
}
