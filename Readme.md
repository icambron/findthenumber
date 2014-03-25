The Impossible Problem
======================

From [http://en.wikipedia.org/wiki/Impossible_Puzzle](http://en.wikipedia.org/wiki/Impossible_Puzzle):

X and Y are two different integers, greater than 1, with sum less than 100. S and P are two mathematicians; S knows the sum X+Y, P knows the product X*Y, and both know the information in these two sentences. The following conversation occurs.

* P says "I cannot find these numbers."
* S says "I was sure that you could not find them. I cannot find them either."
* P says "Then, I found these numbers."
* S says "If you could find them, then I also found them."

What are these numbers?

To run in Mono 2.0 or above:

```sh
dmcs FindTheNumber.cs
mono FindTheNumber.exe
```

Or in .NET 4.0 or above:

```sh
csc /out:FindTheNumber.exe FindTheNumber.cs
FindTheNumber.exe
```
