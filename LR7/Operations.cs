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

        private int _numerator { get; set; }
        private int _denominator { get; set; }

        public void SetNumerator(int numerator)
        {
            _numerator = numerator;
        }
        
        public void SetDenaminator(int denaminator)
        {
            _denominator = denaminator;
        }

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
            var res = new Operations(1, 1);
            if (obj1._denominator == obj2._denominator)
            {
                res._numerator = obj1._numerator + obj2._numerator;
                res._denominator = obj1._denominator;
                return res;
            }

            res._numerator = obj1._numerator * obj2._denominator;
            res._numerator += obj2._numerator * obj1._denominator;

            res._denominator = obj1._denominator * obj2._denominator;
            return res;
        }

        public static Operations operator -(Operations obj1, Operations obj2)
        {
            var res = new Operations(1, 1);
            if (obj1._denominator == obj2._denominator)
            {
                res._numerator = obj1._numerator - obj2._numerator;
                res._denominator = obj1._denominator;
                return res;
            }

            res._numerator = obj1._numerator * obj2._denominator;
            res._numerator -= obj2._numerator * obj1._denominator;

            res._denominator = obj1._denominator * obj2._denominator;
            return res;
        }

        public static Operations operator *(Operations obj1, Operations obj2)
        {
            var res = new Operations(1, 1)
            {
                _numerator = obj1._numerator * obj2._numerator, _denominator = obj1._denominator * obj2._denominator
            };
            return res;
        }

        public static Operations operator /(Operations obj1, Operations obj2)
        {
            var res = new Operations(1, 1) {_numerator = obj1._numerator * obj2._denominator};
            var temp = obj2._numerator * obj1._denominator;
            if (temp > 0)
                res._denominator = temp;
            else
            {
                res._denominator = Math.Abs(temp);
                res._numerator = 0 - res._numerator;
            }

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

        private void Reduce()
        {
            var n = Nod(Math.Abs(_numerator), _denominator);
            while (n != 1)
            {
                n = Nod(Math.Abs(_numerator), _denominator);
                _numerator /= n;
                _denominator /= n;
            }
        }

        public string Fraction()
        {
            if (_numerator % _denominator == 0)
            {
                return Convert.ToString(_numerator / _denominator);
            }

            Reduce();
            return _numerator + "/" + _denominator;
        }

        public int CompareTo(object obj)
        {
            var temp = (Operations) obj;
            if (this > temp) return 1;
            if (this < temp) return -1;
            return 0;
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
