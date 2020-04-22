using System;
using System.Collections.Generic;

namespace Conlang 
{
	public class Phonology
	{
		public Phonology()
		{
			this.Vowels = new List<Vowel>();
			this.Consonants = new List<Consonant>();
		}
		public List<Vowel> Vowels {get; set;}
		public List<Consonant> Consonants {get; set;}

		public void ListLetters(string letterType)
		{
			string message = "There are ";
			if(letterType == "consonants") message += $"{this.Consonants.Count} consonants. \n";
			else if(letterType == "vowels") message += $"{this.Vowels.Count} vowels. \n";
			Console.WriteLine(message);

			if(letterType == "consonants") {
				foreach(Consonant con in this.Consonants) {
					string ipa = (con.Voiced ? "voiced" : "voiceless") + $" {con.Placement} {con.Type}";
					PrintDescription(con, ipa);
				}
			} else if(letterType == "vowels") {
				foreach(Vowel vowel in this.Vowels) {
					string ipa = (vowel.Rounded ? "rounded" : "unrounded") + $" {vowel.TonguePosition} {vowel.Openness}";
					PrintDescription(vowel, ipa);
				}
			}
		}

		public void PrintDescription(Phoneme letter, string ipa)
		{
			Console.WriteLine($"- {letter.Written.ToUpper()} ");
			Console.WriteLine($"IPA Classification: {ipa}");
			Console.WriteLine($"Pronunciation: '{letter.Sound.ToUpper()}', like {letter.ForeignExample.FromLanguage} \"{letter.ForeignExample.Word}\"\n");
		}

	}

	public class Phoneme
	{
		public Phoneme() {}
		public void ConfigPhoneme(Phoneme phoneme, string representation, Example ex, string sound)
		{
			phoneme.Written = representation;
			phoneme.Sound = sound;
			phoneme.ForeignExample = ex;
		}
		public void ConfigPhoneme(Phoneme phoneme, string representation, Example ex)
		{
			phoneme.Written = representation;
			phoneme.Sound = representation;
			phoneme.ForeignExample = ex;
		}
		public string Written {get; set;}
		public string Sound {get; set;}
		public Example ForeignExample {get; set;}
	}

	public class Vowel : Phoneme
	{
		public Vowel(string frontBack, string mouth, bool rounded)
		{
			this.TonguePosition = frontBack;
			this.Openness = mouth;
			this.Rounded = rounded;
		}
		public string TonguePosition {get; set;}
		public string Openness {get; set;}
		public bool Rounded {get; set;}
	}

	public class Consonant : Phoneme
	{
		public Consonant(string placement, string type, bool voiced)
		{
			this.Placement = placement;
			this.Type = type;
			this.Voiced = voiced;
		}
		public string Placement {get; set;}
		public string Type {get; set;}
		public bool Voiced {get; set;}
	}

	public class Example
	{
		public Example(string letter, string word, string fromLanguage)
		{
			this.Letters = letter;
			this.Word = word;
			this.FromLanguage = fromLanguage;
		}
		public string Letters {get; set;}
		public string Word {get; set;}
		public string FromLanguage {get; set;}
	}
}