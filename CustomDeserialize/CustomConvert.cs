using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDeserialize
{
    public static class CustomConvert
    {

        public static TReturn Deserialize<TReturn>(string jsonString) where TReturn : class, new()
        {
            JObject jObject = JObject.Parse(jsonString);
            TReturn Root = new TReturn();

            foreach (var prop in jObject.Properties())
            {
                var targetProp = Root.GetType().GetProperty(prop.Name);
                if (targetProp != null)
                {
                    targetProp.SetValue(Root, prop.Value.ToObject(targetProp.PropertyType));
                }
            }
            return Root;
        }
    }
}
