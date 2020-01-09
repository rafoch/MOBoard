using System;
using AutoFixture;
using AutoFixture.Kernel;

namespace MOBoard.Tests.Common
{
    public static class AutoFixtureExtensions
    {
        public static IFixture WithStandardCustomizations(this IFixture fixture)
        {
            fixture.Customize(new OmitRecursionCustomization());
            return fixture;
        }

        public static void UseGreedyConstructor<T>(this IFixture fixture)
        {
            fixture.Customize<T>(c => c.FromFactory(
                new MethodInvoker(
                    new GreedyConstructorQuery())));
        }
    }
}
