using System;
namespace GestiuneNote.Domain
{
    public interface IHasID<ID>
    {
        ID Id { get; set; }
    }
}
