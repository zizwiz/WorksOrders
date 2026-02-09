using System;

namespace WorksOrders
{
    public static class OrderNumberGenerator
    {
        public static string Generate()
        {
            return "WO-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
    }

}