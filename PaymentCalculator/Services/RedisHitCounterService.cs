using StackExchange.Redis;

namespace PaymentCalculator.Services
{
    class RedisHitCounterService: IHitCounterService
    {
        private IConnectionMultiplexer _conn;
        public RedisHitCounterService(IConnectionMultiplexer conn)
        {
            _conn = conn;
        }

        public long GetAndIncrement()
        {
            IDatabase db = _conn.GetDatabase();
            return db.StringIncrement("payment-calculator");
        }

        public void Reset()
        {
            IDatabase db = _conn.GetDatabase();
            db.StringSet("payment-calculator", 5000);
        }
    }
}
