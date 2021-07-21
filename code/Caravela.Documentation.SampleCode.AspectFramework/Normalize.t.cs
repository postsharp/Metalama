namespace Caravela.Documentation.SampleCode.AspectFramework.Normalize
{
    class TargetCode
    {


        private string _property;
        [Normalize]
        public string Property
        {
            get
            {
                return this.__Property__OriginalImpl;
            }

            set
            {
                this.__Property__OriginalImpl = value?.Trim().ToLowerInvariant();
            }
        }

        private string __Property__OriginalImpl
        {
            get
            {
                return this._property;
            }

            set
            {
                this._property = value;
            }
        }
    }
}
