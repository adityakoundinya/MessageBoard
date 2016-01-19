using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard.Data {
    public class MessageBoardRepository:IMessageBoardRepository {
        #region IMessageBoardRepository Members

        MessageBoardContext _ctx;
        public MessageBoardRepository(MessageBoardContext ctx) {
            _ctx = ctx; 
        }

        public IQueryable<Topic> GetTopics() {
            return _ctx.Topics;
        }

        public IQueryable<Reply> GetRpliesByTopic(int topicId) {
            return _ctx.Replies.Where(o => o.TopicId == topicId);
        }

        #endregion
    }
}