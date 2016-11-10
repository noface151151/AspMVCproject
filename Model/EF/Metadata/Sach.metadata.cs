using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [MetadataTypeAttribute(typeof(SachMetaData))]
    public partial class Sach
    {
        internal sealed class SachMetaData
        {
            [Display(Name = "Mã sách")]
            public int MaSach { get; set; }

            [Display(Name = "Nhà xuất bản")]
            public Nullable<int> MaNXB { get; set; }

            [Display(Name = "Chủ đề")]
            public Nullable<int> MaChuDe { get; set; }

            [Display(Name = "Tác giả")]
            [Required(ErrorMessage = "Tên tác giả không được để trống")]
            public string TenTacGia { get; set; }

            [Display(Name = "Tên sách")]
            [Required(ErrorMessage = "Tên sách không được để trống")]
            public string TenSach { get; set; }

            [Display(Name = "Đơn giá")]
            [Required(ErrorMessage = "Giá không được để trống")]
            [RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?", ErrorMessage = "Giá phải là số thập phân")]
            public Nullable<long> GiaBan { get; set; }

            [Display(Name = "Mô tả")]
            [Required(ErrorMessage = "Mô tả không được để trống")]
            public string MoTa { get; set; }
            [Display(Name = "Ảnh bìa")]
            public string AnhBia { get; set; }

            [Display(Name = "Số lượng tồn")]
            [Required(ErrorMessage = "Số lượng tồn không được để trống")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Số lương tồn phải là số")]
            public Nullable<int> SoLuongTon { get; set; }

            [Display(Name = "Sách mới")]
            public Nullable<int> Moi { get; set; }

            [Display(Name = "Số lần xem")]
            public Nullable<int> SoLanXem { get; set; }
            
        }
    }
}
