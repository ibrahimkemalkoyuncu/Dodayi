using Microsoft.EntityFrameworkCore;

namespace Dodayi.Services.BapAPI
{
    public static class DatabaseExtensions
    {
        public static string? TableName(this DbContext context, Type type)
        {
            var entityType = context.Model.FindEntityType(type);

            return entityType?.GetTableName() ?? throw new NullReferenceException($"Can't find name for type {type.Name}");
        }
    }
}
