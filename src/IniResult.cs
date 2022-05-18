﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniCompacter
{
    public class IniResult
    {
        public IniResult()
        {
            Values = new Dictionary<string, Dictionary<string, string>>();
        }

        public T AsEnumFromString<T>(string header, string property) where T : struct
        {
            string name = AsString(header, property);
            if (Enum.TryParse(name, out T val))
            {
                return val;
            }
            else
            {
                throw new ArgumentException($"No se puede convertir el valor \"{name}\" de la propiedad {header}.{property}, a un enum de tipo {nameof(T)}.");
            }
        }
        public T AsEnumFromInt<T>(string header, string property) where T : Enum
        {
            var type = typeof(T);
            var id = AsString(header, property);
            return (T)Enum.Parse(type, id);
        }
        public string AsString(string header, string property)
        {
            if (string.IsNullOrWhiteSpace(header) ||
                   string.IsNullOrWhiteSpace(property))
                throw new ArgumentException($"La cabecera {header}, o la propiedad {property}, estan en blanco.");

            var lowerHead = header.ToLower().Trim();
            var lowerProperty = property.ToLower().Trim();
            if (!Values.ContainsKey(lowerHead))
            {
                Console.WriteLine($"La llave {lowerHead} no existe.");
                return string.Empty;
            }
            if (!Values[lowerHead].ContainsKey(lowerProperty)) return string.Empty;

            return Values[lowerHead][lowerProperty];
        }
        public float AsFloat(string header, string property, float defaultvalue = 0f)
        {
            if (string.IsNullOrWhiteSpace(header) ||
                   string.IsNullOrWhiteSpace(property))
                throw new ArgumentException($"La cabecera {header}, o la propiedad {property}, estan en blanco.");

            var lowerHead = header.ToLower().Trim();
            var lowerProperty = property.ToLower().Trim();
            if (!Values.ContainsKey(lowerHead))
            {
                Console.WriteLine($"La llave {lowerHead} no existe.");
                return defaultvalue;
            }
            if (!Values[lowerHead].ContainsKey(lowerProperty)) return defaultvalue;

            if (!float.TryParse(Values[lowerHead][lowerProperty], out float result))
            {
                throw new FormatException($"El header {header} y propiedad {property} no tienen un valor convertible a int. Valor {Values[lowerHead][lowerProperty]}");
            }
            return result;
        }

        internal bool IsHeaderPresent(string header)
        {
            if (string.IsNullOrWhiteSpace(header)) throw new ArgumentException($"La cabecera {header}, esta en blanco.");
            var lowerHead = header.ToLower().Trim();
            return Values.ContainsKey(lowerHead);
        }

        public int AsInt(string header, string property, int defaultvalue = 0)
        {
            if (string.IsNullOrWhiteSpace(header) ||
                   string.IsNullOrWhiteSpace(property))
                throw new ArgumentException($"La cabecera {header}, o la propiedad {property}, estan en blanco.");

            var lowerHead = header.ToLower().Trim();
            var lowerProperty = property.ToLower().Trim();
            if (!Values.ContainsKey(lowerHead))
            {
                Console.WriteLine($"La llave {lowerHead} no existe.");
                return defaultvalue;
            }
            if (!Values[lowerHead].ContainsKey(lowerProperty)) return defaultvalue;

            if (!int.TryParse(Values[lowerHead][lowerProperty], out int result))
            {
                throw new FormatException($"El header {header} y propiedad {property} no tienen un valor convertible a int. Valor {Values[lowerHead][lowerProperty]}");
            }
            return result;
        }

        public string this[string header, string property]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(header) ||
                    string.IsNullOrWhiteSpace(property))
                    throw new ArgumentException($"La cabecera {header}, o la propiedad {property}, estan en blanco.");

                var lowerHead = header.ToLower().Trim();
                var lowerProperty = property.ToLower().Trim();
                if (!Values.ContainsKey(lowerHead))
                {
                    Console.WriteLine($"La llave {lowerHead} no existe.");
                    return string.Empty;
                }
                if (!Values[lowerHead].ContainsKey(lowerProperty)) return string.Empty;
                return Values[lowerHead][lowerProperty];
            }
            set
            {
                if (string.IsNullOrWhiteSpace(header) ||
                    string.IsNullOrWhiteSpace(property))
                    throw new ArgumentException($"La cabecera {header}, o la propiedad {property}, estan en blanco.");

                var lowerHead = header.ToLower().Trim();
                var lowerProperty = property.ToLower().Trim();

                if (!Values.ContainsKey(lowerHead)) Values.Add(lowerHead, new Dictionary<string, string>());
                var properties = Values[lowerHead];
                if (!properties.ContainsKey(lowerProperty)) properties.Add(lowerProperty, "");
                properties[lowerProperty] = value;
            }
        }

        private readonly Dictionary<string, Dictionary<string, string>> Values;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Si no existe, devuelve un array de 0 elementos.</returns>
        public string[] GetHeaders()
        {
            if (Values.Keys.Count == 0) return new string[0];
            return Values.Keys.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <returns>Si no existe, devuelve un array de 0 elementos.</returns>
        public string[] GetPropertyNames(string header)
        {
            if (!Values.ContainsKey(header)) return new string[0];
            return Values[header].Keys.ToArray();
        }

        /// <summary>
        /// Devuelve el valor de la propiedad, si existe.
        /// </summary>
        /// <param name="header">La cabecera del ini, delimitada por [].</param>
        /// <param name="property">El nombre de la propiedad que se quiere obtener el valor.</param>
        /// <returns>Si no existe el header o property, <see cref="string.Empty"/></returns>
        public string GetPropertyValue(string header, string property)
        {
            if (Values.Keys.Count == 0) return string.Empty;
            if (!Values.ContainsKey(header)) return string.Empty;
            if (!Values[header].ContainsKey(property)) return string.Empty;
            return Values[header][property];
        }
    }
}
