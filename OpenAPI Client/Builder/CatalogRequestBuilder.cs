﻿using Bol.OpenAPI.Request.Catalog;
using System.Collections.Specialized;
using System.Net;

namespace Bol.OpenAPI.Util
{
    class CatalogRequestBuilder
    {
        public static HttpWebRequest ConstructSearchRequest(string apiKey, SearchResultsRequest searchResultsRequest)
        {
            NameValueCollection queryParams = new NameValueCollection();
            queryParams.Add("apikey", apiKey);

            if (searchResultsRequest.Query != null)
            {
                queryParams.Add("q", searchResultsRequest.Query);
            }
            if (searchResultsRequest.ProductIds != null)
            {
                queryParams.Add("pids", searchResultsRequest.ProductIds);
            }
            if (searchResultsRequest.CategoryId != null || searchResultsRequest.RefinementIds != null)
            {
                string ids = FormatterUtils.CombineCategoryAndRefinementIds(searchResultsRequest.CategoryId, searchResultsRequest.RefinementIds);
                queryParams.Add("ids", ids);
            }
            if (searchResultsRequest.ListId != null)
            {
                queryParams.Add("listid", searchResultsRequest.ListId);
            }
            if (searchResultsRequest.Field != null)
            {
                queryParams.Add("searchfield", EnumUtils.StringValueOf(searchResultsRequest.Field));
            }
            if (searchResultsRequest.IncludeAttributes != null)
            {
                queryParams.Add("includeattributes", searchResultsRequest.IncludeAttributes.ToString().ToLower());
            }
            if (searchResultsRequest.DataOutputs != null)
            {
                queryParams.Add("dataoutput", FormatterUtils.FormatDataOutput(searchResultsRequest.DataOutputs));
            }
            if (searchResultsRequest.Offers != null)
            {
                queryParams.Add("offers", FormatterUtils.FormatOffer(searchResultsRequest.Offers));
            }
            if (searchResultsRequest.Sort != null)
            {
                queryParams.Add("sort", EnumUtils.StringValueOf(searchResultsRequest.Sort));
            }
            if (searchResultsRequest.Offset != null)
            {
                queryParams.Add("offset", searchResultsRequest.Offset.ToString().ToLower());
            }
            if (searchResultsRequest.Limit != null)
            {
                queryParams.Add("limit", searchResultsRequest.Limit.ToString().ToLower());
            }

            string queryString = HttpUtils.ToQueryString(queryParams);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.URL_PREFIX + "/catalog/v4/search/" + queryString);
            request.Method = "GET";
            request.Accept = "application/json";

            return request;
        }

        public static HttpWebRequest ConstructListRequest(string apiKey, ListResultsRequest listResultsRequest)
        {
            NameValueCollection queryParams = new NameValueCollection();
            queryParams.Add("apikey", apiKey);

            if (listResultsRequest.Type != null)
            {
                queryParams.Add("type", EnumUtils.StringValueOf(listResultsRequest.Type));
            }
            if (listResultsRequest.CategoryId != null || listResultsRequest.RefinementIds != null)
            {
                string ids = FormatterUtils.CombineCategoryAndRefinementIds(listResultsRequest.CategoryId, listResultsRequest.RefinementIds);
                queryParams.Add("ids", ids);
            }
            if (listResultsRequest.ListId != null)
            {
                queryParams.Add("listid", listResultsRequest.ListId);
            }
            if (listResultsRequest.IncludeAttributes != null)
            {
                queryParams.Add("includeattributes", listResultsRequest.IncludeAttributes.ToString().ToLower());
            }
            if (listResultsRequest.DataOutputs != null)
            {
                queryParams.Add("dataoutput", FormatterUtils.FormatDataOutput(listResultsRequest.DataOutputs));
            }
            if (listResultsRequest.Offers != null)
            {
                queryParams.Add("offers", FormatterUtils.FormatOffer(listResultsRequest.Offers));
            }
            if (listResultsRequest.Sort != null)
            {
                queryParams.Add("sort", EnumUtils.StringValueOf(listResultsRequest.Sort));
            }
            if (listResultsRequest.Offset != null)
            {
                queryParams.Add("offset", listResultsRequest.Offset.ToString().ToLower());
            }
            if (listResultsRequest.Limit != null)
            {
                queryParams.Add("limit", listResultsRequest.Limit.ToString().ToLower());
            }

            string queryString = HttpUtils.ToQueryString(queryParams);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.URL_PREFIX + "/catalog/v4/lists/" + queryString);
            request.Method = "GET";
            request.Accept = "application/json";

            return request;
        }

        public static HttpWebRequest ConstructProductsRequest(string apiKey, ProductsRequest productsRequest)
        {
            NameValueCollection queryParams = new NameValueCollection();
            queryParams.Add("apikey", apiKey);

            if (productsRequest.IncludeAttributes != null)
            {
                queryParams.Add("includeattributes", productsRequest.IncludeAttributes.ToString().ToLower());
            }
            if (productsRequest.Offers != null)
            {
                queryParams.Add("offers", FormatterUtils.FormatOffer(productsRequest.Offers));
            }

            string queryString = HttpUtils.ToQueryString(queryParams);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.URL_PREFIX + "/catalog/v4/products/" + FormatterUtils.FormatIds(productsRequest.Ids) + "/" + queryString);
            request.Method = "GET";
            request.Accept = "application/json";

            return request;
        }

        public static HttpWebRequest ConstructSellerListRequest(string apiKey, SellerListRequest sellerListRequest)
        {
            NameValueCollection queryParams = new NameValueCollection();
            queryParams.Add("apikey", apiKey);

            if (sellerListRequest.IncludeAttributes != null)
            {
                queryParams.Add("includeattributes", sellerListRequest.IncludeAttributes.ToString().ToLower());
            }
            if (sellerListRequest.Sort != null)
            {
                queryParams.Add("sort", EnumUtils.StringValueOf(sellerListRequest.Sort));
            }
            if (sellerListRequest.Offset != null)
            {
                queryParams.Add("offset", sellerListRequest.Offset.ToString().ToLower());
            }
            if (sellerListRequest.Limit != null)
            {
                queryParams.Add("limit", sellerListRequest.Limit.ToString().ToLower());
            }

            string queryString = HttpUtils.ToQueryString(queryParams);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.URL_PREFIX + "/catalog/v4/sellerlists/" + sellerListRequest.Id + "/" + queryString);
            request.Method = "GET";
            request.Accept = "application/json";

            return request;
        }

        public static HttpWebRequest ConstructProductRecommendationsRequest(string apiKey, ProductRecommendationsRequest productRecommendationsRequest)
        {
            NameValueCollection queryParams = new NameValueCollection();
            queryParams.Add("apikey", apiKey);

            if (productRecommendationsRequest.IncludeAttributes != null)
            {
                queryParams.Add("includeattributes", productRecommendationsRequest.IncludeAttributes.ToString().ToLower());
            }
            if (productRecommendationsRequest.Offset != null)
            {
                queryParams.Add("offset", productRecommendationsRequest.Offset.ToString().ToLower());
            }
            if (productRecommendationsRequest.Limit != null)
            {
                queryParams.Add("limit", productRecommendationsRequest.Limit.ToString().ToLower());
            }

            string queryString = HttpUtils.ToQueryString(queryParams);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.URL_PREFIX + "/catalog/v4/recommendations/" + productRecommendationsRequest.Id + "/" + queryString);
            request.Method = "GET";
            request.Accept = "application/json";

            return request;
        }

        public static HttpWebRequest ConstructProductOffersRequest(string apiKey, ProductOffersRequest productOffersRequest)
        {
            NameValueCollection queryParams = new NameValueCollection();
            queryParams.Add("apikey", apiKey);

            if (productOffersRequest.Offers != null)
            {
                queryParams.Add("offers", FormatterUtils.FormatOffer(productOffersRequest.Offers));
            }            

            string queryString = HttpUtils.ToQueryString(queryParams);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.URL_PREFIX + "/catalog/v4/offers/" + productOffersRequest.Id + "/" + queryString);
            request.Method = "GET";
            request.Accept = "application/json";

            return request;
        }

        public static HttpWebRequest ConstructRelatedProductsRequest(string apiKey, RelatedProductsRequest relatedProductsRequest)
        {
            NameValueCollection queryParams = new NameValueCollection();
            queryParams.Add("apikey", apiKey);

            if (relatedProductsRequest.DataSet != null)
            {
                queryParams.Add("dataset", FormatterUtils.FormatDataSet(relatedProductsRequest.DataSet));
            }

            string queryString = HttpUtils.ToQueryString(queryParams);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.URL_PREFIX + "/catalog/v4/relatedproducts/" + relatedProductsRequest.Id + "/" + queryString);
            request.Method = "GET";
            request.Accept = "application/json";

            return request;
        }
    }
}
