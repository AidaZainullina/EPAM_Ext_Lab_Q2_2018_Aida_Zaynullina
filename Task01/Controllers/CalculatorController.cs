namespace Task01.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using static Task01.Rep.Rep;

    public class CalculatorController : Controller
    {
        private static MvcHtmlString log = MvcHtmlString.Empty;
       
        /// <summary>
        /// Calculate the result of the operation with the specified numbers-parameters
        /// </summary>
        /// <param name="x">The first number-parameter</param>
        /// <param name="y">The second number-parameter</param>
        /// <param name="operation">Specifed operation</param>
        /// <returns>Returns the view</returns>
        public ActionResult Calculator(int x = 0, int y = 0, string operation = "0")
        {
            string space = " ";
            float total = 0;
            switch (operation)
            {
                case "+"://todo pn hardcode у тебя здесь и во вьюшках повторяются операции. Можно было бы их запихнуть в какой-нибудь enum, чтобы они всегда были собраны в одном месте.
                    total = this.Sum(x, y);
                    break;
                case "-":
                    total = this.Subst(x, y);
                    break;
                case "*":
                    total = this.Multi(x, y);
                    break;
                case "/":
                    total = this.Div(x, y);
                    break;
                default:
                    return this.View();
            }

            Logs.Add(DateTime.Now + space + x + space + operation + space + y + space + "=" + space + total);
            return this.View();
        }

        /// <summary>
        /// Summarizes the specified numbers-parameters
        /// </summary>
        /// <param name="x">The first number-parameter</param>
        /// <param name="y">The second number-parameter</param>
        /// <returns>Returns the result of the operation</returns>
        public int Sum(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// Substract the first number-parameter from the second one
        /// </summary>
        /// <param name="x">The first number-parameter</param>
        /// <param name="y">The second number-parameter</param>
        /// <returns>Returns the result of the operation</returns>
        public int Subst(int x, int y)
        {
            return x - y;
        }

        /// <summary>
        /// Multipy numbers-parameters on each other
        /// </summary>
        /// <param name="x">The first number-parameter</param>
        /// <param name="y">The second number-parameter</param>
        /// <returns>Returns the result of the operation</returns>
        public int Multi(int x, int y)
        {
            return x * y;
        }

        /// <summary>
        /// Divides the numbers-parameters one by one using a ternary operator
        /// </summary>
        /// <param name="x">The first number-parameter</param>
        /// <param name="y">The second number-parameter</param>
        /// <returns>Returns the result of the operation</returns>
        public int Div(int x, int y)
        {
            return y != 0 ? x / y : 0;
        }
    }
}