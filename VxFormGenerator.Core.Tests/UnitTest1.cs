using Bunit;
using System;
using VxFormGenerator.Core.Layout;
using Xunit;

namespace VxFormGenerator.Core.Tests
{
    public class VxHelpers
    {
        [Fact]
        public void CheckIfPropertyTypeIsFormGroup()
        {
            VxFormGroup.IsFormGroup(typeof(TValue));
        }
    }
}
