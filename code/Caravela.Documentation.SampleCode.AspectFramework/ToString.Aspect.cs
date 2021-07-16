using System;
using System.Linq;
using System.Text;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.ToString
{
    class ToStringAttribute : Attribute, IAspect<INamedType>
    {
        [Introduce( WhenExists = OverrideStrategy.Override, Name = "ToString" )]
        public string IntroducedToString()
        {
            var formattingString = meta.CompileTime(new StringBuilder());
            formattingString.Append("{ ");
            formattingString.Append(meta.Type.Name );
            formattingString.Append(" ");

            var i = meta.CompileTime(0);
            var fields = meta.Type.FieldsAndProperties.Where( f => !f.IsStatic ).ToList();

            var values = new object[fields.Count];
            foreach ( var field in fields)
            {
                if ( i > 0 )
                {
                    formattingString.Append(", ");
                }

                formattingString.Append(field.Name);
                formattingString.Append("={");
                formattingString.Append(i);
                formattingString.Append("}");
                values[i] = field.Invokers.Final.GetValue(meta.This);

                i++;
            }

            formattingString.Append(" }");


            return string.Format(formattingString.ToString(), values);
            
        }
    }
}
