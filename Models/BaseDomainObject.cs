using System;
using System.Collections.Generic;
using System.Text;

namespace DiaryApp.Models
{
    public abstract class BaseDomainObject
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}
