using System.Collections.Generic;
using System.IO;

namespace Azure.CognitiveServices.FaceRecognition.FaceImporter.Helpers
{
    public class DirectoryProvider
    {
        public virtual IEnumerable<string> EnumerateFiles(string folder, string searchPattern)
        {
            return Directory.EnumerateFiles(folder, searchPattern);
        }
    }
}
