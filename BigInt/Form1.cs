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
            BigInt b1 = dividend;
            BigInt b2 = divisor;
            BigInt b3 = b1 / b2;
            if (b3 > 2147483647 || b3 < -2147483648)
            {
                b3 = -2147483648;
            }
            return Convert.ToInt32(b3.ToString());

            BigInt bigInt1 = 1;
            
            //给以解决LeetCode上大量数字类问题
            for (int i = 1; i < 10000; i++)
            {
                bigInt1 *= 2;
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
        private static BigInt Division(BigInt L, BigInt R, BigInt BigInt1, BigInt BigInt2)
        {
            if (L == R)
            {
                return L;
            }
            if (L + 1 == R)
            {
                if (R * BigInt2 <= BigInt1)
                {
                    return R;
                }
                else
                {
                    return L;
                }
            }
            BigInt center = GetCenter(L, R);//L和R的中间数
            BigInt r = center * BigInt2;
            if (r == BigInt1)
            {
                return center;
            }
            if (r > BigInt1)
            {
                return Division(L, center, BigInt1, BigInt2);
            }
            if (r < BigInt1)
            {
                return Division(center, R, BigInt1, BigInt2);
            }
            return 0;
        }
        private static BigInt GetCenter(BigInt L, BigInt R)
        {
            BigInt temp = R - L;
            int t = 0;
            StringBuilder sb = new StringBuilder();
            bool tag = false;
            for (int i = 0; i < temp._number.Length; i++)
            {
                var v1 = (temp._number[i] + 10 * t) / 2;
                var v2 = (temp._number[i] + 10 * t) % 2;
                if (v1 == 0)
                {
                    if (tag)
                    {
                        sb.Append(v1);
                    }
                }
                else
                {
                    sb.Append(v1);
                    tag = true;
                }
                t = v2;
            }
            if (sb.ToString()=="")
            {

            }
            return L + sb.ToString();
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
            for (int i = 0; i < bi2._number.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                int t = 0;
                for (int k = 0; k < bi1._number.Length; k++)
                {
                    int r = bi2._number[bi2._number.Length - i - 1] * bi1._number[bi1._number.Length - k - 1] + t;
                    sb.Append((r % 10).ToString());
                    t = r / 10;
                }
                if (t > 0)
                {
                    sb.Append(t);
                }
                string str = sb.ToString();
                str = string.Join("", str.Reverse());
                str = str.PadRight(i + str.Length, '0');
                bi3 += str.ToString();
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
                if (bigInt1 == bigInt2)
                {
                    bigInt3 = 1;
                }
                if (1 == bigInt2)
                {
                    bigInt3 = BigInt1;
                }
                bigInt3 = Division(1, bigInt1, bigInt1, bigInt2);//通过二分法寻找商
                if (BigInt1._fuhao != BigInt2._fuhao)
                {
                    bigInt3._fuhao = "-";
                }
                return bigInt3;
            }
            else
            {
                return 0;
            }
        }
        public static BigInt operator %(BigInt BigInt1, BigInt BigInt2)
        {
            if (BigInt2 == 0)
            {
                throw new DivideByZeroException("尝试除以零。");
            }
            return BigInt1 - BigInt1 / BigInt2 * BigInt2;
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