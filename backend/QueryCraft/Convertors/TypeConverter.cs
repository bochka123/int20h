using QueryCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QueryCraft.TypeConversations
{
    public class TypeConverter: ITypeConverter
    {
        public TypeConverter() { }
        public TypeConverter(Dictionary<Type, Func<string, object>> options) 
        {
            foreach (var key in options.Keys)
            {
                if (Converters.ContainsKey(key))
                {
                    Converters[key] = options[key];
                }
                else
                {
                    Converters.Add(key, options[key]);
                }
            }
        }
        private readonly Dictionary<Type, Func<string, object>> Converters = new Dictionary<Type, Func<string, object>>()
        {
            { typeof(DateTime), value => DateTime.Parse(value) },
            { typeof(DateTime?), value => string.IsNullOrWhiteSpace(value) ? (DateTime?)null : DateTime.Parse(value) },
            { typeof(int), value => int.Parse(value) },
            { typeof(int?), value => string.IsNullOrWhiteSpace(value) ? (int?)null : int.Parse(value) },
            { typeof(bool), value => bool.Parse(value) },
            { typeof(bool?), value => string.IsNullOrWhiteSpace(value) ? (bool?)null : bool.Parse(value) },
            { typeof(double), value => double.Parse(value) },
            { typeof(double?), value => string.IsNullOrWhiteSpace(value) ? (double?)null : double.Parse(value) },
            { typeof(string), value => value },
            { typeof(Guid), value => Guid.Parse(value) },
            { typeof(Guid?), value => string.IsNullOrEmpty(value) ? (Guid?)null : Guid.Parse(value) }
        };

        public object GetTypedValue(string value, Type type)
        {
            if (Converters.TryGetValue(type, out var converter))
            {
                return converter.DynamicInvoke(value);
            }

            return Convert.ChangeType(value, type);
        }

        public Expression GetTypedValueExpression(string value, Type type) => Expression.Constant(GetTypedValue(value, type));

        public List<object> GetTypedList(Type type, string value)
        {
            var elements = value.Trim('[', ']').Split(',');
            var list = new List<object>();
            foreach (var element in elements)
            {
                list.Add(GetTypedValue(element, type));
            }
            return list;
        }

        public Array GetTypedArray(Type type, string value)
        {
            var elements = value.Trim('[', ']').Split(',');
            Array array = Array.CreateInstance(type, elements.Length);

            for (int i = 0; i < elements.Length; i++)
            {
                array.SetValue(GetTypedValue(elements[i], type), i);
            }
            return array;
        }
    }
}
