using System;


namespace ProjectPractice.Orders
{
    public record AssignedOrder(Car Car, Order Order) : IHaveId
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ToDisplayString()
        {
            return $"{Order} назначениее {Car}";
        }
    }

    
}
