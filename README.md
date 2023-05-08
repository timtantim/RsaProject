# NttProject
細節說明:

1. BOM表要有表頭和表身2張table

2. MVC架構用Repository Pattern

3. 用 Entity Framework，避免SQL injection

4. 有關的nuget:

Microsoft.EntityFrameworkCore

System.Linq

# 額外系統開發

因為有提到後端系統會以不同模組來佈署，因此為了確保系統安全性，我額外開發OAuth Server 來驗證前端請求。
該系統在Github 的IDServer，如果要下載下來佈署到本機，請到appsettings.json 的IDServerHost 填入 IDServer 的URL

# 開發人員說明
專案採用Asp.net 3.1 版本 Code First 設計，控制器裡面的BomController 是我自行設計與測試用的BOM表，我將BOM表頭與表身藉由is_Head 來區別
小提醒!! 以下BomHeadController與BomDetailController為需求文件所要求，導入Repository 設計模式的API Controller。 此專案為簡易BOM設計，主要目的為程式開發能力展示用!! 

# 佈署說明
1.請將資料庫環境設定於appsettings.json 的DefaultConnection 裡頭 <br/>
2.於套件管理器主控台執行update-database 

# Table Schema
BomHead (Bom 表頭) <br/>
Id int (自增ID) <br/>
BomCode nvarchar(20) (Bom 編碼) <br/>
MaterialCode nvarchar(20) (物料編號) <br/>
Description nvarchar(MAX) (Bom 描述) <br/>

BomDetail (Bom表身) <br/>
Id int (自增ID) <br/>
BomCode nvarchar(20) (Bom 編碼) <br/>
ChildMaterialCode nvarchar(20) (子物料編號) <br/>
MaterialNum int (物料數量) <br/>
