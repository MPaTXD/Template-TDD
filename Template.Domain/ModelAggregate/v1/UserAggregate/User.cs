using Domain.Seedwork;
using Lorni.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.ModelAggregate.v1.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public User(string userName)
        {
            UserName = !string.IsNullOrEmpty(userName) ? userName : throw new DomainException("User name is empty");
        }
    }
}
