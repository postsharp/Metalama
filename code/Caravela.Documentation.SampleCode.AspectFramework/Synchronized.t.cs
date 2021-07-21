namespace Caravela.Documentation.SampleCode.AspectFramework.Synchronized
{
    [Synchronized]
    class SynchronizedClass
    {
        double _total;
        int _samplesCount;

        public void AddSample(double sample)
        {
            lock (this)
            {
                this._samplesCount++;
                this._total += sample;
                return;
            }
        }

        public void Reset()
        {
            lock (this)
            {
                this._total = 0;
                this._samplesCount = 0;
                return;
            }
        }

        public double Average => this._samplesCount / this._total;

    }
}
