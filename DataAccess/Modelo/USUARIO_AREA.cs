namespace DataAccess.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USUARIO_AREA
    {
        public int ID { get; set; }

        public int USUARIO { get; set; }

        public int AREA { get; set; }

        public virtual AREA AREA1 { get; set; }

        public virtual USUARIO USUARIO1 { get; set; }
    }
}
