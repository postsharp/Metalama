namespace Caravela.Documentation.SampleCode.AspectFramework.RegistryStorage
{
    [RegistryStorage("Animals")]
    class Animals
    {
        public int Turtles
        {
            get
            {
                var type = System.Type.GetTypeFromHandle(Compiler.Intrinsics.GetRuntimeTypeHandle("T:System.Int32"));
                var value = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\Animals", "Turtles", null);
                if (value != null)
                {
                    return (int)System.Convert.ChangeType(value, type);
                }
                else
                {
                    return (int)0;
                }
            }

            set
            {
                var stringValue = System.Convert.ToString(value);
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\Animals", "Turtles", stringValue);
                int _;
                this.__Turtles__BackingField = value;
            }
        }
        private int __Turtles__BackingField;
        public int Cats
        {
            get
            {
                var type = System.Type.GetTypeFromHandle(Compiler.Intrinsics.GetRuntimeTypeHandle("T:System.Int32"));
                var value = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\Animals", "Cats", null);
                if (value != null)
                {
                    return (int)System.Convert.ChangeType(value, type);
                }
                else
                {
                    return (int)0;
                }
            }

            set
            {
                var stringValue = System.Convert.ToString(value);
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\Animals", "Cats", stringValue);
                int _;
                this.__Cats__BackingField = value;
            }
        }
        private int __Cats__BackingField;
        public int All => this.Turtles + this.Cats;
    }
}