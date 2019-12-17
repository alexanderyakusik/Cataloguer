using Cataloguer.UI.ViewModels.BaseClasses;
using System;

namespace Cataloguer.UI.Events
{
    public class ItemSavedEventArgs<T> : EventArgs where T : BaseViewModel
    {
        public T Item { get; }

        public bool IsHandled { get; set; } = true;

        public ItemSavedEventArgs(T item)
        {
            Item = item;
        }
    }
}
