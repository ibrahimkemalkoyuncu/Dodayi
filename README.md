# Dodayi

Dodayi, bir mikroservis tabanlı uygulama olarak geliştirilmiştir ve .NET Core platformu üzerinde çalışmaktadır. Bu proje, iki ana servisi barındırır:

- **Dodayi.Services.BapAPI**: İş mantığı ile ilgili fonksiyonları yönetir.
- **Dodayi.Services.CouponAPI**: Kupon işlemlerini ve yönetimini sağlar.

## İçindekiler
- [Özellikler](#özellikler)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Dizin Yapısı](#dizin-yapısı)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)

## Özellikler
- **Modüler yapı**: Her servis ayrı bir modül olarak geliştirilmiştir.
- **RESTful API desteği**: Servisler RESTful mimari prensipleri ile çalışır.
- **Kolay Genişletilebilirlik**: Yeni özellikler kolayca eklenebilir ve mevcut yapılar üzerinde geliştirilebilir.

## Kurulum

### Gereksinimler
- [.NET Core SDK](https://dotnet.microsoft.com/download) (sürüm 3.1 veya üzeri)
- [Docker](https://www.docker.com/) (isteğe bağlı olarak container oluşturmak için)

### Adımlar

1. Bu depoyu klonlayın:
   ```bash
   git clone https://github.com/ibrahimkemalkoyuncu/Dodayi.git
   cd Dodayi
