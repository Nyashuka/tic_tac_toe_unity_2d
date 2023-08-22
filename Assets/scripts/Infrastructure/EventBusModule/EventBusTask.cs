using System.Threading.Tasks;

namespace Infrastructure.EventBusModule
{
    public delegate Task EventBusTask(EventBusArgs args);
}