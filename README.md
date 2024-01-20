**Audit back-end**

This project on the introduction of violations, prescriptions... which were discovered during the branch inspection.
The project is useful for the Department of Labor Protection. It automates their work

This project used clean architecture

If u want launch project uncommented code ~\AuditInfrastructure\Data\AuditDbContext.cs 
       ```CSharp
        public AuditDbContext(DbContextOptions<AuditDbContext> options) :
           base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }```

and ~\Audit\Program.cs
     ```CSharp
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        //for first launch
        //using (var scope = host.Services.CreateScope())
        //{
        //    var services = scope.ServiceProvider;
        //    try
        //    {
        //        var context = services.GetRequiredService<AuditDbContext>();
        //        SeedData.Initialization(context);
        //    }
        //    catch (Exception ex)
        //    {
        //        var logger = services.GetRequiredService<ILogger<Program>>();
        //        logger.LogError(ex, "An error occurred seeding the DB");
        //    }
        //}
        host.Run();
    }```
