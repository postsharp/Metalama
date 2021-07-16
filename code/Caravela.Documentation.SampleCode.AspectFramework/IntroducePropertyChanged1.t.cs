using System.ComponentModel;

namespace Caravela.Documentation.SampleCode.AspectFramework.IntroducePropertyChanged1
{
    [IntroducePropertyChangedAspect]
    class TargetCode
    {


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
