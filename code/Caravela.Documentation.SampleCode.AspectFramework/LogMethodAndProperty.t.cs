namespace Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty
{
    internal class TargetCode
    {
        [Log]
        public int Method(int a, int b)
        {
            System.Console.WriteLine("Entering Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty.TargetCode.Method(int, int)");
            try
            {
                return a + b;
            }
            finally
            {
                System.Console.WriteLine(" Leaving Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty.TargetCode.Method(int, int)");
            }
        }

        [Log]
        public int Property
        {
            get
            {
                return this.__Property__BackingField;
            }

            set
            {
                System.Console.WriteLine("Assigning Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty.TargetCode.Property.set");
                int _;
                this.__Property__BackingField = value;
            }
        }
        private int __Property__BackingField;
        [Log]
        public string Field
        {
            get
            {
                return this.__Field__BackingField;
            }

            set
            {
                System.Console.WriteLine("Assigning Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty.TargetCode.Field.set");
                string _;
                this.__Field__BackingField = value;
            }
        }
        private string __Field__BackingField;
    }
}