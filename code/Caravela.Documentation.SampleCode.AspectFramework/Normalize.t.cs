namespace Caravela.Documentation.SampleCode.AspectFramework.Normalize
{
    class TargetCode
    {
        [Normalize]
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

        private string _property;

    }
}
