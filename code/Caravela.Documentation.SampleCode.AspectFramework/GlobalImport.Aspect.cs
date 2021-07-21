using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework.GlobalImport
{
    internal class ImportAttribute : OverrideFieldOrPropertyAspect
    {
        public override dynamic OverrideProperty
        {
            get => ServiceLocator.ServiceProvider.GetService(meta.FieldOrProperty.Type.ToType());

            set => meta.Proceed();
        }
    }
}
