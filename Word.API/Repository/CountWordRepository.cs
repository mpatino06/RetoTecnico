using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Word.API.Models;

namespace Word.API.Repository
{
    public class CountWordRepository : ICountWordRepository
    {

        public List<WordText> GetCountWord(string words)
        {
			Utilities.Utility.listWords = new List<WordText>();
			var resultArray = words.Replace(".","").Replace(",","").ToLower().Split(' ');
			Utilities.Utility.duplicateWord(resultArray);

			return Utilities.Utility.listWords;
		}

	}
}
