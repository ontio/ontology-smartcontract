1、**每一本native合约创建一个自己的文件夹**

```
目录格式：native/合约名

//所有归属本合约的方法、结构体定义暂时存放在本合约目录下
```
2、**公用方法**
```
目录格式：native/utils/

// 通用方法可统一存放在utils中，如无特殊必要，请存放在自己合约目录中
```
3、**参数序列化反序列化方式**
```
统一采用底层的序列化反序列化方式实现
```
4、**合约的注册实现统一接口**

```
func(native *NativeService)
```
并在初始化时，将合约存放在全局的Contracts Map中。
```
初始化contract存放文件：init/init.go

func init() {
		ont.InitOnt()
}
//Contracts - 全局统一存放合约Map
//genesis.OntContractAddress - ONT合约地址，若需要存放在创世块中，则在创世块中编写好deploy和invoke方法。若不需在创世块中初始化，可直接通过交易形式创建。
//RegisterOntContract - 合约注册接口实现方法
```
5、**合约方法接口**

```
func(native *NativeService) ([]byte, error)

// native合约中的方法定义，统一实现该接口，返回值统一使用byte数组返回。
// 关于返回值
//1、整数类型 - 统一使用BigInteger并转化为byte数组返回。
//2、布尔类型 - true:BYTE_ONE = []byte{1}  false: BYTE_ZERO = []byte{0}
//3、字符串 - 转化为byte数组返回
//4、结构体 - 按底层序列化反序列化或JSON转化为byte数组返回
```

6、**合约方法的注册统一接口**
```
func RegisterOntContract(native *native.NativeService) {
	native.Register("init", OntInit)
	native.Register("transfer", OntTransfer)
	native.Register("approve", OntApprove)
	native.Register("transferFrom", OntTransferFrom)
	native.Register("name", OntName)
	native.Register("symbol", OntSymbol)
	native.Register("decimals", OntDecimals)
	native.Register("totalSupply", OntTotalSupply)
	native.Register("balanceOf", OntBalanceOf)
}

//Register - 统一使用Register方法将native合约的方法注册
//命名规范 - 方法名统一使用小写字母开头，并使用驼峰式命名规则
//方法 - 统一实现合约方法接口
```
7、**native合约调用 - 
统一使用AppCall方法**
```
native.ContextRef.AppCall(genesis.OngContractAddress, "approve", []byte{}, args)

参数说明
// Arg1: 被调用合约的地址
// Arg2: 被调用合约的方法名
// Arg3: 调用的code，基本不会使用，直接使用空的byte数组
// Arg4: 被调用合约参数，根据每本native合约的内部的参数反序列化规则，提前做好序列化。
```
8、**native合约升级**

```
type Contract struct {
	Version byte
	Code    []byte
	Address common.Address
	Method  string
	Args    []byte
}
```

Contract结构体中定义version，默认初始化值为0。


```
type NativeService struct {
	CloneCache    *storage.CloneCache
	ServiceMap    map[string]Handler
	Notifications []*event.NotifyEventInfo
	Code          []byte
	Input         []byte
	Tx            *types.Transaction
	Height        uint32
	Time          uint32
	ContextRef    context.ContextRef
	Version       byte //对应版本号
}
```
在NativeService中定义有Version属性，该属性为当前Contract的版本号，若native合约需要升级可在实现方法中调用该属性编写不同的逻辑。

9、ABI基础类型

序列化反序列化基础类型支持
```
bool
byte
[]byte
string
address
uint256
array
int
struct
```

10、**native合约地址**

合约名称 | 合约地址
---|---
ONT Token | 0000000000000000000000000000000000000001
ONG Token | 0000000000000000000000000000000000000002
ONT ID | 0000000000000000000000000000000000000003
Global Params | 0000000000000000000000000000000000000004
Oracle | 0000000000000000000000000000000000000005
Authorization Manager(Auth) | 0000000000000000000000000000000000000006
Governance | 0000000000000000000000000000000000000007
DDXF(Decentralized Exchange) | 0000000000000000000000000000000000000008





