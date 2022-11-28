namespace ConfigurationBuilder;

public class ObjectContext
{
    private readonly Dictionary<string, object> _objects;

    public ObjectContext() => _objects = new Dictionary<string, object>();

    #region Getters

    public string Get(string key) => _objects.TryGetValue(key, out var value) ? value.ToString() : string.Empty;

    public Dictionary<string, object> GetAll() => _objects;

    #endregion

    #region Setters

    public void Set<T>(string key, T value) => _objects.Add(key, value);

    #endregion

}