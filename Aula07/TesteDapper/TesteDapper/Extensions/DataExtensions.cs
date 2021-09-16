using System;

namespace TesteDapper.Extensions
{
    static class DataExtensions
    {
        public static string FormatarDataSistema(this DateTime data)
        {
            return data.Month + "/" + data.Year;
        }
    }
}
