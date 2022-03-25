using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Less3._3
{
    internal class ReadLineFile 
    {
        public IEnumerable<string> ReadLine(string FilePuth)
        {
            var file = new FileInfo(FilePuth);
            if (!file.Exists)
            {
                throw new FileNotFoundException("noy File");               
            }
            using var read =file.OpenText();
            while (!read.EndOfStream)
            {
                yield return read.ReadLine()!;
            }
        }
    }
}
