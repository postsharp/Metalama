using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.UpdateMethod
{
    [UpdateMethod]
    class CityHunter
    {
        int x;

        public string Y { get; private set; }

        public DateTime Z { get; }
    }

    class Program
    {
        static void Main()
        {
            CityHunter ch = new();
#if CARAVELA
            ch.Update(0, "1", DateTime.Now);
#endif
        }
    }
}
