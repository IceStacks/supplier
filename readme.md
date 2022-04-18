# .Net Core 5 ile WebApi

Bu API .Net Core 5 ile geliştiriliyor.

Api'yi çalıştırmak için (**WebApi** klasörünün içerisinde):

    dotnet watch run

ConnectionString'i environment variable olarak alıyoruz. 

Projeyi bilgisayarınıza çekip çalıştırmak isteseniz, sisteminizde environment variable olarak aşağıdaki variable'ları oluşturmalısınız.

Docker ile çalıştırmak için, docker-compose.yml dosyasında environment variable kısmını doldurunuz.

![environments](https://user-images.githubusercontent.com/44196434/158075594-3c2c06cd-95d8-42e7-bfe0-2453cc715559.png)

<br>

# Paketler

Kullanılan paketleri Nuget Package Manager ile de kurabilirsiniz, terminalden kurmak için **WebApi** içerisinde:

    dotnet add package AutoMapper -v 10.1.1

    dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection -v 8.1.1

    dotnet add package Microsoft.EntityFrameworkCore -v 5.0.6

    dotnet add package Microsoft.EntityFrameworkCore.Tools -v 5.0.6

    dotnet add package Newtonsoft.json -v 13.0.1

    dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0

    dotnet add package FluentValidation -v 10.3.6

    dotnet add package Bogus
    
    
<br>

# Endpoints

|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:5001/suppliers |Index|
|GET| https://localhost:5001/suppliers/id |Show|
|PUT| https://localhost:5001/suppliers/id |Edit|
|POST| https://localhost:5001/suppliers |Store|
|DELETE| https://localhost:5001/suppliers/id |Destroy|

|HTTP|URL|METOT|
|---|---|---|
|POST| https://localhost:5001/migrations/migrating?value=migrate |Migrate|
|POST| https://localhost:5001/migrations/fakedata?value=fakedata |FakeData|

<br>

 # Ekran görüntüleri
 
 - Index
 
    ![getSuppliers](https://user-images.githubusercontent.com/44196434/162528096-4db369df-b254-4aa7-a21b-775ce63e8338.png)

 - Show
    
    ![getSupplierDetail](https://user-images.githubusercontent.com/44196434/162528089-b9c9a100-518b-4397-abef-c1686b653128.png)

 - Store

    ![createSupplier](https://user-images.githubusercontent.com/44196434/158078564-dc7cbdee-8421-4e0d-85b4-b673538afb6e.png)
 
 - Edit
  
    ![updateSupplier](https://user-images.githubusercontent.com/44196434/158078571-93011009-0808-484f-b253-3a049c175cb5.png)

 - Destroy

    ![deleteSupplier](https://user-images.githubusercontent.com/44196434/158078579-f9ffccbc-d096-4a71-97eb-5be4279ba3ab.png)
