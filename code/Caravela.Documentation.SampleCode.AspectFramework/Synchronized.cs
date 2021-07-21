namespace Caravela.Documentation.SampleCode.AspectFramework.Synchronized
{
    [Synchronized]
    class SynchronizedClass
    {
        double _total;
        int _samplesCount;

        public void AddSample(double sample)
        {
            this._samplesCount++;
            this._total += sample;
        }

        public void Reset()
        {
            this._total = 0;
            this._samplesCount = 0;
        }

        public double Average => this._samplesCount / this._total;
        
    }
}
