using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using System;

namespace Cataloguer.UI.Events
{
    public class ItemSavedEventArgs<T> : EventArgs where T : BaseModel
    {
        public T Item { get; }

        public bool IsHandled { get; set; } = true;

        public ItemSavedEventArgs(T item)
        {
            Item = item;
        }
    }
}
