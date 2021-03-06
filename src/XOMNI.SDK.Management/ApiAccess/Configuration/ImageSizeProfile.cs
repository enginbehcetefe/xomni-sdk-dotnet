﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Management.ApiAccess.Configuration
{
    internal class ImageSizeProfile : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/Configuration/imagesizeprofile"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/Configuration/imagesizeprofiles"; }
        }

        public Task<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile> AddAsync(XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile profile, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile>(GenerateUrl(SingleOperationBaseUrl), profile, credential);
        }

        public Task DeleteAsync(int profileId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("id", profileId.ToString());

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile> GetAsync(int profileId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("id", profileId.ToString());

            return HttpProvider.GetAsync<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task<CountedCollectionContainer<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile>> GetAllAsync(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return HttpProvider.GetAsync<CountedCollectionContainer<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        internal XOMNIRequestMessage<Model.Management.Configuration.ImageSizeProfile> CreatePostRequest(Model.Management.Configuration.ImageSizeProfile profile, ApiBasicCredential apiBasicCredential)
        {
            return new XOMNIRequestMessage<Model.Management.Configuration.ImageSizeProfile>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), apiBasicCredential, profile));
        }

        internal XOMNIRequestMessage CreateDeleteRequest(int profileId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("id", profileId.ToString());

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        internal XOMNIRequestMessage<Model.Management.Configuration.ImageSizeProfile> CreateGetByIdRequest(int profileId, ApiBasicCredential apiBasicCredential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("id", profileId.ToString());

            return new XOMNIRequestMessage<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile>(HttpProvider.CreateGetRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), apiBasicCredential));
        }

        internal XOMNIRequestMessage<CountedCollectionContainer<Model.Management.Configuration.ImageSizeProfile>> CreateGetByIdRequest(int skip, int take, ApiBasicCredential apiBasicCredential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return new XOMNIRequestMessage<CountedCollectionContainer<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), apiBasicCredential));
        }
    }
}
