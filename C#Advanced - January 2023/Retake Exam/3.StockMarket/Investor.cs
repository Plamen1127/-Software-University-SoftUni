using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }


        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public List<Stock> Portfolio { get; set; }
        public int Count  {get { return Portfolio.Count; }}

        public void BuyStock( Stock stock)
        {
            if (stock.MarketCapitalization>10000  && MoneyToInvest>=stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string campanyName, decimal sellPrice)
        {
            Stock sellStock = Portfolio.FirstOrDefault(s => s.CompanyName == campanyName);
            if (sellStock ==null)
            {
                return $"{campanyName} does not exist.";
            }
            else if (sellPrice< sellStock.PricePerShare)
            {
                return $"Cannot sell {campanyName}.";
            }
            else
            {
                Portfolio.Remove(sellStock);
                MoneyToInvest += sellStock.MarketCapitalization;
                return $"{campanyName} was sold.";
            }
        }

        public Stock FindStock( string campanyName)
        {
            Stock findStock = Portfolio.FirstOrDefault(s => s.CompanyName == campanyName);
            if (findStock==null)
            {
                return null;
            }
            else
            {
                return findStock;
            }
        }

        public Stock FindBiggestCompany()
        {

            if (Portfolio.Count==0)
            {
                return null;
            }
            else
            {
                Stock richStock = null ;
                decimal biggestMoney = 0;
                foreach (var stoc in Portfolio)
                {
                    if (stoc.MarketCapitalization > biggestMoney)
                    {
                        richStock = stoc;
                        biggestMoney = stoc.MarketCapitalization;
                    }
                }
                return richStock;
            }
        }

        public  string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().Trim() ;
        }

    }
}
