

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MilitaryElite.Models.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {

       IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
