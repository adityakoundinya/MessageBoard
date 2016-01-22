using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MessageBoard.Data {
    public class MessageBoardMigrationsConfiguration : DbMigrationsConfiguration<MessageBoardContext> {
        public MessageBoardMigrationsConfiguration() {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context) {
            base.Seed(context);
#if DEBUG
            if (context.Topics.Count() == 0) {
                Topic topic = new Topic() {
                    Title = "I love MVC",
                    Body = "I love ASP.NET MVC and I want everyone to know",
                    Created = DateTime.Now,
                    Replies = new List<Reply>(){
                        new Reply(){
                            Body = "I love it too",
                            Created = DateTime.Now
                        },
                        new Reply(){
                            Body = "Me Too",
                            Created = DateTime.Now
                        }
                    }
                };
                context.Topics.Add(topic);

                Topic anothertopic = new Topic() {
                    Title = "I love Ruby too",
                    Body = "Ruby on Rails is popular too",
                    Created = DateTime.Now
                };
                context.Topics.Add(anothertopic);

                try {
                    context.SaveChanges();
                } catch (Exception ex) {
                    string msg = ex.Message;
                }

            }
#endif
        }
    }
}
