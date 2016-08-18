namespace AW.Bussiness.BuildVersion
{
    using AutoMapper;
    using DataAccess.BuildVersion;
    using DI;
    using System.Collections.Generic;
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
            var result = repo.GetAll();
            var mappedResult = mapper.Map<IEnumerable<Models.BuildVersion>>(result);

            return mappedResult;
        }
    }
}
