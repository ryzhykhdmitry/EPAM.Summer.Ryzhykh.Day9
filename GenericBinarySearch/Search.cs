using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinarySearch
{
    /// <summary>
    /// Search element by Binary algorythm
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class SearchElement<T>
    {
        #region Public Methods
        /// <summary>
        /// Search element in sorted array
        /// </summary>
        /// <param name="array">Sorted array</param>
        /// <param name="item">Element for searching</param>
        /// <param name="comparer">Rule for comparing elements in array</param>
        /// <returns>Index of element in array or -1, if it doesn't exist</returns>
        public static int BinarySearch(T[] array, T item, Comparison<T> comparer = null)
        {
            CheckInputArray(array);
            if (array.Length == 1 && array[0].Equals(item))
                return 0;
            if (array.Length == 1 && !array[0].Equals(item))
                return -1;
            if (comparer == null)
                comparer = Comparer<T>.Default.Compare;
            if (IsSorted(array, comparer) == false)
                throw new ArgumentException();

            return Search(array, item, comparer);
        }

        /// <summary>
        /// Search element in sorted array
        /// </summary>
        /// <param name="array">Sorted array</param>
        /// <param name="item">Element for searching</param>
        /// <param name="comparer">Rule for comparing elements in array</param>
        /// <returns>Index of element in array or -1, if it doesn't exist</returns>
        public static int BinarySearch(T[] array, T item, IComparer<T> comparer)
        {
            CheckInputArray(array);
            if (array.Length == 1 && array[0].Equals(item))
                return 0;
            if (array.Length == 1 && !array[0].Equals(item))
                return -1;
            if (comparer == null)
                return BinarySearch(array, item);
            if (IsSorted(array, comparer.Compare) == false)
                throw new ArgumentException();

            return Search(array, item, comparer.Compare);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Check array on null and length
        /// </summary>
        /// <param name="array">Array</param>
        private static void CheckInputArray(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException();

        }
        /// <summary>
        /// Check weather the array is sorted
        /// </summary>
        /// <param name="arr">Array</param>
        /// <param name="comparer">Rule for comparing elements in array</param>
        /// <returns>True, if array is sorted</returns>
        private static bool IsSorted(T[] arr, Comparison<T> comparer)
        {
            bool isGreater = comparer(arr[0], arr[1]) <= 0;
            for (int i = 1; i < arr.Length;)
            {
                if (comparer(arr[i], arr[i++]) <= 0 != isGreater)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Search element in sorted array
        /// </summary>
        /// <param name="arr">Sorted array</param>
        /// <param name="item">Element for searching</param>
        /// <param name="comparer">Rule for comparing elements in array</param>
        /// <returns>Index of element in array or -1, if it doesn't exist</returns>
        private static int Search(T[] arr, T item, Comparison<T> comparer)
        {
            int low = 0, high = arr.Length;
            while (low < high)
            {
                int mid = (low + high) / 2;
                if (comparer(item, arr[mid]) == 0)
                    return mid;

                if (comparer(item, arr[mid]) >= 0)
                    low = mid + 1;
                else
                    high = mid;
            }
            return -1;
        }
        #endregion
    }
}
