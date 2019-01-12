using System.Collections.Generic;
using GestiuneNote.Domain;

namespace GestiuneNote
{
    public class Repo<E, ID> where E : IHasID<ID>
    {
        public Dictionary<ID, E> Entities { get; }

        public Repo() => Entities = new Dictionary<ID, E>();

        public E FindOne(ID id)
        {
            if (!Entities.ContainsKey(id))
                return default(E);
            return Entities[id];
        }

        public virtual void Save(E entity) => Entities.Add(entity.Id, entity);

        public virtual void Update(E entity)
        {
            Entities.Remove(entity.Id);
            Entities.Add(entity.Id, entity);
        }
    }
}
