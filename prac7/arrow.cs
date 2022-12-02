using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace prac7
{
    internal class arrow
    {
        int stroka = 0;
        public arrow(int a, int b)
        {
            min = a;
            max = b;
        }
        private void goup()
        {
            Console.SetCursorPosition(0, stroka);
            Console.WriteLine("  ");
            stroka--;
            if (stroka < min)
                stroka = min;
        }
        private void godown()
        {
            Console.SetCursorPosition(0, stroka);
            Console.WriteLine("  ");
            stroka++;
            if (stroka > max)
                stroka = max;
        }
        public int movearrow()
        {
            while (y.key.Key != ConsoleKey.Enter)
            {
                if (y.key.Key == ConsoleKey.UpArrow)
                    goup();
                else if (y.key.Key == ConsoleKey.DownArrow)
                    godown();
                else if (y.key.Key == ConsoleKey.Enter)
                    break;
                else if (y.key.Key == ConsoleKey.Escape)
                    return -1;
                Console.SetCursorPosition(0, stroka);
                Console.WriteLine("->");
                y.key = Console.ReadKey();
            }
            return stroka;
        }
        public int max;
        public int min;
    }
}