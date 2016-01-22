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

        public IQueryable<Topic> GetTopicsIncludingReplies() {
            return _ctx.Topics.Include("Replies");
        }

        public IQueryable<Reply> GetRpliesByTopic(int topicId) {
            return _ctx.Replies.Where(o => o.TopicId == topicId);
        }

        #endregion

        #region IMessageBoardRepository Members


        public bool Save() {
            try {
                return _ctx.SaveChanges() > 0;
            } catch (Exception e) {
                //TODO log this error
                return false;
            }
        }

        public bool AddTopic(Topic NewTopic) {
            try {
                _ctx.Topics.Add(NewTopic);
                return true;
            } catch (Exception e) {
                //TODO log this error
                return false;
            }
        }

        public bool AddReply(Reply NewReply) {
            try {
                _ctx.Replies.Add(NewReply);
                return true;
            } catch (Exception e) {
                //TODO log this error
                return false;
            }
        }

        #endregion
    }
}