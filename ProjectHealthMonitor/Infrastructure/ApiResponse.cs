namespace ProjectHealthMonitor.Infrastructure
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public object Errors { get; set; }

        public string TraceId { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message, string traceId)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                TraceId = traceId
            };
        }

        public static ApiResponse<T> FailureResponse(string message, object errors, string traceId)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors,
                TraceId = traceId
            };
        }
    }
}