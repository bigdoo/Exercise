namespace WebApplication2.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IProduct
    {
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required]
        [oneSpace(ErrorMessage ="必須包含一個空白")]
        public string ProductName { get; set; }
        [JsonProperty(PropertyName ="bigdoo")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        [JsonIgnore]
        public Nullable<decimal> Stock { get; set; }
        
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
