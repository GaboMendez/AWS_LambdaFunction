using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LambdaFunction
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public int FunctionHandler(long input, ILambdaContext context)
        {
            //return input?.ToUpper();

            if (input < 0)
                throw new ArgumentOutOfRangeException(nameof(input));

            int loops = 0;

            while (input > 9)
            {          // beyond a single digit
                long s = 1;

                for (; input > 0; input /= 10) // multiply all the digits
                    s *= input % 10;

                input = s;
                loops += 1;
            }

            return loops;
        }
    }
}
