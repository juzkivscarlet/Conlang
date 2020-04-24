# Unnamed Conlang
__*Matt Juskiw*__

This is a constructed language made using the *C# programming language* and the *.NET Core Framework*. 
It is very much still in the beginning stages. 

For simplicity, this guide shows object definitions as *JSON objects*.

This guide frequently references the __International Phonetic Alphabet__ (abbreviated as __IPA__). 
Click [here](https://en.wikipedia.org/wiki/International_Phonetic_Alphabet) for a guide to the IPA classification system.

Guide to making conlangs: [YouTube playlist](https://www.youtube.com/playlist?list=PL6xPxnYMQpqsooCDYtQQSiD2O3YO0b2nN)

# Table of Contents

1. __Program.cs__
1. __Config.cs__
	1. __class Config__
		1. *function* __Config.SetVowels()__
		2. *function* __Config.SetConsonants()__
1. __Phonology.cs__
	1. __class Phonology__
		1. Constructor
		1. *function* __ListLetters()__
		1. *function* __PrintDescription()__
	1. __class Phoneme__
		1. *function* __ConfigPhoneme()__
		1. __class Vowel : Phoneme__
			- Constructor
		1. __class Consonant : Phoneme__
			- Constructor
	1. __class Example__
		- Constructor

---
# Program.cs

---
# Config.cs

## *CLASS Config*

The __Config__ class does not contain a constructor, however it defines contains two functions: 
- *SetVowels()* 
- *SetConsonants()* 

Usage defined below.

### function *Config.SetVowels()*

Definition:

```public static void SetVowels(Phonology)```

This function defines the vowels used in the conlang. It takes one argument, of the object type *Phonology*, defined in __Phonology.cs__.
It returns nothing, and is called in __Program.cs__, as `Config.SetVowels(set)`. 
The purpose of this function is to define *Vowel* objects and attach them to the *Phonology* object passed as the parameter.

The following vowels are added
	: __Aa, Ee, Ii, Oo, Uu__

For the *Vowel* object definition, read the `class Vowel` section under __Phonology.cs__.

### function *Config.SetConsonants()*

Definition: 

```public static void SetConsonants(Phonology)```

This function defines the consonants used in the conlang. Like `Config.SetVowels(set)`, it takes one *Phonology* object as the only parameter.
It returns nothing, and is called in __Program.cs__, as `Conlang.SetConsonants(set)`.
The purpose of this function is to define the *Consonant* objects, and attach them to the *Phonology* object argument.

The following consonants are added (organized by consonant type):

- *Nasals*
	: __Mm, Nn__
- *Stops*
	: __Kk, Pp, Tt__
- *Fricatives*
	: __Hh, Ss__
- *Liquids*
	: __Jj, Ll, Rr, Ww__

For the *Consonant* object definition, read the `class Consonant` section under __Phonology.cs__.

---
# Phonology.cs

## *CLASS Phonology*

The __Phonology__ class contains:
- a __constructor__
- two functions:
	- *ListLetters()*
	- *PrintDescription()*

A `Phonology` object contains many nested objects, related to the language's sounds
, such as the vowels and consonants used.

### Constructor

Calling the constructor: 
```new Phonology();```

This will create an object with the following structure:
```
	Phonology: {
		Consonants: List<Consonants>,
		Vowels: List<Vowel>
	}
```

These properties essentially refer to two `List` objects (like arrays) of `Consonant` and `Vowel` objects, respectively.
To start, those Lists are empty, but are populated using the methods defined in __Config.cs__.

### function *ListLetters()*

Definition:

```public void ListLetters(string)```

This method prints every vowel or every consonant along with a description of each. 
It takes one string for an argument, referenced as "letterType". 
You can calling the function as such (replacing *"phonology"* with your variable name):

```phonology.ListLetters(letterType);```

The value of `letterType` can be either *"vowels"* or *"consonants"*. 
There is no functionality as of yet for passing in other values, or no parameters. 

Running the function will first print to the console how many vowels/consonants are defined,
then sort through them one by one, printing its definition.
Using "vowels" for `letterType` for example will produce the following output to the console: 
```
There are 5 vowels.

- A
IPA Classification: unrounded front open
Pronounciation: 'AH', like English "father"

- E
...
```

If running with "vowels", the line for *"IPA classification"* will read from the Vowel object's `Rounded`, `TonguePosition`, and `Openness` properties.
For "consonants", the Consonant object's `Voiced`, `Placement`, and `Type` properties will be used instead.
The format for this is stored in a variable and passed to the `PrintDescription()` function to actually write each letter to the console.

```
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
```

### function *PrintDescription()*

Definition:

```public void PrintDescription(Phoneme, string)```

This method is called when `ListLetters()` sorts through each Vowel or Consonant object. It simply logs the letter's description as such (using "A" as an example):

```
- A
IPA Classification: unrounded front open
Pronounciation: 'AH', like English "father"
```

---
## *CLASS Phoneme*

The constructor for the `Phoneme` class in itself is fairly useless, since all phonemes will either fall into the `Vowel` or `Consonant` subclasses.
There is one method under this class, *ConfigPhoneme()*, inherited by both the aforementioned classes.

### function *ConfigPhoneme()*

Once a Vowel or Consonant object is stored in a variable, this function can be called as such (replacing *"letter"* with your variable name):

```letter.ConfigPhoneme(Phoneme, Written, ForeignExample, [Sound]);```

The `Sound` argument is optional, and is used if the letter's pronunciation may be misleading to English speakers.

### *CLASS Vowel : Phoneme*

The __Vowel__ object, as the name suggests, is used to format the definition of vowels in the conlang.
Multiple properties are inherited when called with the `ConfigPhoneme()` method (defined in the __Phoneme__ class), as such (replacing "vowel" with your variable name):

```vowel.ConfigPhoneme(vowel, string representation, Example ex, [string sound]);```

#### Constructor

Calling the constructor:
```new Vowel(TonguePosition, Openness, Rounded);```

Using the constructor will return an object with the following structure: 
```
	{
		Vowel: {
			Openness: String,
			Rounded: bool,
			TonguePosition: String
		}
	}
```

For example, let's define the vowel "Oo":
`new Vowel("back", "open mid", true);`

The aforementioned properties are defined to answer the following questions: 
- __TonguePosition__
	: *Where in the mouth is the tongue positioned for this vowel?* 
	- For our example, "Oo" is pronounced in the __back__ of the mouth. 
	- IPA identifies five degrees of *vowel backness*: 
		1. __front__
		1. __near-front__
		1. __central__
		1. __near-back__
		1. __back__
	- Refer to the "vowel backness" descriptions for vowels as defined in the IPA classification system for more information.
- __Openness__
	: *How open is the mouth to pronounce the vowel?* 
	- For our example, "Oo" is pronounced with the mouth __relatively open__. 
	- IPA identifies seven degrees of *vowel height*: 
		1. __close__ (*high*)
		1. __near-close__ (*near-high*)
		1. __close-mid__ (*high-mid*)
		1. __mid__ (*true-mid*)
		1. __open-mid__ (*low-mid*)
		1. __near-open__ (*near-low*)
		1. __open__ (*low*) 
	- Refer to the "vowel height" descriptions for vowels as defined in the IPA classification system for more information.
- __Rounded__
	: *Are the lips pursed (rounded) to produce the vowel?* 
	- For our example, "Oo" is a __rounded__ vowel, so `Rounded` is set to `true`.
	- Refer to the "vowel roundedness" descriptions for vowels as defined by the IPA classification system for more information.

### *CLASS Consonant : Phoneme*

The __Consonant__ object, as the name suggests, is used to format the definition of consonants for the conlang.
Multiple properties are inherited when called with the `ConfigPhoneme()` method (defined in the __Phoneme__ class), as such (replacing *"consonant"* with your variable name):

```consonant.ConfigPhoneme(consonant, string representation, Example ex, [string sound]);```

#### Constructor

Calling the constructor:
```new Consonant(Placement, Type, Voiced);```

Using the constructor will return an object with the following structure: 
```
	{
		Consonant: {
			Placement: String,
			Type: String,
			Voiced: bool
		}
	}
```

For example, let's define the consonant "Kk":
`new Consonant("velar", "stop", false);`

The aforementioned properties are defined to answer the following questions:
- __Placement__
	: *Where in the mouth is the consonant pronounced?* 
	- For our example, K is pronounced in the __velar__ position. 
	- IPA identifies several *places of articulation* for consonants: 
		- __labial/bilabial__ (*lips*)
		- __alveolar__ (*just behind teeth*)
		- __post-alveolar__ (*back of gum ridge behind teeth*)
		- __palatal__ (*hard palate, middle of mouth*)
		- __velar__ (*soft palate, back of mouth*)
		- __glotal__ (*windpipe*)
		among a few others we won't be needing for this conlang.
	- Refer to the "places of articulation" for consonants, defined by the IPA classification system for more information.
- __Type__
	: *How is the sound produced?*
	- For our example, K is a __stop__.
	- IPA identifies several *manners of articulation* for consonants: 
		- __stops, plosives__: made by briefly blocking airflow, then releasing. 
			Examples: *Kk, Tt, etc.*.
		- __nasals__: made by restricting airflow to just the nasal cavity. 
			Examples: *Mm, Nn*.
		- __fricatives__: made by distorting airflow. 
			Examples: *Ff, Vv, Ss, etc.*.
		- __flaps__: similar to a __trill__, but with only one quick flap of the tongue. 
			Examples: *single 'R' in Spanish*.
		- __approximates__: essentially a vowel sound made very quickly before another sound is phone. 
			Examples: *English 'Ww' and 'Yy' (as in 'yes'), etc.*
		among a few others we won't be needing for this conlang.
	- Refer to "manners of articulation" for consonants, defined by the IPA classification system for more information.
- __Voiced__
	: *Does the voice resonate during the consonant sound?*
	- For example, K is a __voiceless__ consonant, so `Voiced` is set to `false`.
	- __Voiced__ consonants, according to the IPA, the vocal chords are vibrating, thus the voice is used to produce the consonant. 
		Examples: *English 'Vv' and 'Zz', etc.*.
	- In contrast, __voiceless__ consonants are pronounced without the voicebox. Similar to their voiced counterparts, though usually with more airflow.
		Examples: *'Ff', 'Ss', etc.*
	- Most consonant sounds have voiced and voiceless equivalents. 
		For example in English: *'Gg' and 'Kk'*, *'Tt' and 'Dd'*, etc.

---
## *CLASS Example*

An __Example__ object is used for examples of the pronunciation of sounds from other languages. 
Example objects are attached as to the *ForeignExample* property in __Phoneme__ objects.

If I think of an accurate example found in English, that would be used for the object, preferred over another language.

### Constructor

Creating new instance of Example:
```new Example(Letters, Word, FromLanguage);```

Returns:
```
	{
		Example: {
			FromLanguage: String
			Letters: String,
			Word: String
		}
	}
```

For example, let's define an example using the sound found in the "ough" diphthong from the word "thought":
`new Example("ough", "thought", "English");`

The aforementioned properties are defined to answer the following questions:
- __Letters__
: *Which letters from the example represent the sound?*
	- In our example, the sound from the combination __"ough"__ is used.
- __Word__
: *In which word is the sound found?*
	- For our example, the word is __"thought"__.
- __FromLanguage__
: *From which language is the example found?* 
	- As stated above, if an accurate example from English is readily available, this will be set to English. 
	- For our example, this would be __"English"__.

---