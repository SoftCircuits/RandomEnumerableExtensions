// Copyright (c) 2019-2020 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftCircuits.RandomEnumerableExtensions
{
    public static class RandomEnumerableExtensions
    {
        /// <summary>
        /// Returns a random element from this collection, or <c>default(T)</c> if this
        /// collection is null or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in this collection.</typeparam>
        /// <param name="rand">An instance of a random number generator. If this
        /// parameter is <c>null</c>, a random number generator is created. For best
        /// performance and randomization, it is recommended that you supply this
        /// parameter.</param>
        /// <returns>A random element from this collection, or <c>default(T)</c> if
        /// this collection is empty.</returns>
        public static T Random<T>(this IEnumerable<T> list, Random rand = null)
        {
            // Check for empty list
            if (list == null || list.Count() == 0)
                return default;
            // Check for null random number generator
            if (rand == null)
                rand = new Random();
            // Return random element
            return list.ElementAt(rand.Next(list.Count()));
        }

        /// <summary>
        /// Returns a shuffled, shallow copy of this collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in this collection.</typeparam>
        /// <param name="rand">An instance of a random number generator. If this
        /// parameter is <c>null</c>, a random number generator is created. For best
        /// performance and randomization, it is recommended that you supply this
        /// parameter.</param>
        /// <returns>A shuffled, shallow copy of this collection.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rand = null)
        {
            // Check for empty list
            if (source == null || !source.Any())
                return new List<T>();
            // Check for null random number generator
            if (rand == null)
                rand = new Random();
            // Copy and shuffle list
            var list = source.ToList();
            list.Shuffle(rand);
            return list;
        }

        /// <summary>
        /// Shuffles an <see cref="IList{T}"></see> collection in place.
        /// </summary>
        /// <typeparam name="T">The type of elements in this list.</typeparam>
        /// <param name="rand">An instance of a random number generator. If this
        /// parameter is <c>null</c>, a random number generator is created. For best
        /// performance and randomization, it is recommended that you supply this
        /// parameter.</param>
        public static void Shuffle<T>(this IList<T> list, Random rand = null)
        {
            // Check for null random number generator
            if (rand == null)
                rand = new Random();
            // Sort list in place
            int count = list.Count;
            while (count > 1)
            {
                int i = rand.Next(count--);
                T temp = list[count];
                list[count] = list[i];
                list[i] = temp;
            }
        }
    }
}
