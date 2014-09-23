﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.PII
{
    public class WishlistMetadata : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/pii/wishlistmetadata"; }
        }
        protected override string ListOperationBaseUrl
        {
            get { return "/private/pii/wishlistmetadata"; }
        }
        public Task<List<Model.Private.PII.WishlistMetadata>> GetAllMetadataAsync(Guid wishlistUniqueKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>
            {
                {"wishlistUniqueKey", wishlistUniqueKey.ToString("D")}
            };
            return HttpProvider.GetAsync<List<Model.Private.PII.WishlistMetadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }
        public Task<Model.Private.PII.WishlistMetadata> AddMetadataAsync(Model.Private.PII.WishlistMetadata wishlistMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<Model.Private.PII.WishlistMetadata>(GenerateUrl(SingleOperationBaseUrl), wishlistMetadata, credential);
        }
        public Task<Model.Private.PII.WishlistMetadata> UpdateMetadataAsync(Model.Private.PII.WishlistMetadata wishlistMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<Model.Private.PII.WishlistMetadata>(GenerateUrl(SingleOperationBaseUrl), wishlistMetadata, credential);
        }
        public Task DeleteMetadataAsync(Guid wishlistUniqueKey, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>
            {
                { "wishlistUniqueKey", wishlistUniqueKey.ToString("D") },
                { "metadataKey", metadataKey }
            };
            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }
        public Task ClearMetadataAsync(Guid wishlistUniqueKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>
            {
                { "wishlistUniqueKey", wishlistUniqueKey.ToString("D") }
            };
            return HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }
    }
}