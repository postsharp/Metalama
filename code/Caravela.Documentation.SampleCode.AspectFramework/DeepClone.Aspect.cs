using System;
using System.Linq;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.DeepClone
{
    class DeepCloneAttribute : Attribute, IAspect<INamedType>
    {
        public void BuildAspect( IAspectBuilder<INamedType> builder )
        {
            var typedMethod = builder.AdviceFactory.IntroduceMethod(
                builder.TargetDeclaration, 
                nameof(CloneImpl),
                conflictBehavior:ConflictBehavior.Override );

            typedMethod.Name = "Clone";
            typedMethod.ReturnType = builder.TargetDeclaration;

            builder.AdviceFactory.ImplementInterface(
                builder.TargetDeclaration, 
                typeof(ICloneable),
                conflictBehavior: ConflictBehavior.Ignore);
        }

        [Template(IsVirtual = true)]
        public virtual dynamic CloneImpl()
        {
            // Define a local variable of the same type as the target type.
            var clone = meta.NamedType.DefaultValue();

            // TODO: access to meta.Method.Invokers.Base does not work.
            if ( meta.Method.Invokers.Base == null )
            {
                // Invoke base.MemberwiseClone().
                clone = meta.Cast( meta.NamedType,  meta.Base.MemberwiseClone() );
            }
            else
            {
                // Invoke the base method.
                clone = meta.Method.Invokers.Base.Invoke(meta.This);
            }

            // Select clonable fields.
            var clonableFields =
                meta.NamedType.FieldsAndProperties.Where(
                    f => f.IsAutoPropertyOrField &&
                    (f.Type.Is(typeof(ICloneable)) || 
                    (f.Type is INamedType fieldNamedType && fieldNamedType.Aspects<DeepCloneAttribute>().Any())));

            foreach ( var field in clonableFields )
            {
                field.Invokers.Base.SetValue(
                    clone, 
                    meta.Cast(field.Type, ((ICloneable)field.Invokers.Base.GetValue(meta.This)).Clone()));
            }

            return clone;
        }

        [InterfaceMember( IsExplicit = true)]
        object Clone()
        {
            return meta.This.Clone();
        }
    }
}
