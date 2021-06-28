namespace Caravela.Documentation.SampleCode.AspectFramework.Normalize
{
    class TargetCode
    {
        [Normalize]
        public string Property
        {
            get
            {
                return this.__Property__BackingField;
            }

            set
            {
                this.__Property__BackingField = value?.Trim().ToLowerInvariant();
            }
        }
        private string __Property__BackingField;
    }
}