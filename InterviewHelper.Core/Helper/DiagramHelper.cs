namespace InterviewHelper.Core.Helper
{
    public static class DiagramHelper
    {
        public static string AddInfo => "\r\nDo not use special characters between [ ] when generating Graph LR code." +
            "Step 1 - The client sends an HTTP request to the API gateway." +
            "\r\n\r\nStep 2 - The API gateway parses and validates the attributes in the HTTP request." +
            "\r\n\r\nStep 3 - The API gateway performs allow-list/deny-list checks.\r\n\r\nStep 4 - " +
            "The API gateway talks to an identity provider for authentication and authorization.\r\n\r\nStep" +
            " 5 - The rate limiting rules are applied to the request. If it is over the limit, the request " +
            "is rejected.\r\n\r\nSteps 6 and 7 - Now that the request has passed basic checks, the API gateway" +
            " finds the relevant service\r\n to route to by path matching.\r\n\r\nStep 8 - The API gateway " +
            "transforms the request into the appropriate protocol and sends it to backend microservices.\r\n\r\nSteps" +
            " 9-12: The API gateway can handle errors properly, and deals with faults \r\nif the error" +
            " takes a longer time to recover (circuit break). It can also leverage\r\n ELK (Elastic-Logstash-Kibana)" +
            " stack for logging and monitoring. We sometimes cache data in the API gateway.";
    }
}
