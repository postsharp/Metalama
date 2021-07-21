using System;
using System.ComponentModel;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.IntroducePropertyChanged3
{
    class IntroducePropertyChangedAspect : Attribute, IAspect<INamedType>
    {
        [Introduce]
        public event PropertyChangedEventHandler PropertyChanged;

        [Introduce]
        protected virtual void OnPropertyChanged( string propertyName )
        {
            meta.This.PropertyChanged?.Invoke(meta.This, new PropertyChangedEventArgs(propertyName));
        }
    }
}
