# SOLID Yazılım Prensipleri

### 1) S: Single-Responsibility Principle

Bu prensip, bir sınıfın sadece tek bir iş için yükümlü olmasını ve bu sınıfta herhangi bir değişiklik yapılacağı zaman birden fazla sebebin olmamasını hedeflemektedir.

**Örnek:** Bir markette çalışan bir kasiyer, sadece ürünlerin satışını gerçekleştirmek ve satışlara dair faturalar ile ilgilenmek üzere görev yapmalı; depo yönetimi gibi farklı iş tanımları için farklı bir personel görevlendirimelidir.

### 2) O: Open-Closed Principle

Bir nesnenin kendisine eklenecek yenilikler olması durumunda, bu nesnenin sahip olduğu mevcut özelliklerine yönelik herhangi bir etkisi olmamalıdır.

**Örnek:** Bir YouTube kanalının Katıl üyeliğini ele aldığımızda, bir kullanıcıya farklı seviyelerin sunulduğunu görürüz. Bu seviyeleri kanal sahibi dilediği gibi değiştirebilir; yeni bir üyelik seviyesi ekleyebilir yahut mevcut bir seviyeyi silebilir. Eklenecek yeni seviye, sıfırdan oluşturulmak yerine temel bir üyelik tanımlamasının uzantısı olarak oluşturulmalıdır ve bu işlem önceden tanımlanmış diğer üyelik seviyelerinde değişime yol açmamalıdır.

### 3) L: Liskov Substitution Principle

Bu prensip, oluşturulmuş bir temel tanımlama ile bu temel tanımlamanın bir uzantısı olarak oluşturulmuş bir alt tanımlama arasında davranışsal olarak bir fark bulunmamasını amaçlar.

**Örnek:** Kediler ile ilgili bir simülasyon yapmak istediğimizi varsayalım. Oluşturacağımız Kedi sınıfına "Kuyruk Sallama" davranışını eklemek istediğimizde, bu durumun kuyruğu olmayan bir tür olan Manx kedisi için geçerli olmadığını görürüz. Bundan dolayı, "Kuyruk Sallama" davranışını Kedi sınıfının kendisine eklemek yerine, alt Kedi sınıflarının bu davranışa ait bir Interface üzerinden bu işlemi gerçekleştirmesi sağlanır.

### 4) I: Interface Segregation Principle

Bir sınıfın işlemleri bir Interface aracılığıyla yapılmak istendiğinde, Interface'in soyut olarak sahip olduğu bütün davranışları mantıksal olarak tanımlayabilmelidir.

**Örnek:** Barkodlar içerebileceği karakterler bakımından numerik ve alfanumerik olmak üzere ikiye ayrılmaktadır. Eğer bir "Barkod Okuma" Interface yapısı oluşturulursa ve içerisine hem harfleri hem de rakamları okuması için soyut tanımlamalar yapılırsa, sadece numerik karakterler kullanan barkod türlerinin içerisinde harfleri de tanıması için bazı işlemler yapılması gerekecek. Bu tür gereksiz fonksiyonları bir sınıfın içerisine dahil etmemek adına, her iki okuma tipi için ayrı Interface yapıları oluşturulmalıdır.

### 5) D: Dependency Inversion Principle

Bu prensibe göre, üst seviye bir sınıfın alt seviye bir sınıfa bağımlı olmaması ile birlikte bu iki sınıfın da soyut tanımlamalara bağlı olması gerekir. 

**Örnek:** Bir kargo şirketinin gönderiler için sunduğu ambalaj malzemelerini düşündüğümüzde, mukavva, zarf, torba gibi çeşitlerin olduğu aklımıza gelir. Ancak bir kişinin göndermek istediği ürünün hangi malzeme ile gönderileceği belirsizdir. Dolayısıyla ambalajlama işlemi tek bir malzeme üzerinden planlanmamalıdır, zira varsayılan olarak belirlenmiş malzeme ile ambalajlama hizmetinin durdurulmasına karar verildiğinde, bu işlemlerin bilgisini tutan sistemdeki kod parçalarının büyük ölçüde değişmesi gerekecektir.
