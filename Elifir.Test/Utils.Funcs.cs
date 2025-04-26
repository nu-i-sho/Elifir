namespace Nuisho.Elifir.Test;

public static partial class Utils
{
    internal static Func<int, Func<int, int>> Add => x => y => x + y;

    internal static Func<int, bool> Even => x => x % 2 == 0;
    internal static Func<int, bool> Odd  => x => x % 2 != 0;

    internal static Func<int, Func<int, bool>> MoreThen => x => y => y > x;
    internal static Func<int, Func<int, bool>> LessThen => x => y => y < x;

    internal static Func<string, Func<int, bool>> EndingWith => x => y => y.ToString().EndsWith(x);
    internal static Func<string, Func<int, bool>> StartingWith => x => y => y.ToString().StartsWith(x);

    internal static Func<Func<int, bool>, Func<A, bool>> A_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<B, bool>> B_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<C, bool>> C_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<D, bool>> D_Is => f => x => f(x.Value);

    internal static Func<Func<int, bool>, Func<Aʹ, bool>> Aʹ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Bʹ, bool>> Bʹ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Cʹ, bool>> Cʹ_Is => f => x => f(x.Value);

    internal static Func<Func<int, bool>, Func<Aʺ, bool>> Aʺ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Aʺʹ, bool>> Aʺʹ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Aʺʺ, bool>> Aʺʺ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Aʺʺʹ, bool>> Aʺʺʹ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Aʺʺʺ, bool>> Aʺʺʺ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Aʺʺʺʹ, bool>> Aʺʺʺʹ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Aʺʺʺʺ, bool>> Aʺʺʺʺ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Aʺʺʺʺʹ, bool>> Aʺʺʺʺʹ_Is => f => x => f(x.Value);

    internal static Func<Func<int, bool>, Func<Λ, bool>> Λ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<Δ, bool>> Δ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<ΛΛ, bool>> ΛΛ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<ΛΔ, bool>> ΛΔ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<ΔΛ, bool>> ΔΛ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<ΔΔ, bool>> ΔΔ_Is => f => x => f(x.Value);

    internal static Func<Func<int, bool>, Func<ΔΔΔ, bool>> ΔΔΔ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<ΛΛΛ, bool>> ΛΛΛ_Is => f => x => f(x.Value);
    internal static Func<Func<int, bool>, Func<ΛΔΔ, bool>> ΛΔΔ_Is => f => x => f(x.Value);

    internal static Func<Func<int, int>, Func<A, A>> From_A_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, B>> From_A_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, C>> From_A_To_C_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, D>> From_A_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, E>> From_A_To_E_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<A, Aʹ>> From_A_To_Aʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, Bʹ>> From_A_To_Bʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, Cʹ>> From_A_To_Cʹ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<B, A>> From_B_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, B>> From_B_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, C>> From_B_To_C_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, D>> From_B_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, E>> From_B_To_E_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<B, Aʹ>> From_B_To_Aʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, Bʹ>> From_B_To_Bʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, Cʹ>> From_B_To_Cʹ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<C, A>> From_C_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<C, B>> From_C_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<C, D>> From_C_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<C, E>> From_C_To_E_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<C, Aʹ>> From_C_To_Aʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<C, Bʹ>> From_C_To_Bʹ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<D, A>> From_D_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, B>> From_D_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, C>> From_D_To_C_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, E>> From_D_To_E_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<D, Aʹ>> From_D_To_Aʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺ>> From_D_To_Aʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺʹ>> From_D_To_Aʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺʺ>> From_D_To_Aʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺʺʹ>> From_D_To_Aʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺʺʺ>> From_D_To_Aʺʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺʺʺʹ>> From_D_To_Aʺʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺʺʺʺ>> From_D_To_Aʺʺʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺʺʺʺʹ>> From_D_To_Aʺʺʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Aʺʺʺʺʺ>> From_D_To_Aʺʺʺʺʺ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<D, Bʹ>> From_D_To_Bʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Cʹ>> From_D_To_Cʹ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<E, A>> From_E_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, B>> From_E_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, C>> From_E_To_C_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, D>> From_E_To_D_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<E, Aʹ>> From_E_To_Aʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, Bʹ>> From_E_To_Bʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, Cʹ>> From_E_To_Cʹ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Aʹ, A>> From_Aʹ_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʹ, B>> From_Aʹ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʹ, C>> From_Aʹ_To_C_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʹ, D>> From_Aʹ_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʹ, E>> From_Aʹ_To_E_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Aʹ, Aʹ>> From_Aʹ_To_Aʹ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Bʹ, A>> From_Bʹ_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Bʹ, B>> From_Bʹ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Bʹ, E>> From_Bʹ_To_E_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Cʹ, A>> From_Cʹ_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Cʹ, B>> From_Cʹ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Cʹ, E>> From_Cʹ_To_E_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Aʺ, A>> From_Aʺ_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʹ, A>> From_Aʺʹ_To_A_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Aʹ, Aʺ>> From_Aʹ_To_Aʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺ, Aʺʹ>> From_Aʺ_To_Aʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʹ, Aʺʺ>> From_Aʺʹ_To_Aʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺ, Aʺʺʹ>> From_Aʺʺ_To_Aʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʹ, Aʺʺʺ>> From_Aʺʺʹ_To_Aʺʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺ, Aʺʺʺʹ>> From_Aʺʺʺ_To_Aʺʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺʹ, Aʺʺʺʺ>> From_Aʺʺʺʹ_To_Aʺʺʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺʺ, Aʺʺʺʺʹ>> From_Aʺʺʺʺ_To_Aʺʺʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺʺʹ, Aʺʺʺʺʺ>> From_Aʺʺʺʺʹ_To_Aʺʺʺʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺʺʺ, Aʺʺʺʺʹ>> From_Aʺʺʺʺʺ_To_Aʺʺʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺʺʹ, Aʺʺʺʺ>> From_Aʺʺʺʺʹ_To_Aʺʺʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺʺ, Aʺʺʺʹ>> From_Aʺʺʺʺ_To_Aʺʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺʹ, Aʺʺʺ>> From_Aʺʺʺʹ_To_Aʺʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺ, Aʺʺʹ>> From_Aʺʺʺ_To_Aʺʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʹ, Aʺʺ>> From_Aʺʺʹ_To_Aʺʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺ, Aʺʹ>> From_Aʺʺ_To_Aʺʹ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʹ, Aʺ>> From_Aʺʹ_To_Aʺ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺ, Aʹ>> From_Aʺ_To_Aʹ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Aʺ, E>> From_Aʺ_To_E_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʺʺʺʹ, E>> From_Aʺʺʺʹ_To_E_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, Aʺ>> From_A_To_Aʺ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<A, Λ>> From_A_To_Λ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Λ, Λ>> From_Λ_To_Λ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Λ, Δ>> From_Λ_To_Δ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Δ, Λ>> From_Δ_To_Λ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Λ, ΛΔ>> From_Λ_To_ΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Λ, ΛΛ>> From_Λ_To_ΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, Λ>> From_ΛΛ_To_Λ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Λ, ΔΔ>> From_Λ_To_ΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔ, Δ>> From_ΔΔ_To_Δ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Δ, ΔΔ>> From_Δ_To_ΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, Δ>> From_ΛΛ_To_Δ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Δ, ΛΔ>> From_Δ_To_ΛΔ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<ΔΔ, ΔΛ>> From_ΔΔ_To_ΔΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, ΛΛ>> From_ΛΛ_To_ΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, ΛΔ>> From_ΛΛ_To_ΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΔ, ΛΛ>> From_ΛΔ_To_ΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔ, ΛΔ>> From_ΔΔ_To_ΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, ΔΔ>> From_ΛΛ_To_ΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΔ, ΛΔ>> From_ΛΔ_To_ΛΔ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<ΔΔΔ, B>> From_ΔΔΔ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Λ, ΔΔΔ>> From_Λ_To_ΔΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔ, ΔΔΔ>> From_ΔΔ_To_ΔΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛΛ, ΛΛΔ>> From_ΛΛΛ_To_ΛΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, ΛΛΔ>> From_ΛΛ_To_ΛΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, ΛΛΛ>> From_ΛΛ_To_ΛΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΔΔ, Δ>> From_ΛΔΔ_To_Δ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Λ, A>> From_Λ_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, Δ>> From_A_To_Δ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, Λ>> From_B_To_Λ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, Δ>> From_B_To_Δ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Δ, B>> From_Δ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, Λ>> From_E_To_Λ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, Δ>> From_E_To_Δ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Δ, E>> From_Δ_To_E_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Λ, B>> From_Λ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Λ>> From_D_To_Λ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, Δ>> From_D_To_Δ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Δ, C>> From_Δ_To_C_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<C, Λ>> From_C_To_Λ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<A, ΛΔ>> From_A_To_ΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔ, A>> From_ΔΔ_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, ΔΔ>> From_A_To_ΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, ΛΛ>> From_B_To_ΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, D>> From_ΛΛ_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, ΛΔ>> From_D_To_ΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, ΔΛ>> From_D_To_ΔΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΛ, D>> From_ΔΛ_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔ, D>> From_ΔΔ_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, ΔΔ>> From_D_To_ΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, ΛΛ>> From_D_To_ΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, ΔΔ>> From_E_To_ΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, ΛΛ>> From_E_To_ΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔ, E>> From_ΔΔ_To_E_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, ΔΛ>> From_B_To_ΔΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, ΔΔ>> From_B_To_ΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔ, B>> From_ΔΔ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛ, B>> From_ΛΛ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔ, C>> From_ΔΔ_To_C_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, ΛΔ>> From_B_To_ΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, ΛΛ>> From_A_To_ΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Δ, ΛΛ>> From_Δ_To_ΛΛ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<Aʹ, Λ>> From_Aʹ_To_Λ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʹ, Δ>> From_Aʹ_To_Δ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʹ, ΔΔ>> From_Aʹ_To_ΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<Aʹ, ΛΛ>> From_Aʹ_To_ΛΛ_With => f => x => new (f(x.Value));

    internal static Func<Func<int, int>, Func<A, ΛΛΔ>> From_A_To_ΛΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛΛ, A>> From_ΛΛΛ_To_A_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛΛ, D>> From_ΛΛΛ_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, ΛΛΛ>> From_B_To_ΛΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, ΔΔΔ>> From_B_To_ΔΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<D, ΛΛΛ>> From_D_To_ΛΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛΛ, E>> From_ΛΛΛ_To_E_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, ΛΛΛ>> From_E_To_ΛΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛΔ, D>> From_ΛΛΔ_To_D_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<B, ΛΛΔ>> From_B_To_ΛΛΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔΔ, C>> From_ΔΔΔ_To_C_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔΛ, E>> From_ΔΔΛ_To_E_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, ΔΔΛ>> From_E_To_ΔΔΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΛΛΛ, B>> From_ΛΛΛ_To_B_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<ΔΔΔ, E>> From_ΔΔΔ_To_E_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<E, ΔΔΔ>> From_E_To_ΔΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, ΛΛΛ>> From_A_To_ΛΛΛ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, ΛΔΔ>> From_A_To_ΛΔΔ_With => f => x => new (f(x.Value));
    internal static Func<Func<int, int>, Func<A, ΔΛΛ>> From_A_To_ΔΛΛ_With => f => x => new (f(x.Value));

    internal static Func<bool, Func<Func<int, int>, Func<A, A>>> From_A_To_A_OrTo_Λ =>
        toΛ => toΛ ? From_A_To_Λ_With
                   : From_A_To_A_With;

    internal static Func<bool, Func<Func<int, int>, Func<A, A>>> From_A_To_A_OrTo_Aʹ =>
        toAʹ => toAʹ ? From_A_To_Aʹ_With
                     : From_A_To_A_With;

    internal static Func<bool, Func<Func<int, int>, Func<Aʹ, A>>> From_Aʹ_To_A_OrTo_Aʹ =>
        toAʹ => toAʹ ? From_Aʹ_To_Aʹ_With
                     : From_Aʹ_To_A_With;

    internal static Func<bool, Func<Func<int, int>, Func<A, Aʹ>>> From_A_To_Aʹ_OrTo_Aʺ =>
        toAʺ => toAʺ ? From_A_To_Aʺ_With
                     : From_A_To_Aʹ_With;

    internal static Func<bool, Func<Func<int, int>, Func<D, C>>> From_D_To_C_OrTo_Cʹ =>
        toCʹ => toCʹ ? From_D_To_Cʹ_With
                     : From_D_To_C_With;

    internal static Func<bool, Func<Func<int, int>, Func<B, C>>> From_B_To_C_OrTo_Cʹ =>
        toCʹ => toCʹ ? From_B_To_Cʹ_With
                     : From_B_To_C_With;

    internal static Func<bool, Func<Func<int, int>, Func<B, B>>> From_B_To_B_OrTo_Bʹ =>
        toBʹ => toBʹ ? From_B_To_Bʹ_With
                     : From_B_To_B_With;

    internal static Func<bool, Func<Func<int, int>, Func<B, ΛΛ>>> From_B_To_ΛΛ_OrTo_ΛΛΛ =>
        toΛΛΛ => toΛΛΛ ? From_B_To_ΛΛΛ_With
                       : From_B_To_ΛΛ_With;

    internal static Func<bool, Func<Func<int, int>, Func<E, ΛΛ>>> From_E_To_ΛΛ_OrTo_ΛΛΛ =>
        toΛΛΛ => toΛΛΛ ? From_E_To_ΛΛΛ_With
                       : From_E_To_ΛΛ_With;

    internal static Func<bool, Func<Func<int, int>, Func<D, ΛΛ>>> From_D_To_ΛΛ_OrTo_ΛΛΛ =>
        toΛΛΛ => toΛΛΛ ? From_D_To_ΛΛΛ_With
                       : From_D_To_ΛΛ_With;

    internal static Func<bool, Func<Func<int, int>, Func<Λ, Δ>>> From_Λ_To_Δ_OrTo_ΔΔ =>
        toΔΔ => toΔΔ ? From_Λ_To_ΔΔ_With
                     : From_Λ_To_Δ_With;

    internal static Func<bool, Func<Func<int, int>, Func<Λ, ΔΔ>>> From_Λ_To_ΔΔ_OrTo_ΔΔΔ =>
        toΔΔΔ => toΔΔΔ ? From_Λ_To_ΔΔΔ_With
                       : From_Λ_To_ΔΔ_With;

    internal static Func<bool, Func<Func<int, int>, Func<D, Λ>>> From_D_To_Λ_OrTo_ΛΛ =>
        toΛΛ => toΛΛ ? From_D_To_ΛΛ_With
                     : From_D_To_Λ_With;

    internal static Func<bool, Func<Func<int, int>, Func<D, Δ>>> From_D_To_Δ_OrTo_ΔΔ =>
        toΔΔ => toΔΔ ? From_D_To_ΔΔ_With
                     : From_D_To_Δ_With;

    internal static Func<bool, Func<Func<int, int>, Func<B, ΛΛ>>> From_B_To_ΛΛ_OrTo_ΛΛΔ =>
        toΛΛΔ => toΛΛΔ ? From_B_To_ΛΛΔ_With
                       : From_B_To_ΛΛ_With;

    internal static Func<bool, Func<Func<int, int>, Func<E, ΔΔ>>> From_E_To_ΔΔ_OrTo_ΔΔΛ =>
        toΔΔΛ => toΔΔΛ ? From_E_To_ΔΔΛ_With
                       : From_E_To_ΔΔ_With;

    internal static Func<bool, Func<Func<int, int>, Func<B, ΔΔ>>> From_B_To_ΔΔ_OrTo_ΔΔΔ =>
        toΔΔΔ => toΔΔΔ ? From_B_To_ΔΔΔ_With
                       : From_B_To_ΔΔ_With;

    internal static Func<bool, Func<Func<int, int>, Func<Λ, Λ>>> From_Λ_To_Λ_OrTo_ΛΛ =>
        toΛΛ => toΛΛ ? From_Λ_To_ΛΛ_With
                     : From_Λ_To_Λ_With;

    internal static Func<bool, Func<Func<int, int>, Func<E, ΔΔ>>> From_E_To_ΔΔ_OrTo_ΔΔΔ =>
        toΔΔΔ => toΔΔΔ ? From_E_To_ΔΔΔ_With
                       : From_E_To_ΔΔ_With;

    internal static Func<string, Func<Func<int, int>, Func<E, Λ>>> From_E_To_Λ_OrTo_ΛΛ_OrTo_ΛΛΛ =>
        to => to switch
        {
            "Λ" => From_E_To_Λ_With,
            "ΛΛ" => From_E_To_ΛΛ_With,
            "ΛΛΛ" => From_E_To_ΛΛΛ_With,
            _ => throw new NotSupportedException()
        };

    internal static Func<string, Func<Func<int, int>, Func<D, A>>> From_D_To_SomeA =>
        to => to switch
        {
            "A" => From_D_To_A_With,
            "Aʹ" => From_D_To_Aʹ_With,
            "Aʺ" => From_D_To_Aʺ_With,
            "Aʺʹ" => From_D_To_Aʺʹ_With,
            "Aʺʺ" => From_D_To_Aʺʺ_With,
            "Aʺʺʹ" => From_D_To_Aʺʺʹ_With,
            "Aʺʺʺ" => From_D_To_Aʺʺʺ_With,
            "Aʺʺʺʹ" => From_D_To_Aʺʺʺʹ_With,
            "Aʺʺʺʺ" => From_D_To_Aʺʺʺʺ_With,
            "Aʺʺʺʺʹ" => From_D_To_Aʺʺʺʺʹ_With,
            "Aʺʺʺʺʺ" => From_D_To_Aʺʺʺʺʺ_With,
            _ => throw new InvalidOperationException()
        };

    internal static Func<string, Func<Func<int, int>, Func<D, Aʹ>>> From_D_To_SomeAʹ =>
        to => f => x => (Aʹ)From_D_To_SomeA(to)(f)(x);

    internal static Func<string, Func<int, A>> From_Int_To_SomeA =>
        to => x => to switch
        {
            "A" => new A(x),
            "Aʹ" => new Aʹ(x),
            "Aʺ" => new Aʺ(x),
            "Aʺʹ" => new Aʺʹ(x),
            "Aʺʺ" => new Aʺʺ(x),
            "Aʺʺʹ" => new Aʺʺʹ(x),
            "Aʺʺʺ" => new Aʺʺʺ(x),
            "Aʺʺʺʹ" => new Aʺʺʺʹ(x),
            "Aʺʺʺʺ" => new Aʺʺʺʺ(x),
            "Aʺʺʺʺʹ" => new Aʺʺʺʺʹ(x),
            "Aʺʺʺʺʺ" => new Aʺʺʺʺʺ(x),
            _ => throw new InvalidOperationException()
        };

    internal static Func<string, Func<int, Aʹ>> From_Int_To_SomeAʹ =>
        to => x => (Aʹ)From_Int_To_SomeA(to)(x);
}
