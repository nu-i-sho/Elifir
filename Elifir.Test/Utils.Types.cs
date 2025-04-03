namespace Nuisho.Elifir.Test
{
    public static partial class Utils
    {
        public record A(int Value);
        public record B(int Value);
        public record C(int Value);
        public record D(int Value);
        public record E(int Value);

        public record Aʹ(int Value) : A(Value);
        public record Bʹ(int Value) : B(Value);
        public record Cʹ(int Value) : C(Value);

        public record Aʺ(int Value) : Aʹ(Value);
        public record Aʺʹ(int Value) : Aʺ(Value);
        public record Aʺʺ(int Value) : Aʺʹ(Value);
        public record Aʺʺʹ(int Value) : Aʺʺ(Value);
        public record Aʺʺʺ(int Value) : Aʺʺʹ(Value);
        public record Aʺʺʺʹ(int Value) : Aʺʺʺ(Value);
        public record Aʺʺʺʺ(int Value) : Aʺʺʺʹ(Value);
        public record Aʺʺʺʺʹ(int Value) : Aʺʺʺʺ(Value);
        public record Aʺʺʺʺʺ(int Value) : Aʺʺʺʺʹ(Value);

        public record Λ(int Value) : A(Value);
        public record Δ(int Value) : A(Value);

        public record ΛΛ(int Value) : Λ(Value);
        public record ΛΔ(int Value) : Λ(Value);

        public record ΔΛ(int Value) : Δ(Value);
        public record ΔΔ(int Value) : Δ(Value);

        public record ΛΛΛ(int Value) : ΛΛ(Value);
        public record ΛΛΔ(int Value) : ΛΛ(Value);

        public record ΛΔΔ(int Value) : ΛΔ(Value);

        public record ΔΛΛ(int Value) : ΔΛ(Value);

        public record ΔΔΛ(int Value) : ΔΔ(Value);
        public record ΔΔΔ(int Value) : ΔΔ(Value);
    }
}
