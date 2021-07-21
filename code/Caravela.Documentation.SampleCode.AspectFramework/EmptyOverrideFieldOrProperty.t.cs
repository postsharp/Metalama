using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravela.Documentation.SampleCode.AspectFramework
{
    class EmptyOverrideFieldOrPropertyExample
    {

        private string _property;

        // TODO: Add a field (bug #28910).

        [EmptyOverrideFieldOrProperty]
        public string Property
        {
            get
            {
                return __Property__OriginalImpl;
            }

            set
            {
                _ = (object)this.__Property__OriginalImpl = value;
                return;
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
