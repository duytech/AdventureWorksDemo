namespace AW.DataAccess.Shift
{
    using Common;
    public class ShiftRepo : Repository<Entities.Shift>, IShiftRepo
    {
        public ShiftRepo(IDbFactory context) : base(context) { }
    }
}
