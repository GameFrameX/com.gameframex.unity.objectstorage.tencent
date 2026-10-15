<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Object Storage Tencent COS

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.objectstorage.tencent)](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.objectstorage.tencent)](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

**Object Storage Tencent COS Component** - Provides the Tencent Cloud Object Storage (COS) implementation for the Object Storage component. This package implements `TencentCloudObjectStorageManager`, allowing you to upload and download files and directories to and from Tencent Cloud COS buckets in both runtime and editor builds. The Tencent COS SDK is shipped under Plugins.

### Official Resources

- [Tencent COS Documentation](https://cloud.tencent.com/document/product/436/32819)
- [SDK Releases](https://github.com/tencentyun/qcloud-sdk-dotnet/releases)
- [Region Parameters](https://cloud.tencent.com/document/product/436/6224)
- [API Key Console](https://console.cloud.tencent.com/cam/capi)

## Usage

```csharp
using GameFrameX.ObjectStorage.Runtime;
using GameFrameX.ObjectStorage.Tencent.Runtime;

// Create and initialize the manager through the factory
IObjectStorageManager manager = ObjectStorageManagerFactory.Create<TencentCloudObjectStorageManager>(new ObjectStorageOptions
{
    AccessKey = "your-access-key",
    SecretKey = "your-secret-key",
    BucketName = "your-bucket",
    Endpoint = "ap-guangzhou",  // bucket region, required for Tencent
    SavePath = "bundles/android",
});

// Upload a single file (object key = SavePath + file name)
manager.UploadFile(new ObjectStorageUploadOptions { LocalPath = "local/file.bundle" });

// Download a single object (local directories are created automatically)
manager.DownloadFile(new ObjectStorageDownloadOptions
{
    ObjectKey = "bundles/android/file.bundle",
    LocalPath = "downloads/file.bundle",
});
```

## Quick Start

### Installation

Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:
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

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.objectstorage.tencent": "https://github.com/gameframex/com.gameframex.unity.objectstorage.tencent.git"
   }
   ```
3. Use **Package Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.objectstorage.tencent.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.
## Platform Support

| Platform | Supported |
|----------|-----------|
| Windows | Yes |
| macOS | Yes |
| Linux | Yes |
| Android | Yes |
| iOS | Yes |

## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)
- [GitHub Repository](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent)

## Community & Support

- QQ Group: Join via [QR Code](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)


## Dependencies

| Package | Description |
|---------|-------------|
| `com.gameframex.unity.objectstorage` | 1.0.0 |

## Changelog

See [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.objectstorage.tencent/releases) for changelog.
## License

See [LICENSE.md](LICENSE.md) for license information.
