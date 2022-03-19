using System.Text.Json;
using TabasApi.Dtos;
using TabasApi.Repositories;

namespace TabasApi
{
    public static class Extensions
    {
        public static void UpdateDB(this IDataBase db)
        {
            string jsonString = JsonSerializer.Serialize(db);
            System.IO.File.WriteAllText("DataBase.json", jsonString);
        }
    }
}