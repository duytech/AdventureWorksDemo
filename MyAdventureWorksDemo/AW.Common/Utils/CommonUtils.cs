namespace AW.Common.Utils
{
    using Constants;
    public static class CommonUtils
    {
        public static Sorting ParseSorting(string sortingString)
        {
            if (string.IsNullOrEmpty(sortingString))
                return null;

            var sorting = new Sorting();

            var direction = sortingString.Substring(0, 1);

            if (direction == "+")
                sorting.Direction = SortDirection.Ascending;
            else if (direction == "-")
                sorting.Direction = SortDirection.Descending;
            else
                return null;

            var propertyName = sortingString.Substring(1, sortingString.Length - 1);

            if (string.IsNullOrEmpty(propertyName))
                return null;

            sorting.PropertyName = propertyName;

            return sorting;
        }
    }
}
