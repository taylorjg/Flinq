``` C#
public static IEnumerable<B> Map<A, B>(
        this IEnumerable<A> source,
        Func<A, B> f
)
```
Builds a new collection by applying a function to all elements of this list (same as Select).
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
<dt><i>B</i></dt>
<dd>The element type of the returned collection.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>f</i></dt>
<dd>Type: <code>System.Func&lt;A, B&gt;</code><br />The function to apply to each element.</dd>
</dl>
###### Return Value
The output sequence.

---

``` C#
public static IEnumerable<B> FlatMap<A, B>(
        this IEnumerable<A> source,
        Func<A, System.Collections.Generic.IEnumerable`1[B]> f
)
```
Builds a new collection by applying a function to all elements of this list and using the elements of the resulting collections (same as SelectMany).
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
<dt><i>B</i></dt>
<dd>The element type of the returned collection.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>f</i></dt>
<dd>Type: <code>System.Func&lt;A, System.Collections.Generic.IEnumerable`1[B]&gt;</code><br />The function to apply to each element.</dd>
</dl>
###### Return Value
The output sequence.

---

``` C#
public static B FoldLeft<A, B>(
        this IEnumerable<A> source,
        B z,
        Func<B, A, B> op
)
```
Applies a binary operator to a start value and all elements of this list, going left to right.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
<dt><i>B</i></dt>
<dd>The type of the elements in the output sequence and the result type of the binary operator.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>z</i></dt>
<dd>Type: <code></code><br />The start value.</dd>
<dt><i>op</i></dt>
<dd>Type: <code>System.Func&lt;B, A, B&gt;</code><br />The binary operator.</dd>
</dl>
###### Return Value
The result of inserting op between consecutive elements of this list, going left to right with the start value z on the left.

---

``` C#
public static B FoldRight<A, B>(
        this IEnumerable<A> source,
        B z,
        Func<A, B, B> op
)
```
Applies a binary operator to all elements of this list and a start value, going right to left.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
<dt><i>B</i></dt>
<dd>The type of the elements in the output sequence and the result type of the binary operator.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>z</i></dt>
<dd>Type: <code></code><br />The start value.</dd>
<dt><i>op</i></dt>
<dd>Type: <code>System.Func&lt;A, B, B&gt;</code><br />The binary operator.</dd>
</dl>
###### Return Value
The result of inserting op between consecutive elements of this list, going right to left with the start value z on the right.

---

``` C#
public static void ForEach<A>(
        this IEnumerable<A> source,
        Action<A> f
)
```
Applies a function f to all elements of this list.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>f</i></dt>
<dd>Type: <code>System.Action&lt;A&gt;</code><br />The function that is applied for its side-effect to every element.</dd>
</dl>

---

``` C#
public static void ForEach<A>(
        this IEnumerable<A> source,
        Action<A, System.Int32> f
)
```
Applies a function f to all elements of this list.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>f</i></dt>
<dd>Type: <code>System.Action&lt;A, System.Int32&gt;</code><br />The function that is applied for its side-effect to every element.</dd>
</dl>

---

``` C#
public static void ForEach<A>(
        this IEnumerable<A> source,
        Action<A, System.Int64> f
)
```
Applies a function f to all elements of this list.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>f</i></dt>
<dd>Type: <code>System.Action&lt;A, System.Int64&gt;</code><br />The function that is applied for its side-effect to every element.</dd>
</dl>

---

``` C#
public static IEnumerable<System.Int32> Indices<A>(
        this IEnumerable<A> source
)
```
Produces the range of all indices (int) of this sequence.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
</dl>
###### Return Value
A range of values from 0 to one less than the length of this list.

---

``` C#
public static IEnumerable<System.Int64> IndicesLong<A>(
        this IEnumerable<A> source
)
```
Produces the range of all indices (long) of this sequence.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
</dl>
###### Return Value
A range of values from 0 to one less than the length of this list.

---

``` C#
public static B ReduceLeft<A, B>(
        this IEnumerable<A> source,
        Func<B, A, B> op
)
```
Applies a binary operator to all elements of this sequence, going left to right.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
<dt><i>B</i></dt>
<dd>The type of the elements in the output sequence and the result type of the binary operator.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>op</i></dt>
<dd>Type: <code>System.Func&lt;B, A, B&gt;</code><br />The binary operator.</dd>
</dl>
###### Return Value
The result of inserting op between consecutive elements of this sequence, going left to right.
###### Exceptions
Type: <code>System.InvalidOperationException</code><br />Thrown when the input sequence is empty.

---

``` C#
public static B ReduceRight<A, B>(
        this IEnumerable<A> source,
        Func<A, B, B> op
)
```
Applies a binary operator to all elements of this sequence, going right to left.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
<dt><i>B</i></dt>
<dd>The type of the elements in the output sequence and the result type of the binary operator.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>op</i></dt>
<dd>Type: <code>System.Func&lt;A, B, B&gt;</code><br />The binary operator.</dd>
</dl>
###### Return Value
The result of inserting op between consecutive elements of this sequence, going right to left.
###### Exceptions
Type: <code>System.InvalidOperationException</code><br />Thrown when the input sequence is empty.

---

``` C#
public static IEnumerable<A> Slice<A>(
        this IEnumerable<A> source,
        int from,
        int until
)
```
Selects an interval of elements.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence of elements.</dd>
<dt><i>from</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of the first element in the slice.</dd>
<dt><i>until</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of one beyond the last element in the slice.</dd>
</dl>
###### Return Value
The output sequence.

---

``` C#
public static IEnumerable<A> Patch<A>(
        this IEnumerable<A> source,
        int from,
        IEnumerable<A> patch,
        int replaced
)
```
Produces a new sequence where a slice of elements in this sequence is replaced by another sequence.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The original sequence of elements.</dd>
<dt><i>from</i></dt>
<dd>Type: <code>System.Int32</code><br />The index of the first replaced element.</dd>
<dt><i>patch</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence of elements to replace a slice in the original sequence.</dd>
<dt><i>replaced</i></dt>
<dd>Type: <code>System.Int32</code><br />The number of elements to drop in the original sequence.</dd>
</dl>
###### Return Value
The output sequence.

---

``` C#
public static bool IsEmpty<A>(
        this IEnumerable<A> source
)
```
Tests whether this sequence is empty.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence of elements.</dd>
</dl>
###### Return Value
<code>true</code> if the sequence contain no elements, <code>false</code> otherwise.

---

``` C#
public static string MkString<A>(
        this IEnumerable<A> source
)
```
Displays all elements of this sequence in a string.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence of elements to display.</dd>
</dl>
###### Return Value
A string representation of this sequence. In the resulting string the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence follow each other without any separator string.

---

``` C#
public static string MkString<A>(
        this IEnumerable<A> source,
        string sep
)
```
Displays all elements of this sequence in a string using a separator string.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence of elements to display.</dd>
<dt><i>sep</i></dt>
<dd>Type: <code>System.String</code><br />The separator string.</dd>
</dl>
###### Return Value
A string representation of this sequence. In the resulting string the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence are separated by the string *sep*.

---

``` C#
public static string MkString<A>(
        this IEnumerable<A> source,
        string start,
        string sep,
        string end
)
```
Displays all elements of this sequence in a string using start, end, and separator strings.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements of source.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence of elements to display.</dd>
<dt><i>start</i></dt>
<dd>Type: <code>System.String</code><br />The starting string.</dd>
<dt><i>sep</i></dt>
<dd>Type: <code>System.String</code><br />The separator string.</dd>
<dt><i>end</i></dt>
<dd>Type: <code>System.String</code><br />The ending string.</dd>
</dl>
###### Return Value
A string representation of this sequence. The resulting string begins with the string *start* and ends with the string *end*. Inside, the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence are separated by the string *sep*.

---

``` C#
public static bool StartsWith<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that
)
```
Tests whether this list starts with the given sequence.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
</dl>
###### Return Value
<code>true</code> if this collection has *that* as a prefix, <code>false</code> otherwise.

---

``` C#
public static bool StartsWith<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that,
        IEqualityComparer<A> comparer
)
```
Tests whether this list starts with the given sequence.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
<dt><i>comparer</i></dt>
<dd>Type: <code>System.Collections.Generic.IEqualityComparer&lt;A&gt;</code><br />An IEqualityComparer<A> to use to compare elements.</dd>
</dl>
###### Return Value
<code>true</code> if this collection has *that* as a prefix, <code>false</code> otherwise.

---

``` C#
public static bool EndsWith<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that
)
```
Tests whether this list ends with the given sequence.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
</dl>
###### Return Value
<code>true</code> if this collection has *that* as a suffix, <code>false</code> otherwise.

---

``` C#
public static bool EndsWith<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that,
        IEqualityComparer<A> comparer
)
```
Tests whether this list ends with the given sequence.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
<dt><i>comparer</i></dt>
<dd>Type: <code>System.Collections.Generic.IEqualityComparer&lt;A&gt;</code><br />An IEqualityComparer<A> to use to compare elements.</dd>
</dl>
###### Return Value
<code>true</code> if this collection has *that* as a suffix, <code>false</code> otherwise.

---

``` C#
public static bool ContainsSlice<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that
)
```
Tests whether this list contains a given sequence as a slice.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
</dl>
###### Return Value
<code>true</code> if this list contains a slice with the same elements as *that*, otherwise <code>false</code>.

---

``` C#
public static bool ContainsSlice<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that,
        IEqualityComparer<A> comparer
)
```
Tests whether this list contains a given sequence as a slice.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
<dt><i>comparer</i></dt>
<dd>Type: <code>System.Collections.Generic.IEqualityComparer&lt;A&gt;</code><br />An IEqualityComparer<A> to use to compare elements.</dd>
</dl>
###### Return Value
<code>true</code> if this list contains a slice with the same elements as *that*, otherwise <code>false</code>.

---

``` C#
public static int IndexOfSlice<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that
)
```
Finds first index where this list contains a given sequence as a slice.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
</dl>
###### Return Value
The first index such that the elements of this list starting at this index match the elements of sequence *that*, or -1 of no such subsequence exists.

---

``` C#
public static int IndexOfSlice<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that,
        IEqualityComparer<A> comparer
)
```
Finds first index where this list contains a given sequence as a slice.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
<dt><i>comparer</i></dt>
<dd>Type: <code>System.Collections.Generic.IEqualityComparer&lt;A&gt;</code><br />An IEqualityComparer<A> to use to compare elements.</dd>
</dl>
###### Return Value
The first index such that the elements of this list starting at this index match the elements of sequence *that*, or -1 of no such subsequence exists.

---

``` C#
public static int IndexOfSlice<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that,
        int from
)
```
Finds first index where this list contains a given sequence as a slice.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
<dt><i>comparer</i></dt>
<dd>Type: <code>System.Int32</code><br />An IEqualityComparer<A> to use to compare elements.</dd>
</dl>
###### Return Value
The first index such that the elements of this list starting at this index match the elements of sequence *that*, or -1 of no such subsequence exists.

---

``` C#
public static int IndexOfSlice<A>(
        this IEnumerable<A> source,
        IEnumerable<A> that,
        int from,
        IEqualityComparer<A> comparer
)
```
Finds first index after or at a start index where this list contains a given sequence as a slice.
###### Type Parameters
<dl>
<dt><i>A</i></dt>
<dd>The type of the elements in the input sequence.</dd>
</dl>
###### Parameters
<dl>
<dt><i>source</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The input sequence.</dd>
<dt><i>that</i></dt>
<dd>Type: <code>System.Collections.Generic.IEnumerable&lt;A&gt;</code><br />The sequence to test.</dd>
<dt><i>from</i></dt>
<dd>Type: <code>System.Int32</code><br />The start index.</dd>
<dt><i>comparer</i></dt>
<dd>Type: <code>System.Collections.Generic.IEqualityComparer&lt;A&gt;</code><br />An IEqualityComparer<A> to use to compare elements.</dd>
</dl>
###### Return Value
The first index >= *from* such that the elements of this list starting at this index match the elements of sequence *that*, or -1 of no such subsequence exists.
