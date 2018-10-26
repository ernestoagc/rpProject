namespace DataAccess.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INMUEBLE")]
    public partial class INMUEBLE
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string CODIGO { get; set; }

        [Column("NOMBRE")]
        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }
    }
}
