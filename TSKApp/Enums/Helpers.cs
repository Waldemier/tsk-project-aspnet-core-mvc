namespace TSKApp.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Helpers
    {
        public enum Actions
        {
            MoreQuestion = 1,
            MoreAnswer = 2,
            End = 3,
            RemoveAnswer = 4
        }
        public enum TestPassingActions
        {
            NextQuestion = 1,
            NextQuestionWithoutResultSaving = 2,
        }
    }
}
