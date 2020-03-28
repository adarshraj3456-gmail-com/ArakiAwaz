using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArakiAwaz.dto
{
    public class memberform
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Must Provide Name")]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid  Name")]
        [Display(Name = "Name")]
        public string membername { get; set; }


        [Remote("IsAlreadySigned", "Home", HttpMethod = "POST", ErrorMessage = "EmailId already exists")]
        [DataType(DataType.EmailAddress)]
        [Display(Name= "Email Address")]
        public string memberemail { get; set; }


        [Remote("IsAlreadyPhone", "Home", HttpMethod = "POST", ErrorMessage = "Mobile already exists")]
        [Required(ErrorMessage = "Phone Number Required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string memberphone { get; set; }

        [Required(ErrorMessage ="Gender Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string membergender { get; set; }


        [Required(ErrorMessage = "Age Required")]
        [DataType(DataType.Text)]
        [Range(14, int.MaxValue, ErrorMessage = "Please enter valid Age")]
        [Display(Name = "Age")]
        public string memberage { get; set; }

        [Required(ErrorMessage = "State Required")]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public string memberstate { get; set; }

        [Required(ErrorMessage = "City Reqiired")]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string membercity { get; set; }



        [Required(ErrorMessage = "Must Provide Father Name")]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Father Name")]
        [Display(Name ="Father Name")]
        public string memberfathername { get; set; }


        [Required(ErrorMessage = "Ward Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Ward")]
        public string memberwardno { get; set; }

        [Required(ErrorMessage = "Locality Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Locality/Muhhalla")]
        public string memberlocality { get; set; }

        [Required(ErrorMessage = "Village Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Village")]
        public string membervillage { get; set; }

        [Required(ErrorMessage = "Panchayat Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Panchayat")]
        public string memberpanchayat { get; set; }

        [Required(ErrorMessage = "Block Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Block")]
        public string memberblock { get; set; }        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Whatsup Number")]
        public string memberwhatsupno { get; set; }
        public Nullable<System.DateTime> entrydate { get; set; }
        public Nullable<System.DateTime> modifydate { get; set; }
        public Nullable<bool> status { get; set; }



    }
}