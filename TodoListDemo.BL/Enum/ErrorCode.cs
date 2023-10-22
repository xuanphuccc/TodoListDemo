using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDemo.BL
{
    public enum ErrorCode
    {
        /// <summary>
        /// Mã lỗi nhập liệu
        /// </summary>
        BadRequest = 1000,

        /// <summary>
        /// Mã lỗi không tìm thấy tài nguyên
        /// </summary>
        NotFound = 1001,

        /// <summary>
        /// Mã lỗi trùng mã
        /// </summary>
        ConflictCode = 1002,

        /// <summary>
        /// Lỗi hệ thống
        /// </summary>
        ServerError = 1003,

        /// <summary>
        /// Lỗi phụ thuộc
        /// </summary>
        ConstraintError = 1004,

        /// <summary>
        /// Lỗi nhập mã quá lớn
        /// </summary>
        MaxCodeError = 1005
    }
}
