using Azure.CognitiveServices.FaceRecognition.Data.Entities;
using System.Data.Entity;

namespace Azure.CognitiveServices.FaceRecognition.Data
{
    public class FaceContext : DbContext
    {
        public FaceContext() : base(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Faces;Integrated Security=True")
        {

        }

        public virtual DbSet<Face> Faces { get; set; }

    }
}
