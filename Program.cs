using System;
using System.Collections.Generic;

namespace Conlang
{
	class Program
	{
		static void Main(string[] args)
		{
			Phonology phonology = new Phonology();
			Config.SetConsonants(phonology);
			Config.SetVowels(phonology);

			Console.WriteLine();
			phonology.ListLetters("consonants");
			Console.WriteLine();
		}
	}
}
