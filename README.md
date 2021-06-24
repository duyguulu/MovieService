Proje içindekiler:
- API kimlik doğrulaması gerektirecek, login ve register.
- Film listeleme: Sayfa sayfa tüm filmleri alabilen bir endpoint, sayfa büyüklüğü parametre olarak alınıyor.
- Filme not ve puan ekleme: Not text alanı. Puan 1-10 arası bir tam sayı.
- Id ile film görüntüleme: Film bilgileri ile birlikte ortalama puan, kullanıcının verdiği puan ve eklediği notlar gösteriliyor.
- Film tavsiye etme: Verilen bir adrese e-posta gönderiliyor.
- Film listesi periyodik olarak (örn: Saat başı) themoviedb.org'dan bir Worker çalıştırılarak (https://developers.themoviedb.org/3/getting-started/introduction) çekiliyor.
- PostgreSQL kullanılmıştır.
-API servisi: https://developers.themoviedb.org/3/getting-started/introduction
TODO
- Projenin front-end' i üzerinde çalışılıyor.
- Test yazılacak.
