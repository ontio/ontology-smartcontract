using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;
using System.Text;
using Helper = Neo.SmartContract.Framework.Helper;

namespace DID
{
    public class DID : SmartContract
    {
        public static Object Main(string operation, params object[] args)
        {
            if (operation == "TestMap")
            {
                return TestMap();
            }else if (operation == "DeserializeMap")
            {
                return DeserializeMap((byte[])args[0]);
            }
            else if (operation == "TestStruct")
            {
                return TestStruct();
            }
             else if(operation == "DeserializeStruct"){
                return DeserializeStruct((byte[])args[0]);
            }
            return null;
        }

        public static object TestMap()
        {
            StorageContext context = Storage.CurrentContext;
            Map<string, int> m = new Map<string, int>();
            int value = 100;
            //m["hello"] = "world";
            m["key"] = value;

            byte[] b = Helper.Serialize(m);
            Storage.Put(context, "tx", b);

            byte[] v = Storage.Get(context, "tx");

            Map<string, int> b2 = (Map<string, int>)Helper.Deserialize(v);

            //&& b2["hello"] == "world"
            if ( b2 != null  && (int)b2["key"] == value )
            {
                Storage.Put(context, "result", "true");
                return b;
            }

            Storage.Put(context, "result", "false");
            return false;
        }


        public static object DeserializeMap(byte[] param)
        {
            Map<string, int> b2 = (Map<string, int>)Helper.Deserialize(param);
            StorageContext context = Storage.CurrentContext;

            int value = 100;
            //&& b2["hello"] == "world"
            if (b2 != null  && (int)b2["key"] == value )
            {
                Storage.Put(context, "result", "true");
                return true;
            }

            Storage.Put(context, "result", "false");
            return (int)b2["key"];
        }
        
        public static object TestStruct()
        {
            StorageContext context = Storage.CurrentContext;
            ClaimTx m = new ClaimTx();
            m.name = "claimid";
            m.claimId = 100;

            byte[] b = Helper.Serialize(m);
            Storage.Put(context, "tx", b);

            byte[] v = Storage.Get(context, "tx");

            if(b != null){
              return b;
            }
 

            Storage.Put(context, "result", "false");
            return false;
        }
        public static object DeserializeStruct(byte[] param)
        {
            ClaimTx b2 = (ClaimTx)Helper.Deserialize(param);
            StorageContext context = Storage.CurrentContext;

            int value = 100;
            //&& b2["hello"] == "world"
            if (b2 != null  && (int)b2.claimId == value )
            {
                Storage.Put(context, "result", "true");
                return true;
            }

            Storage.Put(context, "result", "false");
            return (int)b2.claimId;
        }
        public class ClaimTx
        {
            public int claimId;
            public string name;
        }
    }
}