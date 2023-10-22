﻿using System.Text.Json;

namespace TodoListDemo.BL
{
    public class BaseException
    {
        public ErrorCode ErrorCode { get; set; }

        public string? DevMessage { get; set; }
        public string? UserMessage { get; set; }
        public string? TraceId { get; set; }
        public string? MoreInfo { get; set; }
        public object? Errors { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
