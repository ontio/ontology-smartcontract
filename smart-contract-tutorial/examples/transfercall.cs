using Ont.SmartContract.Framework;
using Ont.SmartContract.Framework.Services.Ont;
using System;
using System.Numerics;

namespace NativeContract
{
    public class Contract1 : SmartContract
    {
        struct State
        {
            public byte[] From;
            public byte[] To;
            public int Value;
        }

        public static Object Main()
        {
            int value = 1000;
            byte[] address = { 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            byte[] from = { 76, 50, 165, 99, 113, 232, 4, 127, 50, 221, 89, 105, 7, 158, 55, 156, 244, 10, 38, 198 };
            byte[] to = { 76, 50, 165, 99, 113, 232, 4, 127, 50, 221, 89, 105, 7, 158, 55, 156, 244, 10, 38, 198 };

            object[] param = new object[1];
            param[0] = new State { From = from, To = to, Value = 10 };

            return Native.Invoke(0, address, "transfer", param);
        }
    }
}
