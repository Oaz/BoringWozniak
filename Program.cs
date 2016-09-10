using System;

namespace BoringWozniak
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Console.WriteLine (NamesGenerator.GetRandomName(0));
      Console.WriteLine (NamesGenerator.GetRandomName(1));
    }
  }
}
