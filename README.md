# BookingApp - Otel Yönetim Sistemi

BookingApp, otel rezervasyonları ve kullanıcı yönetimi için geliştirilmiş bir Web API projesidir. Katmanlı mimari prensibine uygun şekilde yapılandırılmış olan bu proje, yazılım geliştirmede yaygın olarak kullanılan modern desenleri ve teknolojileri içermektedir.

---

![Image](https://github.com/user-attachments/assets/b7a8456e-34c9-4499-bce6-aa7353032fb4)

---

## Proje Katmanları

- **BookingApp.Business**  
  Uygulamanın iş kuralları bu katmanda yer alır. `Operations`, `Types` ve `DataProtection` gibi alt klasörlerde işlemsel ve yardımcı sınıflar bulunur.

- **BookingApp.Data**  
  Veri erişim işlemleri bu katmanda gerçekleştirilir. `Entities`, `Enums`, `Repositories`, `Context`, `Migrations`, `UnitOfWork` klasörleriyle organize edilmiştir.

- **BookingApp.WebApi**  
  API uç noktalarının yer aldığı ana uygulama katmanıdır. `Controllers`, `Models`, `Jwt`, `Middlewares` gibi klasörleri içerir.

---

## Özellikler ve Geliştirme Süreci

### 1. Entity ve DbContext
`Entities` klasöründe yer alan sınıflar ile veritabanı tabloları temsil edilir. `Context/AppDbContext.cs` dosyasında ise Entity Framework Core kullanılarak veritabanı bağlamı oluşturulmuştur.

### 2. Konfigürasyon ve Migration
EF Core kullanılarak veritabanı şeması oluşturulmuştur. `Migrations` klasörü bu işlemlerden doğan migration dosyalarını içerir. Konfigürasyonlar `appsettings.json` dosyasında tanımlanmıştır.

### 3. Generic Repository Pattern
Tüm veri erişim işlemleri soyutlanarak `Repositories` klasöründe generic repository deseni ile geliştirilmiştir. Bu yaklaşım, veri erişim kodlarının tekrarını önler ve test edilebilirliği artırır.

### 4. UnitOfWork Pattern
Repository’ler arası işlem bütünlüğünü sağlamak için Unit of Work deseni kullanılmıştır. `UnitOfWork` klasörü, transaction yönetimini merkezileştirmek amacıyla yapılandırılmıştır.

### 5. Kullanıcı Kayıt (Register)
Kullanıcılar, API üzerinden güvenli şekilde kayıt olabilirler. Parolalar `DataProtection` mekanizması ile şifrelenmektedir. Gerekli doğrulamalar `BookingApp.Business.Operations` içinde yer almaktadır.

### 6. Giriş (Login)
JWT tabanlı kimlik doğrulama mekanizması ile kullanıcı girişi sağlanmaktadır. Başarılı giriş işlemi sonrasında kullanıcıya access token üretilir.

### 7. JWT Authentication
`Jwt` klasöründe token üretimi, doğrulaması ve token ayarları tanımlanmıştır. API endpoint’lerine erişim için `[Authorize]` attribute’u ile yetkilendirme kontrolü sağlanır.

### 8. Özellikler Controller
Tüm temel API uç noktaları `Controllers` klasöründe yapılandırılmıştır. Kullanıcı ve otel işlemleri burada yönetilir.

### 9. Admin Yetkilendirme
Bazı işlemler yalnızca admin rolüne sahip kullanıcılar tarafından gerçekleştirilebilir. Bu yetkilendirme, JWT içindeki kullanıcı rolleri üzerinden yapılmaktadır.

---

## Otel İşlemleri

### 🏨 HotelCreate (Transactional)
Yeni bir otel oluşturmak için gerekli işlemler transaction yapısı içerisinde gerçekleştirilir. Böylece işlem sırasında oluşacak hatalarda verinin bütünlüğü korunur.

### 🔍 HotelGet
Tüm otelleri veya filtreye göre belirli otelleri listelemek için kullanılır.

### ✏️ HotelPatch & HotelDelete
Kısmi güncelleme (PATCH) ve silme işlemleri (DELETE) gerçekleştirilir. Kullanıcının yetkisine göre işlem izni kontrol edilir.

### 🛠 HotelPut
Var olan bir otelin tüm bilgilerinin güncellenmesi amacıyla kullanılır. Genellikle yönetici (admin) tarafından kullanılır.

---

## Yapılandırma ve Varsayılan Veriler

### ⚙️ Settings
`appsettings.json` dosyasında JWT ayarları, bağlantı stringleri ve diğer yapılandırmalar tanımlanmıştır.

### 🌱 SeedData
İlk verilerin yüklenmesi için Seed mekanizması bulunmaktadır. Geliştirme ortamında varsayılan kullanıcılar ve roller bu sayede otomatik oluşturulabilir.

---

## Middleware Kullanımı

Özel hata yönetimi ve yanıt yapılandırmaları için özel middleware bileşenleri geliştirilmiştir. API dışına sarkan hatalar kullanıcı dostu şekilde ele alınır ve loglanır.

---


