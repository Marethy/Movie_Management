using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Presentation.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        // Phương thức xử lý kết quả chung
        protected IActionResult HandleResult<T>(T result)
        {
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Phương thức kiểm tra ID hợp lệ
        protected bool IsValidId(int id) => id > 0;
    }
}
