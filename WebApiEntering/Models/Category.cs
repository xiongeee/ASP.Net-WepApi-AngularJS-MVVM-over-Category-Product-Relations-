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
        /*[IgnoreDataMember] *///bunu serialize ederken pass ge�ecek, ��nk� komplex tip. Kompleks tip oldu�u i�in hat�rlarsan serialize deserialize ederken daha �nce de problem ya�am��t�k. Bu problemi bu property i viewmodel yaparak ��zm��t�k. AMa bununla u�ra�m�yoruz art�k. Bunu ba��na yaz�nca serialize olay� geldi�inde direkt es ge�iyor. JSON la da ignore etme yolu var. AMa bulamad�k, �imdilik yine eski us�l ViewModel yaprak ��zece�im ��nk� bu kodu hat�rlam�yorum. Ara�t�r�p tekrar yapaca��m. 
        public virtual ICollection<Product> Products { get; set; }
    }
}
