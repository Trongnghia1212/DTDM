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

    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.BaoHiems = new HashSet<BaoHiem>();
        }
        [DisplayName("Mã Nhân Viên ")]
        public string MaNV { get; set; }
        [DisplayName("Tên Nhân Viên ")]
        public string TenNV { get; set; }
        [DisplayName("Giới Tính ")]
        public string GioiTinh { get; set; }
        [DisplayName("Ngày Sinh ")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        [DisplayName("Email ")]
        public string Email { get; set; }
        [DisplayName("Địa Chỉ ")]
        public string DiaChi { get; set; }
        [DisplayName("Số Điện Thoại ")]
        public string SDT { get; set; }
        [DisplayName("Chứng Minh Thư ")]
        public string CMT { get; set; }
        [DisplayName("Mã Công Việc ")]
        public string MaCV { get; set; }
        [DisplayName("Mã Hợp Đồng ")]
        public string MaHD { get; set; }
        [DisplayName("Hệ Số Lương ")]
        public Nullable<double> HSL { get; set; }
        [DisplayName("Mã Phòng")]
        public string MaPhong { get; set; }
        [DisplayName("Mã Bộ Phận")]
        public string MaBoPhan { get; set; }
    
        public virtual BangLuong BangLuong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoHiem> BaoHiems { get; set; }
        public virtual BoPhann BoPhann { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual HopDong HopDong { get; set; }
        public virtual Phong Phong { get; set; }
    }
}
