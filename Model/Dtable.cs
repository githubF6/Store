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
    
    public partial class Dtable
    {
        public int ID { get; set; }
        public int KwID { get; set; }
        public string kwName { get; set; }
        public int CkID { get; set; }
        public int KwTypeID { get; set; }
        public int Status { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual storage1 storage1 { get; set; }
        public virtual storageType storageType { get; set; }
        public virtual store store { get; set; }
    }
}
