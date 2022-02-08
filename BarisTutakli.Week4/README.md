# 4. hafta + Pagination
Sayfalandırma işlemine ilgili sayfaların yönlendirme işlemi yapıldı
Restful api oluşturun
- Api tekrardan sıfırdan oluşturuldu
- Kullanıcı işlemleri için Asp.NET Core Identity altyapısını kullanıldı
- Api de yetkilendirme işlemleri için JWT kullanıldı
- Bir tane local result filter oluşturuldu ve her ürün yükleme response'un da header a verinin oluşturulma/getirilme tarihi saati yazıldı

# bonus
- rol bazlı yapı tanımlayın
<hr>

* Kullanıcı kaydı ve giriş işlemşleri için **AuthenticateController** oluşturuldu. 
* Token oluşturmak için **TokenGenerator** sınıfı oluşturuldu.
* Kullanıcı yekisine göre rolü göz önüne alınarak metotlara erişimi kısıtlandı.
* Oluşturduğum User modeli Microsoft.AspNetCore.Identity içindeki IdentityUser nesnesinden kalıtım almaktadır.
* Yekisiz kullanıcılara ise sadece kısıtlı ürünü görebilme olanağı tanındı.
* DTO lar kullanılarak Mmodellerimize erişimi sınırlayarak istediğimiz şekilde veri alma gönderme işlemleri yapıldı.


### Filters

```c#
public class CreateProductActionFilter :IActionFilter
{
    private DateTime _requestTime { get; set; }
    private DateTime _responseTime { get; set; }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _responseTime = DateTime.Now;
        context.HttpContext.Response.Headers.Add("ProcessTime", $"Request time: {_requestTime} Response time: {_responseTime}");
    }

    public  void  OnActionExecuting(ActionExecutingContext context)
    {
        _requestTime = DateTime.Now;
    }
}

```

### Pagination 
PagedResponse ve PaginationFilter sınıfları sınırlı sayıda öğeyi sayfalayarak göndermek için oluşturuldu. Bunun için Controller'dan filtreleri ```[fromQuery]``` den alarak gerekli işlemi productRespository sınıfında gerçekleştirdim.