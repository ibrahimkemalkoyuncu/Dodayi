namespace Dodayi.Services.CouponAPI.Dto
{
    /// <summary>
    /// API yanıtlarını standartlaştırmak için kullanılan yanıt sınıfı
    /// Her API yanıtı için sonuç, başarı durumu ve mesajı içerir
    /// </summary>
    public class Response
    {
        /// <summary>
        /// API yanıtının sonuç verisi
        /// </summary>
        public object? Result { get; set; }

        /// <summary>
        /// İşlemin başarılı olup olmadığını belirtir
        /// Varsayılan olarak true (başarılı) değeri ile başlar
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// İşlem sonucuna dair bilgi mesajı
        /// Hata durumunda hata mesajını içerir
        /// </summary>
        public string Message { get; set; } = "";

    }
}
