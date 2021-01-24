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
        [InlineData("test","test")]
        public void Sort_AllUpperCaseToLowerCase_TestSuccess(string input, string expected)
        {
            var sysUnderTest = new SortService();

            var result = sysUnderTest.Sort(input);

            result.Should().Be(expected);
        }

        [Fact]
        public void Sort_TestToLowerCasePrivateMethod_TestSuccess()
        {
            Type type = typeof(SortService);

            var test = Activator.CreateInstance(type);

            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "ConvertToLower" && x.IsPrivate).First();

            var result = (string)method.Invoke(test, new object[] { "HELLO" });

            result.Should().Be("hello");
        }

        [Fact]
        public void Sort_TestLoadAlphabetPrivateMethod_TestSuccess()
        {
            Type type = typeof(SortService);

            var test = Activator.CreateInstance(type);

            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "LoadAlphabet" && x.IsPrivate).First();

            var result = (string[])method.Invoke(test, null);

            result.Should().Contain(new string[] { "a", "b" });
        }
    }
}
