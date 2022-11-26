using MyHome.Domain.Aggregates;

namespace MyHome.Domain.Services
{
    public interface IOrderStrategy
    {
        Family GetAbleFamily(HomeQueue home);
    }
}
