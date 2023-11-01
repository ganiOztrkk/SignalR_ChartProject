# SignalR Anlık Grafik Uygulaması - Gençay Yıldız Youtube Serisi

Bu projede, Asp.NET Core ile SQL Server veritabanındaki değişiklikler SqlTableDependency kütüphanesi aracılığıyla anlık olarak yakalanmakta ve SignalR sayesinde, Angular mimarisiyle geliştirdiğimiz client'lar da grafiksel arayüzlere basılmaktadır.

## Özellikler

- Angular Uygulaması
- Anlık grafik gösterimi
- Highcharts - Highcharts-angular
- Service Broker
- Service Broker kütüphaneleri ve SqlTableDependency Kütüphanesi
- Veritabanında gerçekleşen değişikliklerin anlık olarak Client'lara yansıtılması

## Gereksinimler

Bu projenin yerel bir geliştirme ortamında çalıştırılabilmesi için aşağıdaki bileşenlere ihtiyaç vardır:

- [Visual Studio Code](https://code.visualstudio.com/) veya herhangi bir IDE
- [ASP.NET Core SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) ve [npm](https://www.npmjs.com/)
- [SignalR JavaScript istemcisi](https://docs.microsoft.com/en-us/aspnet/core/signalr/javascript-client)
- Angular
- highcharts - highcharts-angular
