
## Flinq

LINQ query operators inspired by Scala.

## The Name

A lame conflation of "functional programming" and "LINQ".

## Documentation

Documentation is available at the following GitHub Pages location: http://taylorjg.github.io/Flinq/. The documentation was generated from XML documentation comments using [Sandcastle Help File Builder](http://shfb.codeplex.com/ "Sandcastle Help File Builder").

## NuGet

Flinq is available as a NuGet package - see http://www.nuget.org/packages/Flinq/.

## Releases

The following sections indicate which methods are supported and in which release they were added.

### v1.0.1

* Map
* FlatMap
* FoldLeft
* FoldRight
* ForEach
* Indices
* ReduceLeft
* ReduceRight
* Slice
* Patch
* IsEmpty
* MkString

### v1.0.2

* StartsWith
* EndsWith
* Contains
* ContainsSlice
* IndexWhere
* LastIndexWhere
* IndexOf
* LastIndexOf
* IndexOfSlice
* LastIndexOfSlice
* SplitAt

## TODO

Improve the efficiency of the following methods:

* ContainsSlice
* IndexOfSlice
* LastIndexOfSlice

by implementing the [Knuth–Morris–Pratt algorithm](http://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm "Knuth–Morris–Pratt algorithm") as the Scala implementation does (see the kmpSearch method in https://github.com/scala/scala/blob/master/src/library/scala/collection/SeqLike.scala).
