namespace TrueStudentInformation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrueStudentInformation.Models.TrueStudentInformationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "TrueStudentInformation.Models.TrueStudentInformationContext";
        }

        protected override void Seed(TrueStudentInformation.Models.TrueStudentInformationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
