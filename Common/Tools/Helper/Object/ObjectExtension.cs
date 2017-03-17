using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tools.Helper.Object
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Créer un Dictionary[clé] = valeur depuis un objet anonyme
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }
            return result;
        }
        
        /// <summary>
        /// Savoir si une propriété existe dans l'objet anonynme
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name">Nom de la propriété</param>
        /// <returns></returns>
        public static bool IsPropertyExist(this object obj, string name)
        {
            if (obj == null || string.IsNullOrWhiteSpace(name))
                throw new FormatException("Les paramètres ne doivent être ni nuls ni vides.");
            return obj.GetType().GetProperty(name) != null;
        }
        
    }
}
