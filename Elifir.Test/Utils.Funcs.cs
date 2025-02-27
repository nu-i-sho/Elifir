namespace Nuisho.Elifir.Test
{
    public static partial class Utils
    {
        public static Func<int, int> Plus(int x) => y => x + y;

        public static Func<int, bool> Even => x => x % 2 == 0;

        public static Func<int, bool> Odd => x => x % 2 != 0;

        public static Func<int, bool> MoreThen(int x) => y => y > x;

        public static Func<A, bool> A_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<B, bool> B_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<C, bool> C_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<D, bool> D_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<E, bool> E_Is(Func<int, bool> f) => x => f(x.Value);

        public static Func<Aʹ, bool> Aʹ_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<Bʹ, bool> Bʹ_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<Cʹ, bool> Cʹ_Is(Func<int, bool> f) => x => f(x.Value);

        public static Func<A, A> From_A_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, B> From_A_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, C> From_A_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, D> From_A_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, E> From_A_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<A, Aʹ> From_A_To_Aʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, Bʹ> From_A_To_Bʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, Cʹ> From_A_To_Cʹ_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<B, A> From_B_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, B> From_B_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, C> From_B_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, D> From_B_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, E> From_B_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<B, Aʹ> From_B_To_Aʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, Bʹ> From_B_To_Bʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, Cʹ> From_B_To_Cʹ_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<C, A> From_C_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, B> From_C_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, C> From_C_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, D> From_C_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, E> From_C_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<C, Aʹ> From_C_To_Aʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, Bʹ> From_C_To_Bʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, Cʹ> From_C_To_Cʹ_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<D, A> From_D_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, B> From_D_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, C> From_D_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, D> From_D_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, E> From_D_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<D, Aʹ> From_D_To_Aʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, Bʹ> From_D_To_Bʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, Cʹ> From_D_To_Cʹ_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<E, A> From_E_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, B> From_E_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, C> From_E_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, D> From_E_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, E> From_E_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<E, Aʹ> From_E_To_Aʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, Bʹ> From_E_To_Bʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, Cʹ> From_E_To_Cʹ_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<Aʹ, A> From_Aʹ_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Aʹ, B> From_Aʹ_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Aʹ, C> From_Aʹ_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Aʹ, D> From_Aʹ_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Aʹ, E> From_Aʹ_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<Aʹ, Aʹ> From_Aʹ_To_Aʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Aʹ, Bʹ> From_Aʹ_To_Bʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Aʹ, Cʹ> From_Aʹ_To_Cʹ_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<Bʹ, A> From_Bʹ_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Bʹ, B> From_Bʹ_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Bʹ, C> From_Bʹ_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Bʹ, D> From_Bʹ_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Bʹ, E> From_Bʹ_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<Bʹ, Aʹ> From_Bʹ_To_Aʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Bʹ, Bʹ> From_Bʹ_To_Bʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Bʹ, Cʹ> From_Bʹ_To_Cʹ_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<Cʹ, A> From_Cʹ_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Cʹ, B> From_Cʹ_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Cʹ, C> From_Cʹ_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Cʹ, D> From_Cʹ_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Cʹ, E> From_Cʹ_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<Cʹ, Aʹ> From_Cʹ_To_Aʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Cʹ, Bʹ> From_Cʹ_To_Bʹ_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<Cʹ, Cʹ> From_Cʹ_To_Cʹ_With(Func<int, int> f) => x => new(f(x.Value));
    }
}
