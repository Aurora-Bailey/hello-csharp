namespace hello_csharp;

internal static class NumberFacts
{
    public static (string Parity, bool IsPrime, int Doubled) Inspect(int number)
    {
        var parity = number % 2 == 0 ? "even" : "odd";
        return (parity, IsPrime(number), number * 2);
    }

    private static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (var candidate = 2; candidate <= Math.Sqrt(number); candidate++)
        {
            if (number % candidate == 0)
            {
                return false;
            }
        }

        return true;
    }
}
