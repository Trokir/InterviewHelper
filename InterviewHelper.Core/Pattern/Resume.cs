using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Core.Pattern
{
    public static class Resume
    {
        public static string Pattern=> @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8""/>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0""/>
    <title>Kirill Troshchevskii's Resume</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        .contact-info, .skills, .languages {
            list-style-type: none;
            padding: 0;
        }
        .section {
            margin-bottom: 20px;
        }
        .section-title {
            font-size: 24px;
            color: #333;
        }
        .sub-title {
            font-size: 20px;
            margin-bottom: 5px;
        }
        .details {
            margin-left: 20px;
        }
        .details li {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <header>
        <h1>Kirill Troshchevskii</h1>
        <ul class=""contact-info"">
            <li>Location: United States</li>
            <li>Email: <a href=""mailto:ktroshefsky@gmail.com"">ktroshefsky@gmail.com</a></li>
            <li>Phone: (727) 554-1060</li>
            <li>LinkedIn: <a href=""https://www.linkedin.com/in/kirill-tro"">in/kirill-tro</a></li>
        </ul>
    </header>
    <section class=""summary"">
        <h2 class=""section-title"">Summary</h2>
        <p>Accomplished Full Stack Developer with a Bachelor’s degree in Computer Science from Omsk State Technical University (OSTU). Offering over 8 years of experience in .NET technologies, I specialize in crafting robust web applications and implementing Azure cloud services. Known for driving innovation and improving user experiences through meticulous UI/UX design and efficient microservices architecture.</p>
    </section>
    <section class=""experience"">
        <h2 class=""section-title"">Experience</h2>
        <div>
            <h3 class=""sub-title"">Full Stack Engineer, Locko Bank (Remote)</h3>
            <p>July 2018 - Feb 2024</p>
            <ul class=""details"">
                <li>Developed scalable web applications using .NET Framework, ASP.NET, C#, and SQL Server, resulting in the successful deployment of three key projects.</li>
                <li>Designed and improved user interfaces and system flows with MVC architecture, significantly enhancing user satisfaction and reducing support inquiries.</li>
                <li>Showcased expertise in desktop application development with WPF and WinForms, delivering flawless applications with zero post-launch bugs.</li>
                <li>Upgraded microservices with the latest .NET features, achieving a substantial increase in system performance and user engagement.</li>
                <li>Managed efficient cross-service interactions with RabbitMQ, achieving a notable reduction in data transfer latency.</li>
                <li>Integrated Azure services such as Azure Functions and Event Hubs to manage event-driven, serverless computing platforms, which optimized the scalability and reliability of banking applications.</li>
                <li>Implemented Azure DevOps for continuous integration and delivery pipelines, reducing manual workloads by 10% and increasing development velocity by 10%.</li>
            </ul>
        </div>
        <div>
            <h3 class=""sub-title"">.NET Developer, HomeCredit Bank (On-site)</h3>
            <p>May 2015 - July 2018</p>
            <ul class=""details"">
                <li>Engineered high-performance web applications using .NET, ASP.NET, C#, and SQL Server, enhancing system stability and functionality.</li>
                <li>Designed intuitive user interfaces through MVC architecture, improving overall user experience.</li>
                <li>Developed web services and refined user experiences with HTML, CSS, Bootstrap, and JavaScript, leading to increased user engagement.</li>
                <li>Managed and optimized databases with MS SQL Server, authoring efficient SQL queries and reducing response times.</li>
                <li>Ensured code reliability with robust Unit Tests using xUnit and Mock testing frameworks, maintaining a high test pass rate.</li>
                <li>Created a streamlined WinForms desktop application with DevExpress components, improving data management and reducing errors.</li>
            </ul>
        </div>
    </section>
    <section class=""education"">
        <h2 class=""section-title"">Education</h2>
        <p>Bachelor’s Degree, Automatic information processing and control systems at Omsk State Technical University (OSTU)</p>
        <p>Graduated August 2019</p>
    </section>
    <section class=""skills"">
        <h2 class=""section-title"">Skills</h2>
        <ul>
            <li>Industry Knowledge: Web Development, API Development, Software Testing, Database Design, Object-Oriented Programming (OOP), Microservices, Azure SQL, Azure Functions, Event Hubs</li>
            <li>Tools & Technologies: .NET Framework, ASP.NET, C#, SQL Server, WPF, WinForms, Entity Framework, REST APIs, Visual Studio, Git, Azure DevOps, JavaScript, HTML5, CSS, Bootstrap</li>
        </ul>
    </section>
    <section class=""languages"">
        <h2 class=""section-title"">Languages</h2>
        <ul>
            <li>English</li>
            <li>Russian</li>
        </ul>
    </section>
</body>
</html>
";
    }
}
