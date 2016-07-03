"# JsonNet.NullValueResolver" 

### 在做APP后台接口开发时，经常遇到以下问题:
> 1 字段为NULL的值，在序列化时，直接序列化为NULL值
>
> 2 对象、对象数组为NULL时
>

这些问题都容易引起APP端的崩溃 

### 理想的处理是：
> 1. 字符串为NULL时，返回：""
>
> 2. 对象为NULL时，返回：{}
>
> 3. 对象数组为NULL时，返回：[]
>
JsonNet.NullValueResolver就是为解决这些问题而来。

