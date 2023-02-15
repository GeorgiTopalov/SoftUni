namespace StockMarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Investor
    {
        public List<Stock> Portfolio { get; set; }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public void BuyStock(Stock stock)
        {
            if ((stock.MarketCapitalization > 10000) &&
        (MoneyToInvest >= stock.PricePerShare))
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {

            var stockToSell = Portfolio.FirstOrDefault(x => x.CompanyName == companyName && x.PricePerShare <= sellPrice);

            if (stockToSell != null)
            {
                Portfolio.Remove(stockToSell);
                return $"{companyName} was sold.";

            }
            else
            {
                if (!Portfolio.Any(x => x.CompanyName == companyName))
                {
                    return $"{companyName} does not exist.";
                }
                else
                {
                    return $"Cannot sell {companyName}.";
                }
            }
        }
        public Stock FindStock(string companyName)
        {
            var stockToFind = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (stockToFind == null)
            {
                return null;
            }
            return stockToFind;
        }

        public Stock FindBiggestCompany()
        {
            var biggestCompany = Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
            if (biggestCompany == null)
            {
                return null;
            }
            return biggestCompany;
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

                foreach (var company in Portfolio)
            {
                sb.AppendLine($"{company}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
