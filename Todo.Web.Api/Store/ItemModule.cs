using Autofac;

namespace todo_app.Store
{
    public class ItemModule : Module
    {
        private readonly string _dbConnectionString;

        public ItemModule(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            // this will do a singleton and not initialise the itemstore everytime the controller uses it.
            // good for in-memory database.
            builder.RegisterInstance(new ItemStore(_dbConnectionString)).SingleInstance().As<IItemStore>();
            // this way returns a new instance of ItemStore anywhere that IItemStore is used (e.g. in the Item controllers constructor)
            // builder.RegisterType<ItemStore>().As<IItemStore>();
        }
    }
}
