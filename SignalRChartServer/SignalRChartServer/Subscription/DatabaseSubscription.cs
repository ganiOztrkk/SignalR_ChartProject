using Microsoft.AspNetCore.SignalR;
using SignalRChartServer.Hubs;
using SignalRChartServer.Models;
using TableDependency.SqlClient;

namespace SignalRChartServer.Subscription;

public interface IDatabaseSubscription
{
    void Configure(string tableName);
}

public class DatabaseSubscription<T> : IDatabaseSubscription where T : class, new()
{
    private readonly IConfiguration _configuration;
    private readonly IHubContext<SatisHub> _hubContext;
    private SqlTableDependency<T> _sqlTableDependency;


    public DatabaseSubscription(IConfiguration configuration, IHubContext<SatisHub> hubContext)
    {
        _configuration = configuration;
        _hubContext = hubContext;
    }

    public void Configure(string tableName)
    {
        _sqlTableDependency = new SqlTableDependency<T>(_configuration.GetConnectionString("SQL"), tableName);

        _sqlTableDependency.OnChanged += async (o, e) =>
        {
            SatisDBContext context = new SatisDBContext();
            var data = (from personel in context.Personellers
                                                join satis in context.Satislars
                                                on personel.Id equals satis.PersonalId
                                                select new { personel, satis }).ToList();

            List<object> datas = new List<object>();
            var personelIsimleri = data.Select(x => x.personel.Adi).Distinct().ToList();
            personelIsimleri.ForEach(p =>
            {
                datas.Add(new
                {
                    name = p,
                    data = data.Where(x=> x.personel.Adi == p).Select(s => s.satis.Fiyat).ToList()
                });
            });
            await _hubContext.Clients.All.SendAsync("receiveMessage", datas);
        };

        _sqlTableDependency.OnError += (o, e) => { };

        _sqlTableDependency.Start();
    }

    ~DatabaseSubscription()
    {
        _sqlTableDependency.Stop();
    }
}