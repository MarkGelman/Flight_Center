using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    interface IBasicDb<T> where T: IPoco
    {
       void Add(T t);
        void Remove(T t);
        void Update(T t);
        T Get();
        IList<T> GelAll();
    }
}
