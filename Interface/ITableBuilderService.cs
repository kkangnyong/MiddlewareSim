namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface ITableBuilderService
    {
        string ToString(byte[] target, bool withTitle = true, params string[] exceptProperties);
    }
}
