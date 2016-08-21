namespace AW.Bussiness.BuildVersion
{
    #region
    using AutoMapper;
    using DataAccess.BuildVersion;
    using DI;
    using System.Collections.Generic;
    #endregion
    public class BuildVersionManager : IBuildVersionManager
    {
        private IBuildVersionRepo repo;
        private IMapper mapper;

        public BuildVersionManager() : this(ServiceLocator.Current.Get<IBuildVersionRepo>(), ServiceLocator.Current.Get<IMapper>())
        { }

        public BuildVersionManager(IBuildVersionRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public IEnumerable<Models.BuildVersion> GetAll()
        {
            return mapper.Map<IEnumerable<Models.BuildVersion>>(repo.GetAll());
        }
    }
}
