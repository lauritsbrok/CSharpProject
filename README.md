# CSharpProject

To Update Database use command:

- dotnet ef --startup-project ../Application/ database update

To Generate Migration use:

- dotnet ef --startup-project ../Application/ migrations add <Title>

To Set Connection String use:

1. CONNECTION_STRING="Server=localhost;Port=5432;User Id=tjornelund;Password=0;Database=GitInsight;"
2. dotnet user-secrets set "ConnectionStrings:GitInsight" "$CONNECTION_STRING"