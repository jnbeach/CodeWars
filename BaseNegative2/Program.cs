// https://www.codewars.com/kata/54c14c1b86b33df1ff000026/train/csharp

Console.WriteLine("Hello, World!");
int TestInt = ToInt("11001000010101");
Console.WriteLine($"{TestInt}");
Console.WriteLine($"{ToNegabinary(TestInt)}");

static string ToNegabinary(int num)
{
    string answer = "";
    int totalDigits = 1;
    int min = 0;
    int max = 1;
    int digitValue = 1;

    if (num == 0) return "0";
    else if (num == 1) return "1";

    while (num > max || num < min)
    {
        digitValue *= -2;
        totalDigits++;
        if (digitValue < 0) min += digitValue;
        else max += digitValue;
    }
    answer += "1";
    num -= digitValue;
    if (digitValue < 0) min -= digitValue;
    else max -= digitValue;
    digitValue /= -2;

    while (num != 0)
    {
        if (num > 0 && digitValue > 0 && num > max - digitValue)
        {
            answer += "1";
            num -= digitValue;
        }
        else if (num < 0 && digitValue < 0 && num < min - digitValue)
        {
            answer += "1";
            num -= digitValue;
        }
        else
        {
            answer += "0";
        }
        if (digitValue < 0) min -= digitValue;
        else max -= digitValue;
        digitValue /= -2;
    }
    while (answer.Length < totalDigits)
    {
        answer += "0";
    }

    return answer;
}

static int ToInt(string s)
{
    int answer = 0;
    int digit;
    int digitValue = 1;
    for (int i = s.Length - 1; i >= 0; i--)
    {
        digit = Convert.ToInt32(s.Substring(i, 1));
        answer += digit * digitValue;
        digitValue *= -2;
    }
    return answer;
}