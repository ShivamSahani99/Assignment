using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Assignment.DTO
{
    [DataContract]
    public class CustomerDTO
    {

        [DataMember(EmitDefaultValue = false)]
        public Guid CustomerId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage ="Customer name required..")]
        public string? CustomerName { get; set; }
        [DataMember(EmitDefaultValue = false)]
       
        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string? PhoneNo { get; set; }
        [DataMember(EmitDefaultValue = false)]

        public string? Address { get; set; }
       
    }
}
