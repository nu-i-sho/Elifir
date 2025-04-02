// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Minor Code Smell", 
    "S2094:Classes should not be empty",
    Justification = "This class's responsibility is to be a token. " 
                  + "It can't be an interface because object creation is necessary. " 
                  + "It has no body because the nominal is enough.  ", 
    Scope = "type", 
    Target = "~T:Nuisho.Elifir.Gen.Utils.Token")]

[assembly: SuppressMessage(
    "Minor Code Smell", 
    "S101:Types should be named in PascalCase", 
    Justification = "This naming style is necessary to highlight warning code IDE0079.", 
    Scope = "type", 
    Target = "~T:Nuisho.Elifir.Gen.Supress_IDE0079_Gen`1")]

[assembly: SuppressMessage(
    "Minor Code Smell", 
    "S101:Types should be named in PascalCase", 
    Justification = "This naming style is necessary to highlight warning code S3427.", 
    Scope = "type", Target = "~T:Nuisho.Elifir.Gen.Supress_S3427_Gen`1")]

[assembly: SuppressMessage(
    "Minor Code Smell",
    "S101:Types should be named in PascalCase", 
    Justification = "This naming style is necessary to highlight warning code IDE0060.", 
    Scope = "type", 
    Target = "~T:Nuisho.Elifir.Gen.Supress_IDE0060_Gen`1")]
