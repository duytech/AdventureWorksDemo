namespace AW.DataAccess.BuildVersion
{
    using Common;

    public class BuildVersionRepo : Repository<Entities.AWBuildVersion>, IBuildVersionRepo
    {
        public BuildVersionRepo(IDbFactory context) : base(context) { }
    }
}
