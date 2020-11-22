using System.ComponentModel.DataAnnotations;
using VxFormGenerator.Core.Layout;


namespace VxFormGeneratorDemoData
{
    [VxFormRowLayout(Id=2, Name = "Adress")]
    public class AddressViewModel
    {
        [Display(Name = "Surname")]
        [VxFormLayout(RowId = 1)]
        public string SurName { get; set; }
        [VxFormLayout(RowId = 1)]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }


        [Display(Name = "Street")]
        [VxFormLayout(RowId = 2, ColSpan = 10)]
        [MinLength(5)]
        public string Street { get; set; }

        [Display(Name = "Number")]
        [VxFormLayout(RowId = 2, ColSpan = 2)]
        public string Number { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
    }
}
