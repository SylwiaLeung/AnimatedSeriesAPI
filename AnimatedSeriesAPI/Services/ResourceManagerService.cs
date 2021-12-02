using System.Reflection;
using System.Resources;

namespace AnimatedSeriesAPI.Models
{
    public class ResourceManagerService
    {
        private const string _path = "C:/Users/CTNW74/Desktop/projects/SeriesAPI/AnimatedSeriesAPI/AnimatedSeriesAPI/Properties/Resources.resx";
        public ResourceManager Manager { get; set; }

        public ResourceManagerService()
        {
            Manager = GetManager();
        }

        private ResourceManager GetManager()
        {
            return new(_path, Assembly.GetExecutingAssembly());
        }
    }
}