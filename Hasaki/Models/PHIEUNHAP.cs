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
    
    public partial class PHIEUNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAP()
        {
            this.CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
            this.CHITIETPHIEUNHAPs1 = new HashSet<CHITIETPHIEUNHAP>();
            this.CHITIETPHIEUNHAPs2 = new HashSet<CHITIETPHIEUNHAP>();
        }
    
        public int MaPN { get; set; }
        public Nullable<int> MaNCC { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs2 { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP1 { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP2 { get; set; }
    }
}
