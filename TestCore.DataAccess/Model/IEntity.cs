using System;

namespace TestCore.DataAccess.Model
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}