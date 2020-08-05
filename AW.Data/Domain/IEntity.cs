using System;
using System.Collections.Generic;
using System.Text;

namespace AW.Data.Domain
{
    public interface IEntity<T> where T : IComparable
    {
        T Id { get; set; }
    }
}
