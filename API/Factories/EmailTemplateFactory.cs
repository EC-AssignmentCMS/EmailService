using API.Models;

namespace API.Factories;


public static class EmailTemplateFactory
{
    public static (string Subject, string Html) Create(ConfirmationRequest request)
    {
        return request.FormType switch
        {
            "CallbackFormViewModel" => (
                "We received your callback request",
                $"""
                <p>Hello {request.Name},</p>
                <p>Thank you for requesting a callback. One of our consultants will contact you soon at <strong>{request.Phone}</strong>.</p>
                <p>Selected service: {request.SelectedOption}</p>
                <br>
                <p>Best regards,<br>The Onatrix Team</p>
                """
            ),

            "QuestionFormViewModel" => (
                "Thank you for your question",
                $"""
                <p>Hello {request.Name},</p>
                <p>We have received your question:</p>
                <blockquote>{request.Question}</blockquote>
                <p>Our team will get back to you shortly via <strong>{request.Email}</strong>.</p>
                <br>
                <p>Best regards,<br>The Onatrix Team</p>
                """
            ),

            "NewsletterViewModel" => (
                "Newsletter Subscription Confirmed",
                $"""
                <p>Hello,</p>
                <p>Thank you for subscribing to our newsletter with <strong>{request.Email}</strong>.</p>
                <p>You will now receive updates and insights directly in your inbox.</p>
                <br>
                <p>Warm regards,<br>The Onatrix Team</p>
                """
            ),

            _ => (
                "Thank you for contacting us",
                $"""
                <p>Hello {request.Name ?? "there"},</p>
                <p>We have received your message and our team will reach out to you soon at <strong>{request.Email}</strong>.</p>
                <br>
                <p>Kind regards,<br>The Onatrix Team</p>
                """
            )
        };
    }
}