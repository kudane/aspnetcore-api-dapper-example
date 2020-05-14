namespace Frontend.Blazor.ViewModels
{
    using System.Collections.Generic;

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
