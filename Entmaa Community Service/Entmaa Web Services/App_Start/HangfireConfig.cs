using System;
using System.Diagnostics;
using System.Collections.Generic;
using Hangfire;
using Hangfire.SqlServer;

namespace Entmaa_Web_Services.App_Start
{
    public class HangfireConfig
    {
        public static void ConfigureHangfire(Owin.IAppBuilder app)
        {
            app.UseHangfireAspNet(GetHangfireServers);

            #if DEBUG
            app.UseHangfireDashboard();
            BackgroundJob.Enqueue(() => Debug.WriteLine("Hello from Hangfire!"));
            #endif
        }

        private static IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("EntmaaConnection", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true,
                    EnableHeavyMigrations = true,
                });

            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromSeconds(25),
            };

            yield return new BackgroundJobServer();
        }
    }
}