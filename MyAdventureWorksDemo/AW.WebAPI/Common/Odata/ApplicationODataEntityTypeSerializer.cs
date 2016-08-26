namespace AW.WebAPI.Common.Odata
{
    using Microsoft.OData.Core;
    using System.Collections.Generic;
    using System.Web.OData;
    using System.Web.OData.Formatter.Serialization;
    public class ApplicationODataEntityTypeSerializer : ODataEntityTypeSerializer
    {
        public ApplicationODataEntityTypeSerializer(ODataSerializerProvider serializerProvider) : base(serializerProvider) { }

        public override ODataEntry CreateEntry(SelectExpandNode selectExpandNode, EntityInstanceContext entityInstanceContext)
        {
            ODataEntry entry = base.CreateEntry(selectExpandNode, entityInstanceContext);

            // Remove any properties which are null.
            var properties = new List<ODataProperty>();
            foreach (ODataProperty property in entry.Properties)
            {
                if (property.Value != null)
                {
                    properties.Add(property);
                }
            }

            entry.Properties = properties;

            return entry;
        }
    }
}