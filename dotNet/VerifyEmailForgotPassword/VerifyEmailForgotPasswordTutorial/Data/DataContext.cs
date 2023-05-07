

namespace VerifyEmailForgotPasswordTutorial.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // AppDomain.CurrentDomain.BaseDirectory
            // string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            // IConfigurationRoot configuration = new ConfigurationBuilder()
            //     .SetBasePath(projectPath)
            //     .AddJsonFile("appsettings.json")
            //     .Build();
            // string connectionString = configuration.GetConnectionString("DefaultConnection");


            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                // .UseSqlServer("Server=.\\SQLExpress;Database=userdb;Trusted_Connection=true;");
                .UseSqlServer("Server=localhost;Database=userdb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<User> Users => Set<User>();
    }
}
