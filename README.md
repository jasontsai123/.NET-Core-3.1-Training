# .NET-Core-3.1-Training
.NET Core 技術練習

## 專案架構
 - [軟體分層設計模式](https://raychiutw.github.io/2019/%E9%9A%A8%E6%89%8B-Design-Pattern-2-%E8%BB%9F%E9%AB%94%E5%88%86%E5%B1%A4%E8%A8%AD%E8%A8%88%E6%A8%A1%E5%BC%8F-Software-Layered-Architecture-Pattern/)

## 實作
 - [Swagger](#swagger)
 - [Redis](#redis)
 - [Dapper](#dapper)
 - [Coreprofiler](#coreprofiler)
 - [HealthCheck](#healthcheck)
 - [Decorator Pattern](#decorator-pattern)
 - [MSTest](#mstest)
 ### Swagger
 在這邊引述鐵人賽[ATai](https://ithelp.ithome.com.tw/users/20129389/ironman/3185)的文章
 [[Day09]使用Swagger自動建立清晰明瞭的REST API文件 - 我與 ASP.NET Core 的 30天](https://ithelp.ithome.com.tw/articles/10242295)
 > 在一般的工作情境中，開發人員要寫API文件時，很容易就會去使用Word、Excel，抑或會使用HackMD作為文件的提供，但是這類的文件，會有維護與修改的問題，比如改了參數但是忘記更新文件，或是手誤打錯，都會是溝通成本，而Swagger能夠自動生成API文件，並能在線上進行測試，正好可以解決上述問題。
 
 ### Redis
 [快取機制IDistributedCache](https://johncode-1.gitbook.io/.net-core/kuai-qu-ji-zhi-idistributedcache)
 
 ### Dapper
 [短小精悍的.NET ORM神器 -- Dapper](https://blog.darkthread.net/blog/dapper/)
 
 [另一種資料存取對映處理方式的選擇 - Dapper](https://kevintsengtw.blogspot.com/2015/09/dapper.html)
 
 保持撰寫SQL Command靈活性同時又對映到ORM的強型別
 EF自動產生Model實在太好用了，在這邊也推薦一個[mrkt](https://kevintsengtw.blogspot.com)大大提供的Dapper可以對映產出Model方法
[Dapper - 使用 LINQPad 快速產生相對映 SQL Command 查詢結果的類別](https://kevintsengtw.blogspot.com/2015/10/dapper-linqpad-sql-command.html)
 ### Coreprofiler
 可以直接查看上線中API效能的工具
 
 這裡可參考[RiCo技術農場](https://dotblogs.com.tw/ricochen)的文章
[monitor performance of webapi via CoreProfiler](https://dotblogs.com.tw/ricochen/2018/04/02/023518)

 ### HealthCheck
 查看上線後網站的健康狀態，每個對於健康的定義不太一樣，有些是網站能跑就好，我這邊定義是DB出問題沒有資料出來就是掛掉
```cs
services.AddHealthChecks()
        .AddSqlServer(Configuration["ConnectionStrings:NorthwindConnection"]);
```
這裡有[marcus116](https://marcus116.blogspot.com)大大更詳細的[介紹](https://marcus116.blogspot.com/2019/05/how-to-setup-netcore-aspnet-core-health-check.html)
 
 ### Decorator Pattern
 [ASP.Net Core Using the Decorator Pattern](https://adamstorr.azurewebsites.net/blog/beyond-basics-aspnetcore-using-the-decorator-pattern) by [Adam Storr](https://adamstorr.azurewebsites.net/)
 
 安裝Scrutor套件可以輕鬆實踐DI的Decorator Pattern，我在工作上通常用在快取機制
 
 ### MSTest
