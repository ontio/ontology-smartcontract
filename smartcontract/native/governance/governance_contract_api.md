# Governance Contract API
## Introduction
This document describes api of governance contract used in gntology network, users can join consensus selection through these apis, deposit ONT to vote for peers, quit selection. ONT deposited in the contract can get ONG bonus.
## API
### InitConfig
function: Initialize the governance contract, only can be invoked in the genesis block, system api。

```text
method: "initConfig"

arguments: nil

returns: bool， error
```
### RegisterCandidate
function: deposit some ONT, expend some extra ONG, apply for a candidate node.

```text
method: "registerCandidate"

arguments:
0       String       peer public key
1       Address      address
2       Uint32       num of deposit ONT
3       ByteArray    caller's OntID
4       Uint64       caller's pubkey index number

returns: bool， error
```
### UnRegisterCandidate
function: cancel apply for a candidate node, draw back deposit ONT.

```text
method: "unRegisterCandidate"

arguments:
0       String       peer public key
1       Address      address

returns: bool， error
```
### ApproveCandidate
function: review by administrator, become candidate node, only can be invoked by administrator.

```text
method: "approveCandidate"

arguments:
0       String       peer public key

returns: bool， error
```
### RejectCandidate
function: review by administrator, remove peer public key,draw back deposit, only can be invoked by administrator.

```text
method: "rejectCandidate"

arguments:
0       String       peer public key

returns: bool， error
```
### BlackNode
function: review by administrator, put a node into black list. Trigger node quit process at the same time but freeze the initPos.

```text
method: "blackNode"

arguments:
0       Array{String}       peer public key list

returns: bool， error
```
### WhiteNode
function: review by administrator, remove node from black list, and refund initPos.

```text
method: "whiteNode"

arguments:
0       String       peer public key

returns: bool， error
```
### QuitNode
function: node applies for quiting, trigger normal quit process, address must be the same as registerSyncNode.

```text
method: "quitNode"

arguments:
0       String       peer public key
1       Address      address

returns: bool， error
```
### VoteForPeer
function: vote for a node by deposit ONT.

```text
method: "voteForPeer"

arguments:
0       Address         address
1       Array{String}   list of peer to vote
2       Array{Uint32}   list of pos to vote

returns: bool， error
```
### UnVoteForPeer
function: uvvote for a node by redeem ONT

```text
method: "unVoteForPeer"

arguments:
0       Address         address
1       Array{String}   list of peer to redeem
2       Array{Uint32}   list of pos to redeem

returns: bool， error
```
### Withdraw
function: withdraw unfreezed ONT deposited.

```text
method: "withdraw"

arguments:
0       Address         address
1       Array{String}   list of peer to withdraw
2       Array{Uint32}   list of pos to withdraw

returns: bool， error
```
### CommitDpos
function: change consensus according to vote result, system invoke.

```text
method: "commitDpos"

arguments: nil

returns: bool， error
```
### UpdateConfig
function: update consensus config, only can be invoked by administrator.

```text
method: "updateConfig"

arguments: 
0       Uint32      network scale
1       Uint32      fault tolerant
2       Uint32      consensus peer num
3       Uint32      length of Dpos table
4       Uint32      block message max delay(ms)
5       Uint32      hash message max delay(ms)
6       Uint32      pee handshake timeout(s)
7       Uint32      consensus change period

returns: bool， error
```
### UpdateGlobalParam
function: update global params, only can be invoked by administrator.

```text
method: "updateGlobalParam"

arguments:
0       Uint32      ONG fee to apply for candidate
1       Uint32      min ONT deposit to apply for candidate
2       Uint32      max candidate and consensus num
3       Uint32      coefficient of max pos each node can recieve
4       Uint32      percentage of consensus bonus(0-100)
5       Uint32      percentage of candidate bonus(0-100)
6       Uint32      bonus coefficient
7       Uint32      penalty coefficient

returns: bool， error
```
### UpdateSplitCurve
function: update ONG split curve, only can be invoked by administrator.

```text
method: "updateSplitCurve"

arguments:
0       Array{Uint64}      Yi of splitCurve

returns: bool， error
```
### CallSplit
function: split ONG according to vote result of previous view, only can be invoked by administrator. 

```text
method: "callSplit"

arguments: nil

returns: bool， error
```
### TransferPenalty
function: transfer deposit ONT of black node to some address, only can be invoked by administrator.

```text
method: "transferPenalty"

arguments: 
0       String      peer pubkey
1       Address     address

returns: bool， error
```