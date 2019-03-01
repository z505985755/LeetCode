using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigInt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //给以解决LeetCode上大量数字类问题,无符号变为有符号也比较简单

        }
    }
    /// <summary>
    /// 无符号超大整数
    /// </summary>
    struct UBigInt
    {

        private byte[] _number;

        public UBigInt(string initial)
        {
            //原则上应该对initial进行格式检查
            _number = new byte[initial.Length];
            for (int i = 0; i < initial.Length; i++)
            {
                _number[i] = Convert.ToByte(initial[i].ToString());
            }
        }

        public UBigInt(int initial)
        {
            string initial2 = initial.ToString();
            _number = new byte[initial2.Length];
            for (int i = 0; i < initial2.Length; i++)
            {
                _number[i] = Convert.ToByte(initial2[i].ToString());
            }
        }

        /// <summary>
        /// C#中没有拷贝构造函数,这样重载构造函数变相的完成了相关功能,虽然仍然不如C++方便,但聊胜于无,使用方法如下:
        /// UBigInt ubi2 = new UBigInt(ubi1);将ubi1深拷贝到ubi2
        /// </summary>
        /// <param name="initial"></param>
        public UBigInt(UBigInt initial)
        {
            _number = new byte[initial._number.Length];
            _number = (byte[])initial._number.Clone();
        }

        public static UBigInt operator +(UBigInt UBigInt1, UBigInt UBigInt2)//核心
        {
            UBigInt bi1 = new UBigInt();
            UBigInt bi2 = new UBigInt();
            bi1._number = (byte[])UBigInt1._number.Clone();
            bi2._number = (byte[])UBigInt2._number.Clone();
            byte b = 0;//表示进位
            int length = Math.Max(bi1._number.Length, bi2._number.Length);
            int length1 = bi1._number.Length;
            int length2 = bi2._number.Length;
            if (length1 > length2)
            {
                for (int i = 0; i < length; i++)//从最后一位开始,向前计算,想来超大Int的最大位数为Int.Max不算小吧
                {
                    byte b1 = bi1._number[length1 - i - 1];
                    byte b2 = 0;
                    if (length2 - i >= 1)//
                    {
                        b2 = bi2._number[length2 - i - 1];
                    }
                    int sum = Convert.ToByte(b1 + b2 + b);
                    bi1._number[length1 - i - 1] = Convert.ToByte(sum % 10);
                    b = Convert.ToByte(sum / 10);
                    if (i == length - 1 && b > 0)//最后一次进位了,则构造一个新的数组并赋值
                    {
                        byte[] barr = new byte[length + 1];
                        barr[0] = b;
                        for (int j = 1; j < length + 1; j++)
                        {
                            barr[j] = bi1._number[j - 1];
                        }
                        bi1._number = barr;
                    }
                }
                return bi1;
            }
            else
            {
                for (int i = 0; i < length; i++)//从最后一位开始,向前计算,想来超大Int的最大位数为Int.Max不算小吧
                {
                    byte b1 = 0;
                    byte b2 = bi2._number[length2 - i - 1];
                    if (length1 - i >= 1)//
                    {
                        b1 = bi1._number[length1 - i - 1];
                    }
                    int sum = Convert.ToByte(b1 + b2 + b);
                    bi2._number[length2 - i - 1] = Convert.ToByte(sum % 10);
                    b = Convert.ToByte(sum / 10);
                    if (i == length - 1 && b > 0)//最后一次进位了,则构造一个新的数组并赋值
                    {
                        byte[] barr = new byte[length + 1];
                        barr[0] = b;
                        for (int j = 1; j < length + 1; j++)
                        {
                            barr[j] = bi2._number[j - 1];
                        }
                        bi2._number = barr;
                    }
                }
                return bi2;
            }
        }

        public static UBigInt operator ++(UBigInt UBigInt1)
        {
            UBigInt bi1 = new UBigInt();
            bi1._number = (byte[])UBigInt1._number.Clone();
            return bi1 + new UBigInt(1);
        }

        public static UBigInt operator *(UBigInt UBigInt1, UBigInt UBigInt2)
        {
            UBigInt bi1 = new UBigInt();
            UBigInt bi2 = new UBigInt();
            bi1._number = (byte[])UBigInt1._number.Clone();
            bi2._number = (byte[])UBigInt2._number.Clone();
            UBigInt bi3 = 0;
            for (UBigInt i = 0; i < bi2; i++)
            {
                bi3 = bi3 + bi1;
            }
            return bi3;
        }

        public static bool operator <(UBigInt bi1, UBigInt bi2)
        {
            if (bi1._number.Length < bi2._number.Length)
            {
                return true;
            }
            if (bi1._number.Length > bi2._number.Length)
            {
                return false;
            }
            if (bi1._number.Length == bi2._number.Length)
            {
                for (int i = 0; i < bi1._number.Length; i++)
                {
                    if (Convert.ToByte(bi1._number[i]) < Convert.ToByte(bi2._number[i]))
                    {
                        return true;
                    }
                    if (Convert.ToByte(bi1._number[i]) > Convert.ToByte(bi2._number[i]))
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool operator >(UBigInt bi1, UBigInt bi2)
        {
            if (bi1._number.Length < bi2._number.Length)
            {
                return false;
            }
            if (bi1._number.Length > bi2._number.Length)
            {
                return true;
            }
            if (bi1._number.Length == bi2._number.Length)
            {
                for (int i = 0; i < bi1._number.Length; i++)
                {
                    if (Convert.ToByte(bi1._number[i]) < Convert.ToByte(bi2._number[i]))
                    {
                        return false;
                    }
                    if (Convert.ToByte(bi1._number[i]) > Convert.ToByte(bi2._number[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator ==(UBigInt bi1, UBigInt bi2)
        {
            return bi1.ToString() == bi2.ToString();
        }

        public static bool operator !=(UBigInt bi1, UBigInt bi2)
        {
            return bi1.ToString() != bi2.ToString();
        }

        public static implicit operator UBigInt(int i)
        {
            return new UBigInt(i);
        }

        public static implicit operator UBigInt(string s)
        {
            return new UBigInt(s);
        }

        public override string ToString()
        {
            return string.Join("", _number);
        }
    }
}
