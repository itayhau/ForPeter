using Medical.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Medical.Controllers
{
    public class IngredientsController : ApiController
    {
        static List<string> supportedReactions = new List<string> { "DEATH", "HEADACHE", "NAUSEA", "VOMITING" };

        [Route("api/Ingredients/GetMainIngredients/{reaction}")]
        public HttpResponseMessage Get(string reaction)
        {
            try
            {
                if (!supportedReactions.Contains(reaction.ToUpper()))
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("Supported reactions: ");
                    foreach(var str in supportedReactions)
                    {
                        message.Append(str.ToLower() + " , ");
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest, message.ToString().Substring(0, message.Length - 2));
                }
                    

                ReactionCount reactionResult = FDAConnector.GetReactionCount(reaction);

                reactionResult.results.Sort();
                reactionResult.results = reactionResult.results.Take(10).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, reactionResult);
            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, String.Format("Server Error {0}", e.Message));
            }
        }
    }
}
