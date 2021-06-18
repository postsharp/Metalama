using System;
using System.Collections.Generic;
using System.Composition;
using Microsoft.DocAsCode.Dfm;

namespace Caravela.Documentation.DfmExtensions
{
    [Export(typeof(IDfmCustomizedRendererPartProvider))]
    public class IncludeSampleRendererPartProvider : IDfmCustomizedRendererPartProvider
    {
        public IEnumerable<IDfmCustomizedRendererPart> CreateParts(IReadOnlyDictionary<string, object> parameters)
        {
            yield return new IncludeSampleRendererPart();
        }
    }
}