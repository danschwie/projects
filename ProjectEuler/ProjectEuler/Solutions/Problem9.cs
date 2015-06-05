using System;
using System.Collections.Generic;
using System.Text;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
  /// <summary>
  /// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, a^(2) + b^(2) = c^(2)
  /// For example, 3^(2) + 4^(2) = 9 + 16 = 25 = 5^(2).
  /// There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.
  /// </summary>
  public class Problem9
  {
    public Triplet Solve()
    {
      List<Triplet> triplets = new List<Triplet>();

      for (int i = 1; i < 998; i++)
      {
        for (int j = 1; j < 998; j++)
        {
          for (int k = 1; k < 998; k++)
          {
            if (i + j + k == 1000)
            {
              triplets.Add(new Triplet() { A = i, B = j, C = k });
            }
          }
        }
      }

      foreach (Triplet t in triplets)
      {
        if ((t.A * t.A) + (t.B * t.B) == (t.C * t.C))
        {
          return t;
        }
        else
        {
          if ((t.A * t.A) + (t.C * t.C) == (t.B * t.B))
          {
            return t;
          }
          else
          {
            if ((t.B * t.B) + (t.C * t.C) == (t.A * t.A))
            {
              return t;
            }
          }
        }
      }

      return null;
    }
  }

  public class Triplet
  {
    public int A
    {
      get;
      set;
    }

    public int B
    {
      get;
      set;
    }

    public int C
    {
      get;
      set;
    }
  }
}
