using System;
using System.Collections.Generic;
using System.Linq;
using Pair = System.Tuple<int, int>;

namespace FindTheNumber
{
  class FindTheNumber
  {
    static void Main()
    {
      //these functions are the rules. each takes in a pair and decides if it passes the rule or not
      //note that the rules depend on each other
      Func<Pair, bool> sumsOk = pair => pair.Item1 + pair.Item2 < 100;
      Func<Pair, bool> hasManyFactors = pair => GetFactors(pair).Where(sumsOk).Skip(1).Any();
      Func<Pair, bool> allSummandsQualify = pair => GetSummands(pair).All(hasManyFactors);
      Func<Pair, bool> hasOneFactor = pair => !GetFactors(pair).Where(allSummandsQualify).Skip(1).Any();
      Func<Pair, bool> hasOneSummand = pair => !GetSummands(pair).Where(hasOneFactor).Skip(1).Any();

      //this lazily produces the set of pairs
      var generator = TwoThrough(99)
        .SelectMany(x => TwoThrough(99)
                    .Where(y => x <= y)
                    .Select(y => Tuple.Create(x, y)));

      //this filters each pair through the set rules and ensures there's only one result
      var answer = new[] { sumsOk, hasManyFactors, allSummandsQualify, hasOneSummand, hasOneFactor }
        .Aggregate(generator, (current, filter) => current.Where(filter))
        .Single();

      Console.WriteLine("{0},{1}", answer.Item1, answer.Item2);
    }

    //lazy factors of the pair's product
    private static IEnumerable<Pair> GetFactors(Pair pair)
    {
      int product = pair.Item1 * pair.Item2;
      return TwoThrough((int)Math.Floor(Math.Sqrt(product)))
        .Where(factor => product % factor == 0)
        .Select(factor => Tuple.Create(factor, product / factor));
    }

    //lazy summands of this pair's sum
    private static IEnumerable<Pair> GetSummands(Pair pair)
    {
      int sum = pair.Item1 + pair.Item2;
      return TwoThrough(sum/2)
        .Select(summand => Tuple.Create(summand, sum - summand));
    }

    //lazily provides the numbers 2 through i
    private static IEnumerable<int> TwoThrough(int i)
    {
      return Enumerable.Range(2, i - 1);
    }
  }
}
