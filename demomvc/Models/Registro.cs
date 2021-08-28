using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace demomvc.Models

{   
    
    [Table("t_producto")]
    public class Registro{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        public string nombre { get; set; }

        [Column("categoria")]   
        public string categoria { get; set; }

        [Column("precio")]
        public double precio {get; set; }

        [Column("descuento")]
        public double descuento {get; set; }

    }
}