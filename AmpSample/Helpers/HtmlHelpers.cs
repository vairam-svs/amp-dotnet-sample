using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AmpSample.Helpers
{
    public class NewsArticleSchema
    {
        public string context { get; set; }
        public string type { get; set; }
        public string headline { get; set; }
        public string datePublished { get; set; }
        public string[] image { get; set; }
    }
    public static class HtmlHelpers
    {
        public static MvcHtmlString PageSchema(this HtmlHelper htmlHelper)
        {
            ///TODO: to convert this into a JSON Converter of param list.
            StringBuilder value2 = new StringBuilder();
            value2.Append(@"
<script type=""application/ld+json"">
        {
        ""@context"": ""http://schema.org/article"",
        ""@type"": ""NewsArticle"",
        ""headline"": ""Open-source framework for publishing content"",
        ""datePublished"": ""2015-10-07T12:02:41Z"",
        ""image"": [
        ""logo.jpg""
        ]
    }
    </script>");
            return MvcHtmlString.Create(value2.ToString());
        }

        
        public static MvcHtmlString NewsArticleSchemaBuilder(this HtmlHelper htmlHelper,
                            string headline = "Open-source framework for publishing content", 
                            string datePublished = "2015-10-07T12:02:41Z",
                            params string[] imageList)
        {
            
            if (imageList.Length == 0)
                imageList = new string[] { "slide1-narrow.jpg" };
            NewsArticleSchema schema = new NewsArticleSchema
            {
                context = "http://schema.org/article",
                type = "NewsArticle",
                headline = headline,
                datePublished = datePublished,
                image = imageList
            };

            string serialized = JsonConvert.SerializeObject(schema);
            ///TODO: to convert this into a JSON Converter of param list.
            StringBuilder value2 = new StringBuilder();
            value2.Append(@"<script type=""application/ld+json"">");
            value2.Append(serialized);
            value2.Append(@"</script>");
            return MvcHtmlString.Create(value2.ToString());
        }
        public static MvcHtmlString StyleAmpTemplate(this HtmlHelper htmlHelper)
        {
            return MvcHtmlString.Create(@"
<style amp-boilerplate>
    body {
        -webkit-animation:-amp-start 8s steps(1,end) 0s 1 normal both;
        -moz-animation:-amp-start 8s steps(1,end) 0s 1 normal both;
        -ms-animation:-amp-start 8s steps(1,end) 0s 1 normal both;
        animation:-amp-start 8s steps(1,end) 0s 1 normal both;
    }
    @-webkit-keyframes -amp-start { 
        from{visibility:hidden}
        to{visibility:visible}
    }
    @-moz-keyframes -amp-start{
        from{visibility:hidden}
        to{visibility:visible}
    }
    @-ms-keyframes -amp-start {
        from{visibility:hidden}
        to{visibility:visible}
    }
    @-o-keyframes -amp-start {
        from{visibility:hidden}
        to{visibility:visible}
    }
    @keyframes -amp-start{
        from{visibility:hidden}
        to{visibility:visible}
    }
</style>");
        }

        public static MvcHtmlString WebKitNoAnimation(this HtmlHelper htmlHelper)
        {
            return MvcHtmlString.Create(@"
<noscript>
        <style amp-boilerplate>
             body {
                -webkit - animation: none;
                -moz - animation: none;
                -ms - animation: none;
                animation: none;
             }
        </style>
</noscript>");
        }

    }

}