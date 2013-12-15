

``` C#
public static TResult ReduceLeft<TSource, TResult>(
	this IEnumerable<TSource> source,
	Func<TResult, TSource, TResult> op
) where TSource : TResult
```

###### Type Parameters

<dl>

<dt><i>TSource</i></dt>
<dd>
The type of the elements in the input sequence.
</dd>

<dt><i>TResult</i></dt>
<dd>
The type of the elements in the output sequence and the result type of the binary operator.
</dd>
</dl>

###### Parameters

<dl>

<dt><i>source</i></dt>
<dd>
Type: <code>IEnumerable&lt;TSource&gt;</code><br />
The input sequence.
</dd>

<dt><i>op</i></dt>
<dd>
Type: <code>Func&lt;TResult, TSource, TResult&gt;</code>
The binary operator.
</dd>
</dl>

###### Return Value

The result of inserting op between consecutive elements of this sequence, going left to right.

##### Exceptions

Type: <code>InvalidOperationException</code><br />
Thrown when the input sequence is empty.

