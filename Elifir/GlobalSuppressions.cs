// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Major Bug",
    "S3453:Classes should not have only \"private\" constructors",
    Justification = "It is declared only for type not for objects",
    Scope = "type",
    Target = "~T:Nuisho.Elifir.AdHocPolyMarker")]

[assembly: SuppressMessage(
    "Major Code Smell", 
    "S3246:Generic type parameters should be co/contravariant when possible", 
    Justification = "This delegate should be used only for one special case where co/contravariant isn't needed", 
    Scope = "type", 
    Target = "~T:Nuisho.Elifir.IsOfType`1")]

[assembly: SuppressMessage(
    "Major Code Smell", 
    "S3246:Generic type parameters should be co/contravariant when possible", 
    Justification = "This delegate should be used only for one special case where co/contravariant isn't needed", 
    Scope = "type", 
    Target = "~T:Nuisho.Elifir.WithReturnType`1")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "AdHocPolyMarker parameter is used as a workaround because of the limitation of static polymorphism, "
                  + "which doesn't recognize generic constraints as a part of the signature.", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``2(Nuisho.Elifir.Іf{``0}.Then{``1},Nuisho.Elifir.AdHocPolyMarker)~System.Func{``0,``1}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "AdHocPolyMarker parameter is used as a workaround because of the limitation of static polymorphism, "
                  + "which doesn't recognize generic constraints as a part of the signature.",
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``3(Nuisho.Elifir.Іf{``0}.Then{``1}.Else.Then{``2},Nuisho.Elifir.AdHocPolyMarker)~System.Func{``0,``2}")]

[assembly: SuppressMessage(
    "Critical Code Smell", 
    "S3218:Inner class members should not shadow outer class \"static\" or type members", 
    Justification = "This name is the best option and doesn't create conflicts", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.Object`1.Is``1~System.ValueTuple{`0,``0}")]

[assembly: SuppressMessage(
    "Critical Code Smell", 
    "S3218:Inner class members should not shadow outer class \"static\" or type members", 
    Justification = "This name is the best option and doesn't create conflicts", 
    Scope = "type", 
    Target = "~T:Nuisho.Elifir.Іf`1.Then`1.Else.Then`1")]

[assembly: SuppressMessage(
    "Style", 
    "IDE0060:Remove unused parameter", 
    Justification = "This parameter is necessary to avoid explicit generic parameter types.", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.AndIf``2(Nuisho.Elifir.Іf{``0},Nuisho.Elifir.IsOfType{``1})~Nuisho.Elifir.Іf{``0}.Is{``1}")]

[assembly: SuppressMessage(
    "Style", 
    "IDE0060:Remove unused parameter", 
    Justification = "This parameter is necessary to avoid explicit generic parameter types.", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.AndIf``3(Nuisho.Elifir.Іf{``0}.Is{``1},Nuisho.Elifir.IsOfType{``2})~Nuisho.Elifir.Іf{``0}.Is{``2}")]

[assembly: SuppressMessage(
    "Style", 
    "IDE0060:Remove unused parameter", 
    Justification = "This parameter is necessary to avoid explicit generic parameter types.", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``3(Nuisho.Elifir.Іf{``0}.Then{``1},Nuisho.Elifir.WithReturnType{``2})~System.Func{``0,``2}")]

[assembly: SuppressMessage(
    "Style", 
    "IDE0060:Remove unused parameter", 
    Justification = "This parameter is necessary to avoid explicit generic parameter types.", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.If``2(Nuisho.Elifir.ObjectOfType{``0}.IsOfType{``1})~Nuisho.Elifir.Іf{``0}.Is{``1}")]
