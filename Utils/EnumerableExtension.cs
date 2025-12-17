using System.Text;

namespace SimReeferMiddlewareSystemWPF.Utils
{
    public static class EnumerableExtension
    {
        public static string JoinItems<T>(this IEnumerable<T> obj, string connector = ",")
        {
            return string.Join(connector, obj);
        }

        public static int IndexOf<T>(this IEnumerable<T> obj, IEnumerable<T> param)
        {
            if (param.Count() == 0)
            {
                return -1;
            }

            int result = -1;
            List<int> list = new List<int>();
            for (int i = 0; i < obj.Count(); i++)
            {
                if (obj.ElementAt(i).Equals(param.ElementAt(0)))
                {
                    list.Add(i);
                }
            }

            foreach (int item in list)
            {
                if (obj.Skip(item).Take(param.Count()).SequenceEqual(param))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        public static void AddRangeParallel<T>(this ICollection<T> collection, IEnumerable<T> toAddList, ParallelOptions options)
        {
            ICollection<T> collection2 = collection;
            Parallel.ForEach(toAddList, options, delegate (T item)
            {
                collection2.Add(item);
            });
        }

        public static void AddRangeParallel<T>(this ICollection<T> collection, IEnumerable<T> toAddList, int taskCount = 0)
        {
            ICollection<T> collection2 = collection;
            if (taskCount > 0)
            {
                ParallelOptions options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = taskCount
                };
                collection2.AddRangeParallel(toAddList, options);
            }
            else
            {
                Parallel.ForEach(toAddList, delegate (T item)
                {
                    collection2.Add(item);
                });
            }
        }

        public static void AddExceptNull<T>(this ICollection<T> collection, T item)
        {
            if (item != null)
            {
                collection.Add(item);
            }
        }

        public static void AddRangeExceptNull<T>(this ICollection<T> collection, IEnumerable<T> toAddList)
        {
            foreach (T toAdd in toAddList)
            {
                collection.AddExceptNull(toAdd);
            }
        }

        public static void AddRangeExceptNullParallel<T>(this ICollection<T> collection, IEnumerable<T> toAddList, ParallelOptions options)
        {
            ICollection<T> collection2 = collection;
            Parallel.ForEach(toAddList, options, delegate (T item)
            {
                if (item != null)
                {
                    collection2.Add(item);
                }
            });
        }

        public static void AddRangeExceptNullParallel<T>(this ICollection<T> collection, IEnumerable<T> toAddList, int taskCount = 0)
        {
            ICollection<T> collection2 = collection;
            if (taskCount > 0)
            {
                ParallelOptions options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = taskCount
                };
                collection2.AddRangeParallel(toAddList, options);
                return;
            }

            Parallel.ForEach(toAddList, delegate (T item)
            {
                if (item != null)
                {
                    collection2.Add(item);
                }
            });
        }

        public static string ToDecimalString<T>(this IEnumerable<T> list, string delimiter = " ")
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (T item in list)
            {
                stringBuilder.Append(Convert.ToDecimal(item).ToString());
                stringBuilder.Append(delimiter);
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Length -= delimiter.Length;
            }

            return stringBuilder.ToString();
        }

        public static string ToUnPrefixedHexString(this IEnumerable<byte> data, string connector = " ")
        {
            string text = string.Empty;
            foreach (byte datum in data)
            {
                text = text + datum.ToString("x2") + connector;
            }

            if (data.Count() > 0)
            {
                text = text.Substring(0, text.Length - connector.Length);
            }

            return text;
        }

        public static string ToUnPrefixedHexString(this IEnumerable<sbyte> data, string connector = " ")
        {
            string text = string.Empty;
            foreach (sbyte datum in data)
            {
                text = text + datum.ToString("x2") + connector;
            }

            if (data.Count() > 0)
            {
                text = text.Substring(0, text.Length - connector.Length);
            }

            return text;
        }

        public static string ToPrefixedHexString(this IEnumerable<byte> value, bool separated = false)
        {
            string text = value.ToUnPrefixedHexString(separated ? " " : "");
            if (text.Length > 0)
            {
                text = "0x" + text;
            }

            if (separated)
            {
                text = text.Replace(" ", " 0x");
            }

            return text;
        }

        public static string ToPrefixedHexString(this IEnumerable<sbyte> value, bool separated = false)
        {
            string text = value.ToUnPrefixedHexString(separated ? " " : "");
            if (text.Length > 0)
            {
                text = "0x" + text;
            }

            if (separated)
            {
                text = text.Replace(" ", " 0x");
            }

            return text;
        }

        public static bool ContainsAll<T>(this IEnumerable<T> array, params T[] values)
        {
            HashSet<T> hashSet = new HashSet<T>(values);
            foreach (T item in array)
            {
                if (!hashSet.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            List<T> list = enumerable.ToList();
            Random random = new Random();
            int count = list.Count;
            while (count > 1)
            {
                int index = random.Next(count--);
                T value = list[index];
                list[index] = list[count];
                list[count] = value;
            }

            return list;
        }

        public static IEnumerable<T> Swap<T>(this IEnumerable<T> enumerable, int index1, int index2)
        {
            List<T> list = enumerable.ToList();
            T value = list[index1];
            list[index1] = list[index2];
            list[index2] = value;
            return list;
        }

        public static IEnumerable<T> Replace<T>(this IEnumerable<T> enumerable, T oldValue, T newValue)
        {
            List<T> list = new List<T>();
            foreach (T item2 in enumerable)
            {
                T item = (T)(EqualityComparer<T>.Default.Equals(item2, oldValue) ? ((object)newValue) : ((object)item2));
                list.Add(item);
            }

            return list;
        }

        public static bool AllEqual<T>(this IEnumerable<T> source)
        {
            using IEnumerator<T> enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return true;
            }

            T current = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (!EqualityComparer<T>.Default.Equals(enumerator.Current, current))
                {
                    return false;
                }
            }

            return true;
        }

        public static string ToEncodedString(this IEnumerable<byte> data, Encoding encoding)
        {
            if (data.Count() != 0)
            {
                return encoding.GetString(data.ToArray(), 0, data.Count());
            }

            return string.Empty;
        }

        public static string ToASCIIString(this IEnumerable<byte> data)
        {
            return data.ToEncodedString(Encoding.ASCII);
        }

        public static string ToBase64String(this IEnumerable<byte> data)
        {
            return Convert.ToBase64String(data.ToArray());
        }

        public static string ToUTF7String(this IEnumerable<byte> data)
        {
            return data.ToEncodedString(Encoding.UTF7);
        }

        public static string ToUTF8String(this IEnumerable<byte> data)
        {
            return data.ToEncodedString(Encoding.UTF8);
        }

        public static string ToUnicodeString(this IEnumerable<byte> data)
        {
            return data.ToEncodedString(Encoding.Unicode);
        }

        public static string ToUTF32String(this IEnumerable<byte> data)
        {
            return data.ToEncodedString(Encoding.UTF32);
        }

        public static IEnumerable<T> Copy<T>(this IEnumerable<T> data)
        {
            List<T> list = new List<T>();
            list.AddRange(data);
            return list;
        }

        public static T[] Copy<T>(this T[] data)
        {
            T[] array = new T[data.Length];
            Array.Copy(data, array, data.Length);
            return array;
        }
    }
}
