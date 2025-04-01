namespace Nuisho.Elifir.Gen
{
    public class EndGen
    {
        public IEnumerable<string> Generate()
        {
            // (ꞏꞏꞏ, Іf<I>)                      -> (ꞏꞏꞏ, Іf<I>.Then<T>)
            // (ꞏꞏꞏ, Іf<I>.Is<Iʹ>)               -> (ꞏꞏꞏ, Іf<I>.Then<Tʹ>)
            // (ꞏꞏꞏ, Іf<I>.Then<T>)              -> (ꞏꞏꞏ, Іf<I>.Then<Tʹ>)
            // (ꞏꞏꞏ, Іf<I>.Then<T>.Else)         -> (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>)
            // (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) -> (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Eʹ>) 

            yield break;
        }
    }
}
