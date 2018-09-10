namespace Task7
{
    using System;

    public static class SumOfArraysElements
    {
        /// <summary>
        /// Final sum 
        /// </summary>
        public static int FinalSum;

        /// <summary>
        /// Сalculation of the sum
        /// </summary>
        /// <param name="array">Our array</param>
        /// <returns>Final sum</returns>
        public static int Sum(this Array array)
        {
            FinalSum = 0;

            try
            {
                foreach (var item in array)
                {
                    FinalSum += (int)item;
                }
            }
            catch (InvalidCastException exception)
            {
                Console.WriteLine("Error! {0}", exception.Message);
            }

            return FinalSum;
        }
    }
}
