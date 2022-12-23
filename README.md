# FixedDictionary

c# Dictionary实现如下：[dictionary.cs (microsoft.com)](https://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,d3599058f8d79be0)

它利用了一个如下存储结构：

```c#
private int[] buckets; //记录了该哈希值对应的(链表)首元素
private Entry[] entries; //真实的数据entry
```



寻路现在使用到了一个 `capacity` 大于10万个的字典，key是UInt32，value是Int16。想要优化它的内存占用，尝试把 `int[] buckets` 干掉，能节省 2/5的内存。