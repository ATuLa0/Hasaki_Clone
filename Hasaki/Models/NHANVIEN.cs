//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hasaki.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHANVIEN
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TenDN { get; set; }
        public string Matkhau { get; set; }
        public string MaCV { get; set; }
    
        public virtual CHUCVU CHUCVU { get; set; }
        public virtual CHUCVU CHUCVU1 { get; set; }
        public virtual CHUCVU CHUCVU2 { get; set; }
    }
}
