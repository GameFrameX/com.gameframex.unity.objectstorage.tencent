<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Object Storage Tencent COS

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.objectstorage.tencent)](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.objectstorage.tencent)](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 项目简介

**Object Storage 腾讯云 COS 组件** - 提供 Object Storage 组件的腾讯云对象存储（COS）实现。本包实现了 `TencentCloudObjectStorageManager`，运行时与编辑器均支持上传、下载文件和目录到/从腾讯云 COS 存储桶，腾讯云 COS SDK 位于 Plugins 目录。

### 官方资源

- [腾讯云 COS 文档](https://cloud.tencent.com/document/product/436/32819)
- [SDK 发布](https://github.com/tencentyun/qcloud-sdk-dotnet/releases)
- [地域参数](https://cloud.tencent.com/document/product/436/6224)
- [API Key 控制台](https://console.cloud.tencent.com/cam/capi)

## 使用示例

```csharp
using GameFrameX.ObjectStorage.Runtime;
using GameFrameX.ObjectStorage.Tencent.Runtime;

// 通过工厂创建并初始化管理器
IObjectStorageManager manager = ObjectStorageManagerFactory.Create<TencentCloudObjectStorageManager>(new ObjectStorageOptions
{
    AccessKey = "your-access-key",
    SecretKey = "your-secret-key",
    BucketName = "your-bucket",
    Endpoint = "ap-guangzhou",  // 存储桶地域，腾讯云必填
    SavePath = "bundles/android",
});

// 上传单个文件（对象键 = SavePath + 文件名）
manager.UploadFile(new ObjectStorageUploadOptions { LocalPath = "local/file.bundle" });

// 下载单个对象（自动创建本地目录）
manager.DownloadFile(new ObjectStorageDownloadOptions
{
    ObjectKey = "bundles/android/file.bundle",
    LocalPath = "downloads/file.bundle",
});
```

## 快速开始

### 安装

选择以下任一方式：

1. 编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：
   ```json
   {
     "scopedRegistries": [
       {
         "name": "GameFrameX",
         "url": "https://gameframex.upm.alianblank.uk",
         "scopes": [
           "com.gameframex"
         ]
       }
     ],
     "dependencies": {
       "com.gameframex.unity.objectstorage.tencent": "1.1.0"
     }
   }
   ```

   `scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex` 开头的包才会从这个注册表获取。

2. 直接在 `manifest.json` 的 `dependencies` 节点下添加以下内容：
   ```json
   {
      "com.gameframex.unity.objectstorage.tencent": "https://github.com/gameframex/com.gameframex.unity.objectstorage.tencent.git"
   }
   ```
3. 在 Unity 的 `Package Manager` 中使用 `Git URL` 的方式添加库，地址为：`https://github.com/gameframex/com.gameframex.unity.objectstorage.tencent.git`
4. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。
## 平台支持

| 平台 | 支持 |
|------|------|
| Windows | 是 |
| macOS | 是 |
| Linux | 是 |
| Android | 是 |
| iOS | 是 |

## 文档与资源

- [文档](https://gameframex.doc.alianblank.com)
- [GitHub 仓库](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent)

## 社区与支持

- QQ群：通过 [二维码](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6) 加入


## 依赖

| 包 | 说明 |
|----|------|
| `com.gameframex.unity.objectstorage` | 1.0.0 |

## 更新日志

查看 [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.objectstorage.tencent/releases) 了解更新日志。
## 开源协议

详见 [LICENSE.md](LICENSE.md) 文件。
