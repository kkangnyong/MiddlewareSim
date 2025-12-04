namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface ITableBuilderService
    {
        string ToString(string[] values, params string[] headers);
    }
}
