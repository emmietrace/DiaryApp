using System;
using System.Collections.Generic;
using System.Text;

namespace DiaryApp.Models
{
    public class Tag : BaseDomainObject
    {
        public string Name { get; set; }

        public List<DiaryEntry> DiaryEntries { get; set; } = new List<DiaryEntry>();
    }
}
