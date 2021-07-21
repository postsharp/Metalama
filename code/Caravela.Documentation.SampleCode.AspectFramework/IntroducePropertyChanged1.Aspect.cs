using System;
using System.ComponentModel;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.IntroducePropertyChanged1
{
    class IntroducePropertyChangedAspect : Attribute, IAspect<INamedType>
    {
        [Introduce]
        public event PropertyChangedEventHandler PropertyChanged;

        [Introduce]
        protected virtual void OnPropertyChanged( string propertyName )
        {
            this.PropertyChanged?.Invoke(meta.This, new PropertyChangedEventArgs(propertyName));
        }
    }
}
