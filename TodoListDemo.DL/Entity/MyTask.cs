using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDemo.DL
{
    public class MyTask
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        [Required]
        public int TaskId { get; set; }

        /// <summary>
        /// Tiêu đề công việc
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả công việc
        /// </summary>
        [StringLength(255)]
        public string? Description { get; set; }

        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Trạng thái công việc: 0 - Todo; 1 - In progress; 2 - Completed
        /// </summary>
        [Required]
        public int Status { get; set; }
    }
}
