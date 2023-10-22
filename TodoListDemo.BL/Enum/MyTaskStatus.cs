using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDemo.BL
{
    public enum MyTaskStatus
    {
        /// <summary>
        /// Việc cần làm
        /// </summary>
        Todo = 0,

        /// <summary>
        /// Việc đang làm
        /// </summary>
        Inprogress = 1,

        /// <summary>
        /// Việc đã hoàn thành
        /// </summary>
        Completed = 2,
    }
}
