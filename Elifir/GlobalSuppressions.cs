// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Major Code Smell", 
    "S2326:Unused type parameters should be removed", 
    Justification = "This class is a type holder to improve type inference and readability.", 
    Scope = "type", 
    Target = "~T:Nuisho.Elifir.Syntax.ReturnType`1")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``3(Nuisho.Elifir.ˣ.If{``0}.Then{``1}.Else.Then{``2},Nuisho.Elifir.AdHocPolyMarker)~System.Func{``0,``2}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``5(Nuisho.Elifir.ˣ{Nuisho.Elifir.ˣ.If{``0}.Then{``1}.Else.Then{``2},Nuisho.Elifir.ˣ.If{``2}.Then{``3}.Else.Then{``4}},Nuisho.Elifir.AdHocPolyMarker)~Nuisho.Elifir.ˣ.If{``0}.Then{``1}.Else.Then{``4}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``5(Nuisho.Elifir.ˣ{Nuisho.Elifir.ˣ{``0,Nuisho.Elifir.ˣ.If{``1}.Then{``2}.Else.Then{``3}},Nuisho.Elifir.ˣ.If{``3}.Then{``4}},Nuisho.Elifir.AdHocPolyMarker)~Nuisho.Elifir.ˣ{``0,Nuisho.Elifir.ˣ.If{``1}.Then{``2}.Else.Then{``4}}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``4(Nuisho.Elifir.ˣ{Nuisho.Elifir.ˣ.If{``0}.Then{``1}.Else.Then{``2},Nuisho.Elifir.ˣ.If{``2}.Then{``3}},Nuisho.Elifir.AdHocPolyMarker)~Nuisho.Elifir.ˣ.If{``0}.Then{``1}.Else.Then{``3}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround",
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``3(Nuisho.Elifir.ˣ{Nuisho.Elifir.ˣ.If{``0}.Then{``1},Nuisho.Elifir.ˣ.If{``1}.Then{``2}},Nuisho.Elifir.AdHocPolyMarker)~Nuisho.Elifir.ˣ.If{``0}.Then{``2}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``6(Nuisho.Elifir.ˣ{Nuisho.Elifir.ˣ{``0,Nuisho.Elifir.ˣ.If{``1}.Then{``2}.Else.Then{``3}},Nuisho.Elifir.ˣ.If{``3}.Then{``4}.Else.Then{``5}},Nuisho.Elifir.AdHocPolyMarker)~Nuisho.Elifir.ˣ{``0,Nuisho.Elifir.ˣ.If{``1}.Then{``2}.Else.Then{``5}}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``2(Nuisho.Elifir.ˣ.If{``0}.Then{``1},Nuisho.Elifir.AdHocPolyMarker)~System.Func{``0,``1}")]

[assembly: SuppressMessage(
    "Major Bug", 
    "S3453:Classes should not have only \"private\" constructors", 
    Justification = "It was declared for type not for instance", 
    Scope = "type", 
    Target = "~T:Nuisho.Elifir.Syntax.ReturnType`1")]

[assembly: SuppressMessage(
    "Critical Code Smell", 
    "S3218:Inner class members should not shadow outer class \"static\" or type members", 
    Justification = "This name more important than this rule", 
    Scope = "type",
    Target = "~T:Nuisho.Elifir.ˣ.If`1.Then`1.Else.Then`1")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``5(Nuisho.Elifir.ˣ{Nuisho.Elifir.ˣ{``0,Nuisho.Elifir.ˣ.If{``1}.Then{``2}},Nuisho.Elifir.ˣ.If{``2}.Then{``3}.Else.Then{``4}},Nuisho.Elifir.AdHocPolyMarker)~Nuisho.Elifir.ˣ{``0,Nuisho.Elifir.ˣ.If{``1}.Then{``4}}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``4(Nuisho.Elifir.ˣ{Nuisho.Elifir.ˣ{``0,Nuisho.Elifir.ˣ.If{``1}.Then{``2}},Nuisho.Elifir.ˣ.If{``2}.Then{``3}},Nuisho.Elifir.AdHocPolyMarker)~Nuisho.Elifir.ˣ{``0,Nuisho.Elifir.ˣ.If{``1}.Then{``2}}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``4(Nuisho.Elifir.ˣ{System.Func{``0,``1},Nuisho.Elifir.ˣ.If{``1}.Then{``2}.Else.Then{``3}},Nuisho.Elifir.AdHocPolyMarker)~System.Func{``0,``3}")]

[assembly: SuppressMessage(
    "Blocker Code Smell",
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``3(Nuisho.Elifir.ˣ{System.Func{``0,``1},Nuisho.Elifir.ˣ.If{``1}.Then{``2}},Nuisho.Elifir.AdHocPolyMarker)~System.Func{``0,``2}")]

[assembly: SuppressMessage(
    "Blocker Code Smell", 
    "S3427:Method overloads with default parameter values should not overlap", 
    Justification = "It is an Ad Hoc polymorphism limitation workaround", 
    Scope = "member", 
    Target = "~M:Nuisho.Elifir.Syntax.End``4(Nuisho.Elifir.ˣ{Nuisho.Elifir.ˣ.If{``0}.Then{``1},Nuisho.Elifir.ˣ.If{``1}.Then{``2}.Else.Then{``3}},Nuisho.Elifir.AdHocPolyMarker)~Nuisho.Elifir.ˣ.If{``0}.Then{``3}")]

[assembly: SuppressMessage(
    "Major Bug",
    "S3453:Classes should not have only \"private\" constructors",
    Justification = "This class is a type holder to improve type inference and readability.",
    Scope = "type",
    Target = "~T:Nuisho.Elifir.TypeCondition`2")]

[assembly: SuppressMessage(
    "Major Code Smell",
    "S2326:Unused type parameters should be removed",
    Justification = "It is necessary for type holding",
    Scope = "type",
    Target = "~T:Nuisho.Elifir.TypeCondition`2")]

[assembly: SuppressMessage(
    "Major Bug",
    "S3453:Classes should not have only \"private\" constructors",
    Justification = "It is declared only for type not for objects",
    Scope = "type",
    Target = "~T:Nuisho.Elifir.AdHocPolyMarker")]