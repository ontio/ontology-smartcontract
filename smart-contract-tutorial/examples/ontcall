using Ont.SmartContract.Framework;
using Ont.SmartContract.Framework.Services.Ont;
using Ont.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace Example
{
  
    public class AppContract : SmartContract
    {
        struct State
        {
            public byte[] From;
            public byte[] To;
            public UInt64 Amount;
        }
        
        public struct StateSend
        {
            public byte[] Send;
            public byte[] From;
            public byte[] To;
            public UInt64 Amount;
        }
        public struct BalanceOfParam
        {
            public byte[] Address;
        }
        struct AllowenceParam
        {
            public byte[] From;
            public byte[] To;
        }
        public static object Main(string operation, params object[] args)
        {
            if (operation == "transfer")
            {
                return TransferInvoke(args);
            }
            
            if(operation == "approve")
            {
                return ApproveInvoke(args);
            }
            if(operation == "transferFrom")
            {
                return TransferFromInvoke(args);
            }
            if(operation == "balanceOf")
            {
                return balanceInvoke(args);
            }
            if(operation == "allowance")
            {
                return allowanceInvoke(args);
            }
            if (operation == "name")
            {
                return nameInvoke();
            }
            if (operation == "decimals")
            {
                return decimalsInvoke();
            }
            if (operation == "symbol")
            {
                return symbolInvoke();
            }
            if (operation == "totalSupply")
            {
                return totalSupplyInvoke();
            }
            return false;
        }

        public static object TransferInvoke(object[] args)
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };            
			byte[] from = (byte[])args[0];
            byte[] to = (byte[])args[1];
            UInt64 amount = (UInt64)args[2];
            
            object[] param = new object[1];
            param[0] = new State { From = from, To = to, Amount = amount };
            
            return Native.Invoke(0, address, "transfer", param);
        }

        public static object ApproveInvoke(object[] args)
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };           
			byte[] from = (byte[])args[0];
            byte[] to = (byte[])args[1];
            UInt64 amount = (UInt64)args[2];
            
            State param = new State { From = from, To = to, Amount = amount };
            
            return Native.Invoke(0, address, "approve", param);
        }

        public static object TransferFromInvoke(object[] args)
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };           
			byte[] send = (byte[])args[0];
            byte[] from = (byte[])args[1];
            byte[] to = (byte[])args[2];
            UInt64 amount = (UInt64)args[3];
            
            StateSend param = new StateSend { Send = send, From = from, To = to, Amount = amount };
            
            return Native.Invoke(0, address, "transferFrom", param);
        }
         public static byte[] nameInvoke()
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            int[] numbers = new int[1];
			byte[] ret = Native.Invoke(0, address, "name", numbers);
            return ret;
        }
        public static byte[] symbolInvoke()
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };          
			byte[] ret = Native.Invoke(0, address, "symbol", false);
            return ret;
        }
        public static byte[] decimalsInvoke()
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };          
			byte[] ret = Native.Invoke(0, address, "decimals", false);
            return ret;
        }
         public static byte[] totalSupplyInvoke()
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };           
			byte[] ret = Native.Invoke(0, address, "totalSupply", false);
            return ret;
        }
        public static byte[] balanceInvoke(object[] args)
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };           
			byte[] add = (byte[])args[0];
            
            BalanceOfParam param = new BalanceOfParam {Address = add};
            
            byte[] ret = Native.Invoke(0, address, "balanceOf", param);
            return ret;
        }
        public static byte[] allowanceInvoke(object[] args)
        {
            byte[] address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };          
			byte[] from = (byte[])args[0];
            byte[] to = (byte[])args[1];

            AllowenceParam param_1 = new AllowenceParam { From =  from, To = to };
            return Native.Invoke(0, address, "allowance", param_1);
        }
    }
    }
