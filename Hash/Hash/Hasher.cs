using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    class Hasher
    {
        public long hasher(String s)
        {
            String characters = "acdegilmnoprstuw";

            long total = 7;

            for (int i = 0; i < s.Length; i++)
            {
                total = total * 37 + characters.IndexOf(s[i]);
            }

            return total;
        }

        public String result()
        {
            return null;
        }
    }
}
