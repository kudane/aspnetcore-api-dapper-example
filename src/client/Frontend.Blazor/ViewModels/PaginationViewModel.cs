using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Blazor.ViewModels
{
    public class PaginationViewModel
    {
        public class Pager
        {
            public string Text { get; set; } = "0";
            public bool IsActive { get; set; } = false;
        }

        public List<Pager> PageItems { get; set; } = new List<Pager>(0);
    }
}
