### Global Params Native合约API

| API                      | 返回值 | 说明                                          |
| ------------------------ | ----- | --------------------------------------------- |
| transferAdmin(Address)   | bool | 原管理员转移管理员权限给新管理员，参数为新管理员地址 |
| acceptAdmin(Address)     | bool | 新管理员调用此方法接受管理员权限，参数为自己的地址 |
| setOperator(Address)     | bool | 管理员调用此方法，设置操作员，参数为操作员的地址 |
| setGlobalParam(Array)    | bool | 操作员设置全局参数，设置的全局参数不会生效；<br>函数参数为结构体数组，结构体结构为两个String类型的字段，分别对应设置的全局参数的名称和值|
| getGlobalParam(Array)    | Array| 查询全局参数；函数参数值是一个String类型的数组，每个元素是查询的全局参数的名称；<br>返回值是一个结构体数组，结构体结构为两个String类型的字段，分别对应设置的全局参数的名称和值 |
| createSnapshot()         | Bool | 操作员调用此方法，使设置的全局参数生效 |