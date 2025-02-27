﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAnalyzer.Commands
{
    public class CountWordsCommand : ICommand
    {
        public string Description => "Count Words";

		public bool Reportable => true;

		public void Activate()
        {
            String text = Regex.Replace(TextFileFetcher.GetTextFileString(), @"(\d|_)+", "");
            List<String> wordsList = Regex.Split(text, @"(\ )",
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(500)).ToList();
            Regex rgx = new Regex(@"^(\ |:)$");
            List<String> wordsOnlyList = wordsList.FindAll(x => !rgx.IsMatch(x) && x != "");

            Writer.WriteMessege("Text words count: {0}\n", wordsOnlyList.Count);
            
        }
    }
}