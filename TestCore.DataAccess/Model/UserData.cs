using System;

namespace TestCore.DataAccess.Model
{
    public class UserData : IEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}