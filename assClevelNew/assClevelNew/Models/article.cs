//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace assClevelNew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public article()
        {
            this.journalist = new HashSet<journalist>();
        }
    
        public int articleid { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string aname { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> atime { get; set; }
        public string atype { get; set; }
        [Required(ErrorMessage = "Please Enter contents")]
        public string acontents { get; set; }
        public string apublisher { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<journalist> journalist { get; set; }
    }

    public enum Gender
    {
        service,
        trade,
		news,
		others
    }


}
