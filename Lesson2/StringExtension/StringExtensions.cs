using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.StringExtension
{
    public static  class StringExtensions
    {
        /// <summary>
        /// переворот строки
        /// </summary>
        public static string RString(this string str)
        {
            var t = str.ToCharArray().Reverse().ToArray();
            return new string(t);
        }
    }
}
