using PusherServer;

namespace Socket.Services
{
    public class PusherService
    {
        private Pusher _pusher;

        public PusherService()
        {
            var options = new PusherOptions
            {
                Cluster = "us2",
                Encrypted = true
            };

            _pusher = new Pusher(
                "1431256",
                "a5bf8736750a379ed757",
                "16b91477d294cf508535",
                options
            );
        }     
        
        public async Task<ITriggerResult> Trigger(string channel, string eventName, string message)
        {
            return await _pusher.TriggerAsync(
                channel,
                eventName,
                new { message = message } 
            );
        }

    }
}