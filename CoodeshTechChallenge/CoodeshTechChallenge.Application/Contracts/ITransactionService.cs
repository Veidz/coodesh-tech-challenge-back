using CoodeshTechChallenge.Application.DTO;
using CoodeshTechChallenge.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoodeshTechChallenge.Application.Contracts
{
    public interface ITransactionService
    {
        Task<List<Transaction>> PostAsync(string fileInputText);
        Task<List<TransactionOutput>> GetAsync();
    }
}
