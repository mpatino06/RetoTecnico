using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Word.API.Models;
using Word.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Word.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsCountController : ControllerBase
    {
        private readonly ICountWordRepository _repository;

        public WordsCountController(ICountWordRepository repository)
        {
            this._repository = repository;
        }
        // GET: api/<WordsCount>
        [HttpGet("{words}")]
        public List<WordText> GetWords(string words)
        {
            return _repository.GetCountWord(words);
        }

        [HttpPost]
        public List<WordText> GetWordsPost(string words)
        {
            return _repository.GetCountWord(words);

        }


    }
}
