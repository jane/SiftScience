namespace SiftScience
{
    public static class DecimalExtensions
    {
         public static long ToMicros(this decimal value)
         {
             return(long)((value*100)*10000);
         }
    }
}
