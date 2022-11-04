namespace Program;
using Npgsql;
using System.Collections.Generic;
using SQLConnection;

class NPGSQL {
    public static async Task<NpgsqlDataSource> CreateDataSource() {
        var connectionString = "Host=localhost:5432;Username=postgres;Password=markus;Database=GitInsight";
        
        await using var dataSource = NpgsqlDataSource.Create(connectionString);
        Console.WriteLine(dataSource);
        return dataSource;
    }

    public static async void doStuff(Task<NpgsqlDataSource> dataSource) {
        Console.WriteLine("hej");
        var dataSourceNew = await dataSource;
        Console.WriteLine("0");
        await using var command = dataSourceNew.CreateCommand("SELECT * FROM data");
        Console.WriteLine("1");
        await using var reader = await command.ExecuteReaderAsync();
        Console.WriteLine("2");
        
        while (await reader.ReadAsync()) {
            Console.WriteLine(reader);
            Console.WriteLine(reader.GetString(0));
        }
    }
}