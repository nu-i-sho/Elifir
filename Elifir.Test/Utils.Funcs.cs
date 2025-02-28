namespace Nuisho.Elifir.Test
{
    public static partial class Utils
    {
        public static Func<int, Func<int, int>> Plus => x => y => x + y;

        public static Func<int, bool> Even => x => x % 2 == 0;

        public static Func<int, bool> Odd => x => x % 2 != 0;

        public static Func<int, Func<int, bool>> MoreThen => x => y => y > x;

        public static Func<Func<int, bool>, Func<A, bool>> A_Is = f => x => f(x.Value);
        public static Func<Func<int, bool>, Func<B, bool>> B_Is = f => x => f(x.Value);
        public static Func<Func<int, bool>, Func<C, bool>> C_Is = f => x => f(x.Value);
        public static Func<Func<int, bool>, Func<D, bool>> D_Is = f => x => f(x.Value);
        public static Func<Func<int, bool>, Func<E, bool>> E_Is = f => x => f(x.Value);

        public static Func<Func<int, bool>, Func<Aʹ, bool>> Aʹ_Is = f => x => f(x.Value);
        public static Func<Func<int, bool>, Func<Bʹ, bool>> Bʹ_Is = f => x => f(x.Value);
        public static Func<Func<int, bool>, Func<Cʹ, bool>> Cʹ_Is = f => x => f(x.Value);

        public static Func<Func<int, int>, Func<A, A>> From_A_To_A_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<A, B>> From_A_To_B_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<A, C>> From_A_To_C_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<A, D>> From_A_To_D_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<A, E>> From_A_To_E_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<A, Aʹ>> From_A_To_Aʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<A, Bʹ>> From_A_To_Bʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<A, Cʹ>> From_A_To_Cʹ_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<B, A>> From_B_To_A_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<B, B>> From_B_To_B_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<B, C>> From_B_To_C_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<B, D>> From_B_To_D_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<B, E>> From_B_To_E_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<B, Aʹ>> From_B_To_Aʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<B, Bʹ>> From_B_To_Bʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<B, Cʹ>> From_B_To_Cʹ_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<C, A>> From_C_To_A_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<C, B>> From_C_To_B_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<C, C>> From_C_To_C_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<C, D>> From_C_To_D_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<C, E>> From_C_To_E_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<C, Aʹ>> From_C_To_Aʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<C, Bʹ>> From_C_To_Bʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<C, Cʹ>> From_C_To_Cʹ_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<D, A>> From_D_To_A_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<D, B>> From_D_To_B_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<D, C>> From_D_To_C_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<D, D>> From_D_To_D_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<D, E>> From_D_To_E_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<D, Aʹ>> From_D_To_Aʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<D, Bʹ>> From_D_To_Bʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<D, Cʹ>> From_D_To_Cʹ_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<E, A>> From_E_To_A_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<E, B>> From_E_To_B_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<E, C>> From_E_To_C_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<E, D>> From_E_To_D_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<E, E>> From_E_To_E_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<E, Aʹ>> From_E_To_Aʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<E, Bʹ>> From_E_To_Bʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<E, Cʹ>> From_E_To_Cʹ_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<Aʹ, A>> From_Aʹ_To_A_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Aʹ, B>> From_Aʹ_To_B_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Aʹ, C>> From_Aʹ_To_C_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Aʹ, D>> From_Aʹ_To_D_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Aʹ, E>> From_Aʹ_To_E_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<Aʹ, Aʹ>> From_Aʹ_To_Aʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Aʹ, Bʹ>> From_Aʹ_To_Bʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Aʹ, Cʹ>> From_Aʹ_To_Cʹ_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<Bʹ, A>> From_Bʹ_To_A_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Bʹ, B>> From_Bʹ_To_B_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Bʹ, C>> From_Bʹ_To_C_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Bʹ, D>> From_Bʹ_To_D_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Bʹ, E>> From_Bʹ_To_E_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<Bʹ, Aʹ>> From_Bʹ_To_Aʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Bʹ, Bʹ>> From_Bʹ_To_Bʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Bʹ, Cʹ>> From_Bʹ_To_Cʹ_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<Cʹ, A>> From_Cʹ_To_A_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Cʹ, B>> From_Cʹ_To_B_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Cʹ, C>> From_Cʹ_To_C_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Cʹ, D>> From_Cʹ_To_D_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Cʹ, E>> From_Cʹ_To_E_With = f => x => new(f(x.Value));

        public static Func<Func<int, int>, Func<Cʹ, Aʹ>> From_Cʹ_To_Aʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Cʹ, Bʹ>> From_Cʹ_To_Bʹ_With = f => x => new(f(x.Value));
        public static Func<Func<int, int>, Func<Cʹ, Cʹ>> From_Cʹ_To_Cʹ_With = f => x => new(f(x.Value));
    }
}
