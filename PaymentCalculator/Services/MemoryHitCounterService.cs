using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentCalculator.Services
{
    public class MemoryHitCounterService: IHitCounterService
    {
        private long HitCount = 0;
        public long GetAndIncrement()
        {
            return ++HitCount;
        }

        public void Reset()
        {
            HitCount = 0;
        }
    }
}
