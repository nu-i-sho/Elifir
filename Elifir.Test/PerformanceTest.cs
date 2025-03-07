namespace Nuisho.Elifir.Test
{
    using System.Diagnostics;
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class PerformanceTest
    {
        [Test]
        public void IfThe_10x_Test()
        {
            // Release mode:
            //      readonly struct:
            //          elifir: 00:00:20.9410000
            //          native: 00:00:09.4360000
            //      class:
            //          elifir: 00:00:12.7150000
            //          native: 00:00:08.3320000

            var native = Stopwatch.StartNew();

            int nativeResult = 0;
            for (int i = 0; i < 100000000; i++)
                unchecked { nativeResult += Native_IfThen_10x(i); }

            native.Stop();

            var elifir = Stopwatch.StartNew();

            int elifirResult = 0;
            for (int i = 0; i < 100000000; i++)
                unchecked { elifirResult += Elifir_IfThen_10x(i); }

            elifir.Stop();

            Console.WriteLine($"native: {TimeSpan.FromMilliseconds(native.ElapsedMilliseconds)}");
            Console.WriteLine($"elifir: {TimeSpan.FromMilliseconds(elifir.ElapsedMilliseconds)}");

            Assert.Multiple(() =>
            {
                Assert.That(elifirResult, Is.EqualTo(nativeResult));
                Assert.That(elifir.ElapsedMilliseconds,
                    Is.LessThan(native.ElapsedMilliseconds * 3));
            });
        }

        private static readonly Func<A, A> _elifir_IfThen_10x = 
            If((A x) => x.Value > 10)
                .Then(x => new A(x.Value + 1))
                .If((A x) => x.Value > 20)
                    .Then(x => new A(x.Value + 1))
                    .If((A x) => x.Value > 30)
                        .Then(x => new A(x.Value + 1))
                        .If((A x) => x.Value > 40)
                            .Then(x => new A(x.Value + 1))
                            .If((A x) => x.Value > 50)
                                .Then(x => new A(x.Value + 1))
                                .If((A x) => x.Value > 60)
                                    .Then(x => new A(x.Value + 1))
                                    .If((A x) => x.Value > 70)
                                        .Then(x => new A(x.Value + 1))
                                        .If((A x) => x.Value > 80)
                                            .Then(x => new A(x.Value + 1))
                                            .If((A x) => x.Value > 90)
                                                .Then(x => new A(x.Value + 1))
                                                .If((A x) => x.Value > 100)
                                                    .Then(x => new A(x.Value + 1))
                                                .End()
                                            .End()
                                        .End()
                                    .End()
                                .End()
                            .End()
                        .End()
                    .End()
                .End()
            .End();

        private static int Elifir_IfThen_10x(int x) => 
            _elifir_IfThen_10x(new (x)).Value;

        private static int Native_IfThen_10x(int x)
        {
            A result = new(x);

            if (x > 10)
            {
                result = new(result.Value + 1);
                if (x > 20)
                {
                    result = new(result.Value + 1);
                    if (x > 30)
                    {
                        result = new(result.Value + 1);
                        if (x > 40)
                        {
                            result = new(result.Value + 1);
                            if (x > 50)
                            {
                                result = new(result.Value + 1);
                                if (x > 60)
                                {
                                    result = new(result.Value + 1);
                                    if (x > 70)
                                    {
                                        result = new(result.Value + 1);
                                        if (x > 80)
                                        {
                                            result = new(result.Value + 1);
                                            if (x > 90)
                                            {
                                                result = new(result.Value + 1);
                                                if (x > 100)
                                                {
                                                    result = new(result.Value + 1);
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result.Value;
        }
    }
}
