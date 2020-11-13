using System.ComponentModel.DataAnnotations;
using VxFormGenerator.Core.Layout;


namespace VxFormGeneratorDemoData
{
    public class AddressViewModel
    {
        [Display(Name = "Surname")]
        [VxFormRow(1)]
        public string SurName { get; set; }
        [VxFormRow(1)]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }


        [Display(Name = "Street")]
        [VxFormRow(2)]
        [VxFormColumn(10)]
        public string Street { get; set; }

        [Display(Name = "Number")]
        [VxFormRow(2)]
        [VxFormColumn(2)]
        public string Number { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
    }
}
