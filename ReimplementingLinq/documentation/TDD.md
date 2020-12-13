# Introduction 
Unit testing is not only about covering your code to make your cli scream - 'hey dude, you broke something', but also it serves as great documentation of your code.
If unit test passes a scenario with certain params, you can prove that the code works under those params.

## TDD
Test drive development is a methodology when writing code and tests process is reversed and you will start all development with a failig test.
Uncle Bob describes it this way:
- 1. You are not allowed to write any prod code unless you already made a failing unit test pass.
- 2. You are not allowed to write any more of unit test than it is sufficient to fail, and compilation failures are failures.
- 3. You are not allowed any more prod code than is sufficient to pass the one failig unit test.

Red-Green-Refactor!

## Linq reimpementation:

## Where
Source code:
public static IEnumerable<TSource> Where(
    this IEnumerable<TSource> source,
    Func<TSource, bool> predicate)

// Lets the predicate use the index withit the sequence as well as the value. The index always starts at 0, and increments by 1 each time regardless
// of previous result from the predicate.
public static IEnumerable<TSource> Where(
    this IEnumerable<TSource> source,
    Func<TSource, int, bool> predicate)

Behaviour:
 - You should not be able to modify the input sequence (source param).
 - The Where is deferred operator - until you go throw the IEnumerable, it won'tt start fetching items from the input sequence.
 - Despite deferred execution, Where will validate that the parameters are not null immediately.
 - It streams it result: it only ever needs to look at one result at a time, and will yield it without keeping a reference to it.
 This means you can apply it to an infinitely long sequence.
 - It will iterate over the input sequence exactly once each time you iterate over the output sequence.
 - Disposing of an iterator over the output sequence will dispose of the corresponding iterator over the input sequence.
 (In case you did not know, the foreach statement in C# uses a try/finally block to make sure the iterator is always disposed when loop finishes.)

 ## Select
public static IEnumerable<TResult> Select<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSouce, TResult> selector)

public static IEnumeralbe<TResult> Select<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, int, TResult> selector)

Behaviour:
 - The operator extrapolate one sequence to another: the 'selector' delegate is applied to each input to yield the output element.
 - You should not be able to modify the input sequence (source param).
 - The Where is deferred operator - until you go throw the IEnumerable, it won'tt start fetching items from the input sequence.
 - Despite deferred execution, Where will validate that the parameters are not null immediately.
 - It streams it result: it only ever needs to look at one result at a time, and will yield it without keeping a reference to it.
 This means you can apply it to an infinitely long sequence.
 - It will iterate over the input sequence exactly once each time you iterate over the output sequence.
 - Disposing of an iterator over the output sequence will dispose of the corresponding iterator over the input sequence.

## Conclusion
 - Linq to Object is based on extension methods, delegates and IEnumerable<T>.
 - Operator do not mutate the original source, but instead return a new sequence which will return the appropriate data.
 - Query expressions are based on compiler translations (no need additional implementation for query).
