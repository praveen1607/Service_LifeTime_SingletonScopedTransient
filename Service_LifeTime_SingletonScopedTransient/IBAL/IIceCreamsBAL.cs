using Service_LifeTime_SingletonScopedTransient.Models;

namespace Service_LifeTime_SingletonScopedTransient.IBAL
{
    public interface IIceCreamsBAL
    {
        List<IceCream> GetIceCreams();
        bool PostIceCreams(IceCream iceCream);
    }
}