using API.Models;

namespace API.Factories;

public static class EmailTemplateFactory
{
    public static (string Subject, string Html) Create(ConfirmationRequest request)
    {
        string baseStyle = """
            <style>
                body {
                    font-family: 'Poppins', Arial, sans-serif;
                    background-color: #F7F7F7;
                    color: #535656;
                    padding: 2rem;
                }
                .container {
                    background-color: #ffffff;
                    max-width: 600px;
                    margin: 0 auto;
                    border-radius: 8px;
                    padding: 2rem;
                    box-shadow: 0 4px 20px rgba(0,0,0,0.08);
                }
                h1 {
                    color: #4F5955;
                    font-weight: 700;
                    font-size: 22px;
                    margin-bottom: 1rem;
                }
                p {
                    font-size: 15px;
                    line-height: 1.6;
                    margin: 0 0 1rem 0;
                }
                strong { color: #4F5955; }
                .footer {
                    text-align: center;
                    color: #9C9EA6;
                    font-size: 13px;
                    margin-top: 2rem;
                }
                .highlight {
                    color: #D9C3A9;
                    font-weight: 600;
                }
                .button {
                    display: inline-block;
                    background-color: #4F5955;
                    color: #F2EDDC;
                    padding: 0.75rem 1.5rem;
                    border-radius: 4px;
                    text-decoration: none;
                    margin-top: 1.5rem;
                    font-weight: 600;
                }
            </style>
        """;

        return request.FormType switch
        {
            "CallbackFormViewModel" => (
                "We received your callback request",
                $"""
                {baseStyle}
                <body>
                    <div class="container">
                        <h1>Hello {request.Name},</h1>
                        <p>Thank you for requesting a callback. One of our consultants will contact you soon at <strong>{request.Phone}</strong>.</p>
                        <p>Selected service: <span class="highlight">{request.SelectedOption}</span></p>
                        <a class="button" href="https://umbraco-cms-joakim-e6geh9bddxe3eyf7.swedencentral-01.azurewebsites.net/">Visit Onatrix</a>
                        <div class="footer">
                            Best regards,<br>The Onatrix Team
                        </div>
                    </div>
                </body>
                """
            ),

            "QuestionFormViewModel" => (
                "Thank you for your question",
                $"""
                {baseStyle}
                <body>
                    <div class="container">
                        <h1>Hello {request.Name},</h1>
                        <p>We have received your question:</p>
                        <blockquote style="border-left:4px solid #D9C3A9;padding-left:1rem;color:#4F5955;">{request.Question}</blockquote>
                        <p>Our team will get back to you shortly via <strong>{request.Email}</strong>.</p>
                        <a class="button" href="https://umbraco-cms-joakim-e6geh9bddxe3eyf7.swedencentral-01.azurewebsites.net/">Visit Onatrix</a>
                        <div class="footer">
                            Best regards,<br>The Onatrix Team
                        </div>
                    </div>
                </body>
                """
            ),

            "NewsletterViewModel" => (
                "Newsletter Subscription Confirmed",
                $"""
                {baseStyle}
                <body>
                    <div class="container">
                        <h1>Welcome to Onatrix News!</h1>
                        <p>Thank you for subscribing with <strong>{request.Email}</strong>.</p>
                        <p>You will now receive updates and insights directly in your inbox.</p>
                        <a class="button" href="https://umbraco-cms-joakim-e6geh9bddxe3eyf7.swedencentral-01.azurewebsites.net/">Explore Services</a>
                        <div class="footer">
                            Best regards,<br>The Onatrix Team
                        </div>
                    </div>
                </body>
                """
            ),

            _ => (
                "Thank you for contacting Onatrix",
                $"""
                {baseStyle}
                <body>
                    <div class="container">
                        <h1>Hello {request.Name ?? "there"},</h1>
                        <p>We have received your message and our team will reach out to you soon at <strong>{request.Email}</strong>.</p>
                        <a class="button" href="https://umbraco-cms-joakim-e6geh9bddxe3eyf7.swedencentral-01.azurewebsites.net/">Visit Onatrix</a>
                        <div class="footer">
                            Best regards,<br>The Onatrix Team
                        </div>
                    </div>
                </body>
                """
            )
        };
    }
}
