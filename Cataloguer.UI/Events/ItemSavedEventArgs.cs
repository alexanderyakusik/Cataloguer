using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using System;

namespace Cataloguer.UI.Events
{
    public class ItemSavedEventArgs<T> : EventArgs
    {
        public T Item { get; }

        public ItemSavedEventArgs(T item)
        {
            Item = item;
        }
    }
}
