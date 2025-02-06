Dictionary<string, bool> TestCases = new Dictionary<string, bool>
{
    { "-90E3", true },
    { "+6e-1", true },
    { "-123.456e789", true },
    
    { "2", true },
    { "0089", true },
    { "-0.1", true },
    { "+3.14", true },
    { "4.", true },
    { "-.9", true },
    { "2e10", true },
    { "3e+7", true },
    { "53.5e93", true },
    { "abc", false },
    { "1a", false },
    { "1e", false },
    { "e3", false },
    { "99e2.5", false },
    { "--6", false },
    { "-+3", false },
    { "95a54e53", false }
};

foreach (var testCase in TestCases)
{
    var result = IsNumber(testCase.Key);
    if (result == testCase.Value)
        Console.WriteLine($"{testCase.Key} - OK");
    else
        Console.WriteLine($"{testCase.Key} - Failed");
}

bool IsNumber(string s)
{
    var result = true;
    
    var hasSign = false;
    var hasDot = false;
    var hasE = false;
    var hasPrevDigit = false;
    
    for (var i = 0; i < s.Length; i++)
    {
        if (i == 0)
        {
            if (s[i] == '+' || s[i] == '-')
            {
                hasSign = true;
                continue;
            }
            
            if (s[i] == '.')
            {
                if (s.Length == 1)
                {
                    result = false;
                    break;
                }
                
                hasDot = true;
                continue;
            }
            
            if (char.IsDigit(s[i]))
            {
                hasPrevDigit = true;
                continue;
            }

            result = false;
            break;
        }

        #region Check for repeating

        if (hasSign)
        {
            if (s[i] == '+' || s[i] == '-')
            {
                result = false;
                break;
            }
        }
        
        if (hasDot)
        {
            if (s[i] == '.')
            {
                result = false;
                break;
            }
        }
        
        if (hasE)
        {
            if (s[i] == 'e' || s[i] == 'E')
            {
                result = false;
                break;
            }
        }

        #endregion
        
        if ((s[i] == '-' || s[i] == '+') && (s[i - 1] != 'E' && s[i - 1] != 'e' || i == s.Length - 1))
        {
            result = false;
            break;
        }
        
        if (s[i] == '.' && hasE)
        {
            result = false;
            break;
        }
        
        if (char.IsLetter(s[i]) && s[i] != 'e' && s[i] != 'E')
        {
            result = false;
            break;
        }
        
        if (s[i] == 'e' || s[i] == 'E')
        {
            hasE = true;
            hasSign = false;
            if (i == s.Length - 1)
            {
                result = false;
                break;
            }

            if (!hasPrevDigit)
            {
                result = false;
                break;
            }
        }
        
        if (char.IsDigit(s[i]))
        {
            hasPrevDigit = true;
        }
        else if (s[i] == '+' || s[i] == '-')
        {
            hasSign = true;
        }
        else if (s[i] == '.')
        {
            hasDot = true;
        }
    }

    return hasPrevDigit && result;
}