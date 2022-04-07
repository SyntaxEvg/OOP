using Lesson7.Interface;
using System;
using System.Text;

namespace Lesson7.Servic
{
    internal class BCoder : IСoder
    {
        static readonly int[] LRange = { 97, 122 };
        static readonly int[] URange = { 65, 90 };

        Func<char, bool> IsLowerCaseDel = IsLowerCase;
        Func<char, bool> IsUpperCaseDel = IsUpperCase;


        /// <summary>
        /// /// диапазон допустимых 
        /// </summary>
        public static bool IsLowerCase(char character)
        {
            return character >= LRange[0] && character <= LRange[1];
        }
        /// <summary>
        /// диапазон допустимых 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static bool  IsUpperCase(char character)
        {
            return character >= URange[0] && character <= URange[1];
        }
        public void Decode(string str, out string res)
        {
            var span = str.AsSpan();
            var sb = new StringBuilder();

            foreach (var character in span)
            {
                if (IsLowerCaseDel(character))
                {
                    var rangeFromEnd = LRange[1] - character;
                    if (rangeFromEnd == 0)
                    {
                        sb.Append((char)LRange[0]);
                        continue;
                    }
                    sb.Append((char)(LRange[0] + rangeFromEnd));
                    continue;
                }

                if (IsUpperCaseDel(character))
                {
                    var rangeFromEnd = URange[1] - character;
                    if (rangeFromEnd == 0)
                    {
                        sb.Append((char)URange[0]);
                        continue;
                    }
                    sb.Append((char)(URange[0] + rangeFromEnd));
                }
            }

            res= sb.ToString();
        }
        /// <summary>
        /// Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра
        /// </summary>
        public void Encode(string str, out string res)
        {
            var span = str.AsSpan();
            var sb = new StringBuilder();

            foreach (var item in span)
            {
                if (IsLowerCaseDel(item))
                {
                    var nuller = item - LRange[0];
                    if (nuller == 0)
                    {
                        sb.Append((char)LRange[1]);
                        continue;
                    }
                    sb.Append((char)(LRange[1] - nuller));
                    continue;
                }
                if (IsUpperCaseDel(item))
                {
                    var rangeFromStart = item - URange[0];
                    if (rangeFromStart == 0)
                    {
                        sb.Append((char)URange[1]);
                        continue;
                    }
                    sb.Append((char)(URange[1] - rangeFromStart));
                }
            }
            res= sb.ToString();
        }
    }
}
