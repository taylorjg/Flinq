``` C#
public static TResult ReduceLeft&lt;TSource, TResult&gt;(
        this IEnumerable&lt;TSource&gt; source,
        Func&lt;TResult, TSource, TResult&gt; op
)
```
Applies a binary operator to all elements of this sequence, going left to right.
###### Type Parameters
<dl>
<dt><i>TSource</i></dt>
<dd>The type of the elements in the input sequence.</dd>
<dt><i>TResult</i></dt>
<dd>The type of the elements in the output sequence and the result type of the binary operator.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The input sequence.</dd>
<dt><i>op</i></dt>
<dd>Type: <code>System.Func&lt;TResult, TSource, TResult&gt;</code><br />The binary operator.</dd>
</dl>
###### Return Value
The result of inserting op between consecutive elements of this sequence, going left to right.
###### Exceptions
Type: <code>System.InvalidOperationException</code><br />
Thrown when the input sequence is empty.
---
``` C#
public static TResult ReduceRight&lt;TSource, TResult&gt;(
        this IEnumerable&lt;TSource&gt; source,
        Func&lt;TSource, TResult, TResult&gt; op
)
```
Applies a binary operator to all elements of this sequence, going right to left.
###### Type Parameters
<dl>
<dt><i>TSource</i></dt>
<dd>The type of the elements in the input sequence.</dd>
<dt><i>TResult</i></dt>
<dd>The type of the elements in the output sequence and the result type of the binary operator.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The input sequence.</dd>
<dt><i>op</i></dt>
<dd>Type: <code>System.Func&lt;TSource, TResult, TResult&gt;</code><br />The binary operator.</dd>
</dl>
###### Return Value
The result of inserting op between consecutive elements of this sequence, going right to left.
###### Exceptions
Type: <code>System.InvalidOperationException</code><br />
Thrown when the input sequence is empty.
---
``` C#
public static IEnumerable&lt;TSource&gt; Slice&lt;TSource&gt;(
        this IEnumerable&lt;TSource&gt; source,
        Int32 from,
        Int32 until
)
```
Selects an interval of elements.
###### Type Parameters
<dl>
<dt><i>TSource</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The sequence of elements.</dd>
<dt><i>from</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of the first element in the slice.</dd>
<dt><i>until</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of one beyond the last element in the slice.</dd>
</dl>
###### Return Value

---
``` C#
public static IEnumerable&lt;TSource&gt; Patch&lt;TSource&gt;(
        this IEnumerable&lt;TSource&gt; source,
        Int32 from,
        IEnumerable&lt;TSource&gt; patch,
        Int32 replaced
)
```
Produces a new sequence where a slice of elements in this sequence is replaced by another sequence.
###### Type Parameters
<dl>
<dt><i>TSource</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The original sequence of elements.</dd>
<dt><i>from</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of the first replaced element.</dd>
<dt><i>patch</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The sequence of elements to replace a slice in the original sequence.</dd>
<dt><i>replaced</i></dt>
<dd>Type: <code>System.Int32</code><br />The number of elements to drop in the original sequence.</dd>
</dl>
###### Return Value

---
``` C#
public static Boolean IsEmpty&lt;TSource&gt;(
        this IEnumerable&lt;TSource&gt; source
)
```
Tests whether this sequence is empty.
###### Type Parameters
<dl>
<dt><i>TSource</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The sequence of elements.</dd>
</dl>
###### Return Value
true if the sequence contain no elements, false otherwise.
---
``` C#
public static String MkString&lt;TSource&gt;(
        this IEnumerable&lt;TSource&gt; source
)
```
Displays all elements of this sequence in a string.
###### Type Parameters
<dl>
<dt><i>TSource</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The sequence of elements to display.</dd>
</dl>
###### Return Value
A string representation of this sequence. In the resulting string the string representations (w.r.t. the method ToString) of all elements of this sequence follow each other without any separator string.
---
``` C#
public static String MkString&lt;TSource&gt;(
        this IEnumerable&lt;TSource&gt; source,
        String sep
)
```
Displays all elements of this sequence in a string using a separator string.
###### Type Parameters
<dl>
<dt><i>TSource</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The sequence of elements to display.</dd>
<dt><i>sep</i></dt>
<dd>Type: <code>System.String</code><br />The separator string.</dd>
</dl>
###### Return Value
A string representation of this sequence. In the resulting string the string representations (w.r.t. the method ToString) of all elements of this sequence are separated by the string sep.
---
``` C#
public static String MkString&lt;TSource&gt;(
        this IEnumerable&lt;TSource&gt; source,
        String start,
        String sep,
        String end
)
```
Displays all elements of this sequence in a string using start, end, and separator strings.
###### Type Parameters
<dl>
<dt><i>TSource</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;TSource&gt;</code><br />The sequence of elements to display.</dd>
<dt><i>start</i></dt>
<dd>Type: <code>System.String</code><br />The starting string.</dd>
<dt><i>sep</i></dt>
<dd>Type: <code>System.String</code><br />The separator string.</dd>
<dt><i>end</i></dt>
<dd>Type: <code>System.String</code><br />The ending string.</dd>
</dl>
###### Return Value
A string representation of this sequence. The resulting string begins with the string start and ends with the string end. Inside, the string representations (w.r.t. the method ToString) of all elements of this sequence are separated by the string sep.
