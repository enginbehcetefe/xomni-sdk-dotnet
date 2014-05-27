﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;
using XOMNI.SDK.Private.ApiAccess.Catalog.CategoryAsset;

namespace XOMNI.SDK.Private.Catalog
{
    public class CategoryManagement : ManagementBase, IAssetRelation
    {
        private CategoryMetadata categoryMetadataApi;
        private XOMNI.SDK.Private.ApiAccess.Catalog.Category categoryApi;

        public CategoryManagement()
        {
            categoryMetadataApi = new CategoryMetadata();
            categoryApi = new ApiAccess.Catalog.Category();
        }

        /// <summary>
        /// Adds a new metadata to given category.
        /// </summary>
        /// <param name="categoryId">The unique id of the category.</param>
        /// <param name="metadataKey">Key for the metadata.</param>
        /// <param name="metadataValue">Value for the metadata.</param>
        /// <returns>Created metadata instance.</returns>
        /// <exception cref="XOMNI.SDK.Core.Exception.NotFoundException">Given category not found in backend.</exception>
        /// <exception cref="XOMNI.SDK.Core.Exception.ConflictException">Given metadata key already exists in category metadata collection.</exception>
        public async Task<CategoryMetaData> AddMetadataAsync(int categoryId, string metadataKey, string metadataValue)
        {
            var metadata = CreateCategoryMetadata(categoryId, metadataKey, metadataValue);
            var createdMetadata = await categoryMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
            return createdMetadata;
        }

        public async Task DeleteMetadataAsync(int categoryId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            await categoryMetadataApi.DeleteMetadataAsync(categoryId, metadataKey, this.ApiCredential);
        }

        public async Task ClearMetadataAsync(int categoryId)
        {
            await categoryMetadataApi.ClearMetadataAsync(categoryId, this.ApiCredential);
        }

        public async Task<List<Metadata>> GetAllMetadataAsync(int categoryId)
        {
            List<Metadata> categoryMetadataList = await categoryMetadataApi.GetAllMetadataAsync(categoryId, this.ApiCredential);
            return categoryMetadataList;
        }

        public async Task<CategoryMetaData> UpdateMetadataAsync(int categoryId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateCategoryMetadata(categoryId, metadataKey, updatedMetadataValue);
            CategoryMetaData updatedMetadata = await categoryMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
            return updatedMetadata;
        }

        private CategoryMetaData CreateCategoryMetadata(int categoryId, string metadataKey, string metadataValue)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            CategoryMetaData metadata = new CategoryMetaData()
            {
                CategoryId = categoryId,
                Key = metadataKey,
                Value = metadataValue
            };
            return metadata;
        }

        public Task<AssetRelationMapping> RelateImageAsync(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(categoryId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Video).PostRelationAsync(categoryId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateDocumentAsync(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Document).PostRelationAsync(categoryId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateImageAsync(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Video).PostRelationAsync(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateDocumentAsync(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Document).PostRelationAsync(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public Task UnrelateImageAsync(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Image).DeleteRelationAsync(categoryId, assetId, this.ApiCredential);
        }

        public Task UnrelateVideoAsync(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Video).DeleteRelationAsync(categoryId, assetId, this.ApiCredential);
        }

        public Task UnrelateDocumentAsync(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Document).DeleteRelationAsync(categoryId, assetId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedImageAsset>> GetImagesAsync(int categoryId)
        {
            return GetAssetApi(AssetContentType.Image).GetRelationAsync<Model.Private.Asset.RelatedImageAsset>(categoryId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedAsset>> GetVideosAsync(int categoryId)
        {
            return GetAssetApi(AssetContentType.Video).GetRelationAsync<Model.Private.Asset.RelatedAsset>(categoryId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedAsset>> GetDocumentsAsync(int categoryId)
        {
            return GetAssetApi(AssetContentType.Document).GetRelationAsync<Model.Private.Asset.RelatedAsset>(categoryId, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateImageRelation(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Image).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateVideoRelation(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Video).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateDocumentRelation(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
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

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> AddCategoryAsync(XOMNI.SDK.Model.Private.Catalog.Category category)
        {
            return categoryApi.AddAsync(category, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> UpdateCategoryAsync(XOMNI.SDK.Model.Private.Catalog.Category category)
        {
            return categoryApi.UpdateAsync(category, this.ApiCredential);
        }

        public Task DeleteCategoryAsync(int categoryId)
        {
            return categoryApi.DeleteAsync(categoryId, this.ApiCredential);
        }

        public Task<Model.Private.Catalog.CategoryTree> GetCategoryTreeAsync()
        {
            return categoryApi.GetCategoryTree(this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> GetCategoryAsync(int categoryId)
        {
            return categoryApi.GetById(categoryId, this.ApiCredential);
        }
    }
}