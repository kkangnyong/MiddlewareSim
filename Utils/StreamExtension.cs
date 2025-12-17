using System.Runtime.InteropServices;

namespace SimReeferMiddlewareSystemWPF.Utils
{
    public static class StreamExtension
    {
        public static byte[] SerializeUsingMarshal(this object data)
        {
            if (data is ICustomMarshal)
            {
                return (data as ICustomMarshal).Serialize(data).ToArray();
            }

            int num = Marshal.SizeOf(data);
            byte[] array = new byte[num];
            IntPtr intPtr = Marshal.AllocHGlobal(num);
            Marshal.StructureToPtr(data, intPtr, fDeleteOld: true);
            Marshal.Copy(intPtr, array, 0, num);
            Marshal.FreeHGlobal(intPtr);
            return array;
        }

        public static void DeSerializeUsingMarshal(this object to, IEnumerable<byte> from)
        {
            byte[] array = from.ToArray();
            if (to is ICustomMarshal)
            {
                (to as ICustomMarshal).Deserialize(array);
                return;
            }

            IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
            Marshal.Copy(array, 0, intPtr, array.Length);
            Marshal.PtrToStructure(intPtr, to);
            Marshal.FreeHGlobal(intPtr);
        }
    }
}
