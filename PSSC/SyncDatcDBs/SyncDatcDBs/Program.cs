// Sql Server provider, the "server" or "hub".
using Dotmim.Sync;
using Dotmim.Sync.SqlServer;

SqlSyncProvider serverProvider = new SqlSyncProvider(@"Server=tcp:datcdatabaseserver.database.windows.net,1433;Initial Catalog=stats;Persist Security Info=False;User ID=admin_datc;Password=test12345#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ");

// Sqlite Client provider acting as the "client"
SqlSyncProvider clientProvider = new SqlSyncProvider(@"Server=tcp:cloudbees.database.windows.net,1433;Initial Catalog=stats;Persist Security Info=False;User ID=admin_datc;Password=test12345#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ");

// Tables involved in the sync process:
var setup = new SyncSetup("AlertsStats", "UsersStats", "__EFMigrationsHistory");

// Sync agent
SyncAgent agent = new SyncAgent(clientProvider, serverProvider);
var progress = new SynchronousProgress<ProgressArgs>(s =>
    Console.WriteLine($"{s.Context.SyncStage}:\t{s.Message}"));
do
{
    var result = await agent.SynchronizeAsync(setup, progress);
    Console.WriteLine(result);

} while (Console.ReadKey().Key != ConsoleKey.Escape);