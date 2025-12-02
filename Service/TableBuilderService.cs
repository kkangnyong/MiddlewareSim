using ConsoleTableExt;
using SimReeferMiddlewareSystemWPF.Interface;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public class TableBuilderService : ITableBuilderService
    {
        public string ToString(byte[] target, bool withTitle = true, params string[] exceptProperties)
        {
            //var properties = target.GetType().GetProperties();
            var columns = new List<string>();
            var datas = new List<object>();
            var tableData = new List<List<object>>()
            {
                datas
            };

            int i = 0;
            foreach (var property in target)
            {
                //if (exceptProperties.Contains(property.Name)) continue;

                columns.Add(exceptProperties[i]);
                datas.Add(property);
                i++;
            }

            var result = ConsoleTableBuilder.From(tableData)
                                            .WithColumn(columns)
                                            .WithFormat(ConsoleTableBuilderFormat.Alternative);

            if (withTitle) result = result.WithTitle(target.GetType().Name);

            return ToTableString(result);
        }

        private string ToTableString(ConsoleTableBuilder consoleTableBuilder)
        {
            string result = string.Empty;
            var builder = consoleTableBuilder.Export();
            for (int i = 0; i < builder.Length; i++) result += builder[i];

            return result;
        }
    }
}
