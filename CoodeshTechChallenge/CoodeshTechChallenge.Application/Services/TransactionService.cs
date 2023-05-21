using CoodeshTechChallenge.Application.Contracts;
using CoodeshTechChallenge.Application.Exceptions;
using CoodeshTechChallenge.Domain;
using CoodeshTechChallenge.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = CoodeshTechChallenge.Domain.Type;

namespace CoodeshTechChallenge.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IDynamicPersistence<Transaction> dynamicPersistenceTransaction;
        private readonly IStaticPersistence<Type> staticPersistenceType;
        private readonly IStaticPersistence<Product> staticPersistenceProduct;
        private readonly IStaticPersistence<Seller> staticPersistenceSeller;

        public TransactionService(
            IDynamicPersistence<Transaction> dynamicPersistenceTransaction,
            IStaticPersistence<Type> staticPersistenceType,
            IStaticPersistence<Product> staticPersistenceProduct,
            IStaticPersistence<Seller> staticPersistenceSeller
        )
        {
            this.dynamicPersistenceTransaction = dynamicPersistenceTransaction;
            this.staticPersistenceType = staticPersistenceType;
            this.staticPersistenceProduct = staticPersistenceProduct;
            this.staticPersistenceSeller = staticPersistenceSeller;
        }

        public async Task<List<Transaction>> PostAsync(string fileInputText)
        {
            StringBuilder stringBuilder = new();

            List<string> transactionsString = new();
            List<Transaction> transactions = new();

            for (int i = 0; i < fileInputText.Length; i++)
            {
                if (fileInputText[i] != '\n')
                {
                    stringBuilder.Append(fileInputText[i]);
                }
                else
                {
                    if (stringBuilder.ToString() != "")
                    {
                        transactionsString.Add(stringBuilder.ToString());
                        stringBuilder.Clear();
                    }
                }
            }

            foreach (string transaction in transactionsString)
            {
                string type = transaction[..1];
                string date = transaction.Substring(1, 25);
                string product = transaction.Substring(26, 30).Trim();
                string price = transaction.Substring(56, 10).TrimStart(new char[] { '0' });
                string seller = transaction[66..];

                List<Type> types = await staticPersistenceType.GetFilterAsync((x) => x.Id == int.Parse(type));
                List<Product> products = await staticPersistenceProduct.GetFilterAsync((x) => x.Name == product);
                List<Seller> sellers = await staticPersistenceSeller.GetFilterAsync((x) => x.Name == seller);

                if (types.FirstOrDefault() == null) throw new ValidationException("Type is invalid.");
                if (products.FirstOrDefault() == null) throw new ValidationException("Product is invalid.");
                if (sellers.FirstOrDefault() == null) throw new ValidationException("Seller is invalid.");

                Transaction transactionDb = new()
                {
                    Date = DateTime.Parse(date),
                    Price = decimal.Parse(price) / 100,
                    Type = types.FirstOrDefault()!.Id,
                    Product = products.FirstOrDefault()!.Id,
                    Seller = sellers.FirstOrDefault()!.Id
                };

                transactions.Add(transactionDb);
            }

            return await this.dynamicPersistenceTransaction.PostListAsync(transactions);
        }
    }
}
