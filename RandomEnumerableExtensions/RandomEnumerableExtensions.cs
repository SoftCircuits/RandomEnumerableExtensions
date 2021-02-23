// Copyright (c) 2019-2021 Jonathan Wood (www.softcircuits.com)
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
        /// Returns a random element from this collection, or <see cref="default{T}"/>
        /// if this collection is null or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements this collection holds.</typeparam>
        /// <param name="rand">An instance of a random number generator. If not provided,
        /// a random number generator is created. For best performance and randomization,
        /// it is recommended that you supply this parameter.</param>
        /// <returns>A random element from this collection, or <see cref="default{T}"/>
        /// if this collection is empty.</returns>
        public static T? Random<T>(this IEnumerable<T> list, Random? rand = null)
        {
            // Check for empty list
            if (list == null || !list.Any())
                return default;

            // Ensure random number generator
            if (rand == null)
                rand = new Random();

            // Return random element
            return list.ElementAt(rand.Next(list.Count()));
        }

        /// <summary>
        /// Returns a shuffled shallow copy of this collection.
        /// </summary>
        /// <typeparam name="T">The type of elements this collection holds.</typeparam>
        /// <param name="rand">An instance of a random number generator. If not provided,
        /// a random number generator is created. For best performance and randomization,
        /// it is recommended that you supply this parameter.</param>
        /// <returns>A shuffled shallow copy of this collection.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random? rand = null)
        {
            // Check for empty list
            if (source == null || !source.Any())
                return Enumerable.Empty<T>();

            // Ensure random number generator
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
        /// <typeparam name="T">The type of elements this collection holds.</typeparam>
        /// <param name="rand">An instance of a random number generator. If not provided,
        /// a random number generator is created. For best performance and randomization,
        /// it is recommended that you supply this parameter.</param>
        public static void Shuffle<T>(this IList<T> source, Random? rand = null)
        {
            // Null check
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            // Empty list optimization
            if (source.Count == 0)
                return;

            // Ensure random number generator
            if (rand == null)
                rand = new Random();

            // Shuffle list in place
            int count = source.Count;
            while (count > 1)
            {
                int i = rand.Next(count--);
                T temp = source[count];
                source[count] = source[i];
                source[i] = temp;
            }
        }
    }
}
