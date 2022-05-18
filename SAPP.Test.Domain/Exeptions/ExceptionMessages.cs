using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Domain.Exeptions
{
    public class ExceptionMessages
    {

        public const string NotFound = "اطلاعاتی در پایگاه داده یافت نشد.";

        public const string NullArgument = "اطلاعاتی از سمت شما دریافت نگردید.";

        public const string InternalError = "خطای داخلی سرور";

        public const string InvalidTime = "ساعت غیر مجاز ثبت سفارش";

        public const string InvalidOrderPrice = "مبلغ سفارش باید بیش از 50 هزار تومان باشد.";
    }
}
