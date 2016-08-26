namespace AW.WebAPI.Common.Odata
{
    using Microsoft.OData.Edm;
    using System.Web.OData.Formatter.Serialization;
    public class ApplicationODataSerializerProvider : DefaultODataSerializerProvider
    {
        private ApplicationODataEntityTypeSerializer serializer;

        public ApplicationODataSerializerProvider()
        {
            serializer = new ApplicationODataEntityTypeSerializer(this);
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