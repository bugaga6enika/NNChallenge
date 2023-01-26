using System;

namespace NNChallenge.WeatherForcast
{
    public class InvalidForcastWindowException : ArgumentException
    {
        public InvalidForcastWindowException(int lowerThreshold, int upperThreshold) : base($"Argument should be within the following limits: [{lowerThreshold}:{upperThreshold}]")
        {
        }
    }
}

