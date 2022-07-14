## Kayıt Rehberi .Net Core Api Projesi

Projede rol bazlı üyelik sistemi kullanılmıştır. ***Access token*** ve ***refres token*** kullanılmıştır.
Müşteri fotoğraflarına watermark ekleme işlemi, API projesinde dar boğaz yaşatmaması için ayrı bir process’de gerçekleştirildi. Bu görev için ; ***RabbitMQ*** ve ***WorkerService*** kullanıldı.
Veritabanı olarak ***PostgreSQL*** kullanılmıştır.
***IOC*** container olarak ***Autofac*** kullanılmıştır. Autofac bize Interfacelerin karşılığı olan somut class ları configüre edebileceğimiz merkezi yapıyı sunan container teknolojisidir.
***AOP***(Aspect Oriented Programming) mimarisi kullanılarak kesişen ilgilerin ayrılmasını sağlanmıştır. Her methoda güvenlik için tekrar tekrar kod yazmamak için kullanılmıştır.
![alt text](https://www.codeproject.com/KB/Articles/aop2/attributes.gif =222x101)
Entity ler ile DTO sınıflarını eşleştirmek için ***AutoMapper*** kütüphanesi kullanılmıştır.
