// See https://aka.ms/new-console-template for more information

while (true)
{
    Console.WriteLine("Введите строку из скобок.");
    var str = Console.ReadLine();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = LongestValidParentheses(str);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(LongestValidParentheses)}: {result}");
    
    Console.WriteLine();
}

int LongestValidParentheses(string s)
{
    var stack = new Stack<int>();
    
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] != '(' && stack.Any() && s[stack.Peek()] == '(')
            stack.Pop();
        else
            stack.Push(i);
    }

    if (!stack.Any()) return s.Length;

    var len = s.Length;
    var unw = 0;
    var result = 0;

    while (stack.Any())
    {
        unw = stack.Pop();
        result = Math.Max(result, len - unw - 1);
        len = unw;
    }

    return Math.Max(result, len);





    //var indStart = 0;
    //var indEnd = s.Length;

    //while (indStart < indEnd)
    //{

    //}
}

// ()))((()

// ()((((((((((()()()()()()() - 14

// ()(() - 2
// (()() - 4