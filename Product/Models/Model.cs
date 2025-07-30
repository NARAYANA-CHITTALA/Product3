using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models
{
    public enum Billin
    {
        Phonepe,
        Googlepay,
        Cash,
    }
    public class Model
    {
        [Display(GroupName = "Name")]
     //   [Display(Prompt = "Enter your first name", Name = "First name")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(20, ErrorMessage = "First name should not exceed 20 characters")]
        public string FirstName { get; set; }



        [Display(GroupName = "Name")]
      //  [Display(Prompt = "Enter your last name", Name = "Last name")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(20, ErrorMessage = "First name should not exceed 20 characters")]
        public string LastName { get; set; }



        [Display(GroupName = "ContactDetails")]
        
        [DataFormDisplayOptions(ColumnSpan = 2)]
      //  [Display(Prompt = "Enter your number", Name = "Mobile number")]
        
        public int ContactNumber { get; set; }



        [Display(GroupName = "ContactDetails")]
      //  [Display(Prompt = "Enter your email", Name = "Email")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [EmailAddress(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }


        [Display(GroupName = "ContactDetails")]
       // [Display(Prompt = "Enter your password", Name = "Password")]
        [DataType(DataType.Password)]
        [DataFormDisplayOptions(ColumnSpan = 2, ValidMessage = "Password strength is good")]
        [Required(ErrorMessage = "Please enter the password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{8,}$", ErrorMessage = "A minimum 8-character password should contain a combination of uppercase and lowercase letters.")]
        public string Password { get; set; }


        [Display(GroupName = "ContactDetails")]
      //  [Display(Prompt = "Confirm password", Name = "Re-enter Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter the password")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string ConformPassword { get; set; }



        [Display(GroupName = "AddressDetails")]
        [DataType(DataType.MultilineText)]
       // [Display(Prompt = "Enter your address", Name = "Address")]
        [DataFormDisplayOptions(ColumnSpan = 2, RowSpan = 2)]
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }



        [Display(GroupName = "AddressDetails")]
       // [Display(Prompt = "Enter your country", Name = "Country")]
        [Required(ErrorMessage = "Please select your country")]
        public string Country { get; set; }



        [Display(GroupName = "AddressDetails")]
       // [Display(Prompt = "Enter your City", Name = "City")]
        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }

        //[Display(GroupName = " Select the PaymentMethod")]
        
        //public Billin Billing { get; set; }
    }


}
