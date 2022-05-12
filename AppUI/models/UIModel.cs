using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Util;

namespace AppUI.models
{
    public abstract class UIModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected Action<string>                 propertyAction;
        protected Action                         DeBounce;

        public void SetBouncer(Action bounceAction)
        {
            if (null != bounceAction) DeBounce = bounceAction.Debounce();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyAction != null)
            {
                propertyAction(propertyName);
            }

            if (null != DeBounce)
            {
                DeBounce();
            }
        }

        protected void PropagateChange([CallerMemberName] string propName = null) => OnPropertyChanged(propName);
    }
}