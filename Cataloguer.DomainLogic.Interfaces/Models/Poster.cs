using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;

namespace Cataloguer.DomainLogic.Interfaces.Models
{
    public class Poster : BaseModel
    {
        public byte[] Image { get; set; }
    }
}
