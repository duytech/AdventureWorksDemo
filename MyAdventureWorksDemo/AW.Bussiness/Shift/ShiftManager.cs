namespace AW.Bussiness.Shift
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DataAccess.Shift;
    using DI;
    using System.Linq;
    using Models;
    using System.Text;
    using AW.Common.Constants;
    using System;

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
            return shiftRepo.GetAllQueryable().ProjectTo<Shift>(configurationProvider);
        }

        public Shift Save(Shift shift, out string error)
        {
            error = Validate(shift);
            if (!string.IsNullOrEmpty(error))
                return null;

            var sh = mapper.Map<DataAccess.Entities.Shift>(shift);
            var shCreated = shiftRepo.Create(sh);
            shiftRepo.Save();

            return mapper.Map<Shift>(shCreated);
        }

        private string Validate(Shift shift)
        {
            var errorBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(shift.Name))
                errorBuilder.AppendLine(string.Format(Message.Common.PropertyNull, nameof(shift.Name)));

            if(shift.StartTime == null)
                errorBuilder.AppendLine(string.Format(Message.Common.PropertyNull, nameof(shift.StartTime)));

            if(shift.EndTime == null)
                errorBuilder.AppendLine(string.Format(Message.Common.PropertyNull, nameof(shift.EndTime)));

            return errorBuilder.ToString();
        }

        public Shift GetById(int id)
        {
            var entity = shiftRepo.GetById(id);
            var model = mapper.Map<Shift>(entity);

            return model;
        }
    }
}
