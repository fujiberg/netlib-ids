using System.Threading.Tasks;
using Fujiberg.Identifiers;
using Xunit;

namespace Identifiers.Tests;

public sealed class TypeIdAttributeTests
{
    public TypeIdAttributeTests()
    {
        SourceHelpers.Repeatable = true;
    }

    [Fact]
    public async Task GenerateCorrectly()
    {
        await SourceGeneratorTestHelpers.TestSourceGeneratorsAsync(
            [new TypedIdAttributeGenerator()],
            [
                """
                using Fujiberg.Identifiers;
                namespace MyNamespace
                {
                    [TypedIdAttribute]
                    public partial record struct SomeId;
                }
                """
            ]
        );
    }
}
