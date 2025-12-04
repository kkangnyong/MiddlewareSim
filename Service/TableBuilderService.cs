using ConsoleTableExt;
using SimReeferMiddlewareSystemWPF.Interface;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public class TableBuilderService : ITableBuilderService
    {
        public string ToString(string[] values, params string[] headers)
        {
            var columns = new List<string>();
            var datas = new List<object>();
            var tableData = new List<List<object>>()
            {
                datas
            };

            int i = 0;
            foreach (var header in headers)
            {
                columns.Add(header);
                datas.Add(values[i]);
                i++;
            }

            var result = ConsoleTableBuilder.From(tableData)
                                            .WithColumn(columns)
                                            .WithFormat(ConsoleTableBuilderFormat.Alternative);

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
