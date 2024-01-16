using DocumentVersionManager.Domain.Entities;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence
{
    public static class SeedExtensionPlsremovethis
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ModelTypeGroup>().HasData(ModelTypeGroup.Create("LOADCELLS_GROUP", "AUTOMATIC", "FLOW TYPES FOR LOADCELL", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")),
            //  ModelTypeGroup.Create("TESTLINKS_GROUP", "MANUAL", "FLOW TYPES FOR TESTLINKS", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")),
            //  ModelTypeGroup.Create("SCALES/PAD", "MANUAL", "FLOW TYPES FOR SCALES/PAD", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")));

            modelBuilder.Entity<ModelType>().HasData((ModelType.Create("FIRSTMODELTYPE", "LOADCELLS_GROUP", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
                         ModelType.Create("SECONDMODELTYPE", "TESTLINKS_GROUP", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")),
                         ModelType.Create("THIRDMODELTYPE", "SCALES/PAD", Guid.Parse("3c69923e-a68e-4348-b06c-7007f527355d"))));


            // modelBuilder.Entity<Model>().HasData((Model.Create("FIRSTMODEL", "FIRSTMODELTYPE", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //              Model.Create("SECONDMODEL", "SECONDMODELTYPE", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")),
            //                                      Model.Create("THIRDMODEL", "THIRDMODELTYPE", Guid.Parse("3c69923e-a68e-4348-b06c-7007f527355d"))));

            // modelBuilder.Entity<ModelVersion>().HasData(ModelVersion.Create(1, "SPECIAL DESIGN", "FIRST_VERSION_FIRSTMODEL_NAME", "FIRSTMODELNAME", "AUTOMATIC", DateTime.UtcNow, "OLADEJI", 100, 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL1", true, 20, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1
            //, 1, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //  ModelVersion.Create(2, "AUTO DESIGN TO COMBAT SPLIILING", "SECOND_VERSION_FIRSTMODELNAME", "FIRSTMODELNAME", "MANUAL", DateTime.UtcNow, "OLADEJI", 100, 2, 2, 2, 2, 2, 2, 2, 2, "SHELLMATERIAL1", true, 20, 2, 2, "CCNUMBER", "CLASS", "APPLICATION", 2, 2, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5")),
            //  ModelVersion.Create(1, "INITIAL DESIGN", "FIRST_VERSION_SECONDMODELNAME", "SECONDMODELNAME", "GETVALUESFROMTESTINGFLOWTYPES", DateTime.UtcNow, "OLADEJI", 100, 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL1", true, 20, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1, 1, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")));


            // modelBuilder.Entity<Document>().HasData(Document.Create("FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1, "CONTENT PDF PATH", "CHANGE ORDER PATH", "DOCPATHID", "SIMPLE DESCRITION OF DOCUMENT", DateTime.UtcNow, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            // Document.Create("FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "CONTENT PDF PATH", "CHANGE ORDER PATH", "DOCPATHID", "SIMPLE DESCRITION OF DOCUMENT", DateTime.UtcNow, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            // Document.Create("FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "CONTENT PDF PATH", "CHANGE ORDER PATH", "DOCPATHID", "SIMPLE DESCRITION OF DOCUMENT", DateTime.UtcNow, Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5")),
            // Document.Create("FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2, "CONTENT PDF PATH", "CHANGE ORDER PATH", "DOCPATHID", "SIMPLE DESCRITION OF DOCUMENT", DateTime.UtcNow, Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")));

            // modelBuilder.Entity<DocumentType>().HasData(DocumentType.Create("Cabling", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //                   DocumentType.Create("Chroming", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //                    DocumentType.Create("Sealing", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //                      DocumentType.Create("Gauging", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //                   DocumentType.Create("Wiring", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")));

            // modelBuilder.Entity<DocumentDocumentType>().HasData(
            //DocumentDocumentType.Create("FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "Cabling", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //DocumentDocumentType.Create("FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "Chroming", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //DocumentDocumentType.Create("FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "Sealing", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //DocumentDocumentType.Create("FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "Cabling", Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5")),
            //DocumentDocumentType.Create("FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "Chroming", Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5")),
            //DocumentDocumentType.Create("FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "Sealing", Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5")));


            // modelBuilder.Entity<TestPoint>().HasData(TestPoint.Create("FIRSTMODELNAME", 1, 10000, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //    TestPoint.Create("FIRSTMODELNAME", 1, 2000, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //    TestPoint.Create("FIRSTMODELNAME", 1, 3000, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //    TestPoint.Create("FIRSTMODELNAME", 1, 4000, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //    TestPoint.Create("SECONDMODELNAME", 1, 49, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")));

            // modelBuilder.Entity<ShellMaterial>().HasData(ShellMaterial.Create("ShellMaterial1", true, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //     ShellMaterial.Create("ShellMaterial2", true, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //      ShellMaterial.Create("ShellMaterial3", true, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //        ShellMaterial.Create("ShellMaterial4", true, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")));

        }




    }

}
