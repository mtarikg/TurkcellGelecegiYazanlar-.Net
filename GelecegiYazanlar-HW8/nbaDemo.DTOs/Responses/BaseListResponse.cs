using System;

namespace nbaDemo.DTOs.Responses
{
    public abstract class BaseListResponse
    {
        public int ID { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
