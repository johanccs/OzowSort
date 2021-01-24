using FluentAssertions;
using Ozow.Service.Services;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Ozow.Test
{
    public class SortTests
    {
        [Theory]
        [InlineData("Hello world", "dehllloorw")]
        [InlineData("Contrary to popular belief, the pink unicorn flies east.", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        public void Sort_VariableTest_TestSuccess(string input, string expected)
        {
            var sysUnderTest = new SortService();

            var result = sysUnderTest.Sort(input);

            result.Should().Be(expected);
        }

        [Fact]
        public void Sort_TestLoadAlphabetPrivateMethod_TestSuccess()
        {
            Type type = typeof(SortService);

            var test = Activator.CreateInstance(type);

            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "LoadAlphabet" && x.IsPrivate).First();

            var result = (char[])method.Invoke(test, null);

            result.Should().Contain(new char[] { 'a', 'b' });
        }

        [Theory]
        [InlineData('a', 0)]
        [InlineData('b', 1)]
        [InlineData('c', 2)]
        [InlineData('d', 3)]
        [InlineData('e', 4)]
        [InlineData('A', 0)]
        [InlineData('!', -1)]
        public void Sort_FindValueByIndexPrivateMethod_TestSuccess(char input, int expected)
        {
            Type type = typeof(SortService);

            var test = Activator.CreateInstance(type);

            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "FindIndexByValue" && x.IsPrivate).First();

            var result = (int)method.Invoke(test, new object[] { input });

            result.Should().Be(expected);
        }
    }
}
