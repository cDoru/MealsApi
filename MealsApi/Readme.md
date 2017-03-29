Add a migration:

Add-Migration -Verbose -ConfigurationTypeName ContextConfiguration -ConnectionString "Data Source=.;Initial Catalog=Meals;Integrated Security=True;" -ConnectionProviderName "System.Data.SqlClient" InitialMigration


Update db : 

Update-Database -Script -ConfigurationTypeName ContextConfiguration -Verbose -ConnectionString "Data Source=.;Initial Catalog=Meals;Integrated Security=True;" -ConnectionProviderName "System.Data.SqlClient"

