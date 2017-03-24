using System;
using System.Drawing;
using System.IO;

namespace Azure.CognitiveServices.FaceRecognition.FaceImporter.Extensions
{
    public static class ImageExtensions
    {
        public static Byte[] ToByteArray(this Image image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
