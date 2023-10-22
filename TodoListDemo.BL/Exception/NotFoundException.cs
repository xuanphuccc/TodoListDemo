﻿
namespace TodoListDemo.BL
{
    public class NotFoundException : Exception
    {
        public int ErrorCode { get; set; }

        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
