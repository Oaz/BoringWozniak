using NUnit.Framework;
using System;
using System.Linq;

namespace BoringWozniak
{
  [TestFixture]
  public class BoringWozniakTest
  {
    int focusedIndex = GetIndexFor(NamesGenerator.adjectives, "focused");
    int turingIndex = GetIndexFor(NamesGenerator.surnames, "turing");

    [Test]
    public void GenerateNameWithoutRetry ()
    {
      Assert.That (NamesGenerator.GetRandomName (0, FakeRandomNumbers(focusedIndex,turingIndex)), Is.EqualTo("focused_turing"));
    }

    [Test]
    public void GenerateNameWithRetry ()
    {
      Assert.That (NamesGenerator.GetRandomName (1, FakeRandomNumbers(focusedIndex,turingIndex,3)), Is.EqualTo("focused_turing3"));
    }

    [Test]
    [TestCase(4,8)]
    [TestCase(0,12)]
    [TestCase(5,1)]
    public void GenerateDifferentNames (int adjectiveIndex, int surnameIndex)
    {
      var expectedName = NamesGenerator.adjectives [adjectiveIndex] + "_" + NamesGenerator.surnames [surnameIndex];
      Assert.That (
        NamesGenerator.GetRandomName (0, FakeRandomNumbers(adjectiveIndex,surnameIndex)),
        Is.EqualTo(expectedName)
      );
    }

    [Test]
    public void SteveWozniakIsNotBoring ()
    {
      var boringIndex = GetIndexFor(NamesGenerator.adjectives, "boring");
      Assert.That (boringIndex, Is.Not.EqualTo (0));
      var wozniakIndex = GetIndexFor(NamesGenerator.surnames, "wozniak");
      Assert.That (wozniakIndex, Is.Not.EqualTo (0));
      Assert.That (
        NamesGenerator.GetRandomName (0, FakeRandomNumbers(boringIndex, wozniakIndex, focusedIndex, turingIndex)),
        Is.EqualTo ("focused_turing")
      );
    }

    private static Func<int,int> FakeRandomNumbers(params int[] numbers)
    {
      var randomCalls = 0;
      return max => numbers [randomCalls++];
    }

    private static int GetIndexFor(string[] allValues, string expectedValue)
    {
      return allValues.TakeWhile(val => val != expectedValue).Count();
    }
  }
}

