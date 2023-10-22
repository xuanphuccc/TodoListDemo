using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDemo.DL;

namespace TodoListDemo.BL
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<MyTask, MyTaskDto>();

            CreateMap<MyTaskRequestDto, MyTask>();
        }
    }
}
