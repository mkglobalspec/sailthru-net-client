using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Sailthru.Tests.Mock
{
    public class UserApi
    {
        public static object ProcessPost(JObject request)
        {
            string id = request["id"].Value<string>();
            string optout = request["optout_email"].Value<string>();
            JObject vars = request["vars"].Value<JObject>();
            JObject fields = request["fields"].Value<JObject>();
            bool returnVars = fields != null && fields["vars"].Value<int>() == 1;
            bool returnOptout = fields != null && fields["optout_email"].Value<int>() == 1;
            Dictionary<string, object> result = new Dictionary<string, object>()
            {
                ["ok"] = true
            };
            if (returnVars)
            {
                if (vars == null)
                {
                    vars = new JObject();
                }
                result.Add("vars", vars);
            }
            if (returnOptout)
            {
                if (optout == null)
                {
                    optout = "none";
                }
                result.Add("optout_email", optout);
            }
            return result;
        }
    }
}