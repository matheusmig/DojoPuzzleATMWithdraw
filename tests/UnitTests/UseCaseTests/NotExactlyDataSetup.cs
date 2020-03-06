using Xunit;

namespace UnitTests.UseCaseTests
{
    internal sealed class NotExactlyDataSetup : TheoryData<decimal>
    {
        public NotExactlyDataSetup()
        {
            Add(75.00m);
        }
    }
}
