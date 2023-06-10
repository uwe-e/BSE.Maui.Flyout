namespace BSE.Maui.Controls.Platform.Windows
{
    internal static class ResourceDictionaryExtensions
    {
        public static void AddLibraryResources(this Microsoft.UI.Xaml.ResourceDictionary? resources, string key, string uri)
        {
            if (resources == null)
                return;

            var dictionaries = resources.MergedDictionaries;
            if (dictionaries == null)
                return;

            if (!resources.ContainsKey(key))
            {
                dictionaries.Add(new Microsoft.UI.Xaml.ResourceDictionary
                {
                    Source = new Uri(uri)
                });
            }
        }
    }
}
