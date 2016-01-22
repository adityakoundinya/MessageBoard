using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard.Data {
    public interface IMessageBoardRepository {
        IQueryable<Topic> GetTopics();
        IQueryable<Topic> GetTopicsIncludingReplies();
        IQueryable<Reply> GetRpliesByTopic(int topicId);

        bool Save();
        bool AddTopic(Topic NewTopic);
        bool AddReply(Reply newReply);
    }
}
