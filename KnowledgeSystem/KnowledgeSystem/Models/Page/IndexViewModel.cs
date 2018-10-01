using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnowledgeSystem.Models.Test;

namespace KnowledgeSystem.Models.Page
{
    public class IndexViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}