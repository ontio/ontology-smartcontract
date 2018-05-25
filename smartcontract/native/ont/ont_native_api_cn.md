### ONT Native合约API


| API                                                          | 返回值 | 说明                                          |
| ------------------------------------------------------------ | ------ | --------------------------------------------- |
| symbol()                                                     | string | Token符号：ONT                             |
| decimals()                                                   | BigInteger    | ONT精度，默认是1                              |
| name()                                                       | string | ONT全称：ONT Token                            |
| totalSupply()                                                | BigInteger    | ONT总发行量                            |
| balanceOf(byte[] address)                                     | BigInteger    | 查询账户ONT余额                                 |
| transfer(byte[] from,  byte[]to, uint64 amount)                | Bool   | Sender 从from账户转移amount个 ONT到to账户 |
| approve(byte[] from, byte[] to,  uint64 amount)                | Bool   | 从from账号授权amount个ONT到to账号，授权amount并不会直接出现在to账号下，需要通用transferFrom提取，多次授权会覆盖前值. |
| transferFrom(byte[] sender, byte[] from, byte[] to, uint64 amount) | Bool   | Sender 从from账户到to账户     |
| allowance(byte[] from, byte[] to) | BigInteger | 查询from账户授权给to账户ONT额度 |
