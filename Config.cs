using System;
using System.Collections.Generic;

namespace Conlang
{
	public class Config
	{
		// Configure vowels
		public static void SetVowels(Phonology set)
		{
			List<Vowel> vowels = new List<Vowel>();

			// A
		    Vowel a = new Vowel("front", "open", false);
			a.ConfigPhoneme(a, "a", new Example("a", "father", "English"), "ah");
			vowels.Add(a);

			// E
			Vowel e = new Vowel("near front", "close mid", false);
			e.ConfigPhoneme(e, "e", new Example("eh", "Fehler", "German"), "eh");
			vowels.Add(e);

			// I
			Vowel i = new Vowel("front", "close", false);
			i.ConfigPhoneme(i, "i", new Example("ee", "tree", "English"), "ee");
			vowels.Add(i);

			// O
			Vowel o = new Vowel("back", "open mid", true);
			o.ConfigPhoneme(o, "o", new Example("ough", "thought", "English"), "aw");
			vowels.Add(o);

			// U
			Vowel u = new Vowel("back", "closed", true);
			u.ConfigPhoneme(u, "u", new Example("uh", "Schuh", "German"), "oo");
			vowels.Add(u);

			// Add vowels to phonology
			foreach(Vowel vowel in vowels) {
				set.Vowels.Add(vowel);
			}
		}

		// Configure consonants
		public static void SetConsonants(Phonology set)
		{
			List<Consonant> cons = new List<Consonant>();

			// NASALS
			// M
			Consonant m = new Consonant("bilabial", "nasal", true);
			m.ConfigPhoneme(m, "m", new Example("m", "mother", "English"));
			cons.Add(m);

			// N
			Consonant n = new Consonant("alveolar", "nasal", true);
			n.ConfigPhoneme(n, "n", new Example("n", "nope", "English"));
			cons.Add(n);

			// STOPS
			// P
			Consonant p = new Consonant("bilabial", "stop", false);
			p.ConfigPhoneme(p, "p", new Example("p", "push", "English"));
			cons.Add(p);

			// T
			Consonant t = new Consonant("alveolar", "stop", false);
			t.ConfigPhoneme(t, "t", new Example("t", "timber", "English"));
			cons.Add(t);

			// K
			Consonant k = new Consonant("velar", "stop", false);
			k.ConfigPhoneme(k, "k", new Example("c", "car", "English"));
			cons.Add(k);

			// FRICATIVES
			// S
			Consonant s = new Consonant("alveolar", "fricative", false);
			s.ConfigPhoneme(s, "s", new Example("s", "sister", "English"));
			cons.Add(s);

			// H
			Consonant h = new Consonant("glottal", "fricative", false);
			h.ConfigPhoneme(h, "h", new Example("h", "house", "English"));
			cons.Add(h);

			// LIQUIDS
			// R
			Consonant r = new Consonant("alveolar", "flap", true);
			r.ConfigPhoneme(r, "r", new Example("r", "para", "Spanish"));
			cons.Add(r);

			// L
			Consonant l = new Consonant("alveolar", "approximate", true);
			l.ConfigPhoneme(l, "l", new Example("l", "Fehler", "German"));
			cons.Add(l);

			// J
			Consonant j = new Consonant("palatal", "approximate", true);
			j.ConfigPhoneme(j, "j", new Example("j", "jawohl", "German"), "y");
			cons.Add(j);

			// W
			Consonant w = new Consonant("labialized velar", "approximate", true);
			w.ConfigPhoneme(w, "w", new Example("w", "winter", "English"));
			cons.Add(w);

			// Add consonants to phonology
			foreach(Consonant con in cons) {
				set.Consonants.Add(con);
			}
		}
	}
}