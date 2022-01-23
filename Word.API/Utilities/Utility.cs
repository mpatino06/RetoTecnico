using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Word.API.Models;

namespace Word.API.Utilities
{
    public static class Utility
    {

		public static List<WordText> listWords = new List<WordText>();
		public static void duplicateWord(string[] array)
		{
			string[] arrayUpdate = {};
			foreach (var item in array)
			{
				var word = item.ToString();

				var countWord = array.Where(a => a.ToString() == word).Count();
				if (countWord > 1)
				{
					arrayUpdate = array.Where(a => a.ToString() != word).ToArray();
					if(word != "")
						listWords.Add(new WordText { Word = word, CountWord = countWord });
					break;
				}
			}

			if (arrayUpdate.Count() > 0)
				duplicateWord(arrayUpdate);
		}

	}
}
