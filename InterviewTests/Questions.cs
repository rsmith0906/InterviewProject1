namespace InterviewTests
{
    [TestClass]
    public class Questions
    {
        /// <summary>
        /// Finds the largest integer in the given list of integers.
        /// </summary>
        [TestMethod]
        public void FindLargestInteger()
        {
            int largestInteger = 0;
            List<int> integers = [3, 5, 2, 8, 23, 0, 100, 29, 32, 34, 21];

            // Insert code here.

            Assert.AreEqual(100, largestInteger);
        }

        /// <summary>
        /// Finds the duplicate integers in the given list of integers.
        /// </summary>
        [TestMethod]
        public void FindDuplicateIntegers()
        {
            List<int> duplicateIntegers = [];
            List<int> integers = [3, 5, 2, 8, 5, 1, 2, 4, 7, 3, 6];

            // Insert code here.

            Assert.IsTrue(duplicateIntegers.Contains(2));
            Assert.IsTrue(duplicateIntegers.Contains(3));
            Assert.IsTrue(duplicateIntegers.Contains(5));
        }

        /// <summary>
        /// Determine if a string is a Palindrome.
        /// </summary>
        [TestMethod]
        public void DetermineIfPalidrome()
        {
            // Modify IsPalindrome method in StringExtensions.cs

            Assert.IsTrue("civic".IsPalindrome());
            Assert.IsTrue("radar".IsPalindrome());
            Assert.IsFalse("dog".IsPalindrome());
            Assert.IsTrue("racecar".IsPalindrome()); 
            Assert.IsFalse("hello".IsPalindrome());
        }
    }
}