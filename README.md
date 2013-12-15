

``` C#
public static TResult ReduceLeft<TSource, TResult>(
	this IEnumerable<TSource> source,
	Func<TResult, TSource, TResult> op
) where TSource : TResult
```

###### Type Parameters

*TSource*

The type of the elements in the input sequence.

*TResult*

The type of the elements in the output sequence and the result type of the binary operator.

###### Parameters

<dl>
<dt><i>source</i></dt>
<dd>
Type: <code>IEnumerable&lt;TSource&gt;</code><br />
The input sequence.
</dd>
</dl>

<dl>
<dt>*source*</dt>
<dd>
Type: <code>IEnumerable&lt;TSource&gt;</code><br />
The input sequence.
</dd>
</dl>

*source*

Type: <code>IEnumerable<TSource></code>

The input sequence.

*source*

    Type: <code>IEnumerable<TSource></code>
    The input sequence.

*op*

Type: <code>Func&lt;TResult, TSource, TResult&gt;</code>

The binary operator.

###### Return Value

The result of inserting op between consecutive elements of this sequence, going left to right.

##### Exceptions

Type: <code>InvalidOperationException</code>

Thrown when the input sequence is empty.

