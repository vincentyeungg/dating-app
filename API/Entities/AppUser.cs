using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        // EF will automatically set this as an auto increment primary key if we use 'int Id'
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}