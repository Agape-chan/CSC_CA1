using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Clarifai.API;

namespace ClarifaiTest.Models
{
    public class Clarifai
    {
        public static async Task Main()
        {
            // Skip the argument to fetch the key from the CLARIFAI_API_KEY environment variable.
            var client = new ClarifaiClient("337168311ecd423a80c5b55261a8b122");
        }
    }
}