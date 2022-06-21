using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMonthlyProject.Models
{
    public class Season
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Fruit> Fruits { get; set; }
        public virtual ICollection<Vegetable> Vegetables { get; set; }
    }

    public class Fruit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsNew { get; set; }
        
        public DateTime PurchaseDate { get; set; }
        
        public string Image { get; set; }

        [ForeignKey("Season")]
        public int SeasonID { get; set; }

        public virtual Season Season { get; set; }

        [ForeignKey("FruitSupplier")]
        public int SupplierID { get; set; }
        
    }

    public class Vegetable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        
        public string Image { get; set; }

        [ForeignKey("Season")]
        public int SeasonID { get; set; }

        public virtual Season Season { get; set; }
    }

    public class FruitSupplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        
    }
}
