using System.Diagnostics;
using System.Text;

while (true)
{
    Console.WriteLine("Введите первое число");
    var a = Console.ReadLine();
    
    Console.WriteLine("Введите второе число");
    var b = Console.ReadLine();
    
    var stopWatch = Stopwatch.StartNew();
    var result = AddBinary(a, b);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(AddBinary)}: Время выполнения: {stopWatch.Elapsed}");

    Console.WriteLine(result);

    Console.WriteLine();
}

string AddBinary(string a, string b)
{
    if (a == "0")
        return b;
    
    if (b == "0")
        return a;

    var result = new StringBuilder();
    
    var ai = a.Length - 1;
    var bi = b.Length - 1;
    var ind = 0;
    var isAbove2 = false;
    
    while (ind <= ai || ind <= bi)
    {
        if (ind > ai)
        {
            if (isAbove2 && b[bi - ind] == '1')
            {
                result.Append('0');
                //isAbove2 = true;
                ind++;
                continue;
            }

            if (isAbove2 || b[bi - ind] == '1')
            {
                result.Append('1');
                isAbove2 = false;
            }
            else
                result.Append('0');

            ind++;
            continue;
        }
        if (ind > bi)
        {
            if (isAbove2 && a[ai - ind] == '1')
            {
                result.Append('0');
                //isAbove2 = true;
                ind++;
                continue;
            }

            if (isAbove2 || a[ai - ind] == '1')
                result.Append('1');
            else
                result.Append('0');

            isAbove2 = false;
            ind++;
            continue;
        }

        var two1 = a[ai - ind] == '1' && b[bi - ind] == '1';
        var any1 = a[ai - ind] == '1' || b[bi - ind] == '1';
        if (two1)
        {
            result.Append(isAbove2 ? '1' : '0');
            isAbove2 = true;
            ind++;
            continue;
        }

        if (any1)
        {
            if (isAbove2)
            {
                result.Append('0');
                //isAbove2 = true;
            }
            else
            {
                isAbove2 = false;
                result.Append('1');    
            }
            
            ind++;
            continue;
        }

        result.Append(isAbove2 ? '1' : '0');
        isAbove2 = false;
        ind++;
    }

    if (isAbove2)
        result.Append('1');

    var str = result.ToString().ToArray();
    Array.Reverse(str);
    
    return new string(str);
}