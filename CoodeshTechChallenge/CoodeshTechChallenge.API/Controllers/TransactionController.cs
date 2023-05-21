using CoodeshTechChallenge.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction = CoodeshTechChallenge.Domain.Transaction;

namespace CoodeshTechChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(IList<IFormFile> filesInput)
        {
            try
            {
                IFormFile? file = filesInput.FirstOrDefault();

                if (file != null)
                {
                    MemoryStream memoryStream = new();
                    file.OpenReadStream().CopyTo(memoryStream);
                    string fileTextInput = Encoding.ASCII.GetString(memoryStream.ToArray());
                    List<Transaction> trasactions = await this.transactionService.PostAsync(fileTextInput);
                    return Ok(trasactions);
                }
                else
                {
                    return BadRequest("File does not exist");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
