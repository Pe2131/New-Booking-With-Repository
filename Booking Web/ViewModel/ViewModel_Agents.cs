using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_Agents
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "please fill Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "please fill Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "please fill FullName")]
        public string FullName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "please fill Country")]
        public string Country { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "please fill City")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "please fill Mobile")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "please fill Address")]
        public string Address { get; set; }
        public bool Sex { get; set; }
        public string image { get; set; }
        public IEnumerable<string> RoleNames { get; set; }

        public string GetSex()
        {
            if (Sex == false)
            {
                return "Male";
            }
            else if (Sex == true)
            {
                return "Female";
            }
            else
            {
                return "Not Defined";
            }
        }
    }
}
