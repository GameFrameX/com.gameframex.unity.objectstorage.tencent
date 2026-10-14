using GameFrameX.ObjectStorage.Tencent.Editor;
using GameFrameX.ObjectStorage.Editor;
using NUnit.Framework;

namespace GameFrameX.ObjectStorage.Tencent.Tests
{
    internal class UnitTests
    {
        IObjectStorageUploadManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = ObjectStorageUploadFactory.Create<TencentCloudObjectStorageUploadManager>("AKurewkfsdmnmzcxzQxdjhsaX4C8sJ", "Njfksjfkwczxdsacxzzdsa2d1PZWFl", "game-xx-132899909", "ap-guangzhou");
            _manager.SetSavePath("test/aa/zz");
        }

        [Test]
        public void Create_ReturnsTencentUploadManager()
        {
            // 工厂按类型参数创建腾讯云上传管理器：本地凭证构造，无网络 I/O。
            Assert.IsNotNull(_manager);
            Assert.IsInstanceOf<TencentCloudObjectStorageUploadManager>(_manager);
        }
    }
}