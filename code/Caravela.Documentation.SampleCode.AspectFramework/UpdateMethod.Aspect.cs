using System;
using System.Linq;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.UpdateMethod
{
    class UpdateMethodAttribute : Attribute, IAspect<INamedType>
    {
        public void BuildAspect( IAspectBuilder<INamedType> builder )
        {
            var updateMethodBuilder = builder.AdviceFactory.IntroduceMethod(builder.TargetDeclaration, nameof(Update));

            var fieldsAndProperties = 
                builder.TargetDeclaration.FieldsAndProperties
                .Where(f => f.Writeability == Writeability.All);

            foreach ( var field in fieldsAndProperties)
            {
                updateMethodBuilder.AddParameter(field.Name, field.Type);
            }
        }

        [Template]
        public void Update()
        {
            var index = meta.CompileTime(0);

            foreach ( var parameter in meta.Parameters )
            {
                var field = meta.NamedType.FieldsAndProperties.OfName(parameter.Name).Single();

                field.Invokers.Final.SetValue(meta.This, meta.Parameters[index].Value);
                index++;
            }
        }
    }
}
