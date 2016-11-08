using FluentAssertions;
using Xunit;

namespace LightInject.Tests
{
    public sealed class MyTriangulationTests
    {
        [Fact]
        public void MultipleResolveWithScopedLifetime()
        {
            var container = new ServiceContainer();
            container.Register<IFoo, FooA>()
                     .Register<IBar, BarA>(new PerScopeLifetime())
                     .Register<Baz>();

            using (container.BeginScope())
            {
                var first = container.GetInstance<Baz>();
                var second = container.GetInstance<Baz>();

                first.Should().NotBeSameAs(second);
                first.Bar.Should().BeSameAs(second.Bar);
            }
        }

        public interface IFoo { }

        public class FooA : IFoo { }

        public class FooB : IFoo { }

        public interface IBar { }

        public class BarA : IBar
        {
            public readonly IFoo Foo;

            public BarA(IFoo foo)
            {
                Foo = foo;
            }
        }

        public interface IBaz { }

        public class Baz : IBaz
        {
            public readonly IBar Bar;

            public Baz(IBar bar)
            {
                Bar = bar;
            }
        }
    }
}