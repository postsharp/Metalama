namespace Caravela.Documentation.SampleCode.AspectFramework.LogParameters
{
    internal class TargetCode
    {
        [Log]
        private void VoidMethod(int a, out int b)
        {
            var arguments = new object[] { a, 0 };
            System.Console.WriteLine("Caravela.Documentation.SampleCode.AspectFramework.LogParameters.TargetCode.VoidMethod(a = {0}, b = <out> ) started", arguments);
            try
            {
                Framework.Aspects.__Void result;
                b = a;
                System.Console.WriteLine(string.Format("Caravela.Documentation.SampleCode.AspectFramework.LogParameters.TargetCode.VoidMethod(a = {0}, b = <out> )", arguments) + " returned " + result);
                return;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Caravela.Documentation.SampleCode.AspectFramework.LogParameters.TargetCode.VoidMethod(a = {0}, b = <out> ) failed: " + e, arguments);
                throw;
            }
        }

        [Log]
        private int IntMethod(int a)
        {
            var arguments = new object[] { a };
            System.Console.WriteLine("Caravela.Documentation.SampleCode.AspectFramework.LogParameters.TargetCode.IntMethod(a = {0}) started", arguments);
            try
            {
                int result;
                result = a;
                System.Console.WriteLine(string.Format("Caravela.Documentation.SampleCode.AspectFramework.LogParameters.TargetCode.IntMethod(a = {0})", arguments) + " succeeded");
                return (int)result;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Caravela.Documentation.SampleCode.AspectFramework.LogParameters.TargetCode.IntMethod(a = {0}) failed: " + e, arguments);
                throw;
            }
        }

    }
}