// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

while (true)
{
    Console.WriteLine("Введите строку");
    var s = Console.ReadLine();

    Console.WriteLine("Введите слова через запятую");
    var words = Console.ReadLine().Split(",");

    var d1 = DateTime.Now;
    var result = FindSubstring(s, words);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    foreach (var str in result) 
        Console.Write(str + " ");

    Console.WriteLine();
}

IList<int> FindSubstring(string s, string[] words)
{
    int wordLength = words[0].Length;
    int wordCount = words.Length;
    int concatenatedSubstringLength = wordCount * wordLength;
    List<int> result = new List<int>();
    ReadOnlySpan<char> chars = s.AsSpan();
    int endSearch = chars.Length - concatenatedSubstringLength;

    Span<char> allWords = stackalloc char[concatenatedSubstringLength];

    for (int i = 0; i < wordCount; i++)
    {
        for (int j = 0; j < wordLength; j++)
        {
            allWords[i * wordLength + j] = words[i][j];
        }
    }

    // Search for word in allWords
    int WordIndex(ReadOnlySpan<char> allWords, ReadOnlySpan<char> word)
    {
        for (int index = 0; index < wordCount; index++)
        {
            bool match = true;

            int cStart = index * wordLength;
            for (int i = 0; i < wordLength; i++)
            {
                int allWordsIndex = index * wordLength + i;
                if (allWords[allWordsIndex] != word[i])
                {
                    match = false;
                    break;
                }
            }

            if (match) return index;
        }
        return -1;
    }

    Span<int> wordCounts = stackalloc int[wordCount];
    for (int j = 0; j < wordCount; j++)
    {
        var word = allWords.Slice(j * wordLength, wordLength);

        int idx = WordIndex(allWords, word);
        wordCounts[idx]++;
    }

    for (int i = 0; i <= endSearch; i++)
    {
        SearchForWord(wordLength, wordCount, result, chars, allWords, wordCounts, i);
    }

    return result;

    void SearchForWord(int wordLength, int wordCount, List<int> result, ReadOnlySpan<char> chars, Span<char> allWords, Span<int> wordCounts, int i)
    {
        Span<int> visitedCountUp = stackalloc int[wordCount];
        int found = 0;
        for (int j = 0; j < wordCount; j++)
        {
            var substr = chars.Slice(j * wordLength + i, wordLength);
            int idx = WordIndex(allWords, substr);
            if (idx < 0) break;

            if (visitedCountUp[idx] >= wordCounts[idx]) break;

            visitedCountUp[idx]++;
            found++;
        }

        if (found == wordCount)
            result.Add(i);
    }
}