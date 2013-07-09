using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AHED.Model
{
    public enum QaStatus
    {
        [Description("")]
        NotSet = 0,

        [Description("New")]
        NewStudy = 100,

        [Description("QA Pending")]
        QaPending = 200,

        [Description("QA Rejected")]
        QaRejected = 300,

        [Description("Accepted")]
        Accepted = 400,
    }
}
