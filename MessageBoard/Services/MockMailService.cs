using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MessageBoard.Services {
    public class MockMailService: IMailService {
        #region IMailService Members

        public bool SendMail(string from, string to, string subject, string message) {
            Debug.WriteLine(string.Concat("SendMail: ", subject));
            return true;
        }

        #endregion
    }
}