using System;
using GroupingNumbers.Services.src.Implementation;
using NUnit.Framework;

namespace GroupingNumbers.UnitTests
{
    [TestFixture]
    public class GroupConsecutivesTests
    {
        private GroupConsecutives _groupConsecutives;

        [SetUp]
        public void Setup()
        {
            _groupConsecutives = new GroupConsecutives();
        }

        [TestCase(new int[] { }, "", TestName = "WithEmptyArray_ReturnsEmptyString")]
        [TestCase(new int[] { 1 }, "1;", TestName = "WithASingleNumber_ReturnsASingleNumber")]
        [TestCase(new int[] { 1, 1, 1, 1 }, "1;", TestName = "WithASingleNumberRepeatingMultipleTimes_ReturnsASingleNumber")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, "1-5;", TestName = "WithAllConsecutiveNumbers_ReturnsASingleRange")]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, "1-5;", TestName = "WithAllConsecutiveNumbersReversed_ReturnsASingleRange")]
        [TestCase(new int[] { 1, 2, 3, 45, 32, 22, 23, 46 }, "1-3;22-23;32;45-46;", TestName = "WithSingleAndConsecutiveNumbers_ReturnsTheRanges")]
        [TestCase(new int[] { 1, 2, 3, 2, 45, 32, 22, 23, 45, 46, 22 }, "1-3;22-23;32;45-46;", TestName = "WithMultipleRepeatingNumbers_ReturnsTheRanges")]
        public void Test_Group_WithVariousValueCombinations(int[] values, string expectedOutput)
        {
            // Act
            string output = _groupConsecutives.Group(values);            

            // Assert
            Assert.That(output, Is.EqualTo(expectedOutput), "Output does not match with expected output");
        }

        [Test]
        public void Test_Group_WhenCalledWithNullArgument_ThrowsArgumentNullException()
        {
            // Arrange
            TestDelegate methodCall = () => { _groupConsecutives.Group(null); };

            // Act & Assert
            Assert.Throws(typeof(ArgumentNullException), methodCall);            
        }
    }
}