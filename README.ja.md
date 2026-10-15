<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Object Storage Tencent COS

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.objectstorage.tencent)](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.objectstorage.tencent)](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>

## プロジェクト概要

**Object Storage Tencent COS コンポーネント** - Object Storage コンポーネントの Tencent Cloud Object Storage（COS）実装を提供します。このパッケージは `TencentCloudObjectStorageManager` を実装し、ランタイムとエディタの両方でファイルやディレクトリの Tencent Cloud COS バケットへのアップロード・ダウンロードを可能にします。Tencent COS SDK は Plugins 以下に同梱されています。

### 公式リソース

- [Tencent COS ドキュメント](https://cloud.tencent.com/document/product/436/32819)
- [SDK リリース](https://github.com/tencentyun/qcloud-sdk-dotnet/releases)
- [リージョンパラメータ](https://cloud.tencent.com/document/product/436/6224)
- [API Key コンソール](https://console.cloud.tencent.com/cam/capi)

## 使用例

```csharp
using GameFrameX.ObjectStorage.Runtime;
using GameFrameX.ObjectStorage.Tencent.Runtime;

// ファクトリでマネージャーを作成・初期化
IObjectStorageManager manager = ObjectStorageManagerFactory.Create<TencentCloudObjectStorageManager>(new ObjectStorageOptions
{
    AccessKey = "your-access-key",
    SecretKey = "your-secret-key",
    BucketName = "your-bucket",
    Endpoint = "ap-guangzhou",  // バケットリージョン、Tencent では必須
    SavePath = "bundles/android",
});

// 単一ファイルのアップロード（オブジェクトキー = SavePath + ファイル名）
manager.UploadFile(new ObjectStorageUploadOptions { LocalPath = "local/file.bundle" });

// 単一オブジェクトのダウンロード（ローカルディレクトリは自動作成）
manager.DownloadFile(new ObjectStorageDownloadOptions
{
    ObjectKey = "bundles/android/file.bundle",
    LocalPath = "downloads/file.bundle",
});
```

## クイックスタート

### インストール

以下のいずれかの方法を選択してください：

1. Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：
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

   `scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

2. `manifest.json` の `dependencies` に直接追加：
   ```json
   {
      "com.gameframex.unity.objectstorage.tencent": "https://github.com/gameframex/com.gameframex.unity.objectstorage.tencent.git"
   }
   ```
3. Unity の **Package Manager** で **Git URL** を使用して追加：`https://github.com/gameframex/com.gameframex.unity.objectstorage.tencent.git`
4. リポジトリを Unity プロジェクトの `Packages` ディレクトリにクローンしてください。自動的に読み込まれます。
## プラットフォーム対応

| プラットフォーム | 対応 |
|-----------------|------|
| Windows | はい |
| macOS | はい |
| Linux | はい |
| Android | はい |
| iOS | はい |

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)
- [GitHub リポジトリ](https://github.com/GameFrameX/com.gameframex.unity.objectstorage.tencent)

## コミュニティとサポート

- QQグループ：[QRコード](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)から参加


## 依存関係

| パッケージ | 説明 |
|----------|------|
| `com.gameframex.unity.objectstorage` | 1.0.0 |

## 変更履歴

[Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.objectstorage.tencent/releases) で変更履歴を確認してください。
## ライセンス

このプロジェクトは [LICENSE](LICENSE) ファイルに定義された条件に基づいてライセンスされています。
