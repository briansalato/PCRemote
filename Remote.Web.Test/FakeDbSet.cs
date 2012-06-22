using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Remote.Web.DTO;

namespace Remote.Web.Test
{
    public class FakeDbSet<T> : IDbSet<T> where T : IdModel
    {
        private List<T> _items;
        public FakeDbSet(List<T> items)
        {
            _items = items;
        }
        public FakeDbSet(T item) 
            : this(new List<T>() { item }) { }
        public FakeDbSet() 
            : this(new List<T>()) { }

        public T Add(T entity)
        {
            entity.Id = _items.Count > 0 ? _items.Max(m => m.Id) + 1 : 1;
            _items.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get { throw new NotImplementedException(); }
        }

        public T Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return _items.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _items.AsQueryable().Provider; }
        }
    }
}
