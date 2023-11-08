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
    
    public partial class XE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XE()
        {
            this.BAOHANHs = new HashSet<BAOHANH>();
            this.BAOHANHs1 = new HashSet<BAOHANH>();
            this.BAOHANHs2 = new HashSet<BAOHANH>();
            this.BAOTRIs = new HashSet<BAOTRI>();
            this.BAOTRIs1 = new HashSet<BAOTRI>();
            this.BAOTRIs2 = new HashSet<BAOTRI>();
            this.CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            this.CHITIETHOADONs1 = new HashSet<CHITIETHOADON>();
            this.CHITIETHOADONs2 = new HashSet<CHITIETHOADON>();
            this.CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
            this.CHITIETPHIEUNHAPs1 = new HashSet<CHITIETPHIEUNHAP>();
            this.CHITIETPHIEUNHAPs2 = new HashSet<CHITIETPHIEUNHAP>();
            this.DANGKYBAOTRIs = new HashSet<DANGKYBAOTRI>();
            this.DANGKYBAOTRIs1 = new HashSet<DANGKYBAOTRI>();
            this.DANGKYBAOTRIs2 = new HashSet<DANGKYBAOTRI>();
        }
    
        public int MaXe { get; set; }
        public string TenXe { get; set; }
        public string MoTa { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public string XuatXu { get; set; }
        public string MauSac { get; set; }
        public string CDBaoHanh { get; set; }
        public Nullable<int> MaNCC { get; set; }
        public string HinhAnh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHANH> BAOHANHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHANH> BAOHANHs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHANH> BAOHANHs2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOTRI> BAOTRIs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOTRI> BAOTRIs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOTRI> BAOTRIs2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGKYBAOTRI> DANGKYBAOTRIs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGKYBAOTRI> DANGKYBAOTRIs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGKYBAOTRI> DANGKYBAOTRIs2 { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP1 { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP2 { get; set; }
        public virtual TONKHO TONKHO { get; set; }
        public virtual TONKHO TONKHO1 { get; set; }
        public virtual TONKHO TONKHO2 { get; set; }
    }
}