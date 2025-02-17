using System.Reflection;

namespace DocQnA.Infrastructure.Helpers;

public static class TypesHelper
{
    #region Public methods

    /// <summary>
    /// Returns target types from all assemblies by current
    /// </summary>
    /// <param name="targetType"></param>
    /// <returns>List of types</returns>
    public static List<Type> GetTypesFromAllAssembliesByGenericInterface(Type targetType)
    {
        return GetAllAssembly()
            .SelectMany(s => s.GetTypes())
            .Where(p => p.GetInterfaces().Any(i => i.Name == targetType.Name) && p.FullName!.StartsWith("DocQnA"))
            .ToList();
    }

    #endregion

    #region Private methods

    private static List<Assembly> GetAllAssembly()
    {
        return AppDomain.CurrentDomain.GetAssemblies().ToList();
    }

    #endregion
}
