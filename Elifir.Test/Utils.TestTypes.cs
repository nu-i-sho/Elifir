namespace Nuisho.Elifir.Test
{
    public static partial class Utils
    {
        public interface IWrappedInt
        {
            public int Value { get; }
        }

        public record A(int Value) : IWrappedInt;
        public record B(int Value) : IWrappedInt;
        public record C(int Value) : IWrappedInt;
        public record D(int Value) : IWrappedInt;
        public record E(int Value) : IWrappedInt;

    }
}
