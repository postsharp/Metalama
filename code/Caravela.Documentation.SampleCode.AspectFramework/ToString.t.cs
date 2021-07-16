namespace Caravela.Documentation.SampleCode.AspectFramework.ToString
{
    [ToString]
    class TargetCode
    {
        int x;
        public string Y { get; set; }


        public override string ToString()
        {
            var values = new object[2];
            values[0] = this.x;
            values[1] = this.Y;
            return string.Format("{ TargetCode x={0}, Y={1} }", values);
        }
    }
}
