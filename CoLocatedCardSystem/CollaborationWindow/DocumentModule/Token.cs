﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.DocumentModule
{
    class Token
    {
        string originalWord = "";
        string stemmedWord = "";
        WordType wordType=WordType.DEFAULT;

        public string OriginalWord
        {
            get
            {
                return originalWord;
            }

            set
            {
                originalWord = value;
            }
        }

        public string StemmedWord
        {
            get
            {
                return stemmedWord;
            }

            set
            {
                stemmedWord = value;
            }
        }

        internal WordType WordType
        {
            get
            {
                return wordType;
            }

            set
            {
                wordType = value;
            }
        }
    }
}
