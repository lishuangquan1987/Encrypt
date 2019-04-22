using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringEncrypt
{
   internal class Encoder
    {
        private Random random = new Random();
        /// <summary>
        /// 字符串加密，原理：开头4字节+每个字节的补偿长度(len*2)+内容len+校验码（1）
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public byte[] Encode(byte[] source)
        {
            if (source == null || source.Count()==0)
                throw new Exception("source is null");
            int lenth = source.Count();
            List<short> offsetList = new List<short>();
            List<byte> content = new List<byte>();
            for (int i = 0; i < lenth; i++)
            {
                short offset = Encode(source[i]);
                offsetList.Add(offset);
                content.Add((byte)(source[i] + offset));
            }
            List<byte> result = new List<byte>();
            //加入字节长度:4
            result.AddRange(BitConverter.GetBytes(lenth));
            //加入offset 2*lenth
            offsetList.ForEach(x => result.AddRange(BitConverter.GetBytes(x)));
            //加入内容：lenth
            content.ForEach(x => result.Add(x));
            //加入校验码
            result.Add(XORHelper.GetXORCode(result));
            return result.ToArray();
        }
        /// <summary>
        /// 对单个字节进行加密
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private short Encode(byte b)
        {
            
            while (true)
            {
                int offset = random.Next(0, 255);
                if (b + offset > 0 && b + offset < 255)
                    return (short)offset;
                if (b - offset > 0 && b - offset < 255)
                    return (short)(-offset);
            }            
        }

       
    }
}
