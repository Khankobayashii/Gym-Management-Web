//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_63134295.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GoiTap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoiTap()
        {
            this.LichTrinhTaps = new HashSet<LichTrinhTap>();
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }
    
        public string MaGoi { get; set; }
        public string TenGoi { get; set; }
        public string MoTa { get; set; }
        public Nullable<double> Gia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichTrinhTap> LichTrinhTaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
