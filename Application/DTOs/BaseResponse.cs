﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Application.DTOs
{
    public class BaseResponse<T>
    {
        [Required]
        public bool IsSuccess { get; set; }

        [Required]
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        // Response Success
        public BaseResponse(T data, string message = "Request Processed Successfully")
        {
            IsSuccess = true;
            Message = message;
            Data = data;
        }

        // Response Failure
        public BaseResponse(string message)
        {
            IsSuccess = false;
            Message = message;
        }
    }
}
