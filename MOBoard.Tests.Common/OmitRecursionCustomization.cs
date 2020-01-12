using AutoFixture;

namespace MOBoard.Tests.Common
{
    public class OmitRecursionCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}