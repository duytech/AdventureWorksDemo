namespace AW.Bussiness.DI
{
    internal interface IServiceLocator
    {
        T Get<T>();
    }
}
