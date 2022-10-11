namespace News.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("catogery")]
    public partial class catogery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public catogery()
        {
            news = new HashSet<news>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "cat cant be empty")]
        [StringLength(50)]
        [DisplayName("Name")]
        public string name { get; set; }
        //navigation properties
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<news> news { get; set; }
    }
}
