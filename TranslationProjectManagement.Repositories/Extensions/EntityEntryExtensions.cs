using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TranslationProjectManagement.Repositories.Extensions;

public static class EntityEntryExtensions
{
    public static bool IsPropertyExists(this EntityEntry entityEntry, string propertyName)
    {
        return entityEntry.Metadata.FindProperty(propertyName) != null;
    }

    public static bool TrySetPropertyCurrentValue(this EntityEntry entityEntry, string propertyName, object value)
    {
        if (entityEntry.IsPropertyExists(propertyName))
        {
            entityEntry.Property(propertyName).CurrentValue = value;
            return true;
        }

        return false;
    }

    public static bool TrySetPropertyIsModified(this EntityEntry entityEntry, string propertyName, bool value)
    {
        if (entityEntry.IsPropertyExists(propertyName))
        {
            entityEntry.Property(propertyName).IsModified = value;
            return true;
        }

        return false;
    }
}
