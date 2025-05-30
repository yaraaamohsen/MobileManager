using System.ComponentModel.DataAnnotations;
namespace Application.DTOs
{
    public class BaseResponse<T>
    {
        [Required]
        public bool IsSuccess { get; set; }

        [Required]
        public string Message { get; set; }

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
            Data = default;
        }
    }
}
