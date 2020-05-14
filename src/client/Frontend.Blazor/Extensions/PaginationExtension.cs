namespace Frontend.Blazor.Extensions
{
    using Frontend.Blazor.ViewModels;
    using System.Collections.Generic;
    using static Frontend.Blazor.ViewModels.PaginationViewModel;

    public static class PaginationExtension
    {
        public static void PageToPager(this PaginationViewModel pagination, int currentPage, int totalPage)
        {
            const int leftActive = 3;
            const int rightActive = 3;

            var lastItem = totalPage;
            var left = currentPage - leftActive;
            var right = currentPage + rightActive;

            var pagesActive = new List<int>();
            var pagesActiveWuthDots = new List<string>();

            #region set range of page active
            if (left < 0)
            {
                left = 1;
                right = leftActive + rightActive;
            }

            if (right > totalPage)
            {
                var diff = (right - totalPage);
                if (diff <= rightActive)
                {
                    right = totalPage;
                    left -= diff;
                }
            }
            #endregion

            #region generate page active
            for (var i = 1; i <= lastItem; i++)
            {
                if (i == 1 || i == lastItem || i >= left && i <= right)
                {
                    pagesActive.Add(i);
                }
            }

            var l = 0;
            foreach (var number in pagesActive)
            {
                if (number - l != 1)
                {
                    pagesActiveWuthDots.Add("...");
                }
                pagesActiveWuthDots.Add(number.ToString());
                l = number;
            }
            #endregion

            #region generate pager
            pagination.PageItems.Clear();
            foreach (var item in pagesActiveWuthDots)
            {
                pagination.PageItems.Add(new Pager()
                {
                    Text = item,
                    IsActive = true
                });
            }
            #endregion
        }
    }
}
