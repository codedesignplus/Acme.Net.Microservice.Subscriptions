namespace Acme.Net.Microservice.Subscriptions.Application;

public class Errors: IErrorCodes
{    
    public const string UnknownError = "200 : UnknownError";
    public const string InvalidRequest = "201 : The request is invalid";
    public const string SuscriptionAlreadyExists = "202 : The subscription already exists";
    public const string SuscriptionNotFound = "203 : The subscription does not exist";
}
