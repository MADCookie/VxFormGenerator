using Bunit;
using System;
using VxFormGenerator.Core.Layout;
using VxFormGeneratorDemoData;
using Xunit;

namespace VxFormGenerator.Core.Tests
{
    public class VxHelpers
    {
        [Fact]
        public void CreateVxColumn()
        {
            var definition = VxFormDefinition.CreateFromModel(typeof(AddressViewModel));

        }
    }
}
