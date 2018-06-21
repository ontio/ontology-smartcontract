# 治理合约API
## 简介
本文档主要描述Ontology治理合约的API接口，用户通过该合约可以申请参与共识节点的竞选，抵押投票给参选节点，退出共识节点的竞选等，抵押的ONT会按照一定的规则产生收益。
## API
### InitConfig
功能：初始化治理合约，仅在在创世块创建时调用，系统方法。
```text
方法名："initConfig"

参数：无

返回值：bool， error
```
### RegisterCandidate
功能：抵押一定的ONT，消耗一定的额外ONG，申请成为候选节点。 
```text
方法名："registerCandidate"

参数：
0       String       节点公钥
1       Address      钱包地址
2       Uint32       抵押的ONT数量
3       ByteArray    调用者的OntID
4       Uint64       调用者公钥序号

返回值：bool， error
```
### UnRegisterCandidate
功能：取消申请成为候选节点，解冻抵押的ONT。 
```text
方法名："unRegisterCandidate"

参数：
0       String       节点公钥
1       Address      钱包地址

返回值：bool， error
```
### ApproveCandidate
功能：管理员审核通过，成为候选节点，只有管理员能够调用。

```text
方法名："approveCandidate"

参数：
0       String       节点公钥

返回值：bool， error
```
### RejectCandidate
功能：管理员审核不通过，移除节点，退还抵押，只有管理员能够调用。

```text
方法名："rejectCandidate"

参数：
0       String       节点公钥

返回值：bool， error
```
### BlackNode
功能：管理员审核，将节点放入黑名单，同时触发节点退出流程，不返还节点的InitPos。

```text
方法名："blackNode"

参数：
0       Array{String}   要放入黑名单的节点列表

返回值：bool， error
```
### WhiteNode
功能：管理员审核，将节点从黑名单中移除，节点的InitPos退还。

```text
方法名："whiteNode"

参数：
0       String       节点公钥

返回值：bool， error
```
### QuitNode
功能：节点申请退出，进入正常退出流程，钱包地址要与申请时相同。

```text
方法名："quitNode"

参数：
0       String       节点公钥
1       Address      钱包地址

返回值：bool， error
```
### VoteForPeer
功能：通过抵押ONT的方式向节点投票。

```text
方法名："voteForPeer"

参数：
0       Address         钱包地址
1       Array{String}   要投票的节点列表
2       Array{Uint32}   要给节点投的票数

返回值：bool， error
```
### UnVoteForPeer
功能：赎回抵押ONT的方式向节点取消投票。

```text
方法名："unVoteForPeer"

参数：
0       Address         钱包地址
1       Array{String}   要取消投票的节点列表
2       Array{Uint32}   要向节点取消的票数

返回值：bool， error
```
### Withdraw
功能：取出处于未冻结状态的抵押ONT。

```text
方法名："withdraw"

参数：
0       Address         钱包地址
1       Array{String}   要从哪些节点去吃抵押的列表
2       Array{Uint32}   要从节点取出抵押数

返回值：bool， error
```
### CommitDpos
功能：共识切换，按照当前投票结果切换共识，系统方法。

```text
方法名："commitDpos"

参数：无

返回值：bool， error
```
### UpdateConfig
功能：更新共识配置，只能由管理员调用。

```text
方法名："updateConfig"

参数：
0       Uint32      网络规模
1       Uint32      容错数目
2       Uint32      共识节点数
3       Uint32      Pos表长度
4       Uint32      区块消息最大广播延迟(ms)
5       Uint32      哈希消息最大广播延迟(ms)
6       Uint32      节点握手超时时间(s)
7       Uint32      共识周期

返回值：bool， error
```
### UpdateGlobalParam
功能：更新全局参数，只能由管理员调用。

```text
方法名："updateGlobalParam"

参数：
0       Uint32      节点申请参与共识选举的摩擦费
1       Uint32      节点申请参与共识选举的最小抵押
2       Uint32      共识和候选节点总数上限
3       Uint32      节点能接受的投票上限倍数
4       Uint32      共识节点激励比例(0-100)
5       Uint32      候选节点激励比例(0-100)
6       Uint32      激励系数
7       UInt32      惩罚系数

返回值：bool， error
```
### UpdateSplitCurve
功能：更新ONG分配曲线，只能由管理员调用。

```text
方法名："updateSplitCurve"

参数：
0       Array{Uint64}      分配曲线的Y轴散点值

返回值：bool， error
```
### CallSplit
功能：管理员调用，按照上一轮投票结果进行ONG分配。

```text
方法名："callSplit"

参数：无

返回值：bool， error
```
### TransferPenalty
功能：取出作恶节点的扣留抵押，只能由管理员调用。

```text
方法名："transferPenalty"

参数：
0       String      节点公钥
1       Address     钱包地址

返回值：bool， error
```