# 安裝手冊

本文件說明如何安裝全球旌旗資訊網。文件說明分2個部份，前台與後台安裝手冊。


## 後台

### 首次安裝 API Service
1. 建立目錄 c:\inetpub\wwwroot\bannerch-admin
2. 解壓輝 banner-api.zip 後，，放到 c:\inetpub\wwwroot\bannerch-admin
3. 設定 IIS 虛擬目錄
4. 修改設定檔
  - appsettings-sql.json 修改資料庫設定為正式環境資料庫
    ```json
    {
        "SqlConfig": {
            "Provider": "MSSQL",
            "Connection": "Server=127.0.0.1,1433;Database=bch_classapp;User Id=gamma;Password=p@ssword;TrustServerCertificate=true"
        }
    }
    ```
5. 修改 web.config
   ```
   ```
6. 測試系統是否安裝正確

### 更新系統
1. 解壓後 banner-api.zip 後，放到 c:\inetpub\wwwroot\bannerch-admin\wwwroot


### 首次安裝 後台介面
1. 建立目錄 c:\inetpub\wwwroot\bannerch-admin\wwwroot
2. 將廠商的 banner-admin.zip 檔，解縮後，放到 c:\inetpub\wwwroot\bannerch-admin\wwwroot
3. 測試系統是否安裝正確 http://127.0.0.1:80/bannerch-admin

### 更新系統
1. 解壓後 banner-admin.zip 後，放到 c:\inetpub\wwwroot\bannerch-admin\wwwroot



## 前台
1. 建立目錄 c:\inetpub\wwwroot\bannerch-client
2. 解壓後 banner-client.zip ，放到 c:\inetpub\wwwroot\bannerch-client
3. 設定 IIS 虛擬目錄
4. 修改 web.config
   ```
   ```

### 更新系統
1. 解壓後 banner-client.zip 後，放到 c:\inetpub\wwwroot\bannerch-client
