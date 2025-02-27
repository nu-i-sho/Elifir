namespace Nuisho.Elifir.Test
{
    public static partial class Utils
    {
        public static Func<int, int> Plus(int x) => y => x + y;

        public static Func<int, bool> Even => x => x % 2 == 0;

        public static Func<int, bool> Odd => x => x % 2 != 0;

        public static Func<A, bool> A_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<B, bool> B_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<C, bool> C_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<D, bool> D_Is(Func<int, bool> f) => x => f(x.Value);
        public static Func<E, bool> E_Is(Func<int, bool> f) => x => f(x.Value);

        public static Func<A, A> From_A_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, B> From_A_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, C> From_A_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, D> From_A_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<A, E> From_A_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<B, A> From_B_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, B> From_B_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, C> From_B_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, D> From_B_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<B, E> From_B_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<C, A> From_C_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, B> From_C_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, C> From_C_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, D> From_C_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<C, E> From_C_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<D, A> From_D_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, B> From_D_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, C> From_D_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, D> From_D_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<D, E> From_D_To_E_With(Func<int, int> f) => x => new(f(x.Value));

        public static Func<E, A> From_E_To_A_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, B> From_E_To_B_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, C> From_E_To_C_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, D> From_E_To_D_With(Func<int, int> f) => x => new(f(x.Value));
        public static Func<E, E> From_E_To_E_With(Func<int, int> f) => x => new(f(x.Value));
    }
}
