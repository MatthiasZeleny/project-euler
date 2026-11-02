namespace Numbers.SpecialNumbers;

public static class PandigitalExtensions
{
    public static bool IsPandigital(this long number)
    {
        var rest = number;
        var oneCounter = 0;
        var twoCounter = 0;
        var threeCounter = 0;
        var fourCounter = 0;
        var fiveCounter = 0;
        var sixCounter = 0;
        var sevenCounter = 0;
        var eightCounter = 0;
        var nineCounter = 0;
        var zeroCounter = 0;

        while (rest != 0)
        {
            var digit = rest % 10;
            
            switch (digit)
            {
                case 1: oneCounter++; break;
                case 2: twoCounter++; break;
                case 3: threeCounter++; break;
                case 4: fourCounter++; break;
                case 5: fiveCounter++; break;
                case 6: sixCounter++; break;
                case 7: sevenCounter++; break;
                case 8: eightCounter++; break;
                case 9: nineCounter++; break;
                case 0: zeroCounter++; break;
            }
            
            rest /= 10;
        }

        return zeroCounter == 0 && oneCounter*twoCounter*threeCounter*fourCounter*fiveCounter*sixCounter*sevenCounter*eightCounter*nineCounter == 1;
    }
}