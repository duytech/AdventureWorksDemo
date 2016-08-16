namespace AW.DataAccess.Implementations
{
    using AW.DataAccess.Common;
    using Interfaces;

    public class AWBuildVersionRepo : Repository<Entities.AWBuildVersion>, IAWBuildVersionRepo
    {
        public AWBuildVersionRepo(IAWDbFactory context) : base(context) { }
    }
}
