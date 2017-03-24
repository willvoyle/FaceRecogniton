using System.Collections.Specialized;
using System.Configuration;

namespace Azure.CognitiveServices.FaceRecognition.FaceImporter.Helpers
{
    public class ConfigurationManagerProvider
    {
        public virtual NameValueCollection AppSettings => ConfigurationManager.AppSettings;
    }
}
