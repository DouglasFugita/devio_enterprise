using NStore.Core.Messages;
using System;
using System.Collections.Generic;

namespace NStore.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        private List<Event> _notificacoes;
        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        public void AdicionarEvento(Event evento)
        {
            _notificacoes = _notificacoes ?? new List<Event>();
            _notificacoes.Add(evento);
        }

        public void RemoverEvento(Event eventoItem)
        {
            _notificacoes?.Remove(eventoItem);
        }

        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }



        #region Comparacoes
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(null, compareTo)) return false;
            if (ReferenceEquals(this, compareTo)) return true;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(null, a) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(null, a) || ReferenceEquals(null, b))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }


        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 888) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id ={Id}]";
        }
        #endregion
        

    }
}
