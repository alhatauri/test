namespace Log.Abstractions
{
    public interface ISerializer
    {
        string Serialize<T>(T val);
        T Deserialize<T>(string val);
    }
}