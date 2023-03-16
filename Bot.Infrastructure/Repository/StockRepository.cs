using Bot.Domain.Interfaces;
using CsvHelper;
using System.Globalization;

namespace Bot.Infrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        public async Task<string> GetStockData(string command)
        {
            var symbol = command.Split("=")[1];
            try
            {
                string stockData = symbol.ToUpper() + " quote is ";
                string quote = string.Empty;
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(
                        "https://stooq.com/q/l/?s=" + symbol + "&f=sd2t2ohlcv&h&e=csv");
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (
                        var csv = new CsvReader(new StreamReader(stream),
                        CultureInfo.InvariantCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        while (await csv.ReadAsync())
                        {
                            quote = csv.GetField<string>(3) ?? "";
                            if (quote != "" && quote != "N/D")
                                stockData += quote + " per share";
                            else
                                stockData =
                                    "There is no current quote information for the symbol: "
                                    + symbol;
                        }
                    }
                }
                return stockData;
            }
            catch (Exception ex)
            {
                return "No stock information could be found, check symbol: " + symbol;
            }
        }
    }
}
