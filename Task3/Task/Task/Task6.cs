namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task6
    {
        /// <summary>
        /// Making styles
        /// </summary>
        public static void Styles()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                string style = string.Empty;
                bool bold = false;
                bool italic = false;
                bool underline = false;

                while (true)
                {
                    Console.WriteLine("Enter:\n\t 1:  Bold style\n\t 2:  Italic style\n\t 3:  Underline style\n\t 0 - exit\n\t Your style:  {0}", style);
                    int n = CheckNumber();
                    Style(n, ref bold, ref italic, ref underline, ref style);
                    if (n == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine("If you want to repeat the task, press 1, back to menu 0:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Checking number for non-zero
        /// </summary>
        /// <returns></returns>
        public static int CheckNumber()
        {
            int.TryParse(Console.ReadLine(), out int n);
            while ((n < 0) ^ (n > 3))
            {
                Console.WriteLine("Enter a positive from 0 to 3 value");
                int.TryParse(Console.ReadLine(), out n);
            }

            return n;
        }

        /// <summary>
        /// Printing
        /// </summary>
        /// <param name="n"></param>
        /// <param name="sbold"></param>
        /// <param name="sitalic"></param>
        /// <param name="sunderline"></param>
        /// <param name="style"></param>
        public static void Style(int n, ref bool sbold, ref bool sitalic, ref bool sunderline, ref string style)
        {
            switch (n)
            {
                case 1:
                    Check("Bold", ref sbold, ref sbold, ref sitalic, ref sunderline, ref style);
                    break;
                case 2:
                    Check("Italic", ref sitalic, ref sbold, ref sitalic, ref sunderline, ref style);
                    break;
                case 3:
                    Check("Underline", ref sunderline, ref sbold, ref sitalic, ref sunderline, ref style);
                    break;
            }
        }

        public static void Check(string str, ref bool flag, ref bool bold, ref bool italic, ref bool underline, ref string style)
        {
            string str2 = ", " + str + ",";
            string str3 = ", " + str;
            string str4 = str + ", ";
            string str5 = string.Empty;

            if (flag)
            {
                if (style.Contains(str2))
                {
                    style = style.Replace(str2, str5);
                }
                else if (style.Contains(str3))
                {
                    style = style.Replace(str3, str5);
                }
                else if (style.Contains(str4))
                {
                    style = style.Replace(str4, str5);
                }
                else if (style.Contains(str))
                {
                    style = style.Replace(str, str5);
                }

                flag = false;

                if ((!italic) && (!underline) && (!bold))
                {
                    style = "None";
                }
            }
            else
            {
                flag = true;

                if ((style == "None") || (style == str5))
                {
                    style = str;
                }
                else
                {
                    style = style + str3;
                }
            }
        }
    }
}
