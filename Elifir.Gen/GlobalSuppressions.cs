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
    "StyleCop.CSharp.SpacingRules",
    "SA1010:Opening square brackets should be spaced correctly",
    Justification = "False positive. This rule should not be applicable for collections initialization syntax like [1,2,3]",
    Scope = "member",
    Target = "~M:Nuisho.Elifir.Gen.EndSeeds.GetDefault~System.Collections.Generic.IEnumerable{Nuisho.Elifir.Gen.EndSeed}")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.SpacingRules",
    "SA1010:Opening square brackets should be spaced correctly",
    Justification = "False positive. This rule should not be applicable for collections initialization syntax like [1,2,3]",
    Scope = "member",
    Target = "~P:Nuisho.Elifir.Gen.EndSeed.Wheres")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.SpacingRules",
    "SA1010:Opening square brackets should be spaced correctly",
    Justification = "False positive. This rule should not be applicable for collections initialization syntax like [1,2,3]",
    Scope = "member",
    Target = "~P:Nuisho.Elifir.Gen.IfSeed.Wheres")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.SpacingRules",
    "SA1010:Opening square brackets should be spaced correctly",
    Justification = "False positive. This rule should not be applicable for collections initialization syntax like [1,2,3]",
    Scope = "member",
    Target = "~M:Nuisho.Elifir.Gen.IfSeeds.GetDefault~System.Collections.Generic.IEnumerable{Nuisho.Elifir.Gen.IfSeed}")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.NamingRules",
    "SA1313:Parameter names should begin with lower-case letter",
    Justification = "False positive. This rule should not apply to parameters of the record primary constructor.",
    Scope = "type",
    Target = "~T:Nuisho.Elifir.Gen.EndSeed")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.NamingRules",
    "SA1313:Parameter names should begin with lower-case letter",
    Justification = "False positive. This rule should not apply to parameters of the record primary constructor.",
    Scope = "type",
    Target = "~T:Nuisho.Elifir.Gen.IfSeed")]

[assembly: SuppressMessage(
    "Minor Code Smell",
    "S101:Types should be named in PascalCase",
    Justification = "This naming style is necessary to highlight warning code IDE0079",
    Scope = "type",
    Target = "~T:Nuisho.Elifir.Gen.SuppressGen.IDE0079`1")]

[assembly: SuppressMessage(
    "Minor Code Smell",
    "S101:Types should be named in PascalCase",
    Justification = "This naming style is necessary to highlight warning code IDE0060",
    Scope = "type",
    Target = "~T:Nuisho.Elifir.Gen.SuppressGen.IDE0060`1")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.MaintainabilityRules",
    "SA1405:Debug.Assert should provide message text",
    Justification = "There are other opinions about it: "
                  + "'S2336: Remove this argument from the method call; it hides the caller information.'",
    Scope = "member",
    Target = "~M:Nuisho.Elifir.Gen.Utils.ParamComparer.Compare(System.String,System.String)~System.Int32")]
