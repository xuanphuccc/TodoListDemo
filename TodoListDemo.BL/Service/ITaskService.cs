using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDemo.DL;

namespace TodoListDemo.BL
{
    public interface ITaskService
    {
        /// <summary>
        /// Lấy toàn bộ các công việc cần làm
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MyTaskDto>> GetAllTaskAsync();

        /// <summary>
        /// Lấy thông tin một công việc theo ID
        /// </summary>
        /// <param name="taskId">ID của công việc</param>
        /// <returns></returns>
        Task<MyTaskDto> GetTaskAsync(int taskId);

        /// <summary>
        /// Thêm mới một công việc
        /// </summary>
        /// <param name="taskRequestDto">Thông tin của công việc</param>
        /// <returns>Số dòng được thêm thành công</returns>
        Task<int> InsertTaskAsync(MyTaskRequestDto taskRequestDto);

        /// <summary>
        /// Cập nhật một công việc
        /// </summary>
        /// <param name="taskId">ID của công việc</param>
        /// <param name="taskRequestDto">Thông tin của công việc</param>
        /// <returns>Số dòng được cập nhật thành công</returns>
        Task<int> UpdateTaskAsync(int taskId, MyTaskRequestDto taskRequestDto);

        /// <summary>
        /// Xoá một công việc
        /// </summary>
        /// <param name="taskId">ID của công việc</param>
        /// <returns>Số dòng được xoá thành công</returns>
        Task<int> DeleteTaskAsync(int taskId);
    }
}
