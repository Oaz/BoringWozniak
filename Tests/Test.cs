using NUnit.Framework;
using System;
using System.Linq;

namespace BoringWozniak
{
  [TestFixture]
  public class BoringWozniakTest
  {
    [Test]
    public void GenerateNameWithoutRetry ()
    {
      Assert.That (NamesGenerator.GetRandomName (0, FakeRandomNumbers(0,1)), Is.EqualTo(GeneratedName (0,1)));
    }

    [Test]
    public void GenerateNameWithRetry ()
    {
      Assert.That (NamesGenerator.GetRandomName (1, FakeRandomNumbers(0,1,2)), Is.EqualTo(GeneratedName (0, 1)+"2"));
    }

    [Test]
    public void SteveWozniakIsNotBoring ()
    {
      var boringIndex = NamesGenerator.left.TakeWhile(val => val != "boring").Count();
      Assert.That (boringIndex, Is.Not.EqualTo (0));
      var wozniakIndex = NamesGenerator.right.TakeWhile(val => val != "wozniak").Count();
      Assert.That (wozniakIndex, Is.Not.EqualTo (0));
      Assert.That (
        NamesGenerator.GetRandomName (0, FakeRandomNumbers(boringIndex, wozniakIndex, 0, 0)),
        Is.EqualTo (GeneratedName (0, 0))
      );
    }

    private string GeneratedName(int adjectiveIndex, int surnameIndex)
    {
      return NamesGenerator.left [adjectiveIndex] + "_" + NamesGenerator.right [surnameIndex];
    }

    private Func<int,int> FakeRandomNumbers(params int[] numbers)
    {
      var randomCalls = 0;
      return max => numbers [randomCalls++];
    }
  }
}

