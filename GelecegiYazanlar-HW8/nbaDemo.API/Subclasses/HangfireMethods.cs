using Hangfire;
using System;

namespace nbaDemo.API.Subclasses
{
    public class HangfireMethods
    {
        /// <summary>
        /// Sets a background job to print on console.
        /// </summary>
        /// <param name="actionName">Specify an action name.</param>
        /// <param name="actionResult">Specify the action's result.</param>
        /// <param name="timer">Set a timer in terms of seconds to schedule the task.</param>
        public void SetBackgroundJob(string actionName, string actionResult, int timer = 1)
        {
            BackgroundJob.Schedule(() => Console.WriteLine($"{actionResult} for {actionName}. Easy peasy!"), TimeSpan.FromSeconds(timer));
        }
    }
}
