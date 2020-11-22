using System.ComponentModel.DataAnnotations;
using VxFormGenerator.Core.Layout;
using VxFormGenerator.Core.Validation;
using VxFormGeneratorDemoData;

namespace VxFormGeneratorDemoData
{
    [VxFormDefinition]
    public class OrderViewModel
    {
        [VxFormGroup]
        [ValidateComplexType]
        public AddressViewModel Address { get; set; } = new AddressViewModel();

        [VxFormGroup]
        [ValidateComplexType]
        public AddressViewModel BillingAddress { get; set; } = new AddressViewModel();

        [Display(Name = "State")]
        [MinLength(5)]
        public string State { get; set; }
    }
}
