``` C#
TResult ReduceLeft[TSource,TResult](System.Collections.Generic.IEnumerable`1[TSource], System.Func`3[TResult,TSource,TResult])
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
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The input sequence.</dd>
<dt><i>op</i></dt>
<dd>Type: <code>System.Func<TResult, TSource, TResult></code><br />The binary operator.</dd>
</dl>
###### Return Value
The result of inserting op between consecutive elements of this sequence, going left to right.
###### Exceptions
Type: <code>System.InvalidOperationException</code><br />
Thrown when the input sequence is empty.
---
``` C#
TResult ReduceRight[TSource,TResult](System.Collections.Generic.IEnumerable`1[TSource], System.Func`3[TSource,TResult,TResult])
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
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The input sequence.</dd>
<dt><i>op</i></dt>
<dd>Type: <code>System.Func<TSource, TResult, TResult></code><br />The binary operator.</dd>
</dl>
###### Return Value
The result of inserting op between consecutive elements of this sequence, going right to left.
###### Exceptions
Type: <code>System.InvalidOperationException</code><br />
Thrown when the input sequence is empty.
---
``` C#
System.Collections.Generic.IEnumerable`1[TSource] Slice[TSource](System.Collections.Generic.IEnumerable`1[TSource], Int32, Int32)
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
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The sequence of elements.</dd>
<dt><i>from</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of the first element in the slice.</dd>
<dt><i>until</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of one beyond the last element in the slice.</dd>
</dl>
###### Return Value

---
``` C#
System.Collections.Generic.IEnumerable`1[TSource] Patch[TSource](System.Collections.Generic.IEnumerable`1[TSource], Int32, System.Collections.Generic.IEnumerable`1[TSource], Int32)
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
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The original sequence of elements.</dd>
<dt><i>from</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of the first replaced element.</dd>
<dt><i>patch</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The sequence of elements to replace a slice in the original sequence.</dd>
<dt><i>replaced</i></dt>
<dd>Type: <code>System.Int32</code><br />The number of elements to drop in the original sequence.</dd>
</dl>
###### Return Value

---
``` C#
Boolean IsEmpty[TSource](System.Collections.Generic.IEnumerable`1[TSource])
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
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The sequence of elements.</dd>
</dl>
###### Return Value
true if the sequence contain no elements, false otherwise.
---
``` C#
System.String MkString[TSource](System.Collections.Generic.IEnumerable`1[TSource])
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
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The sequence of elements to display.</dd>
</dl>
###### Return Value
A string representation of this sequence. In the resulting string the string representations (w.r.t. the method ToString) of all elements of this sequence follow each other without any separator string.
---
``` C#
System.String MkString[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.String)
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
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The sequence of elements to display.</dd>
<dt><i>sep</i></dt>
<dd>Type: <code>System.String</code><br />The separator string.</dd>
</dl>
###### Return Value
A string representation of this sequence. In the resulting string the string representations (w.r.t. the method ToString) of all elements of this sequence are separated by the string sep.
---
``` C#
System.String MkString[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.String, System.String, System.String)
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
<dd>Type: <code>System.Collections.Generic.IEnumerable<TSource></code><br />The sequence of elements to display.</dd>
<dt><i>start</i></dt>
<dd>Type: <code>System.String</code><br />The starting string.</dd>
<dt><i>sep</i></dt>
<dd>Type: <code>System.String</code><br />The separator string.</dd>
<dt><i>end</i></dt>
<dd>Type: <code>System.String</code><br />The ending string.</dd>
</dl>
###### Return Value
A string representation of this sequence. The resulting string begins with the string start and ends with the string end. Inside, the string representations (w.r.t. the method ToString) of all elements of this sequence are separated by the string sep.
