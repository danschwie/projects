//~----------------------------------------------------------------------------
// File:    MapReduceMaster.cs
// Author:  Stephan Brenner (http://www.stephan-brenner.com/)
// Created: 01/21/2007
//----------------------------------------------------------------------------~

using System.Collections.Generic;

namespace Brenner.MapReduce.Core
{
  public class MapReduceMaster<K1, V1, K2, V2>
  {
    private MapFunction mapFunction;
    private ReduceFunction reduceFunction;

    public delegate void MapFunction(K1 key, V1 value, IList<KeyValuePair<K2, V2>> result);
    public delegate void ReduceFunction(K2 key, IList<V2> values, IList<V2> result);

    public MapReduceMaster (MapFunction mapFunction, ReduceFunction reduceFunction)
	  {
      this.mapFunction = mapFunction;
      this.reduceFunction = reduceFunction;
	  }

    public IDictionary<K2, IList<V2>> Execute(IDictionary<K1, V1> input)
    {
      Dictionary<K2, List<V2>> intermediateResult = new Dictionary<K2, List<V2>>();
      foreach (KeyValuePair<K1, V1> inputPair in input)
      {
        List<KeyValuePair<K2, V2>> mapResult = new List<KeyValuePair<K2, V2>>();
        mapFunction(inputPair.Key, inputPair.Value, mapResult);
        ProcessMapResult(intermediateResult, mapResult);        
      }

      Dictionary<K2, IList<V2>> result = new Dictionary<K2, IList<V2>>();
      foreach (KeyValuePair<K2, List<V2>> intermediatePair in intermediateResult)
      {
        List<V2> reduceResult = new List<V2>();
        reduceFunction(intermediatePair.Key, intermediatePair.Value, reduceResult);
        ProcessReduceResult(result, intermediatePair.Key, reduceResult);
      }
      return result;
    }

    private void ProcessReduceResult(Dictionary<K2, IList<V2>> result, K2 key, IList<V2> reduceResult)
    {
      foreach (V2 value in reduceResult)
      {
        if (!result.ContainsKey(key))
        {
          result[key] = new List<V2>();
        }
        result[key].Add(value);
      }
    }

    private void ProcessMapResult(Dictionary<K2, List<V2>> intermediate, IList<KeyValuePair<K2, V2>> mapResult)
    {
      foreach (KeyValuePair<K2, V2> pair in mapResult)
      {
        if (!intermediate.ContainsKey(pair.Key))
        {
          intermediate[pair.Key] = new List<V2>();
        }
        intermediate[pair.Key].Add(pair.Value);
      }
    }
  }
}