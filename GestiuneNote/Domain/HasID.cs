using System;
using System.Xml.Linq;

namespace GestiuneNote.Domain
{
    public interface IHasID<ID>
    {
        ID Id { get; set; }

        void CreateEntityFromElement(XElement elem);
        XElement CreateElementFromEntity();
    }
}
