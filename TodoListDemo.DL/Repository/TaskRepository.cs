using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDemo.DL
{
    public class TaskRepository : ITaskRepository
    {
        #region Fields
        private readonly DbConnection _connection;
        #endregion

        #region Constructors
        public TaskRepository(DbConnection connection)
        {
            _connection = connection;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy toàn bộ các công việc cần làm
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MyTask>> GetAllTaskAsync()
        {
            var sql = "SELECT * FROM task t ORDER BY t.TaskId DESC;";
            var allTasks = await _connection.QueryAsync<MyTask>(sql);

            return allTasks;
        }

        /// <summary>
        /// Lấy thông tin một công việc theo ID
        /// </summary>
        /// <param name="taskId">ID của công việc</param>
        /// <returns></returns>
        public async Task<MyTask?> GetTaskAsync(int taskId)
        {
            var sql = "SELECT * FROM task t WHERE t.TaskId = @TaskId;";

            var parameters = new DynamicParameters();
            parameters.Add("@TaskId", taskId);

            var task = await _connection.QueryFirstOrDefaultAsync<MyTask>(sql, parameters);

            return task;
        }

        /// <summary>
        /// Thêm mới một công việc
        /// </summary>
        /// <param name="task">Thông tin của công việc</param>
        /// <returns>Số dòng được thêm thành công</returns>
        public async Task<int> InsertTaskAsync(MyTask task)
        {
            var sql = "INSERT INTO task (Title, Description, DueDate, Status) " +
                      "VALUES (@Title, @Description, @DueDate, @Status);";

            var parameters = new DynamicParameters();
            parameters.Add("@Title", task.Title);
            parameters.Add("@Description", task.Description);
            parameters.Add("@DueDate", task.DueDate);
            parameters.Add("@Status", task.Status);

            var result = await _connection.ExecuteAsync(sql, parameters);

            return result;
        }

        /// <summary>
        /// Cập nhật một công việc
        /// </summary>
        /// <param name="task">Thông tin của công việc</param>
        /// <returns>Số dòng được cập nhật thành công</returns>
        public async Task<int> UpdateTaskAsync(MyTask task)
        {
            var sql = "UPDATE task t " +
                      "SET Title = @Title, Description = @Description, DueDate = @DueDate, Status = @Status " +
                      "WHERE t.TaskId = @TaskId;";

            var parameters = new DynamicParameters();
            parameters.Add("@TaskId", task.TaskId);
            parameters.Add("@Title", task.Title);
            parameters.Add("@Description", task.Description);
            parameters.Add("@DueDate", task.DueDate);
            parameters.Add("@Status", task.Status);

            var result = await _connection.ExecuteAsync(sql, parameters);

            return result;
        }

        /// <summary>
        /// Xoá một công việc
        /// </summary>
        /// <param name="task">Thông tin của công việc</param>
        /// <returns>Số dòng được xoá thành công</returns>
        public async Task<int> DeleteTaskAsync(MyTask task)
        {
            var sql = "DELETE FROM task WHERE TaskId = @TaskId;";

            var parameters = new DynamicParameters();
            parameters.Add("@TaskId", task.TaskId);

            var result = await _connection.ExecuteAsync(sql, parameters);

            return result;
        }
        #endregion
    }
}
