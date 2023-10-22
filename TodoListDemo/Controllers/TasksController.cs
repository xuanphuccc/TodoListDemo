using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using TodoListDemo.BL;

namespace TodoListDemo.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        #region Fields
        private readonly ITaskService _taskService;
        #endregion

        #region Constructors
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy toàn bộ các công việc
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            var allTasks = await _taskService.GetAllTaskAsync();

            return Ok(allTasks);
        }

        /// <summary>
        /// Lấy thông tin một công việc theo ID
        /// </summary>
        /// <param name="id">ID của công việc</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskAsync([FromRoute] int id)
        {
            var task = await _taskService.GetTaskAsync(id);

            return Ok(task);
        }

        /// <summary>
        /// Thêm mới một công việc
        /// </summary>
        /// <param name="myTaskRequestDto">Thông tin công việc cần thêm</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        [HttpPost]
        public async Task<IActionResult> InsertTaskAsync([FromBody] MyTaskRequestDto myTaskRequestDto)
        {
            var result = await _taskService.InsertTaskAsync(myTaskRequestDto);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Cập nhật một công việc
        /// </summary>
        /// <param name="id">ID của công việc</param>
        /// <param name="myTaskRequestDto">Thông tin công việc cần cập nhật</param>
        /// <returns>Số bản ghi cập nhật thành công</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync([FromRoute] int id, [FromBody] MyTaskRequestDto myTaskRequestDto)
        {
            var result = await _taskService.UpdateTaskAsync(id, myTaskRequestDto);

            return Ok(result);
        }

        /// <summary>
        /// Xoá một công việc theo ID
        /// </summary>
        /// <param name="id">ID của công việc</param>
        /// <returns>Số bản ghi xoá thành công</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync([FromRoute] int id)
        {
            var result = await _taskService.DeleteTaskAsync(id);

            return Ok(result);
        }
        #endregion
    }
}
