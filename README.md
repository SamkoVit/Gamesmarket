# Gamesmarket
## Project Overview
Setup for hosting in Azure-Supabase.
https://orange-island-002961f03.6.azurestaticapps.net/

## Changes:
1. Updated from .NET 7 to .NET 9

2. Moved from MSSQL to PostgreSQL.

3. Added .AsNoTracking(); in read-only queries to improves query performance and Reduces memory usage.

4. DateCreated use DateTime.UtcNow instead of DateTime.Now because of PostgreSQL.

5. Use manualChunks in frontend to split ts code into smaller pieces to improve performance.

6. Created new migrations.

7. Add DesignTimeDbContextFactory so EF Core tools can construct ApplicationDbContext during migrations.

8. Add OnConfiguring to ApplicationDbContext to suppresses a warning (PendingModelChangesWarning) — its occurs when model changes aren't applied via migration.
