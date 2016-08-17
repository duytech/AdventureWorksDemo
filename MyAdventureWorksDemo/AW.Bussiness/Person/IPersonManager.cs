namespace AW.Bussiness.Person
{
    using System.Collections.Generic;

    public interface IPersonManager
    {
        IEnumerable<Models.Person> GetById(int id);

        IEnumerable<Models.Person> Search();
    }
}
