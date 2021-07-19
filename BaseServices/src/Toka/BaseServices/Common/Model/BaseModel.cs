using System;
using System.Text;

namespace Toka.BaseServices.Common.Model
{
    [Serializable]
    public class BaseModel
    {
        protected BaseModel()
        {
        }

        public override string ToString()
        {
            const System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic;
            System.Reflection.PropertyInfo[] infos = GetType().GetProperties(flags);

            StringBuilder sb = new StringBuilder();

            string typeName = GetType().Name;
            sb.Append(typeName);

            foreach (var info in infos)
            {
                object value = info.GetValue(this, null);
                sb.AppendFormat("[{0} = {1}]", info.Name, value != null ? value.ToString() : "null");
            }
            return sb.ToString();
        }
    }
}
