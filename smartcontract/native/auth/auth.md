# Auth Contract

* [Background](#Background)
* [API design](#API-design)
* [Workflow](#Workflow)
* [Contract Example (C#)](#Contract-Example)

## Background

Currently, the function of smart contract can be called by anyone, which obviously does not meet the actual requirements. The basic idea of ​​role-based rights management is that each role can call a partial function, and each entity can be assigned multiple roles (the entity is identified by its ONT ID).

If the smart contract needs to add the rights management function, it must record the roles assigned in the contract, the functions that the role can call, which entity has this role, and so on. This work is tedious and can be managed by a system contract.

In the following, we say that the contract that requires rights management functions are *App Contract*, and the system contract described in this document are *Auth Contract*.

## API design

### a. Set up the administrator of an application contract 

- Initialize the contract administrator

    ```
    Method: initContractAdmin

    Argument:
        adminOntID  ByteArray  admin's ONT ID

    Return: Bool
    ```

  This method should be called inside the application contract.

- Transfer contract management rights

    ```
    Method: transfer

    Argument:
        contractAddr    Address    the address of the target contract
        newAdminOntID   ByteArray  new Admin's ONT ID
        keyNo           Int        the index of admin's public key to invoke this api  

    Return: Bool
    ```

    This function must be called by the contract administrator, and the transaction signature is verified against the public key whose index equals `keyNo`.
    
### b. Verify the contract call

- Verify the validity of the contract call

    ```
    Method: verifyToken

    Argument: 
        contractAddr    Address    the address of the target contract
        callerOntID     ByteArray  the caller's ONT ID
        funcName        String     the name of the function invoked 
        keyNo           Int        the index of caller's public key to invoke this api  
    
    Return: Bool
    ```

	The auth token to invoke an function of smart contract consists of four parts, the contract address, the caller's ONT ID, the function name, and the index of public key that initiated the invocation.
    
### c. Contract permission allocation
- Assign a function to a role

    ```
    Method: assignFuncsToRole

    Argument: 
        contractAddr    Address        the address of the target contract
        adminOntID      ByteArray      admin's ONT ID
        role            ByteArray      the role 
        funcNames       StringArray    the name of the function invoked 
        keyNo           Int            the index of admin's public key to invoke this api  
    
    Return: Bool
    ```
	
    This function must be called by the contract administrator, and it will automatically bind all functions to the role. if it is already binded, the binding procedure will skip automatically, and return true finally.

- Bind a role to an entity 

    ```
    Method: assignOntIDsToRole

    Argument: 
        contractAddr    Address        the address of the target contract
        adminOntID      ByteArray      admin's ONT ID
        role            ByteArray      the role 
        ontIDs          Byte[][]       an array of ONT ID 
        keyNo           Int            the index of admin's public key to invoke this api  
    
    Return: Bool
    ```

	This function must be called by the contract administrator. The ONT ID in the ontIDs array is assigned the `role` and finally returns true.

    In the current implementation, the level of the permission token is equal to 2 by default.

### d. Contract permission delegation
- Delegate contract calling permission to others

    ```
    Method: delegate

    Argument: 
        contractAddr    Address        the address of the target contract
        from            ByteArray      ONT ID of role's owner
        to              ByteArray      ONT ID of delegator
        period          Int            the period this delegation will be valid
        level           Int            the level the delegator will get
        keyNo           Int            the index of from's public key to invoke this api 

    Return: Bool    
    ```
    
    The role owner can delegate the role to others. `from` is the ONT ID of the transferor, `to` is the ONT ID of the delegator, `role` is the role of delegator, and the `period` parameter specifies the duration of the delegation. (use second as the unit).
   
    The delegator can delegate his role to other people too, and the parameter `level` specifies the depth of the delegation level. E.g,
    - level = 1: The delegator cannot delegate his role to others; the current implementation only supports this situation.

- Withdraw the calling permission back
    ```
    Method: withdraw

    Argument: 
        contractAddr    Address        the address of the target contract
        initiator       ByteArray      ONT ID of initiator's owner
        delegate        ByteArray      ONT ID of delegator
        role            ByteArray      the role withdrawn
        keyNo           Int            the index of initiator's public key to invoke this api 

    ```
     The role owner can withdraw the role delegation in advance. `initiator` is the initiator, `delegate` is the role delegator, and the initiator can withdraw the role from the delegator in advance.

## Workflow

1. At initialization, the contract can set up the administrator by calling the `initContractAdmin` method;
2. The contract administrator assigns roles and binds functions that each role can call;
3. The contract administrator assigns roles to OntID;
4. Before the specific function of the contract is executed, you can first verify whether the contract caller has the permission to call, that is, verify whether the caller provides the token; After the verification passes, you can execute the specific function.

## Contract Example

```CSharp
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace Example
{
    public struct initContractAdminParam
    {
        public byte[] adminOntID;
    }

    public struct verifyTokenParam
    {
        public byte[] contractAddr;
        public byte[] caller;
        public string fn;
        public int keyNo;
    }

    public class AppContract : SmartContract
    {
        //the admin ONT ID of this contract must be hardcoded.
        public static readonly byte[] adminOntID = { 
                0x64, 0x69, 0x64, 0x3a, 0x6f, 0x6e, 0x74, 0x3a, 
                0x41, 0x47, 0x68, 0x76, 0x33, 0x6f, 0x63, 0x69, 
                0x59, 0x64, 0x6d, 0x57, 0x66, 0x62, 0x65, 0x33, 
                0x72, 0x77, 0x67, 0x35, 0x41, 0x76, 0x43, 0x57,
                0x4b, 0x37, 0x33, 0x72, 0x65, 0x39, 0x41, 0x57,
                0x56, 0x39 };
        public static readonly byte[] authContractAddr = {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x06 };

        public static Object Main(string operation, object[] token, object[] args)
        {
            if (operation == "init") return init();
            
            
            if (operation == "foo")
            {
                //we need to check if the caller is authorized to invoke foo
                if (!verifyToken(operation, token)) return false;

                return foo(args);
            }

            return false; 
        }

        public static bool foo(object[] args)
        {
            return true;
        }
        
        //this method is a must-defined method if you want to use native auth contract. 
        public static bool init()
        {
            object[] _args = new object[1]; 
            _args[0] = new initContractAdminParam { adminOntID = adminOntID };

            byte[] ret = Native.Invoke(0, authContractAddr, "initContractAdmin", _args);
            return ret[0] == 1;
        }

        internal static bool verifyToken(string operation, object[] token)
        {
            object[] _args = new object[1];
            verifyTokenParam param = new verifyTokenParam{}; 
            param.contractAddr = ExecutionEngine.ExecutingScriptHash;
            param.fn = operation;
            param.caller = (byte[])token[0];
            param.keyNo = (int)token[1];
            _args[0] = param;
            
            byte[] ret = Native.Invoke(0, authContractAddr, "verifyToken", _args);
            return ret[0] == 1;
        }
    }
}
```