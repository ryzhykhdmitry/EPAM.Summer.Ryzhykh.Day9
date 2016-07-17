using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GenericBinarySearch.Tests
{
    [TestFixture]
    public class SearchElementTests
    {
        #region TestData
        private Comparison<int> comparerInt = Comparer<int>.Default.Compare;
        public class DataClass
        {
            private static string[] arrString = new string[] { "bike", "reading", "programming", "rain", "wind" };
            public static IEnumerable<TestCaseData> BinarySearchIntData
            {
                get
                {
                    yield return new TestCaseData(new int[] { 2, 5, 7, 9, 12, 43 }, 2).Returns(0);
                    yield return new TestCaseData(new int[] { 2, 5, 7, 9, 12, 43 }, 43).Returns(5);
                    yield return new TestCaseData(new int[] { 2, 5, 7, 9, 12, 43 }, 7).Returns(2);
                    yield return new TestCaseData(new int[] { 2, 5, 7, 9, 12, 43 }, 13).Returns(-1);
                }
            }
          
            public static IEnumerable<TestCaseData> BinarySearchStringData
            {
                get
                {
                    yield return new TestCaseData(arrString, "bike").Returns(0);
                    yield return new TestCaseData(arrString, "wind").Returns(4);
                    yield return new TestCaseData(arrString, "programming").Returns(2);
                    yield return new TestCaseData(arrString, "fear").Returns(-1);
                    yield return new TestCaseData(new string[] { "sunshine" }, "sunshine").Returns(0);
                    yield return new TestCaseData(new string[] { "nothing" }, "something").Returns(-1);
                }
            }           
        }        
        #endregion

        #region Tests with integer
       
        [Test, TestCaseSource(typeof(DataClass), "BinarySearchIntData")]
        public int BinarySearchTests(int[] arr, int item)
        {
            return SearchElement<int>.BinarySearch(arr, item, comparerInt);
        }

        [Test]
        public void BinarySearchIntExceptionTests()
        {
            int[] arr = null;
            int item = 6;
            Assert.That(() => { SearchElement<int>.BinarySearch(arr, item); }, Throws.TypeOf<ArgumentNullException>());
        }


        #endregion

        #region Tests with string        

        [Test, TestCaseSource(typeof(DataClass), "BinarySearchStringData")]
        public int BinarySearchStringTests(string[] arr, string item)
        {
            return SearchElement<string>.BinarySearch(arr, item);
        }

        [Test]
        public void BinarySearchStringNullExceptionTests()
        {
            string[] arr = null;
            string item = "Weather";
            Assert.That(() => { SearchElement<string>.BinarySearch(arr, item); }, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void BinarySearchStringExceptionTests()
        {
            string[] arr = new string[] { };
            string item = "Wind";
            Assert.That(() => { SearchElement<string>.BinarySearch(arr, item); }, Throws.TypeOf<ArgumentException>());
        }
        #endregion
    }
}
