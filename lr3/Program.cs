using System;
using System.Collections;
using System.Linq;
 
namespace lr3
{
    partial class Vector : IEnumerable
    {
        const string infoTemplate = "Класс {0}, реализующий одномерный массив целых чисел. На данный момент" +
           "насчитывает {1} объекта(-ов)";
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
                this._size = value;
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

        public Vector Filter(Func<int, bool> filter = null) => new Vector(this.Arr.Where(filter ?? (el => true)).ToArray());
        public bool All(Func<int, bool> filter = null) => this.Arr.All(filter ?? (el => true));
        public bool Any(Func<int, bool> filter = null) => this.Arr.Any(filter ?? (el => true));
        public int Sum() => this.Arr.Sum();
        public int Min() => this.Arr.Min();
        public int Max() => this.Arr.Max();


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
            int[] tempV = v.Arr, tempJ = j.Arr;
            int maxLen = Math.Max(v.Size, j.Size);
            if (maxLen == v.Size)
                Array.Resize(ref tempJ, maxLen);
            else Array.Resize(ref tempV, maxLen);

            return new Vector(tempV.Zip(tempJ, (a, b) => a + b).ToArray());
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
            get => this.Arr[index];
            set
            {
                this.Arr[index] = value;
            }
        }

        public IEnumerator GetEnumerator() => Arr.GetEnumerator();


        public override bool Equals(object obj) => Arr.Equals(obj);

        public override int GetHashCode() => Arr.GetHashCode();

        public override string ToString() => String.Join(", ", Arr);


       public static void Info() => Console.WriteLine(string.Format(infoTemplate, "Vector", _vectors));
    }
    class Program
    {
        static void Main(string[] args)
        {

            var firstVector = new Vector(new int[] { 1, 4, 5, 2, 7, 9, 2 });

            Console.WriteLine("Создали вектор: " + firstVector);
            Console.WriteLine("Умножили на два: " + (firstVector *= 2));
            Console.WriteLine("Прибавили три: " + (firstVector += 3));
            Console.WriteLine("Отняли пять:" + (firstVector -= 5));

            var secondVector = new Vector(7, 19, 56, 3);
            Console.WriteLine($"Добавили к вектору {firstVector} вектор {secondVector}: {firstVector += secondVector}");


            
 

            


            var i = new Vector(1, 2, 3, 4);

            Vector[] vectors = new Vector[] { new Vector(1, 2, 3, 4),  new Vector(89, 37, 16, 2), new Vector(2, 7,9,8),
                new Vector(2, 8, 6), new Vector(3, 9, 11) };


            Console.WriteLine("Все вектора: ");
            foreach (var vector in vectors)
                Console.WriteLine(vector);

            Console.WriteLine("Вектора только с нечетными значениями: ");
            foreach (var vector in vectors.Where(v => v.All(el => Convert.ToBoolean(el % 2))))
                Console.WriteLine(vector);

            Console.WriteLine("Вектора только с четными значениями: ");
            foreach (var vector in vectors.Where(v => v.All(el => !Convert.ToBoolean(el % 2))))
                Console.WriteLine(vector);

            Console.WriteLine("Вектор с наибольшей суммой: " + (from vector in vectors orderby vector.Sum() descending select vector).First());  //Array.Sort? да слышал неинтересно

            var anon = new { arr = new int[] { 1, 8, 6 }, size = 3 };
            Console.WriteLine(anon);

            Vector.Info();












 


        }
    }
}

