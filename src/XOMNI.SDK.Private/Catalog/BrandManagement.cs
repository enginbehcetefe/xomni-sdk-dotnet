﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;
using XOMNI.SDK.Private.ApiAccess.Catalog.BrandAsset;
using XOMNI.SDK.Model;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.Catalog
{
    public class BrandManagement : BaseCRUDSkipTakeManagement<Model.Catalog.Brand>, IAssetRelation
    {
        public Task<AssetRelationMapping> RelateImageAsync(int brandId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(brandId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int brandId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Video).PostRelationAsync(brandId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateDocumentAsync(int brandId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Document).PostRelationAsync(brandId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateImageAsync(int brandId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(brandId, assetId, isDefault, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int brandId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Video).PostRelationAsync(brandId, assetId, isDefault, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateDocumentAsync(int brandId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Document).PostRelationAsync(brandId, assetId, isDefault, this.ApiCredential);
        }

        public Task UnrelateImageAsync(int brandId, int assetId)
        {
            return GetAssetApi(AssetContentType.Image).DeleteRelationAsync(brandId, assetId, this.ApiCredential);
        }

        public Task UnrelateVideoAsync(int brandId, int assetId)
        {
            return GetAssetApi(AssetContentType.Video).DeleteRelationAsync(brandId, assetId, this.ApiCredential);
        }

        public Task UnrelateDocumentAsync(int brandId, int assetId)
        {
            return GetAssetApi(AssetContentType.Document).DeleteRelationAsync(brandId, assetId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedImageAsset>> GetImagesAsync(int brandId)
        {
            return GetAssetApi(AssetContentType.Image).GetRelationAsync<Model.Private.Asset.RelatedImageAsset>(brandId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedAsset>> GetVideosAsync(int brandId)
        {
            return GetAssetApi(AssetContentType.Video).GetRelationAsync<Model.Private.Asset.RelatedAsset>(brandId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedAsset>> GetDocumentsAsync(int brandId)
        {
            return GetAssetApi(AssetContentType.Document).GetRelationAsync<Model.Private.Asset.RelatedAsset>(brandId, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateImageRelationAsync(int brandId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = brandId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Image).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateVideoRelationAsync(int brandId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = brandId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Video).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateDocumentRelationAsync(int brandId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = brandId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Document).PutRelationAsync(mapping, this.ApiCredential);
        }

        private CatalogAssetBase GetAssetApi(AssetContentType assetType)
        {
            switch (assetType)
            {
                case AssetContentType.Image:
                    return new Image();
                case AssetContentType.Video:
                    return new Video();
                case AssetContentType.Document:
                    return new Document();
                default: return null;
            }
        }

        public Task<CountedCollectionContainer<Model.Catalog.Brand>> GetByCategoryIdAsync(int categoryId, int skip, int take)
        {
            return ((Private.ApiAccess.Catalog.Brand)ApiAccess).GetByCategoryIdAsync(categoryId, skip, take, this.ApiCredential);
        }

        protected override CRUDApiAccessBase<Model.Catalog.Brand> ApiAccess
        {
            get { return new ApiAccess.Catalog.Brand(); }
        }

        #region low level methods

        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateImageRequest(int brandId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Image).CreatePostRelationRequest(brandId, assetRelation, this.ApiCredential);
        }
        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateVideoRequest(int brandId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Video).CreatePostRelationRequest(brandId, assetRelation, this.ApiCredential);
        }
        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateDocumentRequest(int brandId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Document).CreatePostRelationRequest(brandId, assetRelation, this.ApiCredential);
        }
        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateImageRequest(int brandId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Image).CreatePostRelationRequest(brandId, assetId, isDefault, this.ApiCredential);
        }
        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateVideoRequest(int brandId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Video).CreatePostRelationRequest(brandId, assetId, isDefault, this.ApiCredential);
        }
        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateDocumentRequest(int brandId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Document).CreatePostRelationRequest(brandId, assetId, isDefault, this.ApiCredential);
        }
        public XOMNIRequestMessage CreateUnrelateImageRequest(int brandId, int assetId)
        {
            return GetAssetApi(AssetContentType.Image).CreateDeleteRelationRequest(brandId, assetId, this.ApiCredential);
        }
        public XOMNIRequestMessage CreateUnrelateVideoRequest(int brandId, int assetId)
        {
            return GetAssetApi(AssetContentType.Video).CreateDeleteRelationRequest(brandId, assetId, this.ApiCredential);
        }
        public XOMNIRequestMessage CreateUnrelateDocumentRequest(int brandId, int assetId)
        {
            return GetAssetApi(AssetContentType.Document).CreateDeleteRelationRequest(brandId, assetId, this.ApiCredential);
        }
        public XOMNIRequestMessage<List<Model.Private.Asset.RelatedImageAsset>> CreateGetImagesRequest(int brandId)
        {
            return GetAssetApi(AssetContentType.Image).CreateGetRelationRequest<Model.Private.Asset.RelatedImageAsset>(brandId, this.ApiCredential);
        }
        public XOMNIRequestMessage<List<Model.Private.Asset.RelatedAsset>> CreateGetVideosRequest(int brandId)
        {
            return GetAssetApi(AssetContentType.Video).CreateGetRelationRequest<Model.Private.Asset.RelatedAsset>(brandId, this.ApiCredential);
        }
        public XOMNIRequestMessage<List<Model.Private.Asset.RelatedAsset>> CreateGetDocumentsRequest(int brandId)
        {
            return GetAssetApi(AssetContentType.Document).CreateGetRelationRequest<Model.Private.Asset.RelatedAsset>(brandId, this.ApiCredential);
        }
        public XOMNIRequestMessage<AssetRelationMapping> CreateUpdateImageRelationRequest(int brandId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = brandId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Image).CreatePutRelationRequest(mapping, this.ApiCredential);
        }
        public XOMNIRequestMessage<AssetRelationMapping> CreateUpdateVideoRelationRequest(int brandId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = brandId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Video).CreatePutRelationRequest(mapping, this.ApiCredential);
        }
        public XOMNIRequestMessage<AssetRelationMapping> CreateUpdateDocumentRelationRequest(int brandId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = brandId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Document).CreatePutRelationRequest(mapping, this.ApiCredential);
        }
        public XOMNIRequestMessage<CountedCollectionContainer<Model.Catalog.Brand>> CreateGetByCategoryIdRequest(int categoryId, int skip, int take)
        {
            return ((Private.ApiAccess.Catalog.Brand)ApiAccess).CreateGetByCategoryIdRequest(categoryId, skip, take, this.ApiCredential);
        }

        #endregion
    }
}
