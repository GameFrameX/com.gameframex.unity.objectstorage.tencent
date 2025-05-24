using System;
using System.IO;
using COSXML;
using COSXML.Auth;
using COSXML.Transfer;
using GameFrameX.ObjectStorage.Editor;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.ObjectStorage.Tencent.Editor
{
    /// <summary>
    /// 腾讯云的对象存储
    /// 示例文档：  https://cloud.tencent.com/document/product/436/32819#.E4.B8.8A.E4.BC.A0.E5.AF.B9.E8.B1.A1
    /// SDK：https://github.com/tencentyun/qcloud-sdk-dotnet/releases
    /// </summary>
    public sealed class TencentCloudObjectStorageUploadManager : BaseObjectStorageUploadManager
    {
        private bool _isInit = false;
        private string _bucketName;
        private CosXmlConfig _config;
        private CosXml _cosXml;
        private TransferManager _transferManager;

        public override void Init(string accessKey, string secretKey, string bucketName, string endpoint = null)
        {
            if (_isInit)
            {
                return;
            }

            _bucketName = bucketName;

            //初始化 CosXmlConfig 
            string region = endpoint; //设置一个默认的存储桶地域
            _config = new CosXmlConfig.Builder()
                      .IsHttps(true) //设置默认 HTTPS 请求
                      .SetRegion(region) //设置一个默认的存储桶地域
                      .SetDebugLog(true) //显示日志
                      .Build(); //创建 CosXmlConfig 对象

            long durationSecond = 600; //每次请求签名有效时长，单位为秒
            QCloudCredentialProvider cosCredentialProvider = new DefaultQCloudCredentialProvider(accessKey, secretKey, durationSecond);
            _cosXml = new CosXmlServer(_config, cosCredentialProvider);
            // 初始化 TransferConfig
            TransferConfig transferConfig = new TransferConfig();

            // 初始化 TransferManager
            _transferManager = new TransferManager(_cosXml, transferConfig);
            _isInit = true;
        }

        protected override void UploadDirectoryInternal(string localDirectory)
        {
            var directoryInfo = new DirectoryInfo(localDirectory);
            var files = directoryInfo.GetFiles();
            foreach (var fileInfo in files)
            {
                var savePath = BucketSavePath + fileInfo.FullName.Substring(UploadRootPath.Length);
                savePath = PathHelper.NormalizePath(savePath);
                var uploadTask = new COSXMLUploadTask(_bucketName, savePath);
                uploadTask.SetSrcPath(fileInfo.FullName);
                uploadTask.MaxConcurrent = 20;
                try
                {
                    var result = UploadTaskResult(_transferManager, uploadTask);
                    if (!result.IsSuccessful())
                    {
                        Debug.LogError($"上传文件失败,本地文件路径：{fileInfo.FullName}\n 目标存储路径:{savePath}");
                        Debug.LogError(result.GetResultInfo());
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }

            var directories = directoryInfo.GetDirectories();
            foreach (var directory in directories)
            {
                UploadDirectoryInternal(directory.FullName);
            }
        }

        protected override bool UploadFileInternal(string localFilePathAndName)
        {
            FileInfo fileInfo = new FileInfo(localFilePathAndName);
            if (fileInfo.Exists)
            {
                var savePath = BucketSavePath + Path.DirectorySeparatorChar + fileInfo.Name;
                savePath = PathHelper.NormalizePath(savePath);
                COSXMLUploadTask uploadTask = new COSXMLUploadTask(_bucketName, savePath);
                uploadTask.SetSrcPath(fileInfo.FullName);
                try
                {
                    var result = UploadTaskResult(_transferManager, uploadTask);
                    Console.WriteLine(result.GetResultInfo());
                    if (!result.IsSuccessful())
                    {
                        Debug.LogError($"上传文件失败,本地文件路径：{fileInfo.FullName}\n 目标存储路径:{savePath}");
                        Debug.LogError(result.GetResultInfo());
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }

                return true;
            }

            Debug.LogError($"上传文件失败,本地文件路径：{fileInfo.FullName} 不存在");
            return false;
        }

        private static COSXMLUploadTask.UploadTaskResult UploadTaskResult(TransferManager transferManager, COSXMLUploadTask uploadTask)
        {
            var result = transferManager.UploadAsync(uploadTask).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }
    }
}