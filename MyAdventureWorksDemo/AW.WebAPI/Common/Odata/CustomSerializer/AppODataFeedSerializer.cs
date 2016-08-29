namespace AW.WebAPI.Common.Odata.CustomSerializer
{
    using Microsoft.OData.Core;
    using Microsoft.OData.Edm;
    using System.Collections;
    using System.Web.OData.Formatter.Serialization;
    public class AppODataFeedSerializer : ODataFeedSerializer
    {
        public AppODataFeedSerializer(ODataSerializerProvider serializerProvider)
        : base(serializerProvider)
    {
        }

        public override ODataFeed CreateODataFeed(IEnumerable feedInstance, IEdmCollectionTypeReference feedType, ODataSerializerContext writeContext)
        {
            ODataFeed feed = base.CreateODataFeed(feedInstance, feedType, writeContext);

            return feed;
        }
    }
}