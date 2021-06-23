using System;
using System.Linq;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;
using Microsoft.Win32;

namespace Caravela.Documentation.SampleCode.AspectFramework.RegistryStorage
{
    class RegistryStorageAttribute : Attribute, IAspect<INamedType>
    {
        public string Key { get; }

        public RegistryStorageAttribute(string key)
        {
            this.Key = "HKEY_CURRENT_USER\\SOFTWARE\\Company\\Product\\" + key;
        }

        public void BuildAspect(IAspectBuilder<INamedType> builder )
        {
            foreach ( var property in builder.TargetDeclaration.FieldsAndProperties.Where( p=> p.IsAutoPropertyOrField))
            {
                builder.AdviceFactory.OverrideFieldOrProperty( property, nameof(this.OverrideProperty));
            }
            
        }

        [Template]
        dynamic OverrideProperty
        {
            get
            {
                var type = meta.FieldOrProperty.Type.ToType();
                var value = Registry.GetValue(this.Key, meta.FieldOrProperty.Name, null);
                if (value != null)
                {
                    return Convert.ChangeType(value, type);
                }
                else
                {
                    return meta.FieldOrProperty.Type.DefaultValue();
                }
            }

            set
            {
                var stringValue = Convert.ToString(value);
                Registry.SetValue(this.Key, meta.FieldOrProperty.Name, stringValue);
                var _ = meta.Proceed();
            }
        }
    }
}
