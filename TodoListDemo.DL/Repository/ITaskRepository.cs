using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDemo.DL
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Lấy toàn bộ các công việc cần làm
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MyTask>> GetAllTaskAsync();

        /// <summary>
        /// Lấy thông tin một công việc theo ID
        /// </summary>
        /// <param name="taskId">ID của công việc</param>
        /// <returns></returns>
        Task<MyTask?> GetTaskAsync(int taskId);

        /// <summary>
        /// Thêm mới một công việc
        /// </summary>
        /// <param name="task">Thông tin của công việc</param>
        /// <returns>Số dòng được thêm thành công</returns>
        Task<int> InsertTaskAsync (MyTask task);

        /// <summary>
        /// Cập nhật một công việc
        /// </summary>
        /// <param name="task">Thông tin của công việc</param>
        /// <returns>Số dòng được cập nhật thành công</returns>
        Task<int> UpdateTaskAsync (MyTask task);

        /// <summary>
        /// Xoá một công việc
        /// </summary>
        /// <param name="task">Thông tin của công việc</param>
        /// <returns>Số dòng được xoá thành công</returns>
        Task<int> DeleteTaskAsync (MyTask task);
    }
}
