using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CSVHandler
    {
        // Flags for get non static, public and private field
        private static BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        public static string SerializetoCSV<T>(T obj)
        {
            if (obj == null) return string.Empty;

            Type type = typeof(T); // class type

            var fields = type.GetFields(Flags);
            var properties = type.GetProperties(Flags);

            var names = fields.Select(f => f.Name).Concat(properties.Select(p => p.Name));

            var values = fields.Select(f => f.GetValue(obj)?.ToString() ?? "")
                .Concat(properties.Select(p => p.GetValue(obj)?.ToString() ?? ""));

            return string.Join(",", names) + Environment.NewLine + string.Join(",", values);
        }

        public static T DeserializeFromCSV<T>(string csv) where T : new()
        {
            var lines = csv.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length < 2) return default!;

            var headers = lines[0].Split(',');
            var values = lines[1].Split(',');

            T obj = new T();
            Type type = typeof(T);


            for (int i = 0; i < headers.Length; i++)
            {
                string name = headers[i];
                string value = values[i];

                var field = type.GetField(name, Flags);
                if (field != null)
                {
                    field.SetValue(obj, Convert.ChangeType(value, field.FieldType));
                    continue;
                }

                var properties = type.GetProperty(name, Flags);
                if (properties != null && properties.CanWrite)
                {
                    properties.SetValue(obj, Convert.ChangeType(value, properties.PropertyType));
                }
            }

            return obj;
        }
    }
}
