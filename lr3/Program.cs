using System;
using System.Collections;

namespace lr3
{
    partial class Vector : IEnumerable
    {
       
        readonly int id;
        static int _vectors;  
        private int[] _arr;
        private int _size;

        public int[] Arr
        {
            get => _arr;
            private set
            {
                this._arr = value;
                this.Size = value.Length;
            }
        }
        public int Size
        {
            get => _size;
            set
            {
                Array.Resize(ref _arr, value);
                _size = value;
            }
        }

        public int Number{get;}
        public int Id => id;

        static Vector() => _vectors = 0;
        public Vector(Vector another) : this(another.Arr)
        {
        }

        public static Vector Prefilled(int size, int value = 0)
        {
            return new Vector(size, value);
        }

        public void CopyTo(out int[] value)
        {
            value = Arr;
        }
        public void ConcatWith(ref int[] value)
        {
            var toRet = new int[value.Length + this.Size];
            value.CopyTo(toRet, 0);
            Arr.CopyTo(toRet, value.Length);
            value = toRet;
        }
        
        
        private Vector() {  }
        private Vector(int size, int value = 0)
        {
            this.Number = ++_vectors;
          
            this.Arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                this.Arr[i] = value;
            }

            this.id = this.Arr.GetHashCode() + 49 * this.Number ;
        }
        public Vector(params int[] value)
        {
            this.Number = ++_vectors;
            this.Arr = value;
            this.id = Arr.GetHashCode() + 49 * this.Number;
        }

        public static Vector operator +(Vector v) => v;

        public static Vector operator -(Vector v)
        {
            for (int i = 0; i < v.Size; i++)
            {
                v[i] = -v[i];
            }
            return v;
        }

        public static Vector operator +(Vector v, int scalar)
        {
            for (int i = 0; i < v.Size; i++)
            {
                v[i] += scalar;
            }
            return v;

        }

        public static Vector operator -(Vector v, int scalar) => v + (-scalar);

        public static Vector operator +(int scalar, Vector v) => v + scalar;

        public static Vector operator -(int scalar, Vector v) => scalar + (-v);

        public static Vector operator +(Vector v, Vector j)
        {
            if (v.Size < j.Size) v.Size = j.Size;
            for (int i = 0; i < v.Size; i++)
            {
                v[i] += j[i];
            }
            return v;
        }

        public static Vector operator -(Vector v, Vector j) => v + (-j);

        public static Vector operator *(int scalar, Vector v)
        {
            for (int i = 0; i < v.Size; i++)
            {
                v[i] *= scalar;
            }
            return v;
        }

        public static Vector operator *(Vector v, int scalar) => scalar * v;


        public int this[int index]
        {
            get
            {
                return this.Arr[index];
            }
            set
            {
                this.Arr[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Arr.GetEnumerator();
        }


        public override bool Equals(object obj)
        {
            return Arr.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Arr.GetHashCode();
        }

        public override string ToString()
        {
            return String.Join(", ", Arr);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var h = new Vector(new int[] { 1, 4, 5, 2, 7, 9, 2 });
            h += 3;
            h *= 2;
            var i = new Vector(1, 2, 3, 4);

            var j = Vector.Prefilled(13, 10);

            

 
            



            Console.WriteLine(h);

            Console.WriteLine("Hello World!");


        }
    }
}

