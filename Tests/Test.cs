using NUnit.Framework;
using System;

namespace BoringWozniak
{
  [TestFixture]
  public class BoringWozniakTest
  {
    [Test]
    public void WhenRandomNumberIsZero ()
    {
      Func<int,int> zero = x => 0;
      Assert.That (NamesGenerator.GetRandomName (0, zero), Is.EqualTo(NamesGenerator.left[0]+"_"+NamesGenerator.right[0]));
      Assert.That (NamesGenerator.GetRandomName (1, zero), Is.EqualTo(NamesGenerator.left[0]+"_"+NamesGenerator.right[0]+"0"));
    }
  }
}

