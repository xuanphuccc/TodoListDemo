using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDemo.DL;

namespace TodoListDemo.BL
{
    public class TaskService : ITaskService
    {
        #region Fields
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy toàn bộ các công việc cần làm
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MyTaskDto>> GetAllTaskAsync()
        {
            var allTasks = await _taskRepository.GetAllTaskAsync();

            var allTaskDtos = _mapper.Map<IEnumerable<MyTaskDto>>(allTasks);

            return allTaskDtos;
        }

        /// <summary>
        /// Lấy thông tin một công việc theo ID
        /// </summary>
        /// <param name="taskId">ID của công việc</param>
        /// <returns></returns>
        public async Task<MyTaskDto> GetTaskAsync(int taskId)
        {
            var task = await _taskRepository.GetTaskAsync(taskId);

            if (task == null)
            {
                throw new NotFoundException("Công việc không tồn tại", (int)ErrorCode.NotFound);
            }

            var taskDto = _mapper.Map<MyTaskDto>(task);

            return taskDto;
        }

        /// <summary>
        /// Thêm mới một công việc
        /// </summary>
        /// <param name="taskRequestDto">Thông tin của công việc</param>
        /// <returns>Số dòng được thêm thành công</returns>
        public async Task<int> InsertTaskAsync(MyTaskRequestDto taskRequestDto)
        {
            var task = _mapper.Map<MyTask>(taskRequestDto);

            var result = await _taskRepository.InsertTaskAsync(task);

            return result;
        }

        /// <summary>
        /// Cập nhật một công việc
        /// </summary>
        /// <param name="taskId">ID của công việc</param>
        /// <param name="taskRequestDto">Thông tin của công việc</param>
        /// <returns>Số dòng được cập nhật thành công</returns>
        public async Task<int> UpdateTaskAsync(int taskId, MyTaskRequestDto taskRequestDto)
        {
            var oldTask = await _taskRepository.GetTaskAsync(taskId);

            if(oldTask == null)
            {
                throw new NotFoundException("Công việc không tồn tại", (int)ErrorCode.NotFound);
            }

            var newTask = _mapper.Map(taskRequestDto, oldTask);

            var result = await _taskRepository.UpdateTaskAsync(newTask);

            return result;
        }

        /// <summary>
        /// Xoá một công việc
        /// </summary>
        /// <param name="taskId">ID của công việc</param>
        /// <returns>Số dòng được xoá thành công</returns>
        public async Task<int> DeleteTaskAsync(int taskId)
        {
            var existTask = await _taskRepository.GetTaskAsync(taskId);

            if (existTask == null)
            {
                throw new NotFoundException("Công việc không tồn tại", (int)ErrorCode.NotFound);
            }

            var result = await _taskRepository.DeleteTaskAsync(existTask);

            return result;
        }
        #endregion
    }
}
