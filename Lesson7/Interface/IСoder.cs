using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Interface
{
    public interface IСoder
    {
        void Encode(string str, out string res);
        void Decode(string str, out string res);
    }
}
