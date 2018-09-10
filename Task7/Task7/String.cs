namespace Task7
{
    using System;

    internal static class String
    {
        /// <summary>
        /// Find posiive  integer value
        /// </summary>
        /// <param name="str">Our string</param>
        /// <returns>Bool expresion</returns>
        public static bool FindPositiveNum(this string str)
        {
            foreach (char item in str)
            {
                if (!char.IsDigit(item))
                {
                    Console.WriteLine("The string is not a positive integer");
                    return false;
                }
            }

            Console.WriteLine("The string is a positive integer");
            return true;
        }
    }
}
