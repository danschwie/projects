using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace MapReduce
{
    public class Master<K1, V1, K2, V2, V3>
    {
        #region - Public Delegates -

        public delegate IEnumerable<KeyValuePair<K2, V2>> MapFunction(K1 key, V1 value);
        public delegate IEnumerable<V3> ReduceFunction(K2 key, IEnumerable<V2> values); 

        #endregion

        #region - Member/Instance Variables -

        private MapFunction _map;
        private ReduceFunction _reduce; 

        #endregion

        #region - Constructor -

        public Master(MapFunction mapFunction, ReduceFunction reduceFunction)
        {
            _map = mapFunction;
            _reduce = reduceFunction;
        }

        #endregion

        public Dictionary<string, IEnumerable<KeyValuePair<K2, V3>>> Execute(IEnumerable<KeyValuePair<K1, V1>> input)
        {
            return Reduce(Map(input));
        }

        #region - Private Methods -

        /// <summary>
        /// High-order function applies a caller-defined map function to an input list and returns a list containing the results.
        /// </summary>
        /// <param name="input">List of key/value pairs representing the input to the map function.</param>
        /// <returns>A list of key/value pairs representing the result of calling the map function on each item in the input list.</returns>
        private Dictionary<string, IEnumerable<KeyValuePair<K2, V2>>> Map(IEnumerable<KeyValuePair<K1, V1>> input)
        {
            Dictionary<string, IEnumerable<KeyValuePair<K2, V2>>> mapResults = new Dictionary<string, IEnumerable<KeyValuePair<K2, V2>>>();


            foreach (KeyValuePair<K1, V1> pair in input)
            {
                // Apply caller-defined map function to each key/value pair in the input list and return a new list containing the function output.
                // In a real-world implementation where 'input' is extremely large, Map could break the input up into smaller problems and distribute
                // them to a cluster of worker computers where they could be computed in parallel. Each worker computer would receive a portion of the input,
                // a copy of the function to run on the input, and a key that is assigned to the input in its entirety which is used to recombine results
                // from worker nodes. The recombined results are then passed to Master.Reduce.
                IEnumerable<KeyValuePair<K2, V2>> mappedValues =
                    from mapped in _map(pair.Key, pair.Value)
                    select mapped;

                mapResults.Add(pair.Key.ToString(), mappedValues);
            }

            return mapResults;
        }

        /// <summary>
        /// High-order function applies a caller-defined reduce function to an input list and returns a list containing the results.
        /// </summary>
        /// <param name="intermediateValues">List of intermediate values from the map function representing the input to the reduce function.</param>
        /// <returns>A list of key/value pairs representing the result of calling the reduce function on each item in the input list.</returns>
        private Dictionary<string, IEnumerable<KeyValuePair<K2, V3>>> Reduce(Dictionary<string, IEnumerable<KeyValuePair<K2, V2>>> intermediateValuesList)
        {
            Dictionary<string, IEnumerable<KeyValuePair<K2, V3>>> reduceResults = new Dictionary<string, IEnumerable<KeyValuePair<K2, V3>>>();

            foreach (KeyValuePair<string, IEnumerable<KeyValuePair<K2, V2>>> intermediateValues in intermediateValuesList)
            {
                // Group the key/value pair items in the intermediateValues list on the key and select the grouped values into a new list. As with the Map step,
                // the intermediate values passed to Reduce can be broken into smaller problems and computed in parallel before being recombined according
                // to a unique key that identifies the document that is being processed.
                var groups =
                    from kvp in intermediateValues.Value
                    group kvp.Value by kvp.Key into g
                    select g;

                // Apply caller-defined reduce function to the grouped list.
                reduceResults.Add(intermediateValues.Key.ToString(),
                    from g in groups
                    from reducedValue in _reduce(g.Key, g)
                    select new KeyValuePair<K2, V3>(g.Key, reducedValue));
            }

            return reduceResults;
        } 

        #endregion
    }
}