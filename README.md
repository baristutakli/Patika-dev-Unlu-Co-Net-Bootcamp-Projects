# Patika-dev-Unlu-Co-Net-Bootcamp-Projects
# 1. Hafta Ödev
Restful Api Geliştirin

- Rest standartlarna uygun olmalıdır.
- GET,POST,PUT,DELETE,PATCH methodları kullanılmalıdır.
- Http status code standartlarına uyulmalıdır. Error Handler ile 500, 400, 404, 200,
201 hatalarının standart format ile verilmesi
- Modellerde zorunlu alanların kontrolü yapılmalıdır.
- Routing kullanılmalıdır.
- Model binding işlemleri hem body den hemde query den yapılacak şekilde örneklendirilmelidir.
### Bonus:
- Standart crud işlemlerine ek olarak, listeleme ve sıralama işlevleride eklenmelidir.
Örn: /api/products/list?name=abc

<hr>

# 2. Hafta Ödev
Restful Api Geliştirin
- ilk hafta geliştirdiğiniz api kullanılacaktır.
- Rest standartlarına uygun olmalıdır.
- solid prensiplerine uyulmalıdır.
- Fake servisler geliştirilerek Dependency injection kullanılmalıdır.
- api nizde kullaınılmak üzere extension geliştirin.
- Projede swagger implementasyonu gerçekleştirilmelidir.
- global loglama yapan bir middleware(sadece actiona girildi gibi çok basit düzeyde)
### Bonus
- Fake bir kullanıcı giriş sistemi yapın ve custom bir attribute ile bunu kontrol edin.
- global exception middleware i oluşturun

<hr>


## 3. Hafta Ödev + Week 2 WebApi Improvement(CQRS,Generic Repository) + CleanArch
**Her bölümde yapılan işlemler hakkındaki açıklamaları proje klasöründe aşama aşama bulabilirsiniz.**

1. Patikadev yapısını düşünerek bir db oluşturun
  - eğitimler, öğrenciler,katılımcılar,eğitmenler,asistanlar, eğitimde öğrencilerin yoklamalarının ve başarı durumlarının tutulduğu tablolar olacaktır.
  - veritipleri ve ilişkiler belirtilmelidir.
2. trigger yazın
  - öğrenci yoklaması girildiğinde. yoklama durumuna göre başarı durumunu hafta bazlı olarak güncelleyin.(Örn: eğitim 7 hafta olsun. ilk iki hafta derslere katıldı ise başarı oranı 2/7 nin % olarak karşılı olmalı.)
3. stored procedure yazın
  - öğrencileri eğitimlere ekleyen bir procedure olacak. öğrenci belirtilen eğitim tarihinde herhangi başka bir eğitime kayıtlı olmamalıdır.
4. view yazın
  - eğitim bazlı öğrencileri listeleyin(gruplu olarak)

### Bonus
- Aynı yapıyı ef code first olarak sadece model bazında oluşturun

<hr>

## 3. Hafta Ödev
1.  Veri tabanının tabloları oluşturuldu ve tablolar arası ilişkiler oluşturuldu. Aşağıdaki diagramdan inceleyebilirisiniz.
![Diagram](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/BarisTutakli.Week3/blob/main/Diagram0.png?raw=true)
2. UpdateStudentSuccessStatusWeekly isimli Trigger oluşturuldu.
3. SP_RegisterNewStudent adlı store proc oluşturuldu.
4. OrderByCourseId ve ListStudentDetails adlı iki view oluşturuldu.
5. Backup dosyası yüklendi.

<hr>

# 4. hafta

Restful api oluşturun
- Api tekrardan sıfırdan oluşturuldu
- Kullanıcı işlemleri için Asp.NET Core Identity altyapısını kullanıldı
- Api de yetkilendirme işlemleri için JWT kullanıldı
- Bir tane local result filter oluşturuldu ve her ürün yükleme response'un da header a verinin oluşturulma/getirilme tarihi saati yazıldı

### Bonus
- rol bazlı yapı tanımlayın
<hr>

* Kullanıcı kaydı ve giriş işlemşleri için **AuthenticateController** oluşturuldu. 
* Token oluşturmak için **TokenGenerator** sınıfı oluşturuldu.
* Kullanıcı yekisine göre rolü göz önüne alınarak metotlara erişimi kısıtlandı.
* Yekisiz kullanıcılara ise sadece kısıtlı ürünü görebilme olanağı tanındı.
* DTO lar kullanılarak Mmodellerimize erişimi sınırlayarak istediğimiz şekilde veri alma gönderme işlemleri yapıldı.

# 5. hafta
4. Hafta başladığım sayfalandırma işleminin url yönlendirme kısmı tamamlandı.

Restful api oluşturun
- Daha önce oluşturduğunuz apilerden 4. haftada oluşturulan api kullanıldı.
- Tek bir endpoint ten Filtreleme, sıralama işlemi sayfalandırılarak yapıldı.
- Demo veri sunan endponte ın memory cache kullanım olanağı sunuldu.
- help endpoint ine api hakkındaki basit bilgileri in memory cache de tutan ve kullanımını sağlayan bir yapı geliştirişdi.
- help endpointinde response cache mekanizmasını kullanıldı
- Servis oluşturulmadan direk injection yapılarak Disributed cache olarak redis e yazma okuma işlemi endt point e eklendi
- Bir de Distributed cache olarak redis e yazan ve okuyan bir cache yönetim servisi yazıldı. Sorgu adedi 100 ve üzeri olursa istenilen zaman aralığında cache yazma ve okuma eklendi. Bknz(IDisributedCacheRedisService)