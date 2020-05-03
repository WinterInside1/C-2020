using System;
using System.Linq;

namespace LR7
{
    public class Operations : IComparable, IEquatable<Operations>
    {
        public bool Equals(Operations other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _numerator == other._numerator && _denominator == other._denominator;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Operations) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_numerator, _denominator);
        }

        private readonly int _numerator;
        private readonly int _denominator; 

        // public void SetNumerator(int numerator)
        // {
        //     Numerator = numerator;
        // }
        
        // public void SetDenominator(int denaminator)
        // {
        //     Numerator = denaminator;
        // }

        public Operations(int num, int denum)
        {
            _numerator = num;
            _denominator = denum;
        }

        public Operations(int num)
        {
            _numerator = num;
            _denominator = 1;
        }

        public Operations()
        {
            _numerator = 1;
            _denominator = 1;
        }

        public static Operations operator +(Operations obj1, Operations obj2)
        {
            Operations res;
            if (obj1._denominator == obj2._denominator)
            {
                res = new Operations((obj1._numerator+obj2._numerator),obj1._denominator);
                return res;
            }
            res = new Operations(((obj1._numerator * obj2._denominator)+(obj2._numerator * obj1._denominator)),obj1._denominator * obj2._denominator);
            return res;
        }

        public static Operations operator -(Operations obj1, Operations obj2)
        {
            Operations res;
            if (obj1._denominator == obj2._denominator)
            {
                res = new Operations((obj1._numerator - obj2._numerator),obj1._denominator);
                return res;
            }
            res= new Operations(((obj1._numerator * obj2._denominator)-(obj2._numerator * obj1._denominator)),obj1._denominator * obj2._denominator);
            return res;
        }

        public static Operations operator *(Operations obj1, Operations obj2)
        {
            var res = new Operations(obj1._numerator * obj2._numerator,obj1._denominator * obj2._denominator);
            return res;
        }

        public static Operations operator /(Operations obj1, Operations obj2)
        {
            Operations res;
               // {_numerator = obj1._numerator * obj2._denominator};
            var temp = obj2._numerator * obj1._denominator;
            if (temp > 0)
            {
                res = new Operations((obj1._numerator * obj2._denominator),temp);
                return res;
            }
            res = new Operations((0-(obj1._numerator * obj2._denominator)),(Math.Abs(temp)));
            return res;
        }

        public static bool operator ==(Operations obj1, Operations obj2)
        {
            if (obj1._denominator == obj2._denominator)
            {
                return obj1._numerator == obj2._numerator;
            }

            return obj1._numerator * obj2._denominator == obj2._numerator * obj1._denominator;
        }

        public static bool operator !=(Operations obj1, Operations obj2)
        {
            if (obj1._denominator == obj2._denominator)
            {
                return obj1._numerator != obj2._numerator;
            }

            return obj1._numerator * obj2._denominator != obj2._numerator * obj1._denominator;
        }

        public static bool operator >=(Operations obj1, Operations obj2)
        {
            if (obj1._denominator == obj2._denominator)
            {
                return obj1._numerator >= obj2._numerator;
            }

            return obj1._numerator * obj2._denominator >= obj2._numerator * obj1._denominator;
        }

        public static bool operator <=(Operations obj1, Operations obj2)
        {
            if (obj1._denominator == obj2._denominator)
            {
                return obj1._numerator <= obj2._numerator;
            }

            return obj1._numerator * obj2._denominator <= obj2._numerator * obj1._denominator;
        }

        public static bool operator >(Operations obj1, Operations obj2)
        {
            if (obj1._denominator == obj2._denominator)
            {
                return obj1._numerator > obj2._numerator;
            }

            return obj1._numerator * obj2._denominator > obj2._numerator * obj1._denominator;
        }

        public static bool operator <(Operations obj1, Operations obj2)
        {
            if (obj1._denominator == obj2._denominator)
            {
                return obj1._numerator < obj2._numerator;
            }

            return obj1._numerator * obj2._denominator < obj2._numerator * obj1._denominator;
        }

        private static int Nod(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }

        private string Reduce()
        {
            var tempnum = _numerator;
            var tempdenum = _denominator;
            var n = Nod(Math.Abs(_numerator), _denominator);
            while (n != 1)
            {
                n = Nod(Math.Abs(_numerator), _denominator);
                tempnum /= n;
                tempdenum /=n;
            }

            return tempnum + "/" + tempdenum;
        }

        public override string ToString()
        {
            if (_numerator % _denominator == 0)
            {
                return $"{_numerator / _denominator}";
            }
            return Reduce();
            
        }
        // public string Fraction()
        // {
        //     if (_numerator % _denominator == 0)
        //     {
        //         return Convert.ToString(_numerator / _denominator);
        //     }
        //
        //     Reduce();
        //     return _numerator + "/" + _denominator;
        // }

        public int CompareTo(object obj)
        {
            var temp = (Operations) obj;
            if (temp != null)
            {
                if (this > temp)
                    return 1;
                else if (this < temp)
                    return -1;
                else 
                    return 0;
            }
            else throw new Exception("Unable to compare this two objects!");
        }

        public static explicit operator int(Operations obj)
        {
            return obj._numerator / obj._denominator;
        }

        public static explicit operator double(Operations obj)
        {
            return obj._numerator / obj._denominator;
        }
    }
}
