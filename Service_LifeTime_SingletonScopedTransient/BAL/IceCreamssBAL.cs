using Service_LifeTime_SingletonScopedTransient.IBAL;
using Service_LifeTime_SingletonScopedTransient.Models;

namespace Service_LifeTime_SingletonScopedTransient.BAL
{
    public class IceCreamssBAL : IIceCreamssBAL
    {
        List<IceCream> iceCreams = new List<IceCream>();
        public List<IceCream> GetIceCreams()
        {
            return iceCreams;
        }

        public bool PostIceCreams(IceCream iceCream)
        {
            iceCream.IceCreamVersion = iceCream.IceCreamVersion + 0.1;

            iceCreams.Add(iceCream);

            return true;
        }
    }
}
