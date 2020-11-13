using System.ComponentModel.DataAnnotations;
using VxFormGenerator.Core.Layout;
using VxFormGeneratorDemoData;

namespace VxFormGeneratorDemoData
{
    [VxFormDefinition]
    public class OrderViewModel
    {
        [VxFormGroup]
        public AddressViewModel Address { get; set; }
        [VxFormGroup]
        public AddressViewModel BillingAddress { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
    }
}
