using System;
using System.Text;

namespace PocketDemo1
{
    /// <summary>
    /// 转换二进制
    /// </summary>
    public class ToBinary
    {
        /// <summary>
        /// String转二进制
        /// </summary>
        /// <param name="value">输入</param>
        /// <returns></returns>
        [Obsolete]
        public static string StringToBinary(string value)
        {
            byte[] data = Encoding.Unicode.GetBytes(value);
            StringBuilder result = new StringBuilder(data.Length * 8);

            foreach (byte b in data)
            {
                result.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return result.ToString();
        }

        /// <summary>
        /// 将二进制转换成String
        /// </summary>
        /// <param name="value">输入</param>
        /// <returns></returns>
        [Obsolete]
        public static string BinaryToString(string value)
        {
            System.Text.RegularExpressions.CaptureCollection cs =
                  System.Text.RegularExpressions.Regex.Match(value, @"([01]{8})+").Groups[1].Captures;
            byte[] data = new byte[cs.Count];
            for (int i = 0; i < cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value, 2);
            }
            return Encoding.Unicode.GetString(data, 0, data.Length);
        }

        /// <summary>
        /// 将数字转成二进制
        /// </summary>
        /// <param name="number">输入</param>
        /// <returns></returns>
        public static int[] IntToBinary(double number)
        {
            int[] gen = new int[16];

            for (int i = 0; number > 0; ++i)
            {
                gen[i] = (int)number % 2;
                number /= 2;
                number = Math.Floor(number);
            }
            Array.Reverse(gen);
            return gen;
        }

        /// <summary>
        /// 将数字转成二进制倒序
        /// </summary>
        /// <param name="number">输入</param>
        /// <returns></returns>
        public static short[] ShortToBinaryDESC(short number)
        {
            short[] gen = new short[16];

            for (int i = 0; number > 0; ++i)
            {
                gen[i] = (short)(number % 2);
                number /= 2;
                // number = Math.Floor(number);
            }
            // Array.Reverse(gen);
            return gen;
        }

        /// <summary>
        /// 将数字转成二进制倒序
        /// </summary>
        /// <param name="number">输入</param>
        /// <returns></returns>
        public static int[] IntToBinaryDESC(double number)
        {
            int[] gen = new int[16];

            for (int i = 0; number > 0; ++i)
            {
                gen[i] = (int)number % 2;
                number /= 2;
                number = Math.Floor(number);
            }
            // Array.Reverse(gen);
            return gen;
        }

        /// <summary>
        /// 通过地址位获取二进制后转整
        /// </summary>
        /// <param name="addressBitPar">地址位</param>
        /// <param name="numberOf">点位</param>
        /// <param name="numberValue">数值</param>
        /// <returns>二进制转后的整数</returns>
        public static ushort AddressBitToBinary(string addressBitPar, int numberOf, int numberValue)
        {
            try
            {
                short addressBit = PlcCommon.busTcpClient1.ReadInt16(addressBitPar).Content;
                int[] arrayPar = ToBinary.IntToBinaryDESC(addressBit);

                arrayPar[numberOf] = numberValue;
                Array.Reverse(arrayPar);
                StringBuilder builder = new StringBuilder(addressBit);

                foreach (var item in arrayPar)
                {
                    builder.Append(item);
                }

                return Convert.ToUInt16(builder.ToString(), 2);
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "地址位为：" + addressBitPar + "的值更改失败。" + "\r\n" + "错误详情：" + ex.Message);
                return 0;
            }
        }
    }
}