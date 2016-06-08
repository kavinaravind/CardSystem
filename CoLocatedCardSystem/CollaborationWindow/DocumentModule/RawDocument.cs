using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.DocumentModule
{
    class RawDocument
    {
        string id;
        string title;
        string author;
        string time;
        string content;
        string[] people;
        string[] location;
        string[] organization;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public string[] People
        {
            get
            {
                return people;
            }

            set
            {
                people = value;
            }
        }

        public string[] Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public string[] Organization
        {
            get
            {
                return organization;
            }

            set
            {
                organization = value;
            }
        }
    }
}
