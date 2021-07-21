using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty
{
    internal class TargetCode
    {
        [Log]
        public int Method(int a, int b)
        {
            Console.WriteLine("Entering Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty.TargetCode.Method(int, int)");
            try
            {
                return a + b;
            }
            finally
            {
                Console.WriteLine(" Leaving Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty.TargetCode.Method(int, int)");
            }
        }


        private int _property;

        [Log]
        public int Property
        {
            get
            {
                return this._property;
            }

            set
            {
                Console.WriteLine("Assigning Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty.TargetCode.Property.set");
                this._property = value;
            }
        }


        private string _field;

        [Log]
        public string Field
        {
            get
            {
                return this._field;
            }

            set
            {
                Console.WriteLine("Assigning Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty.TargetCode.Field.set");
                this._field = value;
            }
        }
    }
}
