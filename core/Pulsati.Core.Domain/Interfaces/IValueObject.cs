using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Pulsati.Core.Domain.Interfaces
{
    public interface IValueObject<TValueObject> : IDisplayNameTypeOf, IObjectComDomainValidacao<TValueObject>
    {
    }
}
