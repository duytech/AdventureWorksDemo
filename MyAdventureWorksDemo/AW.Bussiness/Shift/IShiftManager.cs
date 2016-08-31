namespace AW.Bussiness.Shift
{
    using System.Linq;
    public interface IShiftManager
    {
        IQueryable<Models.Shift> Search();

        Models.Shift GetById(int id);

        Models.Shift Save(Models.Shift shift, out string error);
    }
}
