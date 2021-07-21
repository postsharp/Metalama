namespace Caravela.Documentation.SampleCode.AspectFramework.RegistryStorage
{
    [RegistryStorage("Animals")]
    class Animals
    {
        public int Turtles { get; set; }

        public int Cats { get; set; }

        public int All => this.Turtles + this.Cats;
    }
}
