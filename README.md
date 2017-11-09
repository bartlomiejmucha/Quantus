# Quantus
The library to handle plurals of nouns or unit expressions.

Languages vary in how they handle plurals of nouns or unit expressions ("hour" vs "hours", and so on). Some languages have two forms, like English; some languages have only a single form; and some languages have multiple forms.

Quantus is a library that implementes providers that returns correct plural category for cardinal numbering. These categories are:
* Zero
* One
* Two
* Few
* Many
* Other

Providers implements rules that are described here: [Language Plural Rules](http://www.unicode.org/cldr/charts/25/supplemental/language_plural_rules.html)

## Supported languages

Currently only following languages are supported:
* Danish,
* German,
* English,
* French,
* Japanese,
* Polish

## Installation

Nuget package is available: https://www.nuget.org/packages/Quantus

## Roadmap

This is intial version of the library. There are plans to:
* Add all languages,
* Add ordinal numbering support.
