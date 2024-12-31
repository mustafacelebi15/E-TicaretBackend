using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";

        public static string ProductNameInvalid = "Ürün ismi geçersiz.";

        public static string MaintenanceTime = "Bakım zamanı..";

        public static string ProductsListed = "Ürünler başarıyla listelendi.";

        public static string UnitPriceInvalid = "Ürün değeri sıfırdan büyük olmalıdır.";

        public static string ProductCountOfCategoryError = "Kategorideki ürün sayısı 10'dan fazla olamaz.";

        public static string ProductNameExist = "Ürün ismi kullanılıyor.";

        public static string CategoryLimitExceded = "Category limiti aşıldı.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
       
        public static string UserRegistered = "Kullanıcı kaydı tamam.";
        
        public static string UserNotFound= "Kullanıcı bulunamadı.";
        
        public static string PasswordError= "Şifre hatalı.";

        public static string SuccessfulLogin = "Başarılı giriş.";

        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı.";

        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
