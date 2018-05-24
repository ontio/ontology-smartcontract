### ONT Native合约API


| API                                                          | 返回值 | 说明                                          |
| ------------------------------------------------------------ | ------ | --------------------------------------------- |
| symbol()                                                     | string | Token符号：ONT                             |
| decimals()                                                   | BigInteger    | ONT精度，默认是1                              |
| name()                                                       | string | ONT全称：ONT Token                            |
| totalSupply()                                                | BigInteger    | ONT总发行量                            |
| transfer(byte[] from,  byte[]to, uint64 amount)                | Bool   | Sender 从from账户转移amount个 ONT到to账户 |
| transferFrom(byte[] sender, byte[] from, byte[] to, uint64 amount) | Bool   | Sender 从from账户到to账户转移amount个 ONT     |
| approve(byte[] from, byte[] to,  uint64 amount)                | Bool   | Aprrove 从from账户转移 amount ONT到to账户操作 |
| balanceOf(byte[] address)                                     | BigInteger    | 账户ONT余额                                   |
| allowance(byte[] from, byte[] to) | BigInteger | 可以allowance 的ONT数量 |
