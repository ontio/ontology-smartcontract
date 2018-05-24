### ONG Native合约API

| API                                                          | 返回值 | 说明                                          |
| ------------------------------------------------------------ | ------ | --------------------------------------------- |
| symbol()                                                     | string | Token符号：ONG                 |
| decimals()                                                   | BigInteger    | ONG精度，默认是9                            |
| name()                                                       | string | ONG全称：ONG Token                          |
| totalSupply()                                                | BigInteger    | ONG总发行量                           |
| transfer(byte[] from,  byte[]to, uint64 amount)                | Bool   | 从from账户转移 amount 个ONG到to账户          |
| transferFrom(byte[] sender, byte[] from, byte[] to, uint64 amount) | Bool   | Sender 从from账户转移amount个 ONG到to账户 |
| approve(byte[] from, byte[] to,  uint64 amount)                | Bool   | Aprrove 从from账户转移 amount ONG到to账户操作 |
| balanceOf(byte[] address)                                     | BigInteger    | 账户ONG余额                                  |
| allowance(byte[] from, byte[] to) | BigInteger | 可以allowance 的ONG数量 |
