using System;
namespace NNChallenge.WeatherForcast
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public bool HasErrors { get; private set; }
        public string ErrorMessage { get; private set; }

        private Result()
        {

        }

        public static Result<T> SuccessResult(T data) => new Result<T> { Data = data };

        public static Result<T> ErrorResult(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ArgumentNullException(nameof(errorMessage));
            }

            return new Result<T> { Data = default, HasErrors = true, ErrorMessage = errorMessage };
        }
    }
}

