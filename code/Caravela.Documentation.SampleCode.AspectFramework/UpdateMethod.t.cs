using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.UpdateMethod
{
    [UpdateMethod]
    class CityHunter
    {
        int x;

        public string Y { get; private set; }

        public DateTime Z { get; }


        public void Update(int x, string Y)
        {
            this.x = x;
            this.Y = Y;
        }
    }

    class Program
    {
        static void Main()
        {
            CityHunter ch = new();
            ch.Update(0, "1", DateTime.Now);
        }
    }
}
