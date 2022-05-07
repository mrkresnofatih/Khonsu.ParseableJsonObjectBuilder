namespace Khonsu.ParseableJsonObjectBuilder
{
    public interface IParseableJsonObjectBuilder<T>
    {
        IParseableJsonObjectBuilder<T> SetJsonPath(string jsonPath);

        T Build();
    }
}