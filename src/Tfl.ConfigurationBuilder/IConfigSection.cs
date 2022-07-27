namespace Tfl.ConfigurationBuilder;

public interface IConfigSection
{
    T GetConfigSection<T>();
}