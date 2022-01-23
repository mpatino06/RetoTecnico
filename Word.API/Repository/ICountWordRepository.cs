using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Word.API.Models;

namespace Word.API.Repository
{
    public interface ICountWordRepository
    {
        List<WordText> GetCountWord(string words);
    }
}
