namespace AW.Bussiness.Shift
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DataAccess.Shift;
    using DI;
    using System;
    using System.Linq;
    using Models;

    public class ShiftManager : IShiftManager
    {
        private IShiftRepo shiftRepo;
        private IConfigurationProvider configurationProvider;
        private IMapper mapper;

        public ShiftManager() : this(ServiceLocator.Current.Get<IShiftRepo>(), ServiceLocator.Current.Get<IConfigurationProvider>(), ServiceLocator.Current.Get<IMapper>()) { }

        public ShiftManager(IShiftRepo shiftRepo, IConfigurationProvider configurationProvider, IMapper mapper)
        {
            this.shiftRepo = shiftRepo;
            this.configurationProvider = configurationProvider;
            this.mapper = mapper;
        }

        public IQueryable<Models.Shift> Search()
        {
            return shiftRepo.GetAllQueryable().ProjectTo<Models.Shift>(configurationProvider);
        }

        public Shift Save(Shift shift)
        {
            var sh = mapper.Map<DataAccess.Entities.Shift>(shift);
            var shCreated = shiftRepo.Create(sh);
            shiftRepo.Save();

            return mapper.Map<Shift>(shCreated);
        }
    }
}
