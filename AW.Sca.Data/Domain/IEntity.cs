using System;

namespace AW.Sca.Data.Domain
{
    public interface IEntity<T> where T : IComparable
    {
        T Id { get; set; }
    }
}
