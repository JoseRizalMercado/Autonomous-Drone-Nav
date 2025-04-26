using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 9414
// Hash 4131
// Hash 5236
// Hash 8679
// Hash 5259
// Hash 1552
// Hash 6144
// Hash 6072
// Hash 3118
// Hash 7272
// Hash 7993
// Hash 3631
// Hash 7304
// Hash 3825
// Hash 1222
// Hash 5772
// Hash 8069
// Hash 3502
// Hash 8251
// Hash 7522
// Hash 2826
// Hash 2393
// Hash 3978
// Hash 8459
// Hash 4114
// Hash 4276
// Hash 3338
// Hash 9892
// Hash 9915
// Hash 5830
// Hash 7935
// Hash 5025
// Hash 1121
// Hash 5747
// Hash 8924
// Hash 3047
// Hash 2344
// Hash 9217
// Hash 4977
// Hash 7423
// Hash 5717
// Hash 7285
// Hash 9617
// Hash 3084
// Hash 1800
// Hash 2245
// Hash 2925
// Hash 7363
// Hash 9826
// Hash 5887
// Hash 8669
// Hash 7014
// Hash 3489
// Hash 5110
// Hash 4716
// Hash 3756
// Hash 9562
// Hash 3882
// Hash 3180
// Hash 4813
// Hash 7651
// Hash 6695
// Hash 5526
// Hash 1190
// Hash 9446
// Hash 3160
// Hash 9154
// Hash 9482
// Hash 3498
// Hash 1920
// Hash 9531
// Hash 4503
// Hash 6961
// Hash 1016
// Hash 7758
// Hash 1637
// Hash 8445
// Hash 3485
// Hash 6833
// Hash 7459
// Hash 8472
// Hash 3040
// Hash 1588
// Hash 8964
// Hash 4403
// Hash 9851
// Hash 9608
// Hash 9870
// Hash 1813
// Hash 7308
// Hash 4331
// Hash 5047
// Hash 9040
// Hash 3909
// Hash 5552
// Hash 1848
// Hash 9052
// Hash 7446
// Hash 5329
// Hash 1749
// Hash 1845
// Hash 6163
// Hash 4101
// Hash 3944
// Hash 6026
// Hash 3529
// Hash 1305
// Hash 2372
// Hash 6344
// Hash 3036
// Hash 7092
// Hash 3951