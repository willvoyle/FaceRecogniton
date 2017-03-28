namespace Azure.CognitiveServices.FaceRecognition.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initalcommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Guid(nullable: false),
                        Name = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Faces");
        }
    }
}
