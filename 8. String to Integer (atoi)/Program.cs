// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите строку.");
    var s = Console.ReadLine();

    var result = MyAtoi(s);
    Console.WriteLine($"Num: {result}");
}

int MyAtoi(string s)
{
    var withoutWhiteSpaces = s.TrimStart();
    if (withoutWhiteSpaces.Length < 1)
        return 0;

    var isNegative = withoutWhiteSpaces[0] == '-';
    var isPositive = withoutWhiteSpaces[0] == '+';

    int startInd = isPositive || isNegative ? 1 : 0;
    isPositive = !isPositive && !isNegative || isPositive;

    if (withoutWhiteSpaces.Length == startInd)
        return 0;

    var withoutZeros = withoutWhiteSpaces[startInd..].TrimStart('0');

    var numArray = new char[10];
    int i;
    for (i = 0; i < (11) && i < withoutZeros.Length; i++)
    {
        if (i == (10) && char.IsDigit(withoutZeros[i]))
            return isPositive ? int.MaxValue : int.MinValue;

        if (i == (9))
            switch (int.Parse(string.Concat(numArray[..9])))
            {
                case > 214748364:
                    return isPositive ? int.MaxValue : int.MinValue;
                case 214748364 when isPositive && (withoutZeros[i] == '8' || withoutZeros[i] == '9'):
                    return int.MaxValue;
                case 214748364 when isNegative && withoutZeros[i] == '9':
                    return int.MinValue;
            }

        if (char.IsDigit(withoutZeros[i]))
            numArray[i] = withoutZeros[i];
        else
            break;
    }

    var str = string.Concat(numArray[..(i)]);
    return str == ""
        ? 0 
        : int.Parse(isPositive ? str : "-" + str);
}