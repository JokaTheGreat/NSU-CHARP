namespace Lab2;

using Microsoft.Extensions.Hosting;

class Princess : IHostedService
{
    private IHostApplicationLifetime _applicationLifetime;
    private IHall _hall;
    
    private string? _currentContender;
    private string? _chosenContender;

    private double FirstContendersSkipCount;
    private const double ContenderToStopFactor = 2 * 0.93;

    public Princess(IHostApplicationLifetime applicationLifetime, IHall hall)
    {
        _applicationLifetime = applicationLifetime;
        _hall = hall;

        var contendersNumber = _hall.GetContendersNumber();
        FirstContendersSkipCount = contendersNumber * 0.37;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(RunAsync);
        return Task.CompletedTask;
    }

    private void RunAsync()
    {
        _currentContender = _hall.GetNextContender();

        while (_currentContender != null)
        {
            if (_hall.GetContendersCounter() > FirstContendersSkipCount)
            {
                if (IsContenderGoodEnough())
                {
                    _chosenContender = _currentContender;
                    break;
                }
            }

            _currentContender = _hall.GetNextContender();
        }

        _hall.PublishResult(_chosenContender);
        _applicationLifetime.StopApplication();
    }

    private bool IsContenderGoodEnough()
    {
        var contenderCounter = _hall.GetContendersCounter();
        var expectedContenderGoodness = 0;
        for (int i = 0; i < contenderCounter; i++)
        {
            expectedContenderGoodness += (int)_hall.AskFreind(contenderCounter, i);
        }

        return contenderCounter * ContenderToStopFactor <= expectedContenderGoodness;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}