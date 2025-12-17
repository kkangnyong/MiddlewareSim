namespace SimReeferMiddlewareSystemWPF.Utils
{
    public class CRC32 : ErrorDetection
    {
        private static uint[] crc_tab32;

        public CRC32Type Type { get; } = CRC32Type.Classic;


        public CRC32(CRC32Type type = CRC32Type.Classic)
        {
            Type = type;
            switch (type)
            {
                case CRC32Type.Basic:
                    if (crc_tab32 == null)
                    {
                        GenerateCRC32Table();
                    }

                    break;
                case CRC32Type.Classic:
                    if (crc_tab32 == null)
                    {
                        GenerateCRC32Table();
                    }

                    break;
            }
        }

        public override IEnumerable<byte> Compute(IEnumerable<byte> source)
        {
            List<byte> list = new List<byte>();
            if (Type == CRC32Type.Basic)
            {
                list.AddRange(ComputeCRC32(source).ToByteArray());
            }
            else if (Type == CRC32Type.Classic)
            {
                list.AddRange(ComputeCRC32(source).ToByteArray());
            }

            return list;
        }

        public override IEnumerable<byte> Decode(IEnumerable<byte> sourceWithCRC)
        {
            List<byte> result = new List<byte>();
            if (IsError(sourceWithCRC))
            {
                return result;
            }

            return sourceWithCRC.Take(sourceWithCRC.Count() - 4);
        }

        public override IEnumerable<byte> Encode(IEnumerable<byte> source)
        {
            List<byte> list = new List<byte>();
            list.AddRange(source);
            list.AddRange(Compute(source));
            return list;
        }

        public override bool IsError(IEnumerable<byte> sourceWithCRC)
        {
            if (sourceWithCRC.Count() <= 4)
            {
                return true;
            }

            IEnumerable<byte> first = sourceWithCRC.TakeLast(4);
            IEnumerable<byte> second = Compute(sourceWithCRC.Take(sourceWithCRC.Count() - 4));
            return !first.SequenceEqual(second);
        }

        public override string GetDetectionType()
        {
            return Type.ToString();
        }

        private uint ComputeCRC32(IEnumerable<byte> data)
        {
            long num = 0L;
            if (data.Count() <= 0)
            {
                return (uint)num;
            }

            uint num2 = uint.MaxValue;
            for (int i = 0; i < data.Count(); i++)
            {
                byte b = data.ElementAt(i);
                num2 = (num2 >> 8) ^ crc_tab32[(num2 ^ b) & 0xFF];
            }

            return ~num2;
        }

        private static long UpdateCRC32(long crc, byte c)
        {
            long num = 0xFFL & (long)c;
            long num2 = crc ^ num;
            crc = (crc >> 8) ^ crc_tab32[num2 & 0xFF];
            return crc;
        }

        private static void GenerateCRC32Table()
        {
            crc_tab32 = new uint[256];
            for (uint num = 0u; num < 256; num++)
            {
                uint num2 = num;
                for (int i = 0; i < 8; i++)
                {
                    num2 = (((num2 & 1) == 1) ? (0xEDB88320u ^ (num2 >> 1)) : (num2 >> 1));
                }

                crc_tab32[num] = num2;
            }
        }
    }
}
