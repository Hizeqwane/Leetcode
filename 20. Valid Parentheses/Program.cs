// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите строку из скобок.");
    var str = Console.ReadLine();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = IsValid(str);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(IsValid)}: {result}");
    
    Console.WriteLine();
}

bool IsValid(string s)
{
    var st = new Stack<char>();
    foreach (var c in s)
    {
        switch (c)
        {
            case '(':
                st.Push(c);
                continue;
            case ')' when st.Count == 0 || st.Peek() != '(':
                return false;
            case ')':
                st.Pop();
                continue;
            case '[':
                st.Push(c);
                continue;
            case ']' when st.Count == 0 || st.Peek() != '[':
                return false;
            case ']':
                st.Pop();
                continue;
            case '{':
                st.Push(c);
                continue;
            case '}' when st.Count == 0 || st.Peek() != '{':
                return false;
            case '}':
                st.Pop();
                break;
        }
    }

    return st.Count == 0;
}