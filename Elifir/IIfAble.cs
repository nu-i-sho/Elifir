namespace Nuisho.Elifir
{
    public interface IIfAble<Prev, I>
    {
        ˣ<Prev, ˣIf<I>> If(Func<I, bool> condition);

        ˣ<Prev, ˣIf<I>.Is<Iʹ>> If<Iʹ>(Func<TypeCondition<I, Iʹ>> condition)
            where Iʹ : I;
    }
}
