namespace AW.Bussiness.Shift
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DataAccess.Shift;
    using DI;
    using System;
    using System.Linq;
    public class ShiftManager : IShiftManager
    {
        private IShiftRepo shiftRepo;
        private IConfigurationProvider configurationProvider;

        public ShiftManager() : this(ServiceLocator.Current.Get<IShiftRepo>(), ServiceLocator.Current.Get<IConfigurationProvider>()) { }

        public ShiftManager(IShiftRepo shiftRepo, IConfigurationProvider configurationProvider)
        {
            this.shiftRepo = shiftRepo;
            this.configurationProvider = configurationProvider;
        }

        public IQueryable<Models.Shift> Search()
        {
            return shiftRepo.GetAllQueryable().ProjectTo<Models.Shift>(configurationProvider);
        }
    }
}
