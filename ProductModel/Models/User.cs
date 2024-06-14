using System;

namespace ProductModel.Models
{
    public class User
    {
        Guid Id { get; }
        public string Name { get; }

        public User(string name)
        {
            Name = name;
            Id = Guid.NewGuid();    
        }
    }
}
