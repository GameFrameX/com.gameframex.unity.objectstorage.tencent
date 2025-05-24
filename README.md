# HOMEPAGE

GameFrameX 的 Object Storage 腾讯云COS 组件

**Object Storage 腾讯云COS 组件 (Object Storage Component)** - 提供Object Storage 腾讯云COS组件相关的接口。

## 官方文档

https://cloud.tencent.com/document/product/436/32819#.E4.B8.8A.E4.BC.A0.E5.AF.B9.E8.B1.A1

## SDK文档

https://github.com/tencentyun/qcloud-sdk-dotnet/releases

## 地域参数获取

https://cloud.tencent.com/document/product/436/6224

## api Key 获取

https://console.cloud.tencent.com/cam/capi

## 参数传递。请看单元测试代码

# 使用文档(文档编写于GPT4)

参照父组件文档使用

## 注意事项

# 使用方式(任选其一)

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容
   ```json
      {"com.gameframex.unity.objectstorage.tencent": "https://github.com/gameframex/com.gameframex.unity.objectstorage.tencent.git"}
    ```
2. 在Unity 的`Packages Manager` 中使用`Git URL` 的方式添加库,地址为：https://github.com/gameframex/com.gameframex.unity.objectstorage.tencent.git

3. 直接下载仓库放置到Unity 项目的`Packages` 目录下。会自动加载识别