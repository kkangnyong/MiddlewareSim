using System.Runtime.InteropServices;

namespace SimReeferMiddlewareSystemWPF.Utils
{
    public interface ICustomMarshal
    {
        void Deserialize(byte[] from);

        void DeserializeByUnit(byte[] from, int index, object data)
        {
            int num = Marshal.SizeOf(data.GetType());
            IntPtr intPtr = Marshal.AllocHGlobal(num);
            Marshal.Copy(from, index, intPtr, num);
            Marshal.PtrToStructure(intPtr, data);
            Marshal.FreeHGlobal(intPtr);
        }

        IEnumerable<byte> Serialize(object data);

        IEnumerable<byte> SerializeByUnit(object data)
        {
            int num = Marshal.SizeOf(data);
            byte[] array = new byte[num];
            IntPtr intPtr = Marshal.AllocHGlobal(num);
            Marshal.StructureToPtr(data, intPtr, fDeleteOld: true);
            Marshal.Copy(intPtr, array, 0, num);
            Marshal.FreeHGlobal(intPtr);
            return array;
        }
    }
}
