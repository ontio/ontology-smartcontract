### ONG Native合约API


| API                                                          | 返回值 | 说明                                          |
| ------------------------------------------------------------ | ------ | --------------------------------------------- |
| symbol()                                                     | string | Token符号：ONG                            |
| decimals()                                                   | BigInteger    | ONT精度，默认是9                             |
| name()                                                       | string | ONG全称：ONG Token                          |
| totalSupply()                                                | BigInteger    | ONG总发行量                           |
| balanceOf(byte[] address)                                     | BigInteger    | 查询账户ONG余额                                |
| transfer(byte[] from,  byte[]to, uint64 amount)                | Bool   | Sender 从from账户转移amount个ONG到to账户 |
| approve(byte[] from, byte[] to,  uint64 amount)                | Bool   | 从from账号授权amount个ONG到to账号，授权amount并不会直接出现在to账号下，需要通用transferFrom提取，多次授权会覆盖前值. |
| transferFrom(byte[] sender, byte[] from, byte[] to, uint64 amount) | Bool   | Sender从from账户到to账户     |
| allowance(byte[] from, byte[] to) | BigInteger | 查询from账户授权给to账户ONG额度 |
