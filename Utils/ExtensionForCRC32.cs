
namespace SimReeferMiddlewareSystemWPF.Utils
{
    public static class ExtensionForCRC32
    {
        public static uint CRC32(this IEnumerable<byte> data, CRC32Type type = CRC32Type.Basic)
        {
            return BitConverter.ToUInt32(new CRC32(type).Compute(data).ToArray(), 0);
        }

        public static IEnumerable<byte> WithCRC32(this IEnumerable<byte> data, CRC32Type type = CRC32Type.Basic)
        {
            return new CRC32(type).Encode(data);
        }
    }
}
