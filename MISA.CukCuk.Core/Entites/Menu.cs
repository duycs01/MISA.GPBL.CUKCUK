using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.CukCuk.Core.Attributes.MISAAttribute;

namespace MISA.CukCuk.Core.Entites
{
    public class Menu : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public Guid MenuId { get; set; }

        /// <summary>
        /// Mã món ăn
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        [MISARequired("Mã món")]
        public string MenuCode { get; set; }

        /// <summary>
        /// Tên món ăn
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        [MISARequired("Tên món")]
        public string MenuName { get; set; }

        /// <summary>
        /// Giá
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        [MISARequired("Giá")]
        public int Price { get; set; }

        /// <summary>
        /// Giá vốn
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public int CostOfCapital { get; set; }

        /// <summary>
        /// Thứ tự món
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public int OrderOfDishes { get; set; }

        /// <summary>
        /// Mô tả
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Chế biến
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        [MISANotMap]
        public List<Guid> ListProcessing { get; set; } = new List<Guid>();

        /// <summary>
        /// Thay đổi theo thời giá
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public bool ChangeWithTime { get; set; }

        /// <summary>
        /// Thay đổi giá tự do
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public bool FreePriceAdjustment { get; set; }

        /// <summary>
        /// Ngừng bán
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public bool StopSale { get; set; }

        /// <summary>
        /// Định lượng NVL
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public bool QuantitativeNVL { get; set; }

        /// <summary>
        /// Không hiển thị trên thực đơn
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public bool NotDisplayed { get; set; }

        /// <summary>
        /// Nhóm thực đơn
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public Guid? MenuGroupId { get; set; }

        /// <summary>
        /// Tên Nhóm thực đơn
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        [MISANotMap]
        public string MenuGroupName { get; set; }

        /// <summary>
        /// Ảnh đại diện
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public string Avatar { get; set; }

        [MISANotMap]
        public string ImageType { get; set; }


        /// <summary>
        /// Tên Sở thích phục vụ
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        [MISANotMap]
        public List<ServiceHobby> ListServiceHobby { get; set; } = new List<ServiceHobby>();


        /// <summary>
        /// Đơn vị
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        [MISARequired("Đơn vị")]
        public Guid UnitId { get; set; }

        /// <summary>
        /// Tên Đơn vị
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        [MISANotMap]
        public string UnitName { get; set; }

        [MISANotMap]
        public int CollectMore { get; set; }

        public int TypeOfMenu { get; set; }
    }
}
