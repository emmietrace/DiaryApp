using System;
using System.Collections.Generic;
using System.Text;

namespace DiaryApp.Models
{
    public class DiaryEntry : BaseDomainObject
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

    }
}
