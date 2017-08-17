namespace WebApiEntering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /*[IgnoreDataMember] *///bunu serialize ederken pass geçecek, çünkü komplex tip. Kompleks tip olduðu için hatýrlarsan serialize deserialize ederken daha önce de problem yaþamýþtýk. Bu problemi bu property i viewmodel yaparak çözmüþtük. AMa bununla uðraþmýyoruz artýk. Bunu baþýna yazýnca serialize olayý geldiðinde direkt es geçiyor. JSON la da ignore etme yolu var. AMa bulamadýk, þimdilik yine eski usül ViewModel yaprak çözeceðim çünkü bu kodu hatýrlamýyorum. Araþtýrýp tekrar yapacaðým. 
        public virtual ICollection<Product> Products { get; set; }
    }
}
