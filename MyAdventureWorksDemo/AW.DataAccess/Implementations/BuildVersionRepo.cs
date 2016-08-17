namespace AW.DataAccess.Implementations
{
    using AW.DataAccess.Common;
    using Interfaces;

    public class BuildVersionRepo : Repository<Entities.AWBuildVersion>, IBuildVersionRepo
    {
        public BuildVersionRepo(IDbFactory context) : base(context) { }
    }
}
