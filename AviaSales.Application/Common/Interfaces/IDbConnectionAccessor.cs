using System.Data;

namespace AviaSales.Application.Common.Interfaces;

public interface IDbConnectionAccessor
{
    IDbConnection Connection { get; }
}