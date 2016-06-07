using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.DocumentModule
{
    public class Document
    {
        string docID;
        RawDocument rawDocument;
        ProcessedDocument processedDocument;

        public string DocID
        {
            get
            {
                return docID;
            }

            set
            {
                docID = value;
            }
        }

        internal void Load(string jsonLine) {
            RawDocument rawDocument = JsonConvert.DeserializeObject<RawDocument>(jsonLine);
            this.rawDocument = rawDocument;
        }
        /// <summary>
        /// Get the title of the article
        /// </summary>
        /// <returns></returns>
        public string GetTitle() {
            return rawDocument.Title;
        }
        /// <summary>
        /// Get the time when the article is published
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime() {
            return DateTime.Now;
        }

        /// <summary>
        /// Get the text content of the article
        /// </summary>
        /// <returns></returns>
        public string GetContent() {
            return "";
        }
        /// <summary>
        /// Check if the article mention a person
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public bool HasPeople(string people) {
            return false;
        }

        /// <summary>
        /// Check if the article mentions a location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool HasLocation(string location) {
            return false;
        }
        /// <summary>
        /// Check if the article mentions an organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public bool HasOrganization(string organization) {
            return false;
        }
    }
}
