using System;
using System.Collections.Generic;
using System.Text;

namespace lr3
{
    partial class Vector
    {

        public void ConcatWith(ref int[] value)
        {
            var toRet = new int[value.Length + this.Size];
            value.CopyTo(toRet, 0);
            Arr.CopyTo(toRet, value.Length);
            value = toRet;
        }

        public void CopyTo(out int[] value)
        {
            value = Arr;
        }


    }
}
