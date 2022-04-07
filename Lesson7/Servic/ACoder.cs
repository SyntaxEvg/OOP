using Lesson7.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Servic
{
    internal class ACoder : IСoder
    {
        public void Decode(string str, out string res)
        {
            var span = str.AsSpan();
            var sb = new StringBuilder();
            foreach (var character in span)
            {
                sb.Append((char)(character - 1));
            }
            res= sb.ToString();
        }
        /// <summary>
        /// В результате такого сдвига буква А становится буквой Б
        /// </summary>
        public void Encode(string str,out string res)
        {
            var span = str.AsSpan();
            var sb = new StringBuilder();
            foreach (var character in span)
            {
                sb.Append((char)(character + 1));
            }
            res = sb.ToString();
        }
    }
}
