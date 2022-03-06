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

Kullanılan paketleri Nuget Package Manager ile de kurabilirsiniz, terminalden kurmak için **WebApi** içerisinde:

    dotnet add package AutoMapper -v 10.1.1

    dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection -v 8.1.1

    dotnet add package Microsoft.EntityFrameworkCore -v 5.0.6

    dotnet add package Microsoft.EntityFrameworkCore.Tools -v 5.0.6

    dotnet add package Newtonsoft.json -v 13.0.1

    dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0
    
    
 # Ekran görüntüleri
 
 ### Index
 ![getSuppliers](https://user-images.githubusercontent.com/44196434/156903685-1f6c53cf-6571-4bb4-bd99-251226e72e36.png)

 ### Show
 ![getSupplierDetail](https://user-images.githubusercontent.com/44196434/156903687-aa2a45dc-a17e-41b9-9b6c-79d570a9eac1.png)

 ### Store
 ![createSupplier](https://user-images.githubusercontent.com/44196434/156903691-108077f1-0c4e-438e-86cb-308d5959740a.png)
 
 ### Destroy
 ![deleteSupplier](https://user-images.githubusercontent.com/44196434/156903718-05982aeb-b9d2-450e-88d1-5265d1f96152.png)
