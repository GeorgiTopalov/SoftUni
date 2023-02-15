namespace BookingApp.Repositories.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T>
    {        
        void AddNew(T model);

        T Select(string criteria);

        IReadOnlyCollection<T> All();
       
    }
}
