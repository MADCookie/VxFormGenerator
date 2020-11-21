using System.ComponentModel.DataAnnotations;
using VxFormGenerator.Core.Layout;
using VxFormGeneratorDemoData;

namespace VxFormGeneratorDemoData
{
    [VxFormDefinition]
    public class OrderViewModel
    {
        [VxFormGroup]
        public AddressViewModel Address { get; set; } = new AddressViewModel();

        [VxFormGroup]
        public AddressViewModel BillingAddress { get; set; } = new AddressViewModel();

        [Display(Name = "State")]
        public string State { get; set; }
    }
}
