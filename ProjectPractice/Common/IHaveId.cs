using System;

namespace ProjectPractice.Orders
{
    public interface IHaveId
    {
        Guid Id { get; set; }
    }
}