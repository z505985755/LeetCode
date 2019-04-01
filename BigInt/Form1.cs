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
            BigInt bigInt11 = 3;
            BigInt bigInt21 = 2;
            var v = bigInt11  % bigInt21;
            //给以解决LeetCode上大量数字类问题
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    BigInt bigInt1 = i-500;
                    BigInt bigInt2 = j-500;
                    int i1 = i-500;
                    int i2 = j-500;
                    if (i1.ToString() != bigInt1.ToString() || i2.ToString() != bigInt2.ToString())
                    {

                    }
                    //System.IO.File.AppendAllText(@"D:\text.txt", i1 + "  " + i2 + "  " + bigInt1.ToString() + "  " + bigInt2.ToString() + "\r\n");
                    BigInt v1;
                    BigInt v2;
                    v1 = bigInt1 + bigInt2;
                    v2 = i1 + i2;
                    if (v1.ToString() != v2.ToString())
                    {

                    }
                    v1 = bigInt1 - bigInt2;
                    v2 = i1 - i2;
                    if (v1.ToString() != v2.ToString())
                    {

                    }
                    v1 = bigInt1 * bigInt2;
                    v2 = i1 * i2;
                    if (v1.ToString() != v2.ToString())
                    {

                    }
                    if (bigInt2 != 0)
                    {
                        v1 = bigInt1 / bigInt2;
                        v2 = i1 / i2;
                        if (v1.ToString() != v2.ToString())
                        {

                        }
                        v1 = bigInt1 % bigInt2;
                        v2 = i1 % i2;
                        if (v1.ToString() != v2.ToString())
                        {

                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// 超大整数
    /// </summary>
    public struct BigInt
    {
        private string _fuhao;
        private byte[] _number;
        private BigInt(string initial)
        {
            if (initial[0] == '-')
            {
                _fuhao = "-";
            }
            else
            {
                _fuhao = "";
            }
            //原则上应该对initial进行格式检查
            _number = new byte[initial.Length];
            for (int i = 0; i < initial.Length; i++)
            {
                _number[i] = Convert.ToByte(initial[i].ToString());
            }
        }
        private BigInt(int initial)
        {
            if (initial<0)
            {
                _fuhao = "-";
                string initial2 = initial.ToString().Remove(0, 1);
                _number = new byte[initial2.Length];
                for (int i = 0; i < initial2.Length; i++)
                {
                    _number[i] = Convert.ToByte(initial2[i].ToString());
                }
            }
            else
            {
                _fuhao = "";
                string initial2 = initial.ToString();
                _number = new byte[initial2.Length];
                for (int i = 0; i < initial2.Length; i++)
                {
                    _number[i] = Convert.ToByte(initial2[i].ToString());
                }
            }
        }
        private BigInt(BigInt initial)
        {
            _number = new byte[initial._number.Length];
            _number = (byte[])initial._number.Clone();
            _fuhao = initial._fuhao;
        }
        public static BigInt operator +(BigInt BigInt1, BigInt BigInt2)//核心
        {
            if (BigInt1._fuhao == BigInt2._fuhao)
            {
                BigInt bi1 = BigInt1.Abs;
                BigInt bi2 = BigInt2.Abs;
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
                    bi1._fuhao = BigInt1._fuhao;
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
                    bi2._fuhao = BigInt1._fuhao;
                    return bi2;
                }
            }
            else
            {
                BigInt bi1 = BigInt1.Abs;
                BigInt bi2 = BigInt2.Abs;
                BigInt bi3 = bi1 - bi2;
                if (BigInt1._fuhao == "-" && bi1 > bi2)
                {
                    bi3._fuhao = "-";
                }
                if (BigInt1._fuhao == "-" && bi1 < bi2)
                {
                    bi3._fuhao = "";

                }
                if (BigInt1._fuhao == "" && bi1 > bi2)
                {
                    bi3._fuhao = "";
                }
                if (BigInt1._fuhao == "" && bi1 < bi2)
                {
                    bi3._fuhao = "-";

                }
                return bi3;
            }
        }
        public static BigInt operator -(BigInt BigInt1, BigInt BigInt2)//核心
        {
            if (BigInt1._fuhao != BigInt2._fuhao)
            {
                BigInt bi1 = BigInt1.Abs;
                BigInt bi2 = BigInt2.Abs;
                BigInt bi3 = bi1 + bi2;
                bi3._fuhao = BigInt1._fuhao;
                return bi3;
            }
            else
            {
                if (BigInt1 == BigInt2)
                {
                    return 0;
                }
                BigInt bi1 = BigInt1.Abs;
                BigInt bi2 = BigInt2.Abs;
                BigInt bi3 = 0;
                if (BigInt1 < BigInt2)
                {
                    bi3._fuhao = "-";
                }
                if (bi1 > bi2)
                {
                    bi3._number = (byte[])BigInt1._number.Clone();
                    byte b = 0;//表示借位
                    for (int i = 0; i < bi1._number.Length; i++)
                    {
                        if (bi2._number.Length - i - 1 >= 0)
                        {
                            if (bi1._number[bi1._number.Length - i - 1] >= bi2._number[bi2._number.Length - i - 1] + b)
                            {
                                bi3._number[bi1._number.Length - i - 1] = Convert.ToByte(bi1._number[bi1._number.Length - i - 1] - bi2._number[bi2._number.Length - i - 1] - b);
                                b = 0;
                            }
                            else
                            {
                                bi3._number[bi1._number.Length - i - 1] = Convert.ToByte(10 + bi1._number[bi1._number.Length - i - 1] - bi2._number[bi2._number.Length - i - 1] - b);
                                b = 1;
                            }
                        }
                        else
                        {
                            if (bi1._number[bi1._number.Length - i - 1] >= b)
                            {
                                bi3._number[bi1._number.Length - i - 1] = Convert.ToByte(bi1._number[bi1._number.Length - i - 1] - b);
                                b = 0;
                            }
                            else
                            {
                                bi3._number[bi1._number.Length - i - 1] = Convert.ToByte(10 + bi1._number[bi1._number.Length - i - 1] - b);
                                b = 1;
                            }
                        }
                    }
                }
                if (bi2 > bi1)
                {
                    bi3._number = (byte[])BigInt2._number.Clone();
                    byte b = 0;//表示借位
                    for (int i = 0; i < bi2._number.Length; i++)
                    {
                        if (bi1._number.Length - i - 1 >= 0)
                        {
                            if (bi2._number[bi2._number.Length - i - 1] >= bi1._number[bi1._number.Length - i - 1] + b)
                            {
                                bi3._number[bi2._number.Length - i - 1] = Convert.ToByte(bi2._number[bi2._number.Length - i - 1] - bi1._number[bi1._number.Length - i - 1] - b);
                                b = 0;
                            }
                            else
                            {
                                bi3._number[bi2._number.Length - i - 1] = Convert.ToByte(10 + bi2._number[bi2._number.Length - i - 1] - bi1._number[bi1._number.Length - i - 1] - b);
                                b = 1;
                            }
                        }
                        else
                        {
                            if (bi2._number[bi2._number.Length - i - 1] >= b)
                            {
                                bi3._number[bi2._number.Length - i - 1] = Convert.ToByte(bi2._number[bi2._number.Length - i - 1] - b);
                                b = 0;
                            }
                            else
                            {
                                bi3._number[bi2._number.Length - i - 1] = Convert.ToByte(10 + bi2._number[bi2._number.Length - i - 1] - b);
                                b = 1;
                            }
                        }
                    }
                }
                if (bi3._number[0] == 0)
                {
                    byte[] barr =new byte[] { };
                    int L = 0;
                    bool tag = true;
                    for (int i = 0; i < bi3._number.Length; i++)
                    {
                        if (bi3._number[i]==0 && tag)
                        {
                            L++;
                        }
                        else
                        {
                            if (tag)
                            {
                                barr = new byte[bi3._number.Length - L];
                                tag = false;
                                barr[i - L] = bi3._number[i];
                            }
                            else
                            {
                                barr[i - L] = bi3._number[i];
                            }
                        }
                    }
                    bi3._number = barr;
                }
                return bi3;
            }
        }
        public static BigInt operator *(BigInt BigInt1, BigInt BigInt2)
        {
            if (BigInt1 == 0 || BigInt2 == 0)
            {
                return 0;
            }
            BigInt bi3 = 0;
            BigInt bi1 = BigInt1.Abs;
            BigInt bi2 = BigInt2.Abs;
            for (BigInt i = 0; i < bi2; i++)
            {
                bi3 = bi3 + bi1;
            }
            if (BigInt1._fuhao == BigInt2._fuhao)
            {
                bi3._fuhao = "";
            }
            else
            {
                bi3._fuhao = "-";
            }
            return bi3;
        }
        public static BigInt operator /(BigInt BigInt1, BigInt BigInt2)
        {
            if (BigInt2 == 0)
            {
                throw new DivideByZeroException("尝试除以零。");
            }
            BigInt bigInt1 = BigInt1.Abs;
            BigInt bigInt2 = BigInt2.Abs;
            BigInt bigInt3 = 0;
            if (bigInt1 >= bigInt2)
            {
                for (BigInt i = 1; i <= bigInt1; i++)
                {
                    bigInt3 += bigInt2;
                    if (bigInt3 == bigInt1)
                    {
                        if (BigInt1._fuhao != BigInt2._fuhao)
                        {
                            i._fuhao = "-";
                        }
                        return i;
                    }
                    if (bigInt3 > bigInt1)
                    {
                        i--;
                        if (BigInt1._fuhao != BigInt2._fuhao)
                        {
                            i._fuhao = "-";
                        }
                        return i;
                    }
                }
                return 0;
            }
            else
            {
                return 0;
            }

            //if (BigInt2==0)
            //{
            //    throw new DivideByZeroException("尝试除以零。");
            //}
            //BigInt bigInt1 = new BigInt(BigInt1);
            //BigInt bigInt2 = new BigInt(BigInt2);
            //bigInt1._fuhao = "";
            //bigInt2._fuhao = "";
            //if (bigInt1 >= bigInt2)
            //{
            //    for (BigInt i = 1; i <= bigInt1; i++)
            //    {
            //        if (i * bigInt2 == bigInt1 || (i + 1) * bigInt2 > bigInt1)
            //        {
            //            if (BigInt1._fuhao!= BigInt2._fuhao)
            //            {
            //                i._fuhao = "-";
            //            }
            //            return i;
            //        }
            //    }
            //    return 0;
            //}
            //else
            //{
            //    return 0;
            //}
        }
        public static BigInt operator %(BigInt BigInt1, BigInt BigInt2)
        {
            if (BigInt2 == 0)
            {
                throw new DivideByZeroException("尝试除以零。");
            }
            var v = BigInt1 / BigInt2;
            v = v * BigInt2;
            return BigInt1 - v;
        }
        public static BigInt operator ++(BigInt BigInt1)
        {
            BigInt bi1 = new BigInt(BigInt1);
            return bi1 + new BigInt(1);
        }
        public static BigInt operator --(BigInt BigInt1)
        {
            return BigInt1 - 1;
        }
        public static bool operator <(BigInt bi1, BigInt bi2)
        {
            if (bi1._fuhao == "" && bi1._fuhao == bi2._fuhao)
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
            else if (bi1._fuhao == "-" && bi1._fuhao == bi2._fuhao)
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
            else
            {
                if (bi1._fuhao == "-")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool operator >(BigInt bi1, BigInt bi2)
        {
            if (bi1 == bi2)
            {
                return false;
            }
            else
            {
                return !(bi1 < bi2);
            }
        }
        public static bool operator <=(BigInt bi1, BigInt bi2)
        {
            if (bi1 == bi2)
            {
                return true;
            }
            else
            {
                return bi1 < bi2;
            }
        }
        public static bool operator >=(BigInt bi1, BigInt bi2)
        {
            if (bi1 == bi2)
            {
                return true;
            }
            else
            {
                return bi1 > bi2;
            }
        }
        public static bool operator ==(BigInt bi1, BigInt bi2)
        {
            return bi1.ToString() == bi2.ToString();
        }
        public static bool operator !=(BigInt bi1, BigInt bi2)
        {
            return bi1.ToString() != bi2.ToString();
        }
        public override string ToString()
        {
            return _fuhao + string.Join("", _number);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static implicit operator BigInt(int i)
        {
            return new BigInt(i);
        }
        public static implicit operator BigInt(string s)
        {
            return new BigInt(s);
        }

        public BigInt Abs
        {
            get
            {
                BigInt b = new BigInt(this);
                b._fuhao = "";
                return b;
            }
        }
    }
}