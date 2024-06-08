namespace ZaloPay.Helper
{
    public class Utils
    {
        public static long GetTimeStamp(DateTime date) {
            return (long)(date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
        }

        public static long GetTimeStamp(){
            return GetTimeStamp(DateTime.UtcNow);
        }

        public static string GetDateStr()
        {
            return DateTime.UtcNow.ToString("yyMMdd");
        }
    }
}