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
    
    public partial class bs
    {
        public int bsID { get; set; }
        public int ProductID { get; set; }
        public string BsType { get; set; }
        public int Count { get; set; }
        public string check1 { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int Status { get; set; }
    
        public virtual product product { get; set; }
        public virtual admin admin { get; set; }
        public virtual admin admin1 { get; set; }
    }
}
