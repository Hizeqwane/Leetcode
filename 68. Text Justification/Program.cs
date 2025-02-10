using System.Diagnostics;
using System.Text;

List<(string[], int)> tests = 
[
    (["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"], 20),
    (["This", "is", "an", "example", "of", "text", "justification."], 16),
    (["What","must","be","acknowledgment","shall","be"], 16)
];

foreach (var test in tests)
{
    var stopWatch = Stopwatch.StartNew();
    
    var result = FullJustify(test.Item1, test.Item2);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(FullJustify)}: Время выполнения: {stopWatch.Elapsed}");

    foreach (var resLine in result) 
        Console.WriteLine(resLine);
    
    Console.WriteLine();
}

IList<string> FullJustify(string[] words, int maxWidth)
{
    const char whiteSpace = ' ';

    var wordInd = 0;
    var result = new List<string>();
    var rowBuilder = new StringBuilder();
    
    while (true)
    {
        (var nextWords, wordInd) = GetRowWords(words, wordInd, maxWidth);

        if (nextWords.Length == 0)
            break;

        if (wordInd == words.Length)
        {
            var endWhiteSpaceCount = maxWidth - nextWords.Sum(s => s.Length + 1) + 1;
            
            for (var i = 0; i < nextWords.Length; i++)
            {
                rowBuilder.Append(nextWords[i]);
                
                if (i != nextWords.Length - 1)
                    rowBuilder.Append(whiteSpace);
            }

            rowBuilder.Append(string.Join("", Enumerable.Repeat(whiteSpace, endWhiteSpaceCount)));
            result.Add(rowBuilder.ToString());
            break;
        }
        
        if (nextWords.Length == 1)
        {
            rowBuilder
                .Append(nextWords[0])
                .Append(string.Join("", Enumerable.Repeat(whiteSpace, maxWidth - nextWords[0].Length)));
            
            result.Add(rowBuilder.ToString());
            rowBuilder.Clear();
            continue;
        }

        var whiteSpaceCount = maxWidth - nextWords.Sum(s => s.Length);
        var whiteSpaceForeach = whiteSpaceCount / (nextWords.Length - 1);
        var otherWhiteSpaces = whiteSpaceCount - whiteSpaceForeach * (nextWords.Length - 1);

        for (var i = 0; i < nextWords.Length; i++)
        {
            rowBuilder
                .Append(nextWords[i]);
                
            if (i != nextWords.Length - 1)
                rowBuilder
                    .Append(string.Join("", Enumerable.Repeat(whiteSpace, whiteSpaceForeach)));

            if (i < otherWhiteSpaces)
                rowBuilder
                    .Append(whiteSpace);
        }
        
        result.Add(rowBuilder.ToString());
        rowBuilder.Clear();
    }

    return result;
}

(string[], int) GetRowWords(string[] words, int wordInd, int maxWidth)
{
    var counter = 0;
    var nextWords = new List<string>();
    
    for (var i = wordInd; i < words.Length; i++)
    {
        counter += words[i].Length + 1;
        if (counter > maxWidth)
        {
            if (counter - 1 != maxWidth)
                return (nextWords.ToArray(), i);
            
            nextWords.Add(words[i]);
            return (nextWords.ToArray(), i + 1);

        }

        nextWords.Add(words[i]);
    }

    return (nextWords.ToArray(), words.Length);
}