namespace AW.Bussiness.Shift
{
    using System.Linq;
    public interface IShiftManager
    {
        IQueryable<Models.Shift> Search();
    }
}
