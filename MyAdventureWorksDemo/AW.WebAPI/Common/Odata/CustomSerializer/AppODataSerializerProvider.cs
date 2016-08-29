namespace AW.WebAPI.Common.Odata.CustomSerializer
{
    using Microsoft.OData.Edm;
    using System.Web.OData.Formatter.Serialization;
    public class AppODataSerializerProvider : DefaultODataSerializerProvider
    {
        private AppODataEntityTypeSerializer serializer;

        public AppODataSerializerProvider()
        {
            serializer = new AppODataEntityTypeSerializer(this);
        }

        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.IsEntity())
            {
                return serializer;
            }

            return base.GetEdmTypeSerializer(edmType);
        }
    }
}