namespace Caravela.Documentation.SampleCode.AspectFramework.Normalize
{
    class TargetCode
    {
        private string _property;[Normalize]
        public string Property
        {
            get
            {
                return this._property;
            }

            set
            {
                this.Property = value?.Trim().ToLowerInvariant();
            }
        }
    }
}
