namespace BSE.Maui.Controls
{
    public static class ViewExtensions
    {
        internal static T? FindParentOfType<T>(this Element element, bool includeThis = false)
            where T : Microsoft.Maui.IElement
        {
            if (includeThis && element is T view)
                return view;

            foreach (var parent in element.GetParentsPath())
            {
                if (parent is T parentView)
                    return parentView;
            }

            return default;
        }

        internal static IEnumerable<Element> GetParentsPath(this Element self)
        {
            Element current = self;

            while (!Application.IsApplicationOrNull(current.RealParent))
            {
                current = current.RealParent;
                yield return current;
            }
        }
    }
}
