using System;
using Caravela.Compiler;
using Microsoft.Win32;

namespace Caravela.Documentation.SampleCode.AspectFramework.RegistryStorage
{
    [RegistryStorage("Animals")]
    class Animals
    {

        private int _turtles;

        public int Turtles
        {
            get
            {
                var type = Type.GetTypeFromHandle(Intrinsics.GetRuntimeTypeHandle("T:System.Int32"));
                var value = Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\Animals", "Turtles", null);
                if (value != null)
                {
                    return (int)Convert.ChangeType(value, type);
                }
                else
                {
                    return (int)0;
                }
            }

            set
            {
                var stringValue = Convert.ToString(value);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\Animals", "Turtles", stringValue);
                this._turtles = value;
            }
        }

        private int _cats;


        public int Cats
        {
            get
            {
                var type = Type.GetTypeFromHandle(Intrinsics.GetRuntimeTypeHandle("T:System.Int32"));
                var value = Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\Animals", "Cats", null);
                if (value != null)
                {
                    return (int)Convert.ChangeType(value, type);
                }
                else
                {
                    return (int)0;
                }
            }

            set
            {
                var stringValue = Convert.ToString(value);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\Animals", "Cats", stringValue);
                this._cats = value;
            }
        }

        public int All => this.Turtles + this.Cats;
    }
}
