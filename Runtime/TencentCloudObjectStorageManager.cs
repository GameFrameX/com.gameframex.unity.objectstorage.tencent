using System;
using System.Collections.Generic;
using System.IO;
using COSXML;
using COSXML.Auth;
using COSXML.Model.Bucket;
using COSXML.Model.Object;
using COSXML.Model.Tag;
using COSXML.Transfer;
using GameFrameX.ObjectStorage.Runtime;
using UnityEngine;

namespace GameFrameX.ObjectStorage.Tencent.Runtime
{
    /// <summary>
    /// 腾讯云的对象存储实现。支持上传、下载与列举对象。
    /// 示例文档：https://cloud.tencent.com/document/product/436/32819
    /// SDK：https://github.com/tencentyun/qcloud-sdk-dotnet
    /// </summary>
    public sealed class TencentCloudObjectStorageManager : BaseObjectStorageManager
    {
        private const int ListPageSize = 1000;

        private CosXml _cosXml;
        private TransferManager _transferManager;

        /// <summary>
        /// 使用腾讯云凭证初始化。Endpoint 为存储桶地域（如 ap-guangzhou），重复调用会被忽略。
        /// </summary>
        /// <param name="options">初始化参数</param>
        public override void Init(ObjectStorageOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (string.IsNullOrEmpty(options.Endpoint))
            {
                throw new ArgumentException("腾讯云对象存储的 endpoint（存储桶地域，如 ap-guangzhou）不能为空", "options");
            }

            if (_cosXml != null)
            {
                return;
            }

            base.Init(options);

            CosXmlConfig config = new CosXmlConfig.Builder()
                .IsHttps(true)
                .SetRegion(options.Endpoint)
                .SetDebugLog(true)
                .Build();

            long durationSecond = 600;
            QCloudCredentialProvider credentialProvider = new DefaultQCloudCredentialProvider(options.AccessKey, options.SecretKey, durationSecond);
            _cosXml = new CosXmlServer(config, credentialProvider);
            _transferManager = new TransferManager(_cosXml, new TransferConfig());
        }

        protected override bool UploadFileInternal(string objectKey, string localFilePath)
        {
            COSXMLUploadTask uploadTask = new COSXMLUploadTask(Options.BucketName, objectKey);
            uploadTask.SetSrcPath(localFilePath);
            uploadTask.MaxConcurrent = 20;
            COSXMLUploadTask.UploadTaskResult result = _transferManager.UploadAsync(uploadTask).ConfigureAwait(false).GetAwaiter().GetResult();
            if (!result.IsSuccessful())
            {
                Debug.LogError("上传文件失败，本地文件路径：" + localFilePath + " 对象键：" + objectKey + "\n" + result.GetResultInfo());
                return false;
            }

            return true;
        }

        protected override bool DownloadFileInternal(string objectKey, string localFilePath)
        {
            GetObjectRequest request = new GetObjectRequest(Options.BucketName, objectKey, Path.GetDirectoryName(localFilePath), Path.GetFileName(localFilePath));
            GetObjectResult result = _cosXml.GetObject(request);
            if (!result.IsSuccessful())
            {
                Debug.LogError("下载文件失败，对象键：" + objectKey + " 本地文件路径：" + localFilePath + "\n" + result.GetResultInfo());
                return false;
            }

            return true;
        }

        protected override IEnumerable<string> ListObjectKeys(string prefix)
        {
            List<string> objectKeys = new List<string>();
            string nextMarker = null;
            do
            {
                GetBucketRequest request = new GetBucketRequest(Options.BucketName);
                request.SetPrefix(prefix);
                request.SetMaxKeys(ListPageSize.ToString());
                if (nextMarker != null)
                {
                    request.SetMarker(nextMarker);
                }

                GetBucketResult result = _cosXml.GetBucket(request);
                ListBucket listBucket = result.listBucket;
                if (listBucket != null && listBucket.contentsList != null)
                {
                    foreach (ListBucket.Contents contents in listBucket.contentsList)
                    {
                        if (!string.IsNullOrEmpty(contents.key) && !contents.key.EndsWith("/"))
                        {
                            objectKeys.Add(contents.key);
                        }
                    }

                    nextMarker = string.IsNullOrEmpty(listBucket.nextMarker) ? null : listBucket.nextMarker;
                }
                else
                {
                    nextMarker = null;
                }
            } while (nextMarker != null);

            return objectKeys;
        }
    }
}
