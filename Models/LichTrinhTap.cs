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
    
    public partial class LichTrinhTap
    {
        public int MaLichTrinh { get; set; }
        public string MaKH { get; set; }
        public string MaGoi { get; set; }
        public System.DateTime NgayBatDau { get; set; }
        public System.DateTime NgayKetThuc { get; set; }
    
        public virtual GoiTap GoiTap { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}