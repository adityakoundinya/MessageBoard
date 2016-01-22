using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessageBoard.Data;

namespace MessageBoard.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;
        public TopicsController(IMessageBoardRepository repo) {
            _repo = repo;
        }

        public IEnumerable<Topic> Get(bool includeReplies = false) {

            IEnumerable<Topic> results;
            if (includeReplies) {
                results = _repo.GetTopicsIncludingReplies().OrderByDescending(t => t.Created).Take(25).ToList();
            } else {
                results = _repo.GetTopics().OrderByDescending(t => t.Created).Take(25).ToList();
            }
            return results;
        }

        public HttpResponseMessage Post([FromBody]Topic newTopic) {
            if (newTopic.Created == default(DateTime)) {
                newTopic.Created = DateTime.UtcNow;
            }
            if (_repo.AddTopic(newTopic) && _repo.Save()) {
                return Request.CreateResponse(HttpStatusCode.Created, newTopic);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
