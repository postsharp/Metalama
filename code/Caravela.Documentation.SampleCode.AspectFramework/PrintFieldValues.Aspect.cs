using System;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework.PrintFieldValues
{
    internal class PrintFieldValuesAttribute : OverrideMethodAspect
    {
        public override dynamic OverrideMethod()
        {
            foreach (var fieldOrProperty in meta.NamedType.FieldsAndProperties)
            {
                if (fieldOrProperty.IsAutoPropertyOrField)
                {
                    var value = fieldOrProperty.Invokers.Final.GetValue(fieldOrProperty.IsStatic ? null : meta.This);
                    Console.WriteLine($"{fieldOrProperty.Name}={value}");
                }
            }

            return meta.Proceed();
        }
    }
}
