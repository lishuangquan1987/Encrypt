using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringEncrypt
{
   internal class Decoder
    {
        public byte[] Decode(byte[] source)
        {
            if (source == null || source.Length == 0)
                throw new Exception("soure is null");
            if (source.Length < 4)
                throw new Exception("invalid source");
            byte xorCode = XORHelper.GetXORCode(source, 0, source.Length - 1);
            if (xorCode != source[source.Length - 1])
            {
                throw new Exception("invalid checksum");
            }
            int lenth = BitConverter.ToInt32(source,0);
            if (source.Length != 4 + lenth * 2 + lenth + 1)
            {
                throw new Exception("invalid lenth");
            }
            List<short> offsetList = new List<short>();
            List<byte> content = new List<byte>();
            for (int i = 4; i < 4 + lenth * 2; i += 2)
            {
                offsetList.Add(BitConverter.ToInt16(source, i));
            }
            for (int i = 4 + lenth * 2; i < 4 + lenth * 2 + lenth; i++)
            {
                content.Add(source[i]);
            }
            //除去补偿值
            for (int i = 0; i < lenth; i++)
            {
                content[i] = (byte)(content[i] - offsetList[i]);
            }
            return content.ToArray();
        }
    }
}

