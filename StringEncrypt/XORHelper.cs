using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringEncrypt
{
   internal class XORHelper
    {
        public static byte GetXORCode(IEnumerable<byte> source)
        {
            byte b = 0;
            foreach (var bb in source)
            {
                b ^= bb;
            }
            return b;
        }
        public static byte GetXORCode(IEnumerable<byte> source, int startIndex, int lenth)
        {
            byte b = 0;
            for (int i = startIndex; i < startIndex + lenth; i++)
            {
                b ^= source.ElementAt(i);
            }
            return b;
        }
    }
}
