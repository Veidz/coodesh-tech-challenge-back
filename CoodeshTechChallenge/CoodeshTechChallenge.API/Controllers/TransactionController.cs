using CoodeshTechChallenge.API.ViewModels;
using CoodeshTechChallenge.Application.Contracts;
using CoodeshTechChallenge.Application.DTO;
using CoodeshTechChallenge.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                    List<Transaction> transactions = await this.transactionService.PostAsync(fileTextInput);
                    return StatusCode((int)HttpStatusCode.Created, new ResultViewModel<List<Transaction>>(transactions));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResultViewModel<string>("File does not exist."));
                }
            }
            catch (ValidationException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ResultViewModel<string>(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultViewModel<string>(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<TransactionOutput> transactions = await this.transactionService.GetAsync();
                return StatusCode((int)HttpStatusCode.OK, new ResultViewModel<List<TransactionOutput>>(transactions));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultViewModel<string>(ex.Message));
            }
        }
    }
}
