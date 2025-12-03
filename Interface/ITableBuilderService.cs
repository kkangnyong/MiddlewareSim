namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface ITableBuilderService
    {
        string ToString(byte[] values, params string[] headers);
    }
}
