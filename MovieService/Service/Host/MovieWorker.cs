using Microsoft.Extensions.Logging;
using MovieService.Service.TMDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieService.Service.Host
{
    public class MovieWorker : IWorker
    {
        private readonly ILogger<MovieWorker> logger;
        private int number = 0;
        private Timer timer;
        private TheMovieDB theMovieDb;
        //TODOO nerden alınacak performans bak.
        //TODOO dependency injection türleri nelerdir.
        public MovieWorker(ILogger<MovieWorker> logger)
        {
            this.logger = logger;
            this.timer = new Timer(o => UpdateData(), null, TimeSpan.Zero, TimeSpan.FromHours(1)); //TimeSpan.FromHours(1)
            theMovieDb = new TheMovieDB();

        }

        public async Task UpdateData()
        {
            Interlocked.Increment(ref number);
            logger.LogInformation($"{number} - Background Worker is running : {DateTime.Now}");
            /*
             * Update Data Cde Block in here
             */
            theMovieDb.GetMovies(1);
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested) ;
        }
    }
}
