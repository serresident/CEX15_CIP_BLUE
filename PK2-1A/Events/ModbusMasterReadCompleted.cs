using Prism.Events;

namespace cip_blue.Events
{
    public class ModbusMasterReadCompleted : PubSubEvent { }
    public class TcpConnect : PubSubEvent<bool> { }
}