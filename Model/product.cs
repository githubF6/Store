//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.bs = new HashSet<bs>();
            this.th = new HashSet<th>();
        }
    
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Productprice { get; set; }
        public string ProductSpercification { get; set; }
        public int ProductType { get; set; }
        public int ProductUnit { get; set; }
        public int Status { get; set; }
        public int KwID { get; set; }
        public int KwTypeId { get; set; }
        public int count { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bs> bs { get; set; }
        public virtual measure measure { get; set; }
        public virtual Type Type { get; set; }
        public virtual storage1 storage1 { get; set; }
        public virtual storageType storageType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<th> th { get; set; }
    }
}
