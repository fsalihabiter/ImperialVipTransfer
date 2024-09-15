using System.Data.Entity;

namespace ImperialVip.DataAccess
{
    public class MyInitializer : CreateDatabaseIfNotExists<ImperialDatabaseContext>
    {
        protected override void Seed(ImperialDatabaseContext context)
        {
            context.Oteller.Add(new Entities.Otel { Id = 1, OtelAdi = "Default"});
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
