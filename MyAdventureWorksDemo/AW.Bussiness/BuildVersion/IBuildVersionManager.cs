namespace AW.Bussiness.BuildVersion
{
    using System.Collections.Generic;
    public interface IBuildVersionManager
    {
        IEnumerable<Models.BuildVersion> GetAll();
    }
}
