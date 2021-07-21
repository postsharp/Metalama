using System;
using System.Text;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.LogParameters
{
    public class LogAttribute : OverrideMethodAspect
    {

        public override dynamic OverrideMethod()
        {
            // Build a formatting string.
            var formattingString = BuildFormattingString();

            // Write entry message.
            var arguments = meta.Parameters.Values.ToArray();
            Console.WriteLine(formattingString + " started", arguments);

            try
            {
                // Invoke the method.
                dynamic result = meta.Proceed();

                // Display the success message.
                if (meta.Method.ReturnType.Is(typeof(void)))
                {
                    Console.WriteLine(string.Format(formattingString, arguments) + " returned " + result);
                }
                else
                {
                    Console.WriteLine(string.Format(formattingString, arguments) + " succeeded");
                }

                return result;
            }
            catch (Exception e)
            {
                // Display the failure message.
                Console.WriteLine(formattingString + " failed: " + e, arguments);
                throw;
            }
        }

        private static string BuildFormattingString()
        {
            var stringBuilder = meta.CompileTime(new StringBuilder());
            stringBuilder.Append(meta.Type.ToDisplayString());
            stringBuilder.Append('.');
            stringBuilder.Append(meta.Method.Name);
            stringBuilder.Append('(');
            var i = meta.CompileTime(0);

            foreach (var p in meta.Parameters)
            {
                var comma = i > 0 ? ", " : "";

                if (p.IsOut())
                {
                    stringBuilder.Append($"{comma}{p.Name} = <out> ");
                }
                else
                {
                    stringBuilder.Append($"{comma}{p.Name} = {{{i}}}");
                }

                i++;
            }
            stringBuilder.Append(')');

            return stringBuilder.ToString();
        }
    }
}
