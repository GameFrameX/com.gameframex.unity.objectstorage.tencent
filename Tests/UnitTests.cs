using GameFrameX.ObjectStorage.Tencent.Runtime;
using GameFrameX.ObjectStorage.Runtime;
using NUnit.Framework;

namespace GameFrameX.ObjectStorage.Tencent.Tests
{
    internal class UnitTests
    {
        IObjectStorageManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = ObjectStorageManagerFactory.Create<TencentCloudObjectStorageManager>(new ObjectStorageOptions
            {
                AccessKey = "AKurewkfsdmnmzcxzQxdjhsaX4C8sJ",
                SecretKey = "Njfksjfkwczxdsacxzzdsa2d1PZWFl",
                BucketName = "game-xx-132899909",
                Endpoint = "ap-guangzhou",
                SavePath = "test/aa/zz",
            });
        }

        [Test]
        public void Create_ReturnsTencentManager()
        {
            // 工厂按类型参数创建腾讯云管理器：本地凭证构造，无网络 I/O。
            Assert.IsNotNull(_manager);
            Assert.IsInstanceOf<TencentCloudObjectStorageManager>(_manager);
        }
    }
}
