﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNhanSu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class BaoHiem
    {
        [DisplayName("Mã Bảo Hiểm")]
        public string MaBH { get; set; }
        [DisplayName(" Mã Nhân Viên")]
        public string MaNV { get; set; }
        [DisplayName("Nơi Khám Bệnh")]
        public string NoiKhamBenh { get; set; }
        [DisplayName("Sổ Bảo Hiểm")]
        public string SoBaoHiem { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
