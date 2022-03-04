# .Net Core 5 ile WebApi

Bu API .Net Core 5 ile geliştiriliyor.

İlk olarak proje klasörü içerisinde alt kısımdaki komut çalıştırılarak bir 'WebApi' isminde bir Api oluşturmak için:

    dotnet new webapi -n WebApi 

Sonrasında hala proje klasörünün içerisindeyken şu komut ile 'SupplierSln' adında bir **sln** dosyası oluşturmak için:

    dotnet new sln -n SupplierSln

Artık WebApi ile SupplierSln'i birleştirmemiz gerekiyor. Bunun için:

    dotnet sln add WebApi 

Api'yi çalıştırmak için (**WebApi** klasörünün içerisinde):

    dotnet watch run

# Paketler

EntityFrameworkCore **WebApi** içerisinde:

    dotnet add package Microsoft.EntityFrameworkCore 

    dotnet add package Microsoft.EntityFrameworkCore.Tools 

MySql kullanmak için **WebApi** içerisinde:

    dotnet add package MySqlConnector
    
    
 # Ekran görüntüleri
 
 ### Index
 ![getSuppliers](https://user-images.githubusercontent.com/44196434/156747164-85f255bb-82e3-4797-ba2c-26babbffbcfe.png)
 
 ## Show
 ![supplierShow](https://user-images.githubusercontent.com/44196434/156756599-db44c95e-e759-4efa-9e69-862c1d772bfa.png)

 ## Store
 ![supplierStore](https://user-images.githubusercontent.com/44196434/156756626-ae0b5eca-e379-438e-a4f8-f4bc90e189ba.png)
