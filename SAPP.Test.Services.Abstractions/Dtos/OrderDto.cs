using Karizma.Sample.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Services.Abstractions.Dtos;

    public class OrderDto:BaseDto
    {
        public int UserId { get; set; }

        public PayStatus Status { get; set; }

        public decimal FinalPrice { get; set; }

        public PostType postType { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal DisCountAmount { get; set; }

        public IEnumerable<ShoppingBasketDto> ShoppingBaskets { get; set; }
    }

    

